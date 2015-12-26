using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    class ContaPoupanca : Conta,ITributavel
    {
        public ContaPoupanca()
        {
           
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.02;
        }

        public override void saca(double valorSaque)
        {
            base.saca(valorSaque + 0.10);
        }
        
    }
}
