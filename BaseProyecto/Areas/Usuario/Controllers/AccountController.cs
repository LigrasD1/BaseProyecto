using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseProyecto.Areas.Usuario.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Base.Models.Usuario> _userManager;
        private readonly SignInManager<Base.Models.Usuario> _signInManager;
        public AccountController(UserManager<Base.Models.Usuario> userManager, SignInManager<Base.Models.Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Base.Models.Usuario usuario, string password)
        {
            // Registrar el usuario
            var result = await _userManager.CreateAsync(usuario, password);
            if (result.Succeeded)
            {
                // Puedes agregar roles aquí si es necesario
                return RedirectToAction("Index", "Home");
            }

            // Manejar errores
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            // Manejar error de inicio de sesión
            ModelState.AddModelError("", "Intento de inicio de sesión fallido.");
            return View();
        }
    }
}
