using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    class TotalizadorDeContas
    {

        public double SaldoTotal { get; private set; }

        public void Adiciona(Conta c)
        {
            this.SaldoTotal += c.Saldo;
        }

        public void teste()
        {
            TotalizadorDeContas totalizador = new TotalizadorDeContas();
            Conta c = new Conta();
            totalizador.Adiciona(c);
        }
    }
}
