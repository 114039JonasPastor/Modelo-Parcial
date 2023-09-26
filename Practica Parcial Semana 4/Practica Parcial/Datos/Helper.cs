using Practica_Parcial.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Parcial.Datos
{
    public class Helper
    {
        private SqlConnection cnn;

        public Helper()
        {
            cnn = new SqlConnection("Data Source=DESKTOP-35MIDJI\\SQLEXPRESS;Initial Catalog=retiro;Integrated Security=True");
        }

        public DataTable Consultar(string nombreSP)
        {
            cnn.Open();
            
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            cnn.Close();
            return tabla;
        }

        public DataTable ConsultarParametros(string nombreSP, List<Parametro> lparametros)
        {
            cnn.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            comando.Parameters.Clear();
            foreach(Parametro p in lparametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            cnn.Close();
            return tabla;
        }

        public bool ConfimarOrden(OrdenRetiro orden)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_INSERTAR_ORDEN", cnn, t);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fecha", orden.Fecha);
                comando.Parameters.AddWithValue("@responsable", orden.Responsable);

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@nuevo_nro_orden";
                parametro.DbType = DbType.Int32;
                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int nroOrden = Convert.ToInt32(parametro.Value);

                SqlCommand cmd = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < orden.ldetalle.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("id_orden", nroOrden);
                    cmd.Parameters.AddWithValue("id_material", orden.ldetalle[i].Material.Codigo);
                    cmd.Parameters.AddWithValue("cantidad", orden.ldetalle[i].Cantidad);
                    cmd.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return resultado;
        }
    }
}
