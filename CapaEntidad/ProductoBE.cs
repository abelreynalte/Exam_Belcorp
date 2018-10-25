using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoBE
    {
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
