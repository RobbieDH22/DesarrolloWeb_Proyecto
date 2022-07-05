using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CU1_RegistroClientes : Controller
    {
        public IActionResult RegistroCliente()
        {
            return View();
        }

        public IActionResult eleccion()
        {
            return View();
        }

        public IActionResult LoginCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(IFormCollection form)
        {
            var dni = form["dni"];
            var password = form["password"];

            if (dni == "70186471" && password == "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("LoginCliente");
            }
        }

    }
}
