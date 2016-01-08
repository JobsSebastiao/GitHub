using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new EntidadesContext();
            contexto.Database.CreateIfNotExists();
            Usuario victor = new Usuario { Nome = "Victor" };
            contexto.Usuarios.Add(victor);
            contexto.SaveChanges();
            contexto.Dispose();
        }
    }
}


