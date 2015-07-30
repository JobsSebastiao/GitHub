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
        private Proposta objProposta;
        //private ItemProposta objItemProposta;
        private Carga objCarga;
        private SizeF fontStringSize;
        private string sql01;
        private List<ItemProposta> listaItemProposta;
        private DataTable dt;


        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            this.realizaCargaBaseMobile();   
        }

        /// <summary>
        /// Reliza todos os processos nescessários para realizar a carga de dados na base Mobile.
        /// </summary>
        public void realizaCargaBaseMobile()
        {
            objCarga = new Carga();
            objProposta = new Proposta();

            //Carrega um objeto Proposta
            objProposta = objCarga.top1PropostaServidor();

            //Realiza o Insert na Base Mobile
            objCarga.insertProposta(objProposta.Codigo, objProposta.Numero, objProposta.DataLiberacao, objProposta.CodigoCliente, objProposta.RazaoCliente, (int)objProposta.StatusOrdemSeparacao, MainConfig.CodigoUsuarioLogado);
            
            //Recupera List com itens da proposta
            this.listaItemProposta = objCarga.recuperaItensProposta((int)objProposta.Codigo).ToList<ItemProposta>();

            //Insert na Base Mobile
            this.insertItensProposta(listaItemProposta.ToList<ItemProposta>());

            this.atualizaDataGridItensProposta(listaItemProposta.ToList<ItemProposta>());

            this.lbNumeroPedido.Text = objProposta.Codigo.ToString();
            this.lbNomeCliente.Text = objProposta.RazaoCliente.ToString();
        }

        /// <summary>
        /// Atualiza o grid com os itens referentes  aproposta informado como parâmetro.
        /// </summary>
        public void atualizaDataGridItensProposta(int codigoProposta)
        {
            dgProposta.Refresh();
            //dgProposta.DataSource = recuperaItensProposta(codigoProposta).ToList();
            
        }


#region  "Transferidos para a classe CARGA" 



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
                query.AppendFormat("{0},", item.CodigoItemProposta);
                query.AppendFormat("\'{0}\',", item.PropostaItemProposta);
                query.AppendFormat("\'{0}\',", item.Partnumber);
                query.AppendFormat("\'{0}\',", item.Descricao);
                query.AppendFormat("{0},", item.CodigoProduto);
                query.AppendFormat("{0},", item.Quantidade);
                query.AppendFormat("\'{0}\',", item.Ean13);
                query.AppendFormat("{0})", (int)item.StatusSeparado);
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
        /// <param name="partnumberPRODUTO"> Partnumber do item</param>
        /// <param name="ean13PRODUTO">Ean 13 do item</param>
        /// <param name="PRODUTO"> produto separado</param>
        /// <param name="quantidade">quantidade do item  </param>
        /// <param name="statusseparadoPROPODUTO"> Status indicando se o item está separado ou não.</param>
        private void insertItemProposta(Int64 codigoITEMPROPOSTA, Int32 propostaITEMPROPOSTA, string nomePRODUTO, string partnumberPRODUTO,
                                        string ean13PRODUTO, int PRODUTO, double quantidade, int statusseparadoPROPODUTO)
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



#endregion



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

        //public void carregaObjProposta(string sql01)
        //{
        //    ///Carrega o dataReader.
        //    SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

        //    if ((dr.FieldCount > 0))
        //    {
        //        while ((dr.Read()))
        //        {
        //            //Limpa a tabela de propostas.
        //            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0010_Propostas");


        //            this.insertProposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
        //                              Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], Convert.ToInt32(dr["ordemseparacaoimpressaPROPOSTA"]), MainConfig.CodigoUsuarioLogado);


        //            //Carrega o objeto Proposta.
        //            objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
        //                                    Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"]);
        //        }
        //    }

        //    SqlServerConn.closeConn();

        //}


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