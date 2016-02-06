using LojaEF.Migrations.DAO;
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

            //contexto.Database.CreateIfNotExists();
            //Usuario victor = new Usuario { Nome = "Victor" , Senha = 124578,Sobrenome="meu Sobrenome"};
            //contexto.Usuarios.Add(victor);
            //Produto prod01 = new Produto { Nome="Prod0001",Descricao = "produto 0001",Preco = 10.00M };
            //contexto.Produtos.Add(prod01);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario u =  usuarioDAO.buscaPorId(10);
            u.Nome = "Nome Atualizado";
            u.Senha = 1234;
            usuarioDAO.saveChanges();

            Usuario  us = new Usuario { ID= 10, Nome = "João", Senha = 12345 };

            contexto.Entry(us).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
            contexto.Usuarios.Attach()

        }
    }
}


