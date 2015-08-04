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

        //LIST
        private List<ProdutoProposta> listaProdutoProposta;
        private List<Produto> listaProduto;
        private List<String> listInfoProposta;

        //Contrutor.
        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            this.carregaBaseMobile();
        }

        //carga do formulário
        private void FrmProposta_Load(object sender, System.EventArgs e)
        {
            this.carregarForm();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }


    #region "CARGA BASE DE DADOS MOBILE"

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
            catch (Exception ex)
            {
                StringBuilder sbMsg = new StringBuilder();
                sbMsg.Append("Ocorreram problemas durante a carga de dados para a Base Mobile \n");
                sbMsg.AppendFormat("Error : {0}", ex.Message);
                sbMsg.Append("Contate o Administrador do sistema.");
                MainConfig.errorMessage(sbMsg.ToString(), "Sistem Error!");
            }
            finally
            {
                objTransacoes = null;
                objProposta = null;
            }


        }

    #endregion 
      
    #region "CARGA DO FORMULÁRIO"


        private void carregarForm()
        {
            objProposta = new Proposta();
            objProposta = this.fillListInfoProposta();
        }

        /// <summary>
        ///  Preenche um objeto proposta com todas as informações contidas na base de dados da Proposta de de todos os seus itens.
        /// </summary>
        /// <returns> Objeto Proposta </returns>
        private Proposta fillListInfoProposta()
        {
            Proposta objProposta = null;
            objTransacoes = new TransacoesDados();
            listInfoProposta = objTransacoes.informacoesProposta();
            objProposta = objTransacoes.carregaProposta();
            objTransacoes = null;
            return objProposta;
            //this.fillCamposForm(objProposta.Numero,objProposta.RazaoCliente,obj);
        }


        /// <summary>
        /// Carrega os campos do Formulário
        /// É nescessário que o objeto listInfoProposta esteja carregado e atualizado pois 
        /// a carga será feita  a partir dos dados contidos neste Objeto.
        /// </summary>
        private void fillCamposForm()
        {
            lbNumeroPedido.Text = ListInformacoesProposta[1];
            lbNomeCliente.Text = ListInformacoesProposta[2];
            lbQtdPecas.Text = ListInformacoesProposta[3] + " Pçs";
            lbQtdItens.Text = ListInformacoesProposta[4] + " Itens";
        }

        /// <summary>
        /// Carrega os campos do Formulário.
        /// Caso o Objeto listInfoPropostas esteja vazio 
        /// ele também  será carregado para que esses dados possam ser trabalhados em outros pocedimentos.
        /// </summary>
        /// <param name="listInfoProposta">List do tipo String com informações sobre a proposta a ser trabalhada.</param>
        private void fillCamposForm(List<String> listInfoProposta)
        {
            lbNumeroPedido.Text = listInfoProposta[1];
            lbNomeCliente.Text = listInfoProposta[2];
            lbQtdPecas.Text = listInfoProposta[3] + " Pçs";
            lbQtdItens.Text = listInfoProposta[4] + " Itens";

            if (this.listInfoProposta == null || this.listInfoProposta.Count == 0 )
            {
                this.ListInformacoesProposta = listInfoProposta;
            }

        }

        /// <summary>
        /// Carrega parcial os campos do Formulário
        /// </summary>
        private void fillCamposForm(String numeroPedido,String nomeCliente,Double qtdPecas, Double qtdItens)
        {
            lbNumeroPedido.Text = numeroPedido;
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = qtdPecas.ToString() + " Pçs";
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
        }

        /// <summary>
        /// Carrega os campos do Formulário
        /// É nescessário que o objeto listInfoProposta esteja carregado e atualizado pois 
        /// </summary>
        private void fillCamposForm(Int32 numeroPedido, String nomeCliente, Double qtdPecas, Double qtdItens,String partnumber,String produto,String local,String quantidadeItem)
        {
            lbNumeroPedido.Text = numeroPedido.ToString();
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = qtdPecas.ToString() + " Pçs";
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
            tbPartNumber.Text = partnumber;
            tbProduto.Text = produto;
            tbLocal.Text = local;
            tbQuantidade.Text = quantidadeItem;
        }




        /// <summary>
        /// Preenche os campos do Fomulário.  
        /// Caso o Objeto listInfoPropostas esteja vazio 
        /// ele também  será carregado para que esses dados possam ser trabalhados em outros pocedimentos.
        /// </summary>
        ///<param name="codigoProposta"> Código Proposta</param>
        /// <param name="numeroPedido">Número Proposta</param>
        /// <param name="nomeCliente">Nome Cliente</param>
        /// <param name="qtdPecas">Quantidade de Peças</param>
        /// <param name="qtdItens">Quantidade de Itens.</param>
        private void fillCamposForm(String codigoProposta,String numeroPedido, String nomeCliente, String qtdPecas, String qtdItens)
        {
            var codigo = codigoProposta;
            lbNumeroPedido.Text = numeroPedido;
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = qtdPecas + " Pçs";
            lbQtdItens.Text = qtdItens + " Itens";

            if (this.listInfoProposta == null || this.listInfoProposta.Count == 0) 
            {
                List<String> list = new List<String>();
                list.Add(codigoProposta);
                list.Add(numeroPedido);
                list.Add(nomeCliente);
                list.Add(qtdPecas);
                list.Add(qtdItens);

                this.ListInformacoesProposta = list;
            }
        }

    #endregion

    #region "GET E SET"

        public List<String> ListInformacoesProposta
        {
            get { return listInfoProposta; }
            set { listInfoProposta = value; }
        }

    #endregion

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