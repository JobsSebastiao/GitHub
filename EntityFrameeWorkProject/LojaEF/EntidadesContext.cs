using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEF
{
  
    public class EntidadesContext : DbContext
    {
        public EntidadesContext()
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EntidadesContext>(null);

            var usuarioBuilder = modelBuilder.Entity<Usuario>();
            //DEFINE O NOME DA TABELA
            usuarioBuilder.ToTable("tb0001_Usuarios");

            //DEFINE O NOME DAS COLUNAS
            usuarioBuilder.Property(usuario => usuario.ID)
                          .HasColumnName("idUsuario");
            usuarioBuilder.Property(usuario => usuario.Nome)
                          .HasColumnName("nomeUSUARIO");
            usuarioBuilder.Property(usuario => usuario.Senha)
                          .HasColumnName("senhaUSUARIO");
            usuarioBuilder.Property(usuario => usuario.Sobrenome)
                          .HasColumnName("sobrenomeUSUARIO");
        }
    }


}
