using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LojaOnline.Comum
{
    [Table("loja_categorias")]
    public class Categoria
    {
        [Column("codigo")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Codigo { get; set; }
        
        [Column("nome")]
        [Required]
        public string Nome { get; set; }
    }
}
