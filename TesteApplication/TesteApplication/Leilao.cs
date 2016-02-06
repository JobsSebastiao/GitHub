using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TesteApplication
{
    public class Leilao
    {
        public string Objeto { get; }
        public List<Lance> Lances { get; }
        public DateTime dataInicio { get;  private set;}
        public bool encerrado { get; set; }

        public Leilao(string objeto)
        {
            this.Lances = new List<Lance>();
            this.Objeto = objeto;
        }

        public Leilao(string objeto,DateTime dataInicio)
        {
            this.Lances = new List<Lance>();
            this.Objeto = objeto;
            this.dataInicio = dataInicio; 
        }


        public void Propoe(Lance lance)
        {
            if (PodeDarLance(lance.Usuario))
            {
                this.Lances.Add(lance);
            }
        }


        private Usuario UsuarioUltimoLance()
        {
            return Lances.Count > 0 ? Lances[Lances.Count - 1].Usuario: null;       
        }

        internal void Encerra()
        {
            this.encerrado = true;
        }

        public int TotalLances(Usuario usuario)
        {
            var total = 0;

            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario))
                {
                    total++;
                }
            }
            return total;
        }


        public bool PodeDarLance(Usuario usuario)
        {
            return Lances.Count == 0 || (!UsuarioUltimoLance().Equals(usuario)) && (TotalLances(usuario) < 5);
        }

        public void DobraLance(Usuario usuario)
        {
            var ultimoLance = UltimoLanceUsuario(usuario).GetValueOrDefault(0d);

            if (ultimoLance > 0d)
            {
                this.Propoe(new Lance(usuario, ultimoLance * 2));
            }
            
        }

        public double? UltimoLanceUsuario(Usuario usuario)
        {
            var lancesUsuario = from l in Lances
                                where l.Usuario.Equals(usuario)
                                select l;


            var lancesFiltrados = lancesUsuario.ToList<Lance>();

            if (lancesFiltrados.Count > 0)
            {
                return lancesFiltrados[lancesFiltrados.Count - 1].ValorLance;
            }

            return null;
        }
    }
}