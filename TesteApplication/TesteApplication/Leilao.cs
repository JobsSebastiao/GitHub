using System.Collections;

namespace TesteApplication
{
    public class Leilao
    {
        public string Objeto { get; }
        public ArrayList Lances { get; }

        public Leilao(string objeto)
        {
            this.Lances = new ArrayList();
            this.Objeto = objeto;
        }


        public void Propoe(Lance lance)
        {
            this.Lances.Add(lance);
        }
    }
}