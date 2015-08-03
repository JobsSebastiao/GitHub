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
        private Int64 codigoLoteProduto;
        private String identificacaoLoteProduto;
        private Int32 codigoLocalProduto;
        private String nomeLocalProduto;


        /// <summary>
        /// Construtor onde alguns atributos não são setados duarante a intancia da classe.
        /// </summary>
        /// <param name="codigo">Código do produto</param>
        /// <param name="ean13">Ean13 do produto</param>
        /// <param name="partnumber">`Partnumber do Produto</param>
        /// <param name="descricao">DEscrição (NOME) do produto</param>
        /// <param name="codigoLocalLote">Código do local oonde está armazenado este produto.</param>
        /// <param name="nomeLocalLote">Nome(identificação) do local de armazenagem do produto</param>
        public Produto(Int32 codigo,String ean13,String partnumber,String descricao,Int32 codigoLocalLote,String nomeLocalLote)
        {
            CodigoProduto = codigo;
            Ean13 = ean13;
            Partnumber = partnumber;
            Descricao = descricao;
            CodigoLocalLote = codigoLocalLote;
            NomeLocalLote = nomeLocalLote;

        }

        /// <summary>
        /// Inclui ao contrutor valores para os atributos CodigoLoteProduto e IdentificacaoLoteProduto
        /// </summary>
        /// <param name="codigo">Código do produto</param>
        /// <param name="ean13">Ean13 do produto</param>
        /// <param name="partnumber">`Partnumber do Produto</param>
        /// <param name="descricao">DEscrição (NOME) do produto</param>
        /// <param name="codigoLocalLote">Código do local oonde está armazenado este produto.</param>
        /// <param name="nomeLocalLote">Nome(identificação) do local de armazenagem do produto</param>
        /// <param name="codLoteProd">Código do lote do produto</param>
        /// <param name="identificacaoLoteProd">Identificação do Lote do produto</param>
        public Produto(Int32 codigo, String ean13, String partnumber, String descricao, Int32 codigoLocalLote, String nomeLocalLote,Int64 codLoteProd,String identificacaoLoteProd)
        {
            CodigoProduto = codigo;
            Ean13 = ean13;
            Partnumber = partnumber;
            Descricao = descricao;
            CodigoLocalLote = codigoLocalLote;
            NomeLocalLote = nomeLocalLote;
            CodigoLoteProduto = codLoteProd;
            IdentificacaoLoteProduto = identificacaoLoteProd;

        }

        /// <summary>
        /// Recebe outro objeto do tipo Produto e seta seus valores para a nova instância do objeto.
        /// </summary>
        /// <param name="obj">Objeto do tipo Produto</param>
        public Produto(Object obj)
        {
            if (obj.GetType() != typeof(Produto))
            {
                CodigoProduto = ((Produto)obj).CodigoProduto;
                Ean13 = ((Produto)obj).Ean13;
                Partnumber = ((Produto)obj).Partnumber;
                Descricao = ((Produto)obj).Descricao ;
                CodigoLocalLote = ((Produto)obj).CodigoLocalLote;
                NomeLocalLote = ((Produto)obj).NomeLocalLote;
                CodigoLoteProduto = ((Produto)obj).CodigoLoteProduto;
                IdentificacaoLoteProduto = ((Produto)obj).IdentificacaoLoteProduto;
            }
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

        public Int64 CodigoLoteProduto
        {
            get { return codigoLoteProduto; }
            set { codigoLoteProduto = value; }
        }

        public String IdentificacaoLoteProduto
        {
            get { return identificacaoLoteProduto; }
            set { identificacaoLoteProduto = value; }
        }
        public Int32 CodigoLocalLote
        {
          get { return codigoLocalProduto; }
          set { codigoLocalProduto = value; }
        }
        
        public String NomeLocalLote
        {
          get { return nomeLocalProduto; }
          set { nomeLocalProduto = value; }
        }

        public override string ToString()
        {
            return String.Format(" Código : {0} \n Ean13 : {1} \n PartNumber : {2} \n Descricão : {3} \n Código Local : {4} \n NomeLocalLote : {5} \n Código Lote : {6} \n Identificação Lote : {7} ",
                                  this.CodigoProduto,this.Ean13,this.Partnumber,this.Descricao,this.CodigoLocalLote, this.NomeLocalLote,this.CodigoLoteProduto,this.IdentificacaoLoteProduto);
        }
    }
}
