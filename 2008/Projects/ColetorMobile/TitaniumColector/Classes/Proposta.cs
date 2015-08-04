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
        private Double totalItens;
        private Double totalpecas;
        private statusOrdemSeparacao ordemSeparacao;
        private List<ProdutoProposta> listItemProposta;



    #region "CONTRUTORES" 

        public Proposta() 
        { }

        /// <summary>
        /// Instância um Obj Proposta
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da proposta</param>
        /// <param name="dataLiberacaoProposta">Data liberação Proposta</param>
        /// <param name="codigoCliente">Código cliente Proposta</param>
        /// <param name="razaoCliente">Razão cliente Proposta</param>
        /// <param name="statusOrdemSeparacao">Status de Ordem separação Proposta</param>
        public Proposta(Int64 codigoProposta, string numeroProposta, string dataLiberacaoProposta, int codigoCliente,
                        string razaoCliente)
        {
            this.Codigo = codigoProposta;
            this.Numero = numeroProposta;
            this.DataLiberacao = dataLiberacaoProposta;
            this.CodigoCliente = codigoCliente;
            this.RazaoCliente = razaoCliente;
        }

        /// <summary>
        /// Instância um Obj Proposta
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da proposta</param>
        /// <param name="dataLiberacaoProposta">Data liberação Proposta</param>
        /// <param name="codigoCliente">Código cliente Proposta</param>
        /// <param name="razaoCliente">Razão cliente Proposta</param>
        /// <param name="statusOrdemSeparacao">Status de Ordem separação Proposta</param>
        public Proposta(Int64 codigoProposta,string numeroProposta,string dataLiberacaoProposta,int codigoCliente,
                        string razaoCliente,statusOrdemSeparacao statusOrdemSeparacao)
        {
            this.Codigo = codigoProposta;
            this.Numero = numeroProposta;
            this.DataLiberacao = dataLiberacaoProposta;
            this.CodigoCliente = codigoCliente;
            this.RazaoCliente = razaoCliente;
            this.StatusOrdemSeparacao = statusOrdemSeparacao;
        }


        /// <summary>
        /// Instância um Obj Proposta
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da proposta</param>
        /// <param name="dataLiberacaoProposta">Data liberação Proposta</param>
        /// <param name="codigoCliente">Código cliente Proposta</param>
        /// <param name="razaoCliente">Razão cliente Proposta</param>
        /// <param name="statusOrdemSeparacao">Status de Ordem separação Proposta</param>
        /// <param name="totalItensProposta">Total de itens na Proposta</param>
        /// <param name="totalPecasProposta">Total de Pecas na Proposta</param>
        public Proposta(Int64 codigoProposta, string numeroProposta, string dataLiberacaoProposta, int codigoCliente,
                        string razaoCliente, statusOrdemSeparacao statusOrdemSeparacao,Double totalItensProposta,Double totalPecasProposta)
        {
            this.Codigo = codigoProposta;
            this.Numero = numeroProposta;
            this.DataLiberacao = dataLiberacaoProposta;
            this.CodigoCliente = codigoCliente;
            this.RazaoCliente = razaoCliente;
            this.StatusOrdemSeparacao = statusOrdemSeparacao;
            this.Totalpecas = totalPecasProposta;
            this.TotalItens = totalItensProposta;
        }

        /// <summary>
        /// Recebe outro obj do tipo Proposta e set os parâmetros para a nova instância a ser criada.
        /// </summary>
        /// <param name="obj"></param>
        public Proposta(Object obj,List<ProdutoProposta> listItens)
        {
            if (obj.GetType() == typeof(Proposta))
            {

                this.Codigo = ((Proposta)obj).Codigo;
                this.Numero = ((Proposta)obj).Numero;
                this.DataLiberacao = ((Proposta)obj).DataLiberacao;
                this.CodigoCliente = ((Proposta)obj).CodigoCliente;
                this.RazaoCliente = ((Proposta)obj).RazaoCliente;
                this.StatusOrdemSeparacao = ((Proposta)obj).StatusOrdemSeparacao;
                this.ListObjItemProposta = listItens;
            }

        }


        /// <summary>
        /// Instância um Obj Proposta recebendo um List do tipo ProdutoProposta
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da proposta</param>
        /// <param name="dataLiberacaoProposta">Data liberação Proposta</param>
        /// <param name="codigoCliente">Código cliente Proposta</param>
        /// <param name="razaoCliente">Razão cliente Proposta</param>
        /// <param name="statusOrdemSeparacao">Status de Ordem separação Proposta</param>
        /// <param name="listItemProposta">List de objetos do tipo ProdutoProposta</param>
        public Proposta(Int64 codigoProposta, string numeroProposta, string dataLiberacaoProposta, int codigoCliente,
                string razaoCliente, statusOrdemSeparacao statusOrdemSeparacao,List<ProdutoProposta> listItemProposta)
        {
            this.Codigo = codigoProposta;
            this.Numero = numeroProposta;
            this.DataLiberacao = dataLiberacaoProposta;
            this.CodigoCliente = codigoCliente;
            this.RazaoCliente = razaoCliente;
            this.StatusOrdemSeparacao = statusOrdemSeparacao;
            this.ListObjItemProposta = listItemProposta;

        } 

    #endregion

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

        internal List<ProdutoProposta> ListObjItemProposta
        {
            get { return listItemProposta; }
            set { listItemProposta = value; }
        }

        public Double TotalItens
        {
            get { return totalItens; }
            set { totalItens = value; }
        }

        public Double Totalpecas
        {
            get { return totalpecas; }
            set { totalpecas = value; }
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
                   "\n StatusOrdemSeparação : " + StatusOrdemSeparacao +
                   "\n Quantidade de Itens : " + ListObjItemProposta.Count();
        }
    }
}
