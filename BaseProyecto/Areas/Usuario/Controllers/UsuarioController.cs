using Base.Data.Data.Repository.IRepository;
using Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BaseProyecto.Areas.Usuario.Controllers
{
	[Area("Usuario")]
	[Authorize(Roles = "Administrador")]

	public class UsuarioController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
		private readonly UserManager<IdentityUser> _userManager;

		public UsuarioController(IContenedorTrabajo contenedor, UserManager<IdentityUser> userManager)
        {
            _contenedorTrabajo=contenedor;
			_userManager = userManager;

		}
		
        
        public IActionResult Index()
        {
            var usuarios = _contenedorTrabajo.Usuario.GetAll();
            return View(usuarios);
        }

        public IActionResult Editar(string id)
        {
			var usuarios = _contenedorTrabajo.Usuario.GetFirstOrDefault(u=>u.Id==id);
			return View(usuarios);
        }
        [HttpPost]
        public IActionResult Editar(Base.Models.Usuario user)
        {
            _contenedorTrabajo.Usuario.Update(user);
            _contenedorTrabajo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Habilitar(string id)
        {
            var usuario= _contenedorTrabajo.Usuario.GetFirstOrDefault(u=>u.Id == id);
            if(usuario.LockoutEnabled==null) usuario.LockoutEnabled=true;
            else usuario.LockoutEnabled = !usuario.LockoutEnabled;
            _contenedorTrabajo.Save();
			return RedirectToAction("Index");   
        }

        public IActionResult Borrar(string id)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == id) return RedirectToAction("Index");
			var usuario = _contenedorTrabajo.Usuario.GetFirstOrDefault(u => u.Id == id);
            _contenedorTrabajo.Usuario.Remove(usuario);
            _contenedorTrabajo.Save();
            return RedirectToAction("Index");

        }
    }
}
