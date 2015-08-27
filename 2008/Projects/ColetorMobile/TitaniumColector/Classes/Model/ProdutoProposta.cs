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


    #region "CONTRUTORES"

        public ProdutoProposta()
        {

        }

        public ProdutoProposta(Int32 codigoItemProposta, Int32 propostaItemProposta, Double quantidade, statusSeparado isSeparado,
            Int32 codigoProduto, String ean13, String partnumber, String descricao)
            : base(codigoProduto, ean13, partnumber, descricao)
        {
            this.CodigoItemProposta = codigoItemProposta;
            this.PropostaItemProposta = propostaItemProposta;
            this.Quantidade = quantidade;
            this.StatusSeparado = isSeparado;
            this.LotereservaItemProposta = 0;
        }

        public ProdutoProposta(Int32 codigoItemProposta, Int32 propostaItemProposta, Double quantidade, statusSeparado isSeparado, Int32 loteReservaItemProposta,
         Int32 codigoProduto, String ean13, String partnumber, String nomeProduto, String nomeLocalLote, Int32 codigoLoteProduto, String identificacaoLoteProduto)
        : base(codigoProduto, ean13, partnumber, nomeProduto, nomeLocalLote, codigoLoteProduto, identificacaoLoteProduto)
        {
            this.CodigoItemProposta = codigoItemProposta;
            this.PropostaItemProposta = propostaItemProposta;
            this.Quantidade = quantidade;
            this.StatusSeparado = isSeparado;
            this.LotereservaItemProposta = loteReservaItemProposta;
        }

        /// <summary>
        /// Sem informações de LOTE
        /// </summary>
        /// <param name="codigoItemProposta"></param>
        /// <param name="propostaItemProposta"></param>
        /// <param name="quantidade"></param>
        /// <param name="isSeparado"></param>
        /// <param name="loteReservaItemProposta"></param>
        /// <param name="codigoProduto"></param>
        /// <param name="ean13"></param>
        /// <param name="partnumber"></param>
        /// <param name="nomeProduto"></param>
        /// <param name="codigoLocalLote"></param>
        /// <param name="nomeLocalLote"></param>
        public ProdutoProposta(Int32 codigoItemProposta, Int32 propostaItemProposta, Double quantidade, statusSeparado isSeparado, Int32 loteReservaItemProposta,
                       Int32 codigoProduto, String ean13, String partnumber, String nomeProduto, Int32 codigoLocalLote, String nomeLocalLote)
            : base(codigoProduto, ean13, partnumber, nomeProduto, codigoLocalLote, nomeLocalLote)
        {
            this.CodigoItemProposta = codigoItemProposta;
            this.PropostaItemProposta = propostaItemProposta;
            this.Quantidade = quantidade;
            this.StatusSeparado = isSeparado;
            this.LotereservaItemProposta = loteReservaItemProposta;
        }

        public ProdutoProposta(Int32 codigoItemProposta, Int32 propostaItemProposta, Double quantidade, statusSeparado isSeparado, Int32 loteReservaItemProposta,object objProduto)
            : base(objProduto)
        {
            this.CodigoItemProposta = codigoItemProposta;
            this.PropostaItemProposta = propostaItemProposta;
            this.Quantidade = quantidade;
            this.StatusSeparado = isSeparado;
            this.LotereservaItemProposta = loteReservaItemProposta;
        }


    #endregion

    #region"GETS E SETS"

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

    #endregion

        /// <summary>
        /// Altera o statusSeparado do Produto entre SEPARADO e NAOSEPARADO
        /// </summary>
        /// <param name="itemProposta">OBJETO </param>
        public void alteraStatusSeparado()
        {
            if (this.StatusSeparado == statusSeparado.NAOSEPARADO)
            {
                this.StatusSeparado = statusSeparado.SEPARADO;
            }
            else
            {
                this.StatusSeparado = statusSeparado.NAOSEPARADO;
            }  
        }

        /// <summary>
        /// Altera o statusSeparado do Produto entre SEPARADO e NAOSEPARADO
        /// </summary>
        /// <param name="itemProposta">OBJETO DO TIPO PRODUTOPROPOSTA</param>
        public void alteraStatusSeparado(ProdutoProposta itemProposta)
        {
            if (itemProposta.GetType() == typeof(ProdutoProposta))
            {
                if (itemProposta.StatusSeparado == statusSeparado.NAOSEPARADO)
                {
                    itemProposta.StatusSeparado = statusSeparado.SEPARADO;
                }
                else
                {
                    itemProposta.StatusSeparado = statusSeparado.NAOSEPARADO;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("\n Código Item : {0} \n Proposta Item : {1} \n Quantidade : {2} \n Status Separado : {3} \n Lote da Reserva : {4}",
                                                    this.CodigoItemProposta,this.PropostaItemProposta,this.Quantidade,this.StatusSeparado,this.LotereservaItemProposta );
        }
    }
}
