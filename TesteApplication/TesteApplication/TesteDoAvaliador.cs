using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    class TesteDoAvaliador
    {
        static void Main(string[] args)
        {
            Usuario joao = new Usuario("João");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("playStation 3");

            double maiorEsperado = 400d;
            double menorEsperado = 250d;

            leilao.Propoe(new Lance(joao, 300.00));
            leilao.Propoe(new Lance(jose, 400.00));
            leilao.Propoe(new Lance(maria, 250.00));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Console.WriteLine(maiorEsperado == leiloeiro.MaiorLance);
            Console.WriteLine(menorEsperado == leiloeiro.MenorLance);

            Console.ReadKey();
        }
    }
}
