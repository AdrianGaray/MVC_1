using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplMVC.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public string TodosLosProveedores()
        {
            return @"<ul>
                    <li>AlCampo</li>
                    <li>Carrefour</li>
                    <li>Mercadona</li>
                    <li>Gladis</li>
                    </ul>";
        }
    }
}