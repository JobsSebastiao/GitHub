﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{
    class Etiqueta
    {
        private string partnumber;
        private string descricaoProduto;
        private Int64 ean13;
        private String lote;
        private Int32 sequencia;
        private Double quantidade;

    #region "CONTRUTORES"
        public Etiqueta() { }

        public Etiqueta(String partnumber,String descricao,Int64 ean13,String lote,Int32 sequencia,Double quantidade) 
        {
            PartnumberEtiqueta = partnumber;
            DescricaoProdutoEtiqueta = descricao;
            Ean13Etiqueta = ean13;
            LoteEtiqueta = lote;
            SequenciaEtiqueta = sequencia;
            QuantidadeEtiqueta = quantidade;
        }

        /// <summary>
        /// Contrutor recebe um array com os valores a serem passados para cada atributo do objEtiqueta;
        /// </summary>
        /// <param name="arrayEtiqueta">Array no seguite formato 
        ///                             "EAN13:?|LOTE:?|SEQ:?|QTD:?"
        /// </param>
        public Etiqueta(Array arrayEtiqueta) 
        {
            foreach (string item in arrayEtiqueta)
            {
                string strItem = item.Substring(0, item.IndexOf(":", 0));

                if (strItem == "PNUMBER")
                {
                    PartnumberEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "DESCRICAO")
                {
                    DescricaoProdutoEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "EAN13")
                {
                    Ean13Etiqueta  = Convert.ToInt64(item.Substring(item.IndexOf(":", 0) + 1));
                }
                else if (strItem == "LOTE")
                {
                    LoteEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "SEQ")
                {
                    SequenciaEtiqueta = Convert.ToInt32(item.Substring(item.IndexOf(":", 0) + 1));
                }
                else if (strItem == "QTD")
                {
                   QuantidadeEtiqueta = Convert.ToDouble(item.Substring(item.IndexOf(":", 0) + 1));
                }

            }
        }

    #endregion

    #region "GET E SETS "

        public Int64 Ean13Etiqueta
        {
            get { return ean13; }
            set { ean13 = value; }
        }

        public String LoteEtiqueta
        {
            get { return lote; }
            set { lote = value; }
        }

        public Int32 SequenciaEtiqueta
        {
            get { return sequencia; }
            set { sequencia = value; }
        }

        public Double QuantidadeEtiqueta
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public string PartnumberEtiqueta
        {
            get { return partnumber; }
            set { partnumber = value; }
        }

        public string DescricaoProdutoEtiqueta
        {
            get { return descricaoProduto; }
            set { descricaoProduto = value; }
        }


    #endregion


        /// <summary>
        /// Recebe um array de strings referentes aos atributos do obj Etiqueta.
        /// retorna Um objeto do tipo Etiqueta
        /// </summary>
        /// <param name="array">Array de String referentes aos atributos de uma etiqueta</param>
        public static Etiqueta arrayToEtiqueta(Array array)
        {
            Etiqueta objEtiqueta = new Etiqueta();

            foreach (string item in array)
            {
                string strItem = item.Substring(0, item.IndexOf(":", 0));

                if (strItem == "PNUMBER")
                {
                    objEtiqueta.PartnumberEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "DESCRICAO")
                {
                    objEtiqueta.DescricaoProdutoEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "EAN13")
                {
                    objEtiqueta.Ean13Etiqueta = Convert.ToInt64(item.Substring(item.IndexOf(":", 0) + 1));
                }
                else if (strItem == "LOTE")
                {
                    objEtiqueta.LoteEtiqueta = item.Substring(item.IndexOf(":", 0) + 1);
                }
                else if (strItem == "SEQ")
                {
                    objEtiqueta.SequenciaEtiqueta = Convert.ToInt32(item.Substring(item.IndexOf(":", 0) + 1));
                }
                else if (strItem == "QTD")
                {
                    objEtiqueta.QuantidadeEtiqueta = Convert.ToDouble(item.Substring(item.IndexOf(":", 0) + 1));
                }
            }
            return objEtiqueta;
        }

        //Verifica se já existe um determinado Objeto Etiqueta em um list.
        public static bool validarEtiqueta(Etiqueta etiqueta,List<Etiqueta> listEtiquetas) 
        {
             foreach( Etiqueta itemList in listEtiquetas.ToList<Etiqueta>())
             {
                 if(etiqueta.Equals(itemList))
                 {
                     return false;
                 }
             }
             return true;
        }

        public override bool Equals(object obj)
        {
            System.Type type = obj.GetType();

            if (obj == null || (type != typeof(Etiqueta)))
            {
                return false;
            }
            else
            {
                return (Ean13Etiqueta == ((Etiqueta)obj).Ean13Etiqueta && SequenciaEtiqueta == ((Etiqueta)obj).SequenciaEtiqueta);
            }

        }

        public override string ToString()
        {
            return String.Format("PNUMBER:{0}|DESCRICAO:{1}|EAN13:{2}|LOTE:{3}|SEQ:{4}|QTD:{5}",PartnumberEtiqueta,DescricaoProdutoEtiqueta, Ean13Etiqueta, LoteEtiqueta, SequenciaEtiqueta, QuantidadeEtiqueta);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}