using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Classes;
using TitaniumColector.SqlServer;
using System.Data.SqlClient;
using TitaniumColector.Classes.SqlServer;

namespace TitaniumColector.Forms
{
    public partial class FrmProposta : Form
    {
        private Proposta proposta;
        private ItemProposta itemProposta;
        private SizeF fStringSize;
        private string sql01;


        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            this.fillForm();   
        }



        private void fillForm()
        {

            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            query.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            query.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = query.ToString();

            proposta = this.fillPropostaTop1();

            this.insertProposta(proposta.Codigo, proposta.Numero, proposta.DataLiberacao,proposta.CodigoCliente ,
                                proposta.RazaoCliente,(int)proposta.StatusOrdemSeparacao, MainConfig.CodigoUsuarioLogado);

            //carregaObjProposta(sql01);

            dgProposta.DataSource = carregarItemProposta().ToList();

            this.txtNumero.Text = proposta.Codigo.ToString();
            this.txtDataLiberacao.Text = proposta.DataLiberacao.Substring(1, 10);
            this.txtCliente.Text = proposta.RazaoCliente.ToString();

        }

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


        private IEnumerable<ItemProposta> carregarItemProposta() 
        {
 
            List<ItemProposta> listItensProposta = new List<ItemProposta>() ;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,produtoRESERVA AS PRODUTO,  SUM(quantidadeRESERVA) AS QTD ");
            query.Append("FROM tb1206_Reservas (NOLOCK) ");
            query.Append("INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA ");
            query.Append("INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO ");
            query.Append("WHERE propostaITEMPROPOSTA = 78527");
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

                    //Insert na tabela de Itens 
                    insertItemProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]),Convert.ToInt32(dr["propostaITEMPROPOSTA"]), (string)(dr["nomePRODUTO"]), (string)dr["partnumberPRODUTO"], (string)dr["ean13PRODUTO"], Convert.ToInt32(dr["PRODUTO"]),
                                            Convert.ToDouble(dr["QTD"]),0);


                    itemProposta = new ItemProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]), Convert.ToInt32(dr["propostaITEMPROPOSTA"]), (string)(dr["nomePRODUTO"]), (string)dr["partnumberPRODUTO"], (string)dr["ean13PRODUTO"], Convert.ToInt32(dr["PRODUTO"]),
                                            Convert.ToDouble(dr["QTD"]), ItemProposta.statusSeparado.NAOSEPARADO);


                    listItensProposta.Add(itemProposta);
                }
            }
             
            SqlServerConn.closeConn();

            return listItensProposta;
        }

        private void insertProposta(Int64 codigoProposta, string numeroProposta, string dataliberacaoProposta, Int32 clienteProposta,
                                    string razaoEmpreza, int ordemseparacaoimpresaProposta, int usuarioLogado)
        {

            //Query de insert na Base Mobile
            StringBuilder query = new StringBuilder();
            query.Append("Insert INTO tb0010_Propostas VALUES (");
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
        private Proposta fillPropostaTop1()
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

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }

       
    }
}