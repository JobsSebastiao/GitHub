using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Limite 20 Caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage ="Preencha o campo preço!"),DataType(DataType.Currency)]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public String Descricao { get; set; }
        
        [Range(10,100,ErrorMessage ="Qunatidade deve ser entre 10 e 100!")]
        public int Quantidade { get; set; }
    }
}
