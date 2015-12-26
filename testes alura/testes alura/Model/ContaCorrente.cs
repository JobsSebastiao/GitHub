using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    class ContaCorrente : Conta
    {

        public ContaCorrente()
        {
        }
        public override void saca(double valorSaque)
        {
             base.saca(valorSaque + 0.03);
        }

    }
}
