using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Classes;
using TitaniumColector.Classes.Procedimentos;

namespace TitaniumColector.Forms
{
    public partial class FrmProposta : Form
    {
        //OBEJETOS
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


    #region "EVENTOS"

        private void FrmProposta_Load(object sender, System.EventArgs e)
        {
            //carga do formulário
            this.clearFormulario(true, true);
            this.carregarForm();
            Cursor.Current = Cursors.Default;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }

    #endregion

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
                objProposta = objTransacoes.fillTop1PropostaServidor();

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
                sbMsg.Append("\nContate o Administrador do sistema.");
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
            objProposta = this.fillProposta();
        }

        /// <summary>
        ///  Preenche um objeto proposta com todas as informações contidas na base de dados da Proposta e de todos os seus itens.
        /// </summary>
        /// <returns> Objeto Proposta </returns>
        private Proposta fillProposta()
        {
            Proposta proposta = null;

            objTransacoes = new TransacoesDados();

            try
            {
                //Carrega um list com informações gerais sobre a proposta atual na base Mobile.
                listInfoProposta = objTransacoes.fillInformacoesProposta();

                //carrega um obj Proposta com a atual proposta na base mobile 
                //e com o item top 1 da proposta que ainda não esteja separado.
                proposta = objTransacoes.fillPropostaWithTop1Item();

                //Set o total de peças e o total de Itens para o objeto proposta
                proposta.totalItensPecasProposta(Convert.ToDouble(listInfoProposta[4]), Convert.ToDouble(listInfoProposta[3]));

                //Set os valores para os atributos auxiliares.
                ProcedimentosLiberacao.inicializarProcedimentos(Convert.ToDouble(listInfoProposta[4]), Convert.ToDouble(listInfoProposta[3]), proposta.ListObjItemProposta[0].Quantidade);

                //Carregao formulário  com as informações que serão manusueadas para a proposta e o item da proposta
                this.fillCamposForm(proposta.Numero, (string)proposta.RazaoCliente, proposta.Totalpecas, proposta.TotalItens, (string)proposta.ListObjItemProposta[0].Partnumber, (string)proposta.ListObjItemProposta[0].Descricao, (string)proposta.ListObjItemProposta[0].NomeLocalLote, proposta.ListObjItemProposta[0].Quantidade.ToString());
                
                //zera o obj transações 
                objTransacoes = null;

                //Retorna o objeto proposta o qual terá suas informações trabalhadas do processo de conferencia do item.
                return proposta;
            }
            catch (Exception ex)
            {
                StringBuilder sbMsg = new StringBuilder();
                sbMsg.Append("Problemas durante o processamento de informações sobre a proposta \n");
                sbMsg.AppendFormat("Error : {0}", ex.Message);
                sbMsg.Append("Contate o Administrador do sistema.");
                MainConfig.errorMessage(sbMsg.ToString(), "Sistem Error!");
                return null;
            }

        }

        ////CARREGA AS INFORMAÇÔES PARA O FORMULÁRIO

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
        /// Carga parcial do fomulário
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
        /// Carga apenas de informações gerais da proposta
        /// </summary>
        /// <param name="numeroPedido">Número da Proposta</param>
        /// <param name="nomeCliente">Nome do Cliente</param>
        /// <param name="qtdPecas">Total de Peças/param>
        /// <param name="qtdItens">Total de Itens</param>
        private void fillCamposForm(String numeroPedido,String nomeCliente,Double qtdPecas, Double qtdItens)
        {
            lbNumeroPedido.Text = numeroPedido;
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = qtdPecas.ToString() + " Pçs";
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
        }

        /// <summary>
        /// Carrega os campo do Fomulário de Propostas
        /// </summary>
        /// <param name="numeroPedido">Numero da Proposta</param>
        /// <param name="nomeCliente">Cliente Proposta</param>
        /// <param name="qtdPecas">Total de peças da porposta</param>
        /// <param name="qtdItens">Total de itens na proposta</param>
        /// <param name="partnumber">Partnumber no item a ser manipulado</param>
        /// <param name="produto">Descrição(NOME) do produto a ser manipulado</param>
        /// <param name="local">local de armazenagem do produto</param>
        /// <param name="quantidadeItem">Quantidade de item do produto atual a ser manipulado.</param>
        private void fillCamposForm(String numeroProposta, String nomeCliente, Double qtdPecas, Double qtdItens,String partnumber,String produto,String local,String quantidadeItem)
        {
            lbNumeroPedido.Text = numeroProposta.ToString();
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = qtdPecas.ToString() + " Pçs";
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
            tbPartNumber.Text = partnumber;
            tbDescricao.Text = produto;

            if (local.Contains(','))
            {
                tbLocal.Font = MainConfig.FontMediaBold;
            }
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

    #region "MANUSEIO DE INFORMAÇÔES DA PROPOSTA"

        /// <summary>
        /// Realiza o decrementos e passa os valores para os Labels 
        /// dando a visão da alteração ao usuário.
        /// </summary>
        /// <param name="qtditens">Total de Itens a ser decrementado</param>
        /// <param name="qtdPecas">Total de Peças a ser decrementado</param>
        public void atualizaFormTotalPecasTotalItens(Double qtditens, Double qtdPecas)
        {
            //if ((this.decrementaQtdTotalPecas(qtdPecas) == true) && (this.decrementaQtdTotalItens(qtditens) == true))
            //{
            //    lbQtdItens.Text = ProcedimentosLiberacao.TotalItens.ToString() + " Itens";
            //    lbQtdPecas.Text = ProcedimentosLiberacao.TotalPecas.ToString() + " Pçs";
            //}
        }

        /// <summary>
        /// Decrementa a quantidade do item que está sendo trabalhado e atualiza o formulário 
        /// para que o usuário vizualize a alteração.
        /// </summary>
        /// <param name="qtditens">Qunatidade de itens a ser decrementado.</param>
        //public void atualizaFormQuantidadeItens(Double qtditens)
        //{
        //    if ((this.decrementaQuatidadeItem(qtditens) == true))
        //    {
        //       // tbQuantidade.Text = AuxQuantidadeItens.ToString() + " Itens";
        //    }
        //}

      
    #endregion

    #region "MÉTODOS GERAIS"

        /// <summary>
        /// Decrementa a quantidade de item do atual item em processamento.
        /// </summary>
        /// <param name="qtd">quantidade a ser diminuida</param>
        /// <returns>Retorna true caso não ocorra erros
        ///          false se o calculo não ocorrer com esperado.</returns>
        //public Boolean decrementaQuatidadeItem(double qtd)
        //{
        //    try
        //    {
        //        if (AuxQuantidadeItens > 0 && (AuxQuantidadeItens - qtd >= 0))
        //        {
        //            AuxQuantidadeItens -= qtd;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Limpa todos os campos que possuem valores manipuláveis.
        /// </summary>
        private void clearFormulario()
        {

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Panel))
                {
                    //loop nos controles do painel PRINCIPAL
                    if (ctrl.Name.ToString().ToUpper() == "PNLFRMPROPOSTA")
                    {
                        foreach (Control pnFrmCtrl in ctrl.Controls)
                        {
                            //realiza um loop nos controles do painel CENTRAL
                            if (pnFrmCtrl.Name.ToString().ToUpper() == "PNCENTRAL")
                            {
                                foreach (Control pnCentralCtrl in pnFrmCtrl.Controls)
                                {
                                    if (pnCentralCtrl.Tag.ToString() != "" && pnCentralCtrl.Tag.ToString().ToUpper() == "L")
                                    {
                                        pnCentralCtrl.Text = "";
                                    }
                                }

                            }
                            else if (pnFrmCtrl.Tag.ToString() != "" && pnFrmCtrl.Tag.ToString().ToUpper() == "L")
                            {

                                pnFrmCtrl.Text = "";
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Limpa os campos com valores manipuláveis podendo selecionar se quer limpar apenas um dos dois paineis no formulário ou os dois.
        /// </summary>
        /// <param name="boolPnPrincipal">Limpa apenas o painel Principal (TRUE)</param>
        /// <param name="boolPnCentral"> limpa apenas o painel central (TRUE)</param>
        private void clearFormulario(bool boolPnPrincipal, bool boolPnCentral)
        {
            //Entra no painel
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Panel))
                {
                    if (ctrl.Name.ToString().ToUpper() == "PNLFRMPROPOSTA")
                    {
                        foreach (Control pnFrmCtrl in ctrl.Controls)
                        {

                            if (pnFrmCtrl.Name.ToString().ToUpper() == "PNCENTRAL")
                            {
                                foreach (Control pnCentralCtrl in pnFrmCtrl.Controls)
                                {
                                    if (pnCentralCtrl.Tag.ToString() != "" && pnCentralCtrl.Tag.ToString().ToUpper() == "L" && (boolPnCentral == true))
                                    {
                                        pnCentralCtrl.Text = "";
                                    }
                                }

                            }

                            else if (pnFrmCtrl.Tag.ToString() != "" && pnFrmCtrl.Tag.ToString().ToUpper() == "L" && (boolPnPrincipal == true))
                            {

                                pnFrmCtrl.Text = "";
                            }
                        }
                    }
                }
            }
        }

        private void clearParaProximoItem()
        {
            this.clearFormulario(false, true);
            this.tbProduto.Text = "";
            this.tbLote.Text = "";
            this.tbSequencia.Text = "";
            this.tbMensagem.Text = "";
        }

    #endregion

    #region "GET E SET"

        public List<String> ListInformacoesProposta
        {
            get { return listInfoProposta; }
            set { listInfoProposta = value; }
        }

    #endregion


        private void menuItem2_Click(object sender, EventArgs e)
        {
            ProcedimentosLiberacao.gerarEtiquetas();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {

            ProcedimentosLiberacao.lerEtiqueta(objProposta.ListObjItemProposta[0], tbProduto, tbLote, tbSequencia, tbQuantidade, tbMensagem);

            if (ProcedimentosLiberacao.QtdPecasItem == 0)
            {
                objTransacoes = new TransacoesDados();
                this.clearParaProximoItem();
                ProcedimentosLiberacao.decrementaQtdTotalItens(1,this.lbQtdItens);
                ProcedimentosLiberacao.decrementaQtdTotalPecas(objProposta.ListObjItemProposta[0].Quantidade,this.lbQtdPecas);
                ProcedimentosLiberacao.setStatusProdutoParaSeparado(objProposta.ListObjItemProposta[0]);
                objTransacoes.updateItemProposta(objProposta.ListObjItemProposta[0]);
                objProposta.setNextItemProposta(objTransacoes.fillTop1ItemProposta());
                ProcedimentosLiberacao.inicializarProcedimentos(objProposta.ListObjItemProposta[0].Quantidade);

                this.fillCamposForm(objProposta.Numero,objProposta.RazaoCliente,ProcedimentosLiberacao.TotalPecas,
                     ProcedimentosLiberacao.TotalItens, objProposta.ListObjItemProposta[0].Partnumber, 
                     objProposta.ListObjItemProposta[0].Descricao, objProposta.ListObjItemProposta[0].NomeLocalLote, 
                     objProposta.ListObjItemProposta[0].Quantidade.ToString());
            }

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

   
        #endregion

    }
}