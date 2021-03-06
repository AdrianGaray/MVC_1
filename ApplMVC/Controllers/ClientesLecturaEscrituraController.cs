﻿using ApplMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplMVC.Controllers
{


    public class ClientesLecturaEscrituraController : Controller
    {
        public static List<Clientes> empList = new List<Clientes> {
         new Clientes {
                    ID = 1,
                    Nombre ="Angel",
                    FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    Edad = 30
                },
                new Clientes {
                    ID = 2,
                    Nombre ="Patricia",
                    FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    Edad = 35
                },
        };

        private EmpDBContext db = new EmpDBContext(); // EmpDBContext viene de Entity Framework y re
        // GET: ClientesLecturaEscritura
        public ActionResult Index()
        {
            //var Clientes = from e in empList
            var Clientes = from e in db.Clientes // consulta nuestra base de datos clientes
                           orderby e.ID
                           select e;
            return View(Clientes);
        }

        // GET: ClientesLecturaEscritura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientesLecturaEscritura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesLecturaEscritura/Create
        [HttpPost]
        public ActionResult Create(Clientes emp)
        {
            try
            {         
                //Ejemplo Model Binding
                //empList.Add(emp);
                
                db.Clientes.Add(emp); // Entity Framework: se cambia la recepcion de datos
                db.SaveChanges(); // guarda los datos que hermos realizados

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesLecturaEscritura/Edit/5
        public ActionResult Edit(int id)
        {
            List<Clientes> empList = TodosLosClientes();
            // selecciona el id que se le paso por parametro
            //var Clientes = empList.Single(m => m.ID == id);

            // se cambia la variable de lista por la variabl  de base de datos(db.Clientes)
            var Clientes = db.Clientes.Single(m => m.ID == id);

            return View(Clientes);
        }

        // POST: ClientesLecturaEscritura/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // var clientes = empList.Single(m => m.ID == id);
                // se cambia la lista por la llamada a la base de datos
                var clientes = db.Clientes.Single(m => m.ID == id);

                // Miestras esta actualizando nuestro modelo. Le vamos a decir que nos vuelva a la pagina de inicio
                if (TryUpdateModel(clientes))
                {
                    db.SaveChanges(); // guarda los datos que hermos realizados
                    return RedirectToAction("Index"); 
                }
                return View(clientes); // muestra la vista clientes
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesLecturaEscritura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesLecturaEscritura/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Clientes> TodosLosClientes()
        {
            return new List<Clientes>
            {
                new Clientes {
                    ID = 1,
                    Nombre ="Angel",
                    FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    Edad = 30
                },
                new Clientes {
                    ID = 2,
                    Nombre ="Patricia",
                    FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    Edad = 35
                }
            };

        }
    }
}
