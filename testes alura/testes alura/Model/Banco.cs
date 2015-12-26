using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    class Banco
    {
        Conta[] contas = new Conta[10];
        int contador;

        public Banco()
        {
            this.contador=0;
        }


        public void adiciona(Conta conta)
        {
            contas[contador] = conta;
            this.contador++;
        }
    }
}
