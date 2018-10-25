using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class ProductoAD
    {
        private static ProductoAD instance = null;

        private ProductoAD() { }

        public static ProductoAD GetInstance()
        {
            if (instance == null)
                instance = new ProductoAD();

            return instance;
        }
        public List<ProductoBE> ListarProducto()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<ProductoBE> lstcobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_listar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductoBE cobj = new ProductoBE();
                    cobj.AnioCampania = Convert.ToInt32(ds.Tables[0].Rows[i]["AnioCampania"].ToString());
                    cobj.Cuv = ds.Tables[0].Rows[i]["Cuv"].ToString();
                    cobj.MarcaId = Convert.ToInt16(ds.Tables[0].Rows[i]["MarcaID"]);
                    cobj.Precio = Convert.ToDecimal(ds.Tables[0].Rows[i]["Precio"].ToString());
                    cobj.Descripcion = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                    cobj.CodigoTipoOferta = ds.Tables[0].Rows[i]["CodigoTipoOferta"].ToString();
                    cobj.CodigoSAP = ds.Tables[0].Rows[i]["CodigoSAP"].ToString();
                    cobj.EstadoActivo = Convert.ToBoolean(ds.Tables[0].Rows[i]["EstadoActivo"]);

                    lstcobj.Add(cobj);
                }
                return lstcobj;
            }
            catch
            {
                return lstcobj;
            }
            finally
            {
                con.Close();
            }
        }

        public ProductoBE BuscarProducto(int AnioCampania, string Cuv, short MarcaId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            ProductoBE cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_buscar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnioCampania", AnioCampania);
                cmd.Parameters.AddWithValue("@Cuv", Cuv);
                cmd.Parameters.AddWithValue("@MarcaID", MarcaId);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new ProductoBE();
                    cobj.AnioCampania = Convert.ToInt32(ds.Tables[0].Rows[i]["AnioCampania"].ToString());
                    cobj.Cuv = ds.Tables[0].Rows[i]["Cuv"].ToString();
                    cobj.MarcaId = Convert.ToInt16(ds.Tables[0].Rows[i]["MarcaID"]);
                    cobj.Precio = Convert.ToDecimal(ds.Tables[0].Rows[i]["Precio"].ToString());
                    cobj.Descripcion = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                    cobj.CodigoTipoOferta = ds.Tables[0].Rows[i]["CodigoTipoOferta"].ToString();
                    cobj.CodigoSAP = ds.Tables[0].Rows[i]["CodigoSAP"].ToString();
                    cobj.EstadoActivo = Convert.ToBoolean(ds.Tables[0].Rows[i]["EstadoActivo"]);

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }

        public string InsertaProducto(ProductoBE objpro)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_inserta_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnioCampania", objpro.AnioCampania);
                cmd.Parameters.AddWithValue("@Cuv", objpro.Cuv);
                cmd.Parameters.AddWithValue("@MarcaID", objpro.MarcaId);
                cmd.Parameters.AddWithValue("@Precio", objpro.Precio);
                cmd.Parameters.AddWithValue("@Descripcion", objpro.Descripcion);
                cmd.Parameters.AddWithValue("@CodigoTipoOferta", objpro.CodigoTipoOferta);
                cmd.Parameters.AddWithValue("@CodigoSAP", objpro.CodigoSAP);
                //cmd.Parameters.AddWithValue("@CodigoSAP", objpro.MarcaId);

                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }            
        }
    }
}
