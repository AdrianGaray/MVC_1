using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// se agrega el namespace
using System.Data.Entity;

namespace ApplMVC.Models
{
    public class Clientes
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Edad { get; set; }
    }

    // Se añade al modelo una clase de contexto de base de datos
    // DbContext pertence a EntityFramework
    public class EmpDBContext : DbContext
    { 
        // definicion de la clase

        public EmpDBContext()
        {
        
        }

        // Se define una propiedad para que pueda trabajar con nuesta entidad Clientes, para que pueda consultar Y establecer los datos de nuestros clientes
        public DbSet<Clientes> Clientes { get; set; }
    }
}