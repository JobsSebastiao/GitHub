using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEF
{
    public class Usuario
    {
        public int ID { get; set; }

        /// <summary>
        /// define que o campo tem que ser preenchido.
        /// </summary>
        [Required(ErrorMessage="Nome não pode ser em branco")]
        public string Nome { get; set; }
        public int Senha { get; set; }
        public string Sobrenome { get; set; }

    }
}
