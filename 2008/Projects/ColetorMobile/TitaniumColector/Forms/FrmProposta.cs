using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Classes ;
using TitaniumColector.SqlServer;
using System.Data.SqlClient;
using TitaniumColector.Classes.SqlServer;

namespace TitaniumColector.Forms
{
    public partial class FrmProposta : Form
    {
        private Proposta proposta;
        private ItemProposta itemProposta;
        private SizeF fontStringSize;
        private string sql01;
        private List<ItemProposta> listaItensProposta;
        private DataTable dt;


        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            //carregarBaseMobile();   
        }

        public void carregarBaseMobile()
        {
            //Recupera a proposta TOP 1 entre as propostas liberadas para o Picking
            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            query.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            query.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = query.ToString();

            //Carrega um objeto da classe Proposta
            proposta = this.buscaTop1Proposta();

            //Insert Proposta na Base Mobile
            this.insertProposta(proposta.Codigo, proposta.Numero, proposta.DataLiberacao, proposta.CodigoCliente,
                                proposta.RazaoCliente, (int)proposta.StatusOrdemSeparacao, MainConfig.CodigoUsuarioLogado);

            recuperaItensProposta((int)proposta.Codigo);

            //Recupera List com itens da proposta
            this.listaItensProposta = recuperaItensProposta((int)proposta.Codigo).ToList<ItemProposta>();

            //Insert na Base Mobile
            this.insertItensProposta(listaItensProposta.ToList<ItemProposta>());

            this.atualizaDataGridItensProposta(listaItensProposta.ToList<ItemProposta>());

            this.lbNumeroPedido.Text = proposta.Codigo.ToString();
            this.lbNomeCliente.Text = proposta.RazaoCliente.ToString();
        }

        /// <summary>
        /// Atualiza o grid com os itens referentes  aproposta informado como parâmetro.
        /// </summary>
        public void atualizaDataGridItensProposta(int codigoProposta)
        {
            dgProposta.Refresh();
            dgProposta.DataSource = recuperaItensProposta(codigoProposta).ToList();
            
        }

        /// <summary>
        /// Carrega uma List com objetos da classe ItemProposta preenchida com dados sobre os itens de uma determinada Proposta 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ItemProposta> recuperaItensProposta(int codigoProposta)
        {
 
            List<ItemProposta> listItensProposta = new List<ItemProposta>() ;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,produtoRESERVA AS PRODUTO,  SUM(quantidadeRESERVA) AS QTD ");
            query.Append("FROM tb1206_Reservas (NOLOCK) ");
            query.Append("INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA ");
            query.Append("INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO ");
            query.AppendFormat("WHERE propostaITEMPROPOSTA = {0} " , codigoProposta);     //78527
            query.Append("AND tipodocRESERVA = 1602 ");
            query.Append("AND statusITEMPROPOSTA = 3 ");
            query.Append("AND separadoITEMPROPOSTA = 0  ");
            query.Append("GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO ");
            this.sql01 = query.ToString();

            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    itemProposta = new ItemProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]), Convert.ToInt32(dr["propostaITEMPROPOSTA"]), (string)(dr["nomePRODUTO"]), (string)dr["partnumberPRODUTO"], (string)dr["ean13PRODUTO"], Convert.ToInt32(dr["PRODUTO"]),
                                            Convert.ToDouble(dr["QTD"]), ItemProposta.statusSeparado.NAOSEPARADO);

                    //Carrega a lista de itens que será retornada ao fim do procedimento.
                    listItensProposta.Add(itemProposta);
                }
            }

            dr.Close();

            SqlServerConn.closeConn();

            return listItensProposta;
        }

        /// <summary>
        /// Realiza o insert na tabela de Propostas
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da Proposta</param>
        /// <param name="dataliberacaoProposta">data de liberação da Proposta</param>
        /// <param name="clienteProposta">Código do cliente</param>
        /// <param name="razaoEmpreza">Nome da empreza cliente</param>
        /// <param name="ordemseparacaoimpresaProposta">Status 0 ou 1</param>
        /// <param name="usuarioLogado">Usuário logado</param>
        private void insertProposta(Int64 codigoProposta, string numeroProposta, string dataliberacaoProposta, Int32 clienteProposta,
                                    string razaoEmpreza, int ordemseparacaoimpresaProposta, int usuarioLogado)
        {

            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0001_Propostas");

            //Query de insert na Base Mobile
            StringBuilder query = new StringBuilder();
            query.Append("Insert INTO tb0001_Propostas VALUES (");
            query.AppendFormat("{0},", codigoProposta);
            query.AppendFormat("\'{0}\',", numeroProposta);
            query.AppendFormat("\'{0}\',", dataliberacaoProposta);
            query.AppendFormat("{0},", clienteProposta);
            query.AppendFormat("\'{0}\',", razaoEmpreza);
            query.AppendFormat("{0},", ordemseparacaoimpresaProposta);
            query.AppendFormat("{0})", usuarioLogado);
            sql01 = query.ToString();
           
            CeSqlServerConn.execCommandSqlCe(sql01);
        }
        /// <summary>
        /// Insert na base Mobile tabela de itens da proposta
        /// </summary>
        /// <param name="listProposta"></param>
        private void insertItensProposta(List<ItemProposta> listProposta)
        {

            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0011_ItensProposta");

            foreach (var item in listProposta)
            {
                //Query de insert na Base Mobile
                StringBuilder query = new StringBuilder();
                query.Append("Insert INTO tb0011_ItensProposta VALUES (");
                query.AppendFormat("{0},", item.Codigo);
                query.AppendFormat("\'{0}\',", item.PropostaItemProposta);
                query.AppendFormat("\'{0}\',", item.PartNumber);
                query.AppendFormat("\'{0}\',", item.NomeProduto);
                query.AppendFormat("{0},", item.ProdutoReserva );
                query.AppendFormat("{0},", item.Quantidade);
                query.AppendFormat("\'{0}\',", item.Ean13);
                query.AppendFormat("{0})", (int)item.Separado);
                sql01 = query.ToString();
                
                CeSqlServerConn.execCommandSqlCe(sql01);
            }
        }

        /// <summary>
        /// Insert na base Mobile tabela d Itens da Proposta.
        /// </summary>
        /// <param name="codigoITEMPROPOSTA"> Código do item da proposta</param>
        /// <param name="propostaITEMPROPOSTA">código da proposta ao qual o item está vínculado</param>
        /// <param name="nomePRODUTO">Nome(Descrição ) do item.</param>
        /// <param name="partnumberPRODUTO"> partnumber do item</param>
        /// <param name="ean13PRODUTO">Ean 13 do item</param>
        /// <param name="PRODUTO"> produto separado</param>
        /// <param name="quantidade">quantidade do item  </param>
        /// <param name="statusseparadoPROPODUTO"> Status indicando se o item está separado ou não.</param>
        private void insertItemProposta(Int64 codigoITEMPROPOSTA, Int32 propostaITEMPROPOSTA, string nomePRODUTO, string partnumberPRODUTO,
                                        string ean13PRODUTO, int PRODUTO, double quantidade,int statusseparadoPROPODUTO)
        {

            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0011_ItensProposta");

             //Query de insert na Tabela de itens da prosposta
            StringBuilder query = new StringBuilder();
            query.Append("Insert INTO tb0011_ItensProposta VALUES (");
            query.AppendFormat("{0},", codigoITEMPROPOSTA);
            query.AppendFormat("\'{0}\',", propostaITEMPROPOSTA);
            query.AppendFormat("\'{0}\',", partnumberPRODUTO);
            query.AppendFormat("\'{0}\',", nomePRODUTO);
            query.AppendFormat("{0},", PRODUTO);
            query.AppendFormat("{0},", quantidade);
            query.AppendFormat("\'{0}\',", ean13PRODUTO);
            query.AppendFormat("{0})", statusseparadoPROPODUTO);
            sql01 = query.ToString();

            CeSqlServerConn.execCommandSqlCe(sql01);

        }



        /// <summary>
        /// Recupera a proposta TOP 1 e devolve um objeto do tipo Proposta com as informações resultantes.
        /// </summary>
        /// <returns>Objeto do tipo Proposta</returns>
        private Proposta buscaTop1Proposta()
        {
            Proposta objProposta = null;

            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            sbSql01.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = sbSql01.ToString();


            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                   objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                            Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"]);
                
                }
            }

            SqlServerConn.closeConn();

            return objProposta;

        }

        private void buscaItensBaseMobile() 
        {
            dt = new DataTable();

            StringBuilder stb = new StringBuilder();
            stb.Append("SELECT codigoITEMPROPOSTA, propostaITEMPROPOSTA, partnumberITEMPROPOSTA, nomeITEMPROPOSTA,");
            stb.Append("produtopedidoITEMPROPOSTA, quantidadeITEMPROPOSTA, ean13ITEMPROPOSTA,statusseparadoITEMPROPOSTA ");
            stb.Append(" FROM  tb0011_ItensProposta");
            CeSqlServerConn.fillDataTableCe(dt,stb.ToString());
                       
        }


        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }

#region   "NAO UTILIZADOS"

        public void carregaObjProposta(string sql01)
        {
            ///Carrega o dataReader.
            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    //Limpa a tabela de propostas.
                    CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0010_Propostas");


                    this.insertProposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                      Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], Convert.ToInt32(dr["ordemseparacaoimpressaPROPOSTA"]), MainConfig.CodigoUsuarioLogado);


                    //Carrega o objeto Proposta.
                    proposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                            Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"]);
                }
            }

            SqlServerConn.closeConn();

        }


#endregion


        /// <summary>
        /// Atualiza o grid a partir de uma List que refência a classe ItemProposta.
        /// </summary>
        private void atualizaDataGridItensProposta(List<ItemProposta> listItemProposta)
        {

            buscaItensBaseMobile();


            DataGridTableStyle tbStyle = new DataGridTableStyle();
            tbStyle.MappingName = "ItemProposta";

            DataGridTextBoxColumn codigoItem = new DataGridTextBoxColumn();
            codigoItem.MappingName = "codigoITEMPROPOSTA";
            codigoItem.HeaderText = "Código";
            codigoItem.Width = 42;
            tbStyle.GridColumnStyles.Add(codigoItem);

            DataGridTextBoxColumn itemProposta = new DataGridTextBoxColumn();
            itemProposta.MappingName = "propostaITEMPROPOSTA";
            itemProposta.HeaderText = "Item";
            itemProposta.Width = 42;
            tbStyle.GridColumnStyles.Add(itemProposta);

            DataGridTextBoxColumn nomeItemProposta = new DataGridTextBoxColumn();
            nomeItemProposta.MappingName = "nomePRODUTO";
            nomeItemProposta.HeaderText = "nome";
            nomeItemProposta.Width = 42;
            tbStyle.GridColumnStyles.Add(nomeItemProposta);

            DataGridTextBoxColumn partnumberItem = new DataGridTextBoxColumn();
            partnumberItem.MappingName = "partnumberPRODUTO";
            partnumberItem.HeaderText = "partnumber";
            partnumberItem.Width = 42;
            tbStyle.GridColumnStyles.Add(partnumberItem);

            DataGridTextBoxColumn ean13Item = new DataGridTextBoxColumn();
            ean13Item.MappingName = "ean13PRODUTO";
            ean13Item.HeaderText = "Ean13";
            ean13Item.Width = 42;
            tbStyle.GridColumnStyles.Add(ean13Item);

            DataGridTextBoxColumn produtoseparadoItem = new DataGridTextBoxColumn();
            produtoseparadoItem.MappingName = "PRODUTO";
            produtoseparadoItem.HeaderText = "ProdutoSeparado";
            produtoseparadoItem.Width = 42;
            tbStyle.GridColumnStyles.Add(produtoseparadoItem);

            DataGridTextBoxColumn quantidade = new DataGridTextBoxColumn();
            quantidade.MappingName = "QTD";
            quantidade.HeaderText = "Quantidade";
            quantidade.Width = 42;
            tbStyle.GridColumnStyles.Add(quantidade);

            dgProposta.TableStyles.Clear();
            dgProposta.TableStyles.Add(tbStyle);
            dgProposta.DataSource = dt;

        }


        private void FrmProposta_GotFocus(object sender, EventArgs e)
        {

        }

        private void FrmProposta_KeyDown(object sender, KeyEventArgs e)
        {
            //string = "EAN=789123654587|LOTE=LT-01|SEQ=023654|QTD=5"
        }

        //private void recuperaItensProposta(int codigoProposta)
        //{

        //    StringBuilder query = new StringBuilder();
        //    query.Append("SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,produtoRESERVA AS PRODUTO,  SUM(quantidadeRESERVA) AS QTD ");
        //    query.Append("FROM tb1206_Reservas (NOLOCK) ");
        //    query.Append("INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA ");
        //    query.Append("INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO ");
        //    query.AppendFormat("WHERE propostaITEMPROPOSTA = {0} ", codigoProposta);     //78527
        //    query.Append("AND tipodocRESERVA = 1602 ");
        //    query.Append("AND statusITEMPROPOSTA = 3 ");
        //    query.Append("AND separadoITEMPROPOSTA = 0  ");
        //    query.Append("GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO ");
        //    this.sql01 = query.ToString();

        //    SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

        //    if ((dr.FieldCount > 0))
        //    {
        //        while ((dr.Read()))
        //        {
        //            itemProposta = new ItemProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]), Convert.ToInt32(dr["propostaITEMPROPOSTA"]), (string)(dr["nomePRODUTO"]), (string)dr["partnumberPRODUTO"], (string)dr["ean13PRODUTO"], Convert.ToInt32(dr["PRODUTO"]),
        //                                    Convert.ToDouble(dr["QTD"]), ItemProposta.statusSeparado.NAOSEPARADO);

        //            //Carrega a lista de itens que será retornada ao fim do procedimento.
        //            listItensProposta.Add(itemProposta);
        //        }
        //    }

        //    dr.Close();

        //    SqlServerConn.closeConn();


        //}



    }
}