using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Agregue el nombre del articulo")]
        [StringLength(50)]
        public string? Nombre { get; set; }
        //public string? ImagenLink { get; set; }
        public int habilitado { get; set; }
        public string? Imagen { get; set; }
        public int? precio { get; set; }
        public int? cantidad { get; set; }

        public int CategoriaId {  get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categoria? Categoria { get; set; }

    }
}
