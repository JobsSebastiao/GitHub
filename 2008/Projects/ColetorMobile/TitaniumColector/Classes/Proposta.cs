using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{

    class Proposta
    {
        private Int64 codigo;
        private string numero;
        private string dataLiberacao;
        private string razaoCliente;
        private int codigoCliente;
        private statusOrdemSeparacao ordemSeparacao;

        public Proposta() 
        { }

        public Proposta(Int64 codigoProposta,string numeroProposta,string dataLiberacaoProposta,int codigoCliente,
                        string razaoCliente,statusOrdemSeparacao statusOrdemSeparacao)
        {
            Codigo = codigoProposta;
            Numero = numeroProposta;
            DataLiberacao  = dataLiberacaoProposta;
            CodigoCliente = codigoCliente;
            RazaoCliente = razaoCliente;
            StatusOrdemSeparacao = statusOrdemSeparacao;
            
        } 

        public enum statusOrdemSeparacao 
        {
            NAOIMPRESA = 0,
            IMPRESA = 1
        }

        public Int64 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string DataLiberacao
        {
            get { return dataLiberacao; }
            set { dataLiberacao = value; }
        }

        public statusOrdemSeparacao StatusOrdemSeparacao
        {
            get{ return ordemSeparacao; }
            set { ordemSeparacao = value; }
        }

        public int CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }

        public string RazaoCliente
        {
            get { return razaoCliente; }
            set { razaoCliente = value; }
        }


        /// <summary>
        /// Altera o status da Ordem de separação Entre Impressa e não Impressa.
        /// </summary>
        /// <param name="proposta"></param>
        public void atualizaStatusOrdemSeparacao(Proposta proposta) 
        {
            if (proposta.GetType() == typeof(Proposta)) 
            {
                if (proposta.StatusOrdemSeparacao == statusOrdemSeparacao.NAOIMPRESA)
                {
                    proposta.StatusOrdemSeparacao = statusOrdemSeparacao.IMPRESA;
                }
                else 
                {
                    proposta.StatusOrdemSeparacao = statusOrdemSeparacao.NAOIMPRESA;
                }
            }
        }

        public override bool Equals(object obj)
        {
            System.Type type = obj.GetType();
            if (obj == null || (type != typeof(Proposta)))
            {
                return false;
            }
            else
            {
                return Codigo == ((Proposta)obj).Codigo;
            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return " Código : " + Codigo +
                   "\n Número : " + Numero +
                   "\n Data Liberação : " + DataLiberacao +
                   "\n Código Cliente : " + CodigoCliente +
                   "\n Razao Cliente : " + RazaoCliente +
                   "\n StatusOrdemSeparação : " + StatusOrdemSeparacao;
        }
    }
}
