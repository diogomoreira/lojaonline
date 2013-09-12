using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnline.Comum
{
    [Table("loja_produtos")]
    public class Produto
    {
        [Column("codigo")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Codigo { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("preco")]
        [Required]
        public decimal Preco { get; set; }

        [Column("cod_categoria")]
        [Required]
        public long CodigoCategoria { get; set; }

        [ForeignKey("CodigoCategoria")]
        public virtual Categoria Categoria { get; set; }

        public Produto()
        {

        }
    }
}
