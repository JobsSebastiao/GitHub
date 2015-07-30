using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{
    class Produto
    {
        private Int32 codigoProduto;
        private String ean13;
        private String partnumber;
        private String descricao;
        private Int32 codigoLocalLote;
        private String nomeLocalLote;


        public Produto(Int32 codigo,String ean13,String partnumber,String descricao,Int32 codigoLocalLote,String nomeLocalLote)
        {
            CodigoProduto = codigo;
            Ean13 = ean13;
            Partnumber = partnumber;
            Descricao = descricao;
            CodigoLocalLote = codigoLocalLote;
            NomeLocalLote = nomeLocalLote;

        }


        public Produto()
        {

        }


        public Int32 CodigoProduto
        {
            get { return codigoProduto; }
            set { codigoProduto = value; }
        }

        public String Ean13
        {
            get { return ean13; }
            set { ean13 = value; }
        }

        public String Partnumber
        {
            get { return partnumber; }
            set { partnumber = value; }
        }
        
        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public Int32 CodigoLocalLote
        {
          get { return codigoLocalLote; }
          set { codigoLocalLote = value; }
        }
        
        public String NomeLocalLote
        {
          get { return nomeLocalLote; }
          set { nomeLocalLote = value; }
        }

        public override string ToString()
        {
            return String.Format("Código : {0} \n Ean13 : {1} \n PartNumber : {2} \n Descricão : {3} \n Código Local : {4} \n NomeLocalLote : {5}",
                                  this.CodigoProduto,this.Ean13,this.Partnumber,this.Descricao,this.CodigoLocalLote, this.NomeLocalLote);
        }
    }
}
