using Base.Data.Data.Repository;
using Base.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProyecto.Areas.Cliente.Controllers
{
    [Area("Cliente")]

    public class ArticuloController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ArticuloController(IContenedorTrabajo contenedor, IHttpContextAccessor contextAccessor)
        {
            _contenedorTrabajo = contenedor;
            httpContextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
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
    }
}
