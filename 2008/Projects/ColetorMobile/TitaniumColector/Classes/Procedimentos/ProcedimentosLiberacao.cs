using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Utility;
using TitaniumColector.Classes.Exceptions;
using System.Xml;
using System.Xml.Linq;

namespace TitaniumColector.Classes.Procedimentos
{
     static class ProcedimentosLiberacao
    {
        private static Double totalItens;
        private static Double totalPecas;
        private static Double qtdPecasItem;
        private static Int32 qtdVolumes;
        private static Int32 proximaEtiqueta;
        private static List<Etiqueta> listEtiquetasLidas;
        private static List<Etiqueta> listEtiquetas;
        private static Array arrayStringToEtiqueta;

        /// <summary>
        /// Carrega as a serem trabalhadas durante o procedimento de liiberção dos itens da proposta.
        /// </summary>
        /// <param name="tItens">Total de Itens da Proposta</param>
        /// <param name="tPecas">Total de peças na Proposta</param>
        /// <param name="pecasItens">quantidade de pecas do item a ser trabalhado.</param>
        public static void inicializarProcedimentos(Double tItens, Double tPecas, Double pecasItens)
        {
            TotalItens = tItens;
            TotalPecas = tPecas;
            qtdPecasItem = pecasItens;

            if (ListEtiquetasGeradas != null)
            {
                ListEtiquetasGeradas.Clear();

            }
            else 
            {
                listEtiquetasLidas = new List<Etiqueta>();
            }
            
            ProximaEtiqueta = 0;

            if(ListEtiquetasGeradas != null)
            {
                ListEtiquetasGeradas.Clear();
            }

            if (arrayStringToEtiqueta != null)
            {
                arrayStringToEtiqueta = null;
            }
        }

        public static void inicializarProcedimentos(Double tItens, Double tPecas, Double pecasItens,Int32 qtdVolumes)
        {
            TotalItens = tItens;
            TotalPecas = tPecas;
            qtdPecasItem = pecasItens;
            QtdVolumes = qtdVolumes;

            if (ListEtiquetasGeradas != null)
            {
                ListEtiquetasGeradas.Clear();

            }
            else
            {
                listEtiquetasLidas = new List<Etiqueta>();
            }

            ProximaEtiqueta = 0;

            if (ListEtiquetasGeradas != null)
            {
                ListEtiquetasGeradas.Clear();
            }

            if (arrayStringToEtiqueta != null)
            {
                arrayStringToEtiqueta = null;
            }
        }

        /// <summary>
         /// Não altera o total de peças e o total de itens atualmente setados.
         /// </summary>
         /// <param name="pecasItens">quantidade de peças do item a ser trabalhado.</param>
        public static void inicializarProcedimentosProximoItem(Double pecasItens)
        {
            TotalItens = TotalItens;
            TotalPecas = TotalPecas;
            qtdPecasItem = pecasItens;

            if (listEtiquetasLidas != null)
            {
                listEtiquetasLidas.Clear();
            }
            else
            {
                listEtiquetasLidas = new List<Etiqueta>();
            }

            ProximaEtiqueta = 0;

            if (ListEtiquetasGeradas != null)
            {
                ListEtiquetasGeradas.Clear();
            }

            if (arrayStringToEtiqueta != null)
            {
                arrayStringToEtiqueta = null;
            }
        }

    #region "GETS E SETS"

        public static Double TotalPecas
        {
            get { return totalPecas; }
            set { totalPecas = value; }
        }

        public static Double QtdPecasItem
        {
            get { return qtdPecasItem; }
 
        }

        public static Int32 QtdVolumes
        {
            get { return ProcedimentosLiberacao.qtdVolumes; }
            set { ProcedimentosLiberacao.qtdVolumes = value; }
        }

        public static Double subtrairQtdPecasItem(Double value)
        {
            if (QtdPecasItem - value >= 0)
            {
                return qtdPecasItem -= value;
            }
            else 
            {
                throw new QuantidadeInvalidaException(String.Format ("O valor informado é maior que a quantidade de peças existentes."));
            }
        }

        public static void somarQtdPecasItem(Double value)
        {
            totalPecas = value;
        }

        public static Int32 ProximaEtiqueta
        {
            get { return proximaEtiqueta; }
            set { proximaEtiqueta = value; }
        }

        public static Double TotalItens
        {
            get { return totalItens; }
            set { totalItens = value; }
        }

        internal static List<Etiqueta> EtiquetasLidas
        {
            get { return listEtiquetasLidas; }
            set { listEtiquetasLidas = value; }
        }
      
        internal static List<Etiqueta> ListEtiquetasGeradas
        {
          get { return listEtiquetas; }
          set { listEtiquetas = value; }
        }

        public static Array ArrayStringToEtiqueta
        {
            get { return ProcedimentosLiberacao.arrayStringToEtiqueta; }
            set { ProcedimentosLiberacao.arrayStringToEtiqueta = value; }
        }

    #endregion

        /// <summary>
        /// Verifica se a Etiqueta já foi lida.
        /// </summary>
        /// <returns>FALSE --> se a etiqueta for encontrada na list
        ///          TRUE --> se a etiqueta ainda não foii lida.
        /// </returns>
        public static bool validaEtiquetaNaoLida(Etiqueta objEtiqueta)
        {
            //Verifica se o List foi iniciado
            if (EtiquetasLidas != null)
            {
                if (EtiquetasLidas.Count == 0)
                {
                    return true;
                }
                else
                {
                    //Verifica se a etiqueta está na lista de etiquetas lidas.
                    if (Etiqueta.validarEtiqueta(objEtiqueta, EtiquetasLidas))
                    {
                        //Caso esteja na lista
                        return false;
                    }
                    else
                    {
                        //caso não esteja na lista.
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica se a Etiqueta já foi lida.
        /// </summary>
        /// <returns>FALSE --> se a etiqueta for encontrada na list
        ///          TRUE --> se a etiqueta ainda não foii lida.
        /// </returns>
        public static bool validaEtiquetaNaoLida(Etiqueta objEtiqueta, List<Etiqueta> listEtiquetas)
        {
            //Verifica se o List foi iniciado
            if (listEtiquetas != null)
            {
                if (listEtiquetas.Count == 0)
                {
                    return true;
                }
                else
                {
                    //Verifica se a etiqueta está na lista de etiquetas lidas.
                    if (Etiqueta.validarEtiqueta(objEtiqueta, listEtiquetas))
                    {
                        //Caso esteja na lista
                        return false;
                    }
                    else
                    {
                        //caso não esteja na lista.
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
         /// Gera etiquetas para testes.
         /// </summary>
        public static void gerarEtiquetas()
        {
            Etiqueta objEtiqueta;
            List<Etiqueta> list = new List<Etiqueta>();

            ProximaEtiqueta = 0;
            list.Add(new Etiqueta("8031", "Chicote Soquete luz", 7895479042576, "LT-10051", Convert.ToInt32("12349"), 25));
            for (int i = 1; i <= 8; i++)
            {
                if (i < 5)
                {
                    objEtiqueta = new Etiqueta("8031", "Chicote Soquete luz", 7895479042575, "LT-10051", Convert.ToInt32("1234" + i), 50);
                }
                else 
                {
                    objEtiqueta = new Etiqueta("7085", "Soquete pisca dianteiro lateral", 7895479000995, "LT-27796", Convert.ToInt32("1234" + (i - 4)), 100);
                }
                
                list.Add(objEtiqueta);
                objEtiqueta = null;
            }

            list.Add(new Etiqueta("8030", "Chicote Soquete luz", 7895479042576, "LT-10051", Convert.ToInt32("12340"), 25));
            ListEtiquetasGeradas = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="tbProduto"></param>
        /// <param name="tblote"></param>
        /// <param name="tbSequencia"></param>
        /// <param name="tbQuantidade"></param>
        /// <param name="tbMensagem"></param>
        public static void lerEtiqueta(ProdutoProposta produto,TextBox tbProduto,TextBox tblote,TextBox tbSequencia,TextBox tbQuantidade,TextBox tbMensagem)
        {
            tbMensagem.Text = "";

            if (ProximaEtiqueta <= ListEtiquetasGeradas.Count - 1)
            {
                ArrayStringToEtiqueta = FileUtility.arrayOfTextFile(ListEtiquetasGeradas[ProximaEtiqueta].ToString(), FileUtility.splitType.PIPE);
                Etiqueta objEtiqueta = new Etiqueta();
                objEtiqueta = Etiqueta.arrayToEtiqueta(ArrayStringToEtiqueta);
                efetuaLeituraEtiqueta(produto,tbProduto,tblote,tbSequencia,tbQuantidade,tbMensagem,objEtiqueta);
                
            }
            else
            {
                tbMensagem.Text = "Próximo Item.";
            }
        }

        public static void lerEtiqueta(String inputValue,ProdutoProposta produto, TextBox tbProduto, TextBox tblote, TextBox tbSequencia, TextBox tbQuantidade, TextBox tbMensagem)
        {
            tbMensagem.Text = "";

            ArrayStringToEtiqueta = FileUtility.arrayOfTextFile(inputValue, FileUtility.splitType.PIPE);
            Etiqueta objEtiqueta = new Etiqueta();
            objEtiqueta = Etiqueta.arrayToEtiqueta(ArrayStringToEtiqueta);
            efetuaLeituraEtiqueta(produto, tbProduto, tblote, tbSequencia, tbQuantidade, tbMensagem, objEtiqueta);
        }

        public static void lerEtiqueta(ProdutoProposta produto,TextBox tbProduto, TextBox tblote, TextBox tbSequencia, TextBox tbQuantidade, TextBox tbMensagem, Array arrayEtiqueta)
        {
            tbMensagem.Text = "";

            if (ProximaEtiqueta  <= ListEtiquetasGeradas.Count - 1)
            {
                arrayEtiqueta = FileUtility.arrayOfTextFile(ListEtiquetasGeradas[ProximaEtiqueta].ToString(), FileUtility.splitType.PIPE);
                Etiqueta objEtiqueta = new Etiqueta();
                objEtiqueta = Etiqueta.arrayToEtiqueta(arrayEtiqueta);
                efetuaLeituraEtiqueta(produto,tbProduto, tblote, tbSequencia, tbQuantidade, tbMensagem, objEtiqueta);
            }
            else
            {
                tbMensagem.Text = "Próximo Item.";
            }
        }

        public static void efetuaLeituraEtiqueta(ProdutoProposta produto,TextBox tbProduto,TextBox tbLote,TextBox tbSequencia,TextBox tbQuantidade,
                                                 TextBox tbMensagem,Etiqueta objEtiqueta)
        {
            try
            {
                if (comparaProdutoEtiquetaProdutoTrabalhado(produto, objEtiqueta))
                {
                    if (validaEtiquetaNaoLida(objEtiqueta))
                    {
                        if (QtdPecasItem > 0)
                        {
                            tbProduto.Text = objEtiqueta.PartnumberEtiqueta.ToString() + " - " + objEtiqueta.DescricaoProdutoEtiqueta.ToString();
                            tbLote.Text = objEtiqueta.LoteEtiqueta;
                            tbSequencia.Text = objEtiqueta.SequenciaEtiqueta.ToString();
                            tbQuantidade.Text = (subtrairQtdPecasItem(objEtiqueta.QuantidadeEtiqueta)).ToString();
                            objEtiqueta.VolumeEtiqueta = ProcedimentosLiberacao.qtdVolumes;
                            addToListEtiquetasLidas(objEtiqueta);
                        }
                    }
                    else
                    {
                        tbMensagem.Text = String.Format("A etiqueta {0} já foi validada.", objEtiqueta.SequenciaEtiqueta);
                        ProximaEtiqueta += 1;
                    }
                }
                else
                {
                    tbMensagem.Text = String.Format("Produto da Etiqueta {0} não pertence a está proposta.", objEtiqueta.SequenciaEtiqueta);
                    ProximaEtiqueta += 1;
                }

            }
            catch ( QuantidadeInvalidaException qtdEx)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("A quantidade de peças desta etiqueta difere com a quantidade de peças do Item.");
                sb.AppendFormat("error : {0} ", qtdEx.Message);
                MainConfig.errorMessage(sb.ToString(),"Etiqueta Inválida!!");

            }
            catch (Exception)
            {
                
                throw;
            }   
        }

        /// <summary>
         /// Verifica se  Produto trabalhado e Produto Etiqueta são os mesmos.
         /// </summary>
         /// <param name="propostaProduto">Obj Produto que será verificado </param>
         /// <param name="etiquetaLida"> Obj Etiqueta que será verificado </param>
         /// <returns>True --> Caso sejam iguais.</returns>
        public static bool comparaProdutoEtiquetaProdutoTrabalhado(ProdutoProposta produtoProposta,Etiqueta etiquetaLida)
        {
            //Verifica se os produtos são iguais
            if (produtoProposta.Partnumber == etiquetaLida.PartnumberEtiqueta)
            {
                if (Convert.ToInt64(produtoProposta.Ean13) == etiquetaLida.Ean13Etiqueta)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
         /// Adiciona uma atiqueta a List Etiquetas Lidas.
         /// </summary>
         /// <param name="etiquetaLida"></param>
        public static void addToListEtiquetasLidas(Etiqueta etiquetaLida)
        {
            EtiquetasLidas.Add(etiquetaLida);
        }

        /// <summary>
        /// Limpa a list de Etiquetas Lidas.
        /// </summary>
        public static void clearListEtiquetasLidas() 
        {
            EtiquetasLidas.Clear();
            EtiquetasLidas = null;
            EtiquetasLidas = new List<Etiqueta>();
        }

        ///<summary>
         ///Altera o valor do atributo auxiliar que armazena informações sobre a quantidade de Pecas
         ///</summary>
         ///<param name="qtd">quantidade a ser diminuida</param>
         ///<returns>Retorna true caso não ocorra erros
         ///         false se o calculo não ocorrer com esperado.</returns>
        public static  Boolean decrementaQtdTotalPecas(double qtd)
        {
            try
            {
                if (ProcedimentosLiberacao.TotalPecas > 0 && (ProcedimentosLiberacao.TotalPecas - qtd >= 0))
                {
                    ProcedimentosLiberacao.TotalPecas -= qtd;
                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new QuantidadeInvalidaException();
            }
        }

        /// <summary>
        /// Altera o valor do atributo auxiliar que armazena informações sobre a quantidade de Itens
        /// </summary>
        /// <param name="qtd">quantidade a ser diminuida</param>
        /// <returns>Retorna true caso não ocorra erros
        ///          false se o calculo não ocorrer com esperado.</returns>
        public static Boolean decrementaQtdTotalItens(double qtd )
        {
            try
            {
                if (ProcedimentosLiberacao.TotalItens > 0 && (ProcedimentosLiberacao.TotalItens - qtd >= 0))
                {
                    ProcedimentosLiberacao.TotalItens -= qtd;
                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new QuantidadeInvalidaException();
            }
        }

        /// <summary>
        /// Altera o status do produto para separado.
        /// </summary>
        /// <param name="item">item que tera o seu status alterado.</param>
        public static void setStatusProdutoParaSeparado(ProdutoProposta item)
        {

            if (item.StatusSeparado == ProdutoProposta.statusSeparado.SEPARADO)
            {
                return;
            }
            else
            {
                item.alteraStatusSeparado();
            }    

        }

        /// <summary>
         /// Verifica o formato da string bate com o formato esperado para a etiqueta.
         /// </summary>
         /// <param name="inputValue">String a ser verificada.</param>
         /// <returns>True caso seja válido do contrário retorna false.</returns>
        public static bool validaInputValueEtiqueta(String inputValue)
        {
            bool resposta = false;
            if (inputValue.Contains("PNUMBER:"))
            {
                if (inputValue.Contains("DESCRICAO:"))
                {
                    if (inputValue.Contains("EAN13:"))
                    {
                        if (inputValue.Contains("LOTE:"))
                        {
                            if (inputValue.Contains("SEQ:"))
                            {
                                if (inputValue.Contains("QTD:"))
                                {
                                    resposta = true;
                                }
                                else
                                {
                                    resposta = false;
                                }
                            }
                            else
                            {
                                resposta = false;
                            }
                        }
                        else
                        {
                            resposta = false;
                        }
                    }
                    else
                    {
                        resposta = false;
                    }
                }
                else
                {
                    resposta = false;
                }
            }
            else
            {
                resposta = false;
            }

            return resposta;
        }

        /// <summary>
        /// Valida a quantidade de volumes existentes e decrementa 1 se caso for possível.
        /// </summary>
        /// <returns>String com a quantidade restante, ou uma mensagem informando que não foi possível realizar a alteração.</returns>
        public static String decrementaVolume() 
        {
            if (QtdVolumes > 1)
            {
                String teste = QtdVolumes.ToString();
                --QtdVolumes;
                return QtdVolumes.ToString();
            }
            return "Qtd Volumes não pode ser menor que 1.";
        }

         /// <summary>
         /// Encrementa mais 1 a quantidade de volumes atual.
         /// </summary>
         /// <returns>String com a quantidade de volumes após a alteração
         /// </returns>
        public static String incrementaVolume() 
        {
            String teste = QtdVolumes.ToString();
            ++QtdVolumes;
            return QtdVolumes.ToString();
        }
    }
}
