using EntityFrameeWorkProject.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            EntidadesContext contexto = new EntidadesContext();
            contexto.Database.CreateIfNotExists();
            Usuario usuario = new Usuario() { Nome= "Sebastião" , Senha="Martins"};
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
            contexto.Dispose();
        }
    }
}
