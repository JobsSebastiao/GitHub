﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Classes;
using TitaniumColector.Classes.Procedimentos;
using System.Globalization;
using TitaniumColector.Classes.Dao;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using TitaniumColector.Classes.Exceptions;

namespace TitaniumColector.Forms
{
    public partial class FrmProposta : Form
    {
        //OBJETOS
        private Proposta objProposta;
        private BaseMobile objTransacoes;
        private String inputText;

        private DaoEtiqueta daoEtiqueta;
        private DaoProdutoProposta daoItemProposta;
        private DaoProposta daoProposta;
        private DaoProduto daoProduto;

        //private SqlCommand command;

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
        
        /// <summary>
        /// Menu evento ao clicar em Opções/Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpcoes_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                this.newLogin();
            }
            catch (Exception ex)
            {
                MainConfig.errorMessage(ex.Message, "Logout");
            }
        }
     
        /// <summary>
        /// Menu evento ao clicar em Opções/Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpcoes_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        /// <summary>
        /// realiza o decremento do campo volume.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDecrementaVol_Click(object sender, System.EventArgs e)
        {
            String valor = ProcedimentosLiberacao.decrementaVolume();

            if (valor.Contains("Qtd"))
            {
                tbMensagem.Text = valor;
                
            }
            else 
            {
                lbQtdVolumes.Text = valor;
                tbMensagem.Text = "";
            }

            this.Focus();
        }

        /// <summary>
        /// Realiza o incremento do campo volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIncrementaVol_Click(object sender, System.EventArgs e)
        {
            lbQtdVolumes.Text = ProcedimentosLiberacao.incrementaVolume();
            this.Focus();
            tbMensagem.Text = "";
        }

        /// <summary>
        /// Recebe o valor de input durante a leitura do dispositivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProposta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Etiqueta.Tipo tipoEtiqueta = ProcedimentosLiberacao.validaInputValueEtiqueta(inputText);

                switch (tipoEtiqueta)
                {
                    case Etiqueta.Tipo.INVALID:

                        inputText = string.Empty;
                        tbMensagem.Text = " Tipo de Etiqueta inválida!!!";
                        break;

                    case Etiqueta.Tipo.QRCODE:

                        this.liberarItem(inputText);
                        inputText = string.Empty;
                        break;

                    case Etiqueta.Tipo.BARRAS:

                        inputText = string.Empty;
                        tbMensagem.Text = " Ean13!!!";
                        break;

                    default:

                        inputText = string.Empty;
                        tbMensagem.Text = " Tipo de Etiqueta inválida!!!";
                        break;
                }
                
            }
            else
            {
                inputText += e.KeyChar.ToString();
            }
        }

        /// <summary>
        /// Valida o fechamento do form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProposta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Desejar salvar as alterações realizadas?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                MessageBox.Show("Aqui eu salvo tudo que acontece.");
            }
            else
            {
                e.Cancel = true;
            }
        }


    #endregion

    #region "CARGA BASE DE DADOS MOBILE"

        /// <summary>
        /// Reliza todos os processos nescessários para efetuar a carga de dados na base Mobile.
        /// </summary>
        private void carregaBaseMobile()
        {

            objTransacoes = new BaseMobile();
            objProposta = new Proposta();
            daoItemProposta = new DaoProdutoProposta();
            daoProposta = new DaoProposta();
            daoProduto = new DaoProduto();

            try
            {
                //Limpa a Base.
                objTransacoes.clearBaseMobile();

                //Carrega um objeto Proposta e inicia todo o procedimento.
                //Caso não exista propostas a serem liberadas gera um exception 
                //onde será feito os tratamentos para evitar o travamento do sistema.
                if ((objProposta = daoProposta.fillTop1PropostaServidor()) != null)
                {
                    daoProposta.InsertOrUpdatePickingMobile(objProposta, MainConfig.CodigoUsuarioLogado, Proposta.StatusLiberacao.TRABALHANDO, DateTime.Now);

                    //recupera o codigoPickingMobile da proposta trabalhada.
                    objProposta.CodigoPikingMobile = daoProposta.selectMaxCodigoPickingMobile(objProposta.Codigo);

                    //Realiza o Insert na Base Mobile
                    daoProposta.insertProposta(objProposta, MainConfig.CodigoUsuarioLogado);

                    //Recupera List com itens da proposta
                    this.listaProdutoProposta = daoItemProposta.fillListItensProposta((int)objProposta.Codigo).ToList<ProdutoProposta>();

                    //Insert na Base Mobile tabela tb0002_ItensProsposta
                    daoItemProposta.insertItemProposta(listaProdutoProposta.ToList<ProdutoProposta>());

                    //Recupera informações sobre os produtos existentes na proposta
                    this.listaProduto = daoProduto.fillListProduto((int)objProposta.Codigo).ToList<Produto>();

                    //Insert na base Mobile tabela tb0003_Produtos
                    daoProduto.insertProdutoBaseMobile(listaProduto.ToList<Produto>());
                }
                else
                {
                    throw new NoNewPropostaException("Não existem novas propostas a serem liberadas!!");
                }
            }
            catch (SqlQueryExceptions ex) 
            {
                this.exitOnError(ex.Message, "Próxima Proposta");
            }
            catch (NoNewPropostaException ex)
            {
                this.exitOnError(ex.Message, "Próxima Proposta");
            }
            catch (SqlCeException sqlEx)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
                strBuilder.Append("O procedimento não pode ser concluído");
                strBuilder.AppendFormat("Erro : {0}", sqlEx.Errors);
                strBuilder.AppendFormat("Description : {0}", sqlEx.Message);
                MainConfig.errorMessage(strBuilder.ToString(), "SqlException!!");
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
                daoProposta = null;
                daoProduto = null;
                daoItemProposta = null;
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
            objTransacoes = new BaseMobile();
            daoProposta = new DaoProposta();

            try
            {
                //Carrega um list com informações gerais sobre a proposta atual na base Mobile.
                listInfoProposta = daoProposta.fillInformacoesProposta();

                //carrega um obj Proposta com a atual proposta na base mobile 
                //e com o item top 1 da proposta que ainda não esteja separado.
                proposta = daoProposta.fillPropostaWithTop1Item();

                //Set o total de peças e o total de Itens para o objeto proposta
                proposta.setTotalValoresProposta(Convert.ToDouble(listInfoProposta[4]), Convert.ToDouble(listInfoProposta[3]),Convert.ToInt32(listInfoProposta[5]));

                //Set os valores para os atributos auxiliares.
                ProcedimentosLiberacao.inicializarProcedimentos(Convert.ToDouble(listInfoProposta[4]), Convert.ToDouble(listInfoProposta[3]), proposta.ListObjItemProposta[0].Quantidade, proposta.Volumes);

                //Carregao formulário  com as informações que serão manusueadas para a proposta e o item da proposta
                this.fillCamposForm(proposta.Numero, (string)proposta.RazaoCliente, proposta.Totalpecas, proposta.TotalItens, (string)proposta.ListObjItemProposta[0].Partnumber, (string)proposta.ListObjItemProposta[0].Descricao, (string)proposta.ListObjItemProposta[0].NomeLocalLote, proposta.ListObjItemProposta[0].Quantidade.ToString());
                
                //zera o obj transações 
                objTransacoes = null;
                objProposta = null;

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
        /// Carrega o form com as informações nescessárias para separação do próximo item.
        /// </summary>
        /// <param name="objProposta">ObjProposta já setado com as informações do seu próximo item. ITEM INDEX[0] DA LISTOBJITEMPROPOSTA</param>
        /// <param name="qtdPecas">quantidade de peças ainda a separar</param>
        /// <param name="qtdItens">quantidade itens ainda a liberar</param>
        /// <remarks > O objeto proposta já deve ter sido carregado com o próximo item que será trabalhado pois as informações serão retira
        ///           retiradas do item de index [0] na ListObjItemProsta
        /// </remarks>
        private void fillCamposForm(Proposta objProposta,Double qtdPecas, Double qtdItens)
        {
            lbNumeroPedido.Text = objProposta.Numero.ToString();
            lbNomeCliente.Text = objProposta.RazaoCliente;
            lbQtdPecas.Text = qtdPecas.ToString() + " Pçs";
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
            tbPartNumber.Text = objProposta.ListObjItemProposta[0].Partnumber;
            tbDescricao.Text = objProposta.ListObjItemProposta[0].Descricao;
            if (objProposta.ListObjItemProposta[0].NomeLocalLote.Contains(','))
            {
                tbLocal.Font = MainConfig.FontGrandeBold;
            }
            tbLocal.Text = objProposta.ListObjItemProposta[0].NomeLocalLote;
            tbQuantidade.Text = objProposta.ListObjItemProposta[0].Quantidade.ToString();
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
        /// Preenche os campos do Fomulário.  
        /// Caso o Objeto listInfoPropostas esteja vazio 
        /// ele também  será carregado para que esses dados possam ser trabalhados em outros pocedimentos.
        /// </summary>
        ///<param name="codigoProposta"> Código Proposta</param>
        /// <param name="numeroPedido">Número Proposta</param>
        /// <param name="nomeCliente">Nome Cliente</param>
        /// <param name="qtdPecas">Quantidade de Peças</param>
        /// <param name="qtdItens">Quantidade de Itens.</param>
        private void fillCamposForm(String codigoProposta, String numeroPedido, String nomeCliente, String qtdPecas, String qtdItens)
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
                    
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");

            lbNumeroPedido.Text = numeroProposta.ToString();
            lbNomeCliente.Text = nomeCliente;
            lbQtdPecas.Text = this.intOrDecimal(qtdPecas.ToString()) + " Pçs";
            lbQtdVolumes.Text = ProcedimentosLiberacao.QtdVolumes.ToString();     
            lbQtdItens.Text = qtdItens.ToString() + " Itens";
            tbPartNumber.Text = partnumber;
            tbDescricao.Text = produto;
            if (local.Contains(','))
            {
                tbLocal.Font = MainConfig.FontGrandeBold;
            }
            tbLocal.Text = local;

            tbQuantidade.Text = this.intOrDecimal(quantidadeItem);

        }
        
        /// <summary>
        /// Realiza todos os procedimentos nescessários para carregar o próximo item a ser separado.
        /// </summary>
        /// 
        /// <returns>
        ///          TRUE --> caso exista um próximo item a ser trabalhado
        ///          FALSE --> caso não exista mais items para serem trabalhados.
        /// </returns>
        private bool nextItemProposta()
        {
            bool hasItem = false;
            daoItemProposta = new DaoProdutoProposta();
            daoEtiqueta = new DaoEtiqueta();
            objTransacoes = new BaseMobile();

            try
            {
                this.clearParaProximoItem();
                //processa quantidade de itens
                ProcedimentosLiberacao.decrementaQtdTotalItens(1);
                //processa qunatidade de peças
                ProcedimentosLiberacao.decrementaQtdTotalPecas(objProposta.ListObjItemProposta[0].Quantidade);
                //seta status para separado
                ProcedimentosLiberacao.setStatusProdutoParaSeparado(objProposta.ListObjItemProposta[0]);
                //grava informações do item na base de dados mobile
                daoItemProposta.updateStatusItemProposta(objProposta.ListObjItemProposta[0]);
                //ESTE TRECHO TALVES ESTEJA SENDO DESNECESSÀRIO.
                //ANALIZAR MELHOR Action SUA UTILIZACAO 
                daoEtiqueta.insertSequencia(ProcedimentosLiberacao.EtiquetasLidas);
                //inseri informações das etiquetas referente ao produto liberado em formato Xml
                daoItemProposta.updateXmlItemProposta(Etiqueta.gerarXmlItensEtiquetas(ProcedimentosLiberacao.EtiquetasLidas), objProposta.ListObjItemProposta[0].CodigoItemProposta);
                //carrega próximo item
                if (ProcedimentosLiberacao.TotalItens > 0)
                {
                    ProdutoProposta prod = daoItemProposta.fillTop1ItemProposta();


                    if (prod != null)
                    {
                        hasItem = true;

                        objProposta.setNextItemProposta(prod);
                    }
                    else
                    {
                        hasItem = false;
                    }
                }
                else // CASO não tenha um próximo item 
                {
                    hasItem = false;
                }

                //Se existir um próximo item
                if (hasItem)
                {
                    //seta parametros para iniciar leitura do próximo item
                    ProcedimentosLiberacao.inicializarProcedimentosProximoItem(objProposta.ListObjItemProposta[0].Quantidade);
                    //recarrega o form com as informações do próximo item.
                    this.fillCamposForm(objProposta, ProcedimentosLiberacao.TotalPecas, ProcedimentosLiberacao.TotalItens);
                }
                else
                {
                    this.clearFormulario(true, true);
                }
            }
            catch (SqlCeException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                daoEtiqueta = null;
                daoItemProposta = null;
            }

            return hasItem;
        }

    #endregion

    #region "MÉTODOS GERAIS"

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

        /// <summary>
        /// Limpar formulário para preencher informações de um próximo item.
        /// </summary>
        private void clearParaProximoItem()
        {
            this.clearFormulario(false, true);
            this.tbProduto.Text = "";
            this.tbLote.Text = "";
            this.tbSequencia.Text = "";
            this.tbMensagem.Text = "";
        }

        private void liberarItem() 
        {
            ProcedimentosLiberacao.lerEtiqueta(objProposta.ListObjItemProposta[0], tbProduto, tbLote, tbSequencia, tbQuantidade, tbMensagem);

            if (ProcedimentosLiberacao.QtdPecasItem == 0)
            {
                if (!this.nextItemProposta())
                {
                    MessageBox.Show("PRÒXIMA PROPOSTA.");
                    this.Dispose();
                    this.Close();
                }

            }
        }

        private void liberarItem(String inputText)
        {
            try
            {
                ProcedimentosLiberacao.lerEtiqueta(inputText, objProposta.ListObjItemProposta[0], tbProduto, tbLote, tbSequencia, tbQuantidade, tbMensagem);

                if (ProcedimentosLiberacao.QtdPecasItem == 0)
                {
                    if (!this.nextItemProposta())
                    {
                        daoItemProposta = new DaoProdutoProposta();
                        daoProposta = new DaoProposta();
                        daoProposta.updatePropostaTbPickingMobileFinalizar(objProposta,Proposta.StatusLiberacao.FINALIZADO);
                        daoItemProposta.updateItemPropostaRetorno();
                        this.Dispose();
                        this.Close();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                if (daoProposta != null)
                {
                    daoProposta = null;
                }
                if (daoItemProposta != null)
                {
                    daoItemProposta = null;
                }
            }
        }

        private String intOrDecimal(String value)
        {

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");

            if (Convert.ToDouble(value) % 1 == 0)
            {
                value = String.Format(culture, "{0:0}", value);
            }
            else
            {
                value = String.Format(culture, "{0:0.000}", Convert.ToDouble(value));
            }
            return value;
        }

        private String intOrDecimal(int value)
        {

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            String retorno = "";
            if (Convert.ToDouble(value)% 1 == 0)
            {
                retorno = String.Format(culture, "{0:0} Pçs", value);
            }
            else
            {
                retorno = String.Format(culture, "{0:0.00} Pçs", value);
            }

            return retorno;
        }

        private String intOrDecimal(double value)
        {

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            String retorno = "";
            if (Convert.ToDouble(value) % 1 == 0)
            {
                retorno = String.Format(culture, "{0:0} Pçs", value);
            }
            else
            {
                retorno = String.Format(culture, "{0:0.00} Pçs", value);
            }

            return retorno;
        }

        private void exitOnError(String mensagem,String headForm) 
        {
            this.Dispose();
            this.Close();
            MainConfig.errorMessage(mensagem, headForm);
            FrmAcao frmAcao = new FrmAcao();
            Cursor.Current = Cursors.Default;
            frmAcao.Show();
        }

        private void newLogin() 
        {
            try
            {
                DialogResult resp = MessageBox.Show("Deseja salvar as altereções relalizadas", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (resp == DialogResult.Yes)
                {


                }
                else if (resp == DialogResult.No)
                {
                    daoProposta = new DaoProposta();
                    daoProposta.updatePropostaTbPickingMobile(objProposta, Proposta.StatusLiberacao.INSERIDO, "null");
                    daoProposta = null;
                    this.Dispose();
                    this.Close();
                    frmLogin login = new frmLogin();
                    login.Show();
                }

            }
            catch (Exception)
            {
                throw new Exception("Não foi possível executar o comando solicitado. \n ", null);
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

        #endregion

    }

}