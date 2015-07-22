using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{

    class Proposta
    {
        private Int64 codigo;
        private Int64 numero;
        private string dataLiberacao;
        private statusOrdemSeparacao ordemSeparacao;

        enum statusOrdemSeparacao 
        {
            NAOIMPRESA = 0,
            IMPRESA = 1
        }

        public Int64 Codigo
        {
            get 
            {
                return codigo; 
            }
            set 
            { 
                codigo = value; 
            }
        }

        public Int64 Numero
        {
            get 
            { 
                return numero; 
            }
            set 
            { 
                numero = value; 
            }
        }

        public string DataLiberacao
        {
            get 
            { 
                return dataLiberacao; 
            }
            set 
            { 
                dataLiberacao = value; 
            }
        }

        private statusOrdemSeparacao StatusOrdemSeparacao
        {
            get 
            { 
                return ordemSeparacao; 
            }
            set 
            { 
                ordemSeparacao = value;
            }
        }
    }
}
