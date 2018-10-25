using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class ProductoBL
    {
        private static ProductoBL instance = null;

        private ProductoBL() { }

        public static ProductoBL GetInstance()
        {
            if (instance == null)
                instance = new ProductoBL();

            return instance;
        }

        public List<ProductoBE> ListarProducto()
        {
            return ProductoAD.GetInstance().ListarProducto();
        }
        public ProductoBE BuscarProducto(int AnioCampania, string Cuv, short MarcaId)
        {
            return ProductoAD.GetInstance().BuscarProducto(AnioCampania, Cuv, MarcaId);
        }
        public string InsertaProducto(ProductoBE objpro)
        {
            return ProductoAD.GetInstance().InsertaProducto(objpro);
        }
    }
}
