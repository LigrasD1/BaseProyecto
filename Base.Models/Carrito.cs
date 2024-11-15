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
	public class Carrito
	{
		[Key]
		public int Id { get; set; }

		public string UsuarioId { get; set; }
		[ForeignKey("UsuarioId")]
		public Usuario Usuario { get; set; }
		public DateTime FechaCreacion { get; set; }  // Fecha de creación del carrito

        // Relación de muchos a muchos con Articulo
        [JsonIgnore]
        public ICollection<CarritoArticulo> CarritoArticulos { get; set; }
	}
}
