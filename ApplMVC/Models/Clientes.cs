using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// se agrega el namespace
using System.Data.Entity;
// agrega el namespace: Nos va a permitir usar los atributos de validacion
using System.ComponentModel.DataAnnotations;

namespace ApplMVC.Models
{
    public class Clientes
    {
        public int ID { get; set; }

        [StringLength(60,MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display (Name = "Fecha de Alta")]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString ="{0:YYYY-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; }

        [Range(18, 75)]
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