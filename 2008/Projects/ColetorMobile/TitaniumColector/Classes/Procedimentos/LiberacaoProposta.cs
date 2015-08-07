using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Utility;
using TitaniumColector.Classes.Exceptions;

namespace TitaniumColector.Classes.Procedimentos
{
     static class ProcedimentosLiberacao
    {

        private static Double totalItens;
        private static Double totalPecas;
        private static Double qtdPecasItem;
        private static Int32 proximaEtiqueta;
        private static List<Etiqueta> listEtiquetasLidas;
        private static List<Etiqueta> listEtiquetas;
        private static Array arrayStringToEtiqueta;

        public static void inicializarProcedimentos(Double tItens, Double tPecas, Double pecasItens)
        {
            TotalItens = tItens;
            TotalPecas = tPecas;
            qtdPecasItem = pecasItens;
            listEtiquetasLidas = new List<Etiqueta>();
            ProximaEtiqueta = 0;
            ListEtiquetasGeradas = null;
            arrayStringToEtiqueta = null;
        }

        public static Double TotalPecas
        {
            get { return totalPecas; }
            set { totalPecas = value; }
        }

        public static Double QtdPecasItem
        {
            get { return qtdPecasItem; }
 
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
                objEtiqueta = new Etiqueta("8031", "Chicote Soquete luz", 7895479042575, "LT-10051", Convert.ToInt32("1234" + i), 50);
                list.Add(objEtiqueta);
                objEtiqueta = null;
            }

            list.Add(new Etiqueta("8030", "Chicote Soquete luz", 7895479042576, "LT-10051", Convert.ToInt32("12340"), 25));
            ListEtiquetasGeradas = list;
        }


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

                            addToListEtiquetasLidas(objEtiqueta);
                            ProximaEtiqueta += 1;
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

    }
}
