using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el nombre de la categoria")]
        [StringLength(50)]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario asignar habilitacion o no")]

        public int? Habilitada { get; set; }

    }
}
