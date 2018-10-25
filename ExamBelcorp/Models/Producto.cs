using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ExamBelcorp.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int AnioCampania { get; set; }
        public string Cuv { get; set; }
        public short MarcaId { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string CodigoTipoOferta { get; set; }
        public string CodigoSAP { get; set; }
        public bool EstadoActivo { get; set; }
    }
}