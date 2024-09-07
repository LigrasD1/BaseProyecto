﻿using Base.Data.Data.Repository;
using Base.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Base.Models;

namespace BaseProyecto.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class CategoriaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public CategoriaController(IContenedorTrabajo Contenedor)
        {
            _contenedorTrabajo = Contenedor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria) 
        {
            if (ModelState.IsValid) 
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Categoria categoria = new Categoria();
            categoria=_contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

    }
}
