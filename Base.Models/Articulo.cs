using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Agregue el nombre del articulo")]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int habilitado { get; set; }

        public int CategoriaId {  get; set; }
        public Categoria Categoria { get; set; }
    }
}
