using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    public class GerenciadorDeImposto
    {
        public double Total { get; private set; }


        public void Adiciona(ITributavel tributavel)
        {
            this.Total += tributavel.CalculaTributos();
        }

        public double CalculaTributos()
        {
            throw new NotImplementedException();
        }
    }
}
