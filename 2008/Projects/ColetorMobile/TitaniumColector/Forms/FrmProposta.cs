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
        private List<Produto> listaProduto;

        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            this.carregaBaseMobile();   
        }

        /// <summary>
        /// Reliza todos os processos nescessários para efetuar a carga de dados na base Mobile.
        /// </summary>
        private void carregaBaseMobile()
        {

            objTransacoes = new TransacoesDados();
            objProposta = new Proposta();

            try 
            {
                //Limpa a Base.
                objTransacoes.clearBaseMobile();

                //Carrega um objeto Proposta
                objProposta = objTransacoes.top1PropostaServidor();

                //Realiza o Insert na Base Mobile
                objTransacoes.insertProposta(objProposta.Codigo, objProposta.Numero, objProposta.DataLiberacao, objProposta.CodigoCliente, objProposta.RazaoCliente, (int)objProposta.StatusOrdemSeparacao, MainConfig.CodigoUsuarioLogado);
                
                //Recupera List com itens da proposta
                this.listaProdutoProposta = objTransacoes.fillListItensProposta((int)objProposta.Codigo).ToList<ProdutoProposta>();

                //Insert na Base Mobile tabela tb0002_ItensProsposta
                objTransacoes.insertItemProposta(listaProdutoProposta.ToList<ProdutoProposta>());

                //Recupera informações sobre os produtos esistentes na proposta
                this.listaProduto = objTransacoes.fillListProduto((int)objProposta.Codigo).ToList<Produto>();
                
                //Insert na base Mobile tabela tb0003_Produtos
                objTransacoes.insertProduto(listaProduto.ToList<Produto>());
            }
            catch(Exception ex)
            {
                StringBuilder sbMsg = new StringBuilder();
                sbMsg.Append("Ocorreram problemas durante a carga de dados para a Base Mobile \n");
                sbMsg.AppendFormat("Error : {0}", ex.Message);
                sbMsg.Append("Contate o Administrador do sistema.");
                MainConfig.errorMessage(sbMsg.ToString(),"Sistem Error!");
            }
            finally 
            {
                objTransacoes = null;
                objProposta = null;
            }


        }


        private void carregarInformacoesProposta() 
        {
            objTransacoes = new TransacoesDados();
            objTransacoes.informacoesProposta();
        }

        private void FrmProposta_Load(object sender, System.EventArgs e)
        {
           // this.carregarInformacoesProposta();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }

    #region   "NAO UTILIZADOS"

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



    #endregion


    }
}