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

        public void Avalia(Leilao leilao)
        {
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.ValorLance > maiordeTodos)
                {
                    this.MaiorLance = lance.ValorLance;
                }
                else if (lance.ValorLance < this.menorDeTodos)
                {
                    this.MenorLance = lance.ValorLance;
                }
            }
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
    }


}
