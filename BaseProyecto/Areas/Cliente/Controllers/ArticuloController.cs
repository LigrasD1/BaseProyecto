using Base.Data.Data.Repository;
using Base.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BaseProyecto.Areas.Cliente.Controllers
{
    [Area("Cliente")]

    public class ArticuloController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        public ArticuloController(IContenedorTrabajo contenedor)
        {
            _contenedorTrabajo = contenedor;       
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var art = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria");
            return Json(new { data = art });
        }
    }
}
