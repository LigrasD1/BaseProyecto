using Base.Data.Data.Repository.IRepository;
using Base.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BaseProyecto.Areas.Cliente.Controllers
{
    [Area("Cliente")]
	public class CarritoController : Controller
	{
		private readonly IContenedorTrabajo _contenedorTrabajo;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CarritoController(IContenedorTrabajo contenedor, IHttpContextAccessor contextAccessor)
        {
			_contenedorTrabajo= contenedor;
			httpContextAccessor = contextAccessor;

		}
        public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetAll()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var carro= _contenedorTrabajo.Carrito.GetFirstOrDefault(x=>x.UsuarioId==userId);
			if(carro==null)return RedirectToAction("Index","Articulo");

			var carritoArticulos = _contenedorTrabajo.CarritoArticulo
						  .GetAll(x => x.CarritoId == carro.Id, includeProperties: "Articulo") // Filtrar por CarritoId
						  .ToList(); 
			foreach (var item in carritoArticulos)
			{
				var request = httpContextAccessor.HttpContext.Request;
				var baseURL = $"{request.Scheme}://{request.Host}";
				item.Articulo.Imagen = $"{baseURL}{item.Articulo.Imagen}";
			}

			return Json(new { data = carritoArticulos });
		}

        // Acción para eliminar un artículo del carrito
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carro = _contenedorTrabajo.Carrito.GetFirstOrDefault(x => x.UsuarioId == userId);

            if (carro != null)
            {
                var carritoArticulo = _contenedorTrabajo.CarritoArticulo.GetFirstOrDefault(x=>x.Id == id);
                if (carritoArticulo != null)
                {
                    _contenedorTrabajo.CarritoArticulo.Remove(carritoArticulo);
                    _contenedorTrabajo.Save();
                }
            }

            return Json(new { success = true });
        }

        // Acción para realizar la compra (vaciar el carrito)
        [HttpPost]
        public IActionResult RealizarCompra()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carro = _contenedorTrabajo.Carrito.GetFirstOrDefault(x => x.UsuarioId == userId);

            if (carro != null)
            {
                var carritos = _contenedorTrabajo.CarritoArticulo.GetAll(x => x.CarritoId == carro.Id);
                foreach (var item in carritos)
                {
                    var articulo = _contenedorTrabajo.Articulo.Get(item.ArticuloId);
                    if (articulo.cantidad >= item.Cantidad)
                    {
                        articulo.cantidad -= item.Cantidad;
                        _contenedorTrabajo.CarritoArticulo.Remove(item);
                    }
                    else
                    {
                        // Retorna un error indicando que no hay suficiente stock
                        return BadRequest(new { success = false, mensaje = $"No hay stock suficiente para {articulo.Nombre}." });
                    }
                }
                _contenedorTrabajo.Save();
                return Json(new { success = true });
            }

            return Json(new { success = false, mensaje = "Carrito no encontrado." });
        }


    }
}
