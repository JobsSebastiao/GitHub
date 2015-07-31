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
        private TransacoesDados objTransacoes;
        private List<ProdutoProposta> listaProdutoProposta;

        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            this.realizaCargaBaseMobile();   
        }

        /// <summary>
        /// Reliza todos os processos nescessários para efetuar a carga de dados na base Mobile.
        /// </summary>
        public void realizaCargaBaseMobile()
        {
            objTransacoes = new TransacoesDados();
            objProposta = new Proposta();

            //Carrega um objeto Proposta
            objProposta = objTransacoes.top1PropostaServidor();

            //Realiza o Insert na Base Mobile
            objTransacoes.insertProposta(objProposta.Codigo, objProposta.Numero, objProposta.DataLiberacao, objProposta.CodigoCliente, objProposta.RazaoCliente, (int)objProposta.StatusOrdemSeparacao, MainConfig.CodigoUsuarioLogado);
            
            //Recupera List com itens da proposta
            this.listaProdutoProposta = objTransacoes.recuperaItensProposta((int)objProposta.Codigo).ToList<ProdutoProposta>();

            //Insert na Base Mobile
            objTransacoes.insertItensProposta(listaProdutoProposta.ToList<ProdutoProposta>());

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
        private void atualizaDataGridItensProposta(List<ProdutoProposta> listItemProposta)
        {

            //buscaItensBaseMobile();


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
            //dgProposta.DataSource = dt;

        }

        private void FrmProposta_KeyDown(object sender, KeyEventArgs e)
        {
            //string = "EAN=789123654587|LOTE=LT-01|SEQ=023654|QTD=5"
        }

    }
}