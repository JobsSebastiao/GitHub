using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{
    class ProdutoProposta : Produto 
    {
        private int codigoItemProposta;
        private int propostaItemProposta;
        private double quantidade;
        private statusSeparado isSeparado;
        private Int32 lotereservaItemProposta;

        public enum statusSeparado { NAOSEPARADO = 0, SEPARADO = 1 };

        public ProdutoProposta() 
        {

        }

        public ProdutoProposta(Int32 codigoItemProposta, Int32 propostaItemProposta, Double quantidade, statusSeparado isSeparado,Int32 loteReservaItemProposta,
                            Int32 codigoProduto, String ean13, String partnumber, String nomeProduto, Int32 codigoLocalLote, String nomeLocalLote)  
                            : base(codigoProduto,ean13, partnumber, nomeProduto,codigoLocalLote,nomeLocalLote)
        {
            this.CodigoItemProposta = codigoItemProposta;
            this.PropostaItemProposta = propostaItemProposta;
            this.Quantidade = quantidade;
            this.StatusSeparado = isSeparado;
            this.LotereservaItemProposta = loteReservaItemProposta;
        }

        public int CodigoItemProposta
        {
            get { return codigoItemProposta; }
            set { codigoItemProposta = value; }
        }


        public int PropostaItemProposta
        {
            get { return propostaItemProposta; }
            set { propostaItemProposta = value; }
        }
  
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        internal statusSeparado StatusSeparado
        {
            get { return isSeparado; }
            set { isSeparado = value; }
        }

        public Int32 LotereservaItemProposta
        {
            get { return lotereservaItemProposta; }
            set { lotereservaItemProposta = value; }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("\n Código Item : {0} \n Proposta Item : {1} \n Quantidade : {2} \n Status Separado : {3} \n Lote da Reserva : {4}",
                                                    this.CodigoItemProposta,this.PropostaItemProposta,this.Quantidade,this.StatusSeparado,this.LotereservaItemProposta );
        }
    }
}
