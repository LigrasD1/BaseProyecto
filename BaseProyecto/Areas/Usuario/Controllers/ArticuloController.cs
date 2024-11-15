using Base.Data.Data.Repository.IRepository;
using Base.Models;
using BaseProyecto.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BaseProyecto.Areas.Usuario.Controllers
{
    [Area ("Usuario")]
	[Authorize(Roles = "Administrador")]

	public class ArticuloController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public ArticuloController(IContenedorTrabajo Contenedor)
        {
            _contenedorTrabajo = Contenedor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var art = _contenedorTrabajo.Articulo.GetAll(includeProperties:"Categoria");
            return Json(new { data =  art});
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM articuloVM = new ArticuloVM()
            {
                Articulo = new Articulo(),
                ListaCategoria = _contenedorTrabajo.Categoria.GetListaCategoria()
            };

            return View(articuloVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM ArtiVM, IFormFile file)
        {
            
                if (file != null && file.Length > 0)
                {
                    ArtiVM.Articulo.Imagen = GuardarImagen(file);
                }
                _contenedorTrabajo.Articulo.Add(ArtiVM.Articulo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            
            ArtiVM.ListaCategoria = _contenedorTrabajo.Categoria.GetListaCategoria();
            return View(ArtiVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Articulo articulo, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    articulo.Imagen = GuardarImagen(file);
                }
                _contenedorTrabajo.Articulo.Update(articulo);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Articulo articulo = new Articulo();
            articulo = _contenedorTrabajo.Articulo.Get(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var articulo = _contenedorTrabajo.Articulo.Get(id);
            if (articulo == null)
            {
                return Json(new { success = false, message = "Error al eliminar el Articulo" });
            }

            _contenedorTrabajo.Articulo.Remove(articulo);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Articulo eliminada exitosamente" });
        }

        private string GuardarImagen(IFormFile formFile)
        {

            if (formFile != null && formFile.Length > 0)
            {
                // Generar una ruta única para la imagen
                var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                var extension = Path.GetExtension(formFile.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                // Ruta de almacenamiento en el sistema de archivos
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolder)) //Si el directorio no existe crear uno
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Guardar la imagen en el servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyToAsync(stream);
                }

                // Asignar la ruta de la imagen al producto
                return $"/Uploads/{uniqueFileName}";


            }

            return "/Uploads/default.jpeg";
        }

    }
}
