using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamBelcorp.Models
{
    public class Contexto: DbContext
    {
        DbSet<Producto> Productos { get; set; }

        public System.Data.Entity.DbSet<ExamBelcorp.Models.Producto> Productoes { get; set; }
    }
}