using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StartProject.Models
{
    public class CategoriaDoProduto
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        //indica o relacionamenot one to many entre categoria e produtos
        //deve ser virtual.
        //do tipo list referente a classe com qual tenha vínculo.
        public virtual IList<Produto> Produtos { get;  set; }
    }
}