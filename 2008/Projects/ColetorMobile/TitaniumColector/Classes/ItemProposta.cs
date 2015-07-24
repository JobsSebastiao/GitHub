using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{
    class ItemProposta
    {
        private int codigo;
        private int propostaItemProposta;
        private string nomeProduto;
        private string partNumber;
        private string ean13;
        private int produtoReserva;
        private double quantidade;
        private statusSeparado separado;
       

        public enum statusSeparado { NAOSEPARADO = 0, SEPARADO = 1 };

        public ItemProposta() 
        {

        }

        public ItemProposta(int codigo,int propostaItemproposta,string nomeProduto,string partnumber,string ean13,int produtoReserva,double quantidade,statusSeparado isSeparado) 
        {
            Codigo = codigo;
            PropostaItemProposta = propostaItemproposta;
            NomeProduto = nomeProduto;
            PartNumber = partnumber;
            Ean13 = ean13;
            ProdutoReserva = produtoReserva;
            Quantidade = quantidade;
            Separado = Separado;
        }


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public int PropostaItemProposta
        {
            get { return propostaItemProposta; }
            set { propostaItemProposta = value; }
        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value; }
        }

        public string Ean13
        {
            get { return ean13; }
            set 
            {
                ean13 = value.Trim() != "" ? value : "N/D"; 
            }
        }

        public int ProdutoReserva
        {
            get { return produtoReserva; }
            set { produtoReserva = value; }
        }
        
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        internal statusSeparado Separado
        {
            get { return separado; }
            set { separado = value; }
        }    
    }
}
