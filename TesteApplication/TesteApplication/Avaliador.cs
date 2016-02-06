using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class Avaliador
    {
        private double maiordeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double valorMedio = Double.MinValue;
        private List<Lance> maiores;
       
        public void Avalia(Leilao leilao)
        {
            var sumValores = 0d;

            if (leilao.Lances.Count == 0)
            {
                throw new ArgumentNullException("O leilão não possui lances");
            }

            foreach (Lance lance in leilao.Lances)
            {
                if (lance.ValorLance <= 0 )
                {
                    throw new ArgumentException("O valor do lance deve ser maior que 0");
                }

                if (lance.ValorLance > maiordeTodos)
                {
                    this.MaiorLance = lance.ValorLance;
                }

                if (lance.ValorLance < this.menorDeTodos)
                {
                    this.MenorLance = lance.ValorLance;
                }

                sumValores += lance.ValorLance;

                PegaMaioresLances(leilao);

            }

            ValorMedio = sumValores / leilao.Lances.Count;

        }

        public void PegaMaioresLances(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.ValorLance));
            maiores = maiores.GetRange(0, leilao.Lances.Count >= 3 ? 3 : leilao.Lances.Count);
        }

        public IList<Lance> TresMaiores
        {
            get { return this.maiores; }
        }

        public double MaiorLance
        {
            get { return this.maiordeTodos;}
            private set { this.maiordeTodos = value; }
        }

        public double MenorLance
        {
            get { return this.menorDeTodos;}
            private set { this.menorDeTodos = value; }
        }

        public double ValorMedio
        {
            get { return this.valorMedio; }
            private set { this.valorMedio = (value > 0 ? value : 0); }
        }
    }

   

    public class Program
    {
        public static void Main()
        {

        }
    }

}
