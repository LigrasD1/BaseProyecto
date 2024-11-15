using Base.Data;
using Base.Data.Data.Repository;
using Base.Data.Data.Repository.IRepository;
using Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BaseProyecto.Areas.Cliente.Controllers
{
    [Area("Cliente")]

    public class ArticuloController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext _Context;

        public ArticuloController(ApplicationDbContext contexto, IContenedorTrabajo contenedor, IHttpContextAccessor contextAccessor)
        {
            _Context = contexto;
            _contenedorTrabajo = contenedor;
            httpContextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult AgregarAlCarro(int idArticulo)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Carrito Carro = _contenedorTrabajo.Carrito.GetFirstOrDefault(c => c.UsuarioId == userId);
            if (Carro == null)
            {
				Carro = new Carrito();
                Carro.FechaCreacion = DateTime.Now;
                Carro.UsuarioId = userId;
                _contenedorTrabajo.Carrito.Add(Carro);
                _contenedorTrabajo.Save();
			}
            CarritoArticulo Articulo=_contenedorTrabajo.CarritoArticulo.GetFirstOrDefault(a=>a.ArticuloId == idArticulo && a.CarritoId==Carro.Id);
            if (Articulo != null)
            {
                Articulo.Cantidad += 1;
                _contenedorTrabajo.CarritoArticulo.Update(Articulo);

            }
            else
            {

				Articulo = new CarritoArticulo()
				{
					CarritoId = Carro.Id,
					ArticuloId = idArticulo,
					Cantidad = 1
				};
                _contenedorTrabajo.CarritoArticulo.Add(Articulo);

            }


            _contenedorTrabajo.Save();

			return RedirectToAction("Index","Carrito");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var art = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria").Where(A=>A.habilitado==1);
            foreach (var item in art)
            {
                var request = httpContextAccessor.HttpContext.Request;
                var baseURL = $"{request.Scheme}://{request.Host}";
                item.Imagen = $"{baseURL}{item.Imagen}";
            }
            
            return Json(new { data = art });
        }
        [Authorize]
		public IActionResult Detalle(int id)
        {
            var articulo = _Context.Articulo
                       .Include(a => a.Categoria)
                       .FirstOrDefault(a => a.Id == id);
            return View(articulo);
        }
    }
}
