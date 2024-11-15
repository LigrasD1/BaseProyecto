using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Base.Models
{
	public class CarritoArticulo
	{
		[Key]
		public int Id { get; set; }
        public int CarritoId { get; set; }  // Llave foránea de Carrito
		public int ArticuloId { get; set; }  // Llave foránea de Articulo
        public int Cantidad { get; set; }  // Cantidad del producto en el carrito

		[ForeignKey(nameof(CarritoId))]
		public Carrito Carrito { get; set; }

		[ForeignKey(nameof(ArticuloId))]
        public Articulo Articulo { get; set; }

	}
}
