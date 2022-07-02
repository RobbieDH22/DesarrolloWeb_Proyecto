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
        public IActionResult Validar(string eleccion)
        {
            if (eleccion == "IniciarSesion")
            {
                return RedirectToAction("LoginCliente");
            }
            else
            {
                return RedirectToAction("RegistroCliente");
            }
        }
    }
}
