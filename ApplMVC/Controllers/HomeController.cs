using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // RedirectToAction. redirecciona a otra accion de un  controller.
            return RedirectToAction("TodosLosProveedores", "proveedores");
        }

        // Selector: ActionName
        [ActionName ("Hora")]
        public string HoraActual()
        {
            return CadenaHora();
        }

        // Selector: NonAction
        [NonAction]
        private string CadenaHora()
        {
            return "Son las " + DateTime.Now.ToString("T");
        }
    }
}