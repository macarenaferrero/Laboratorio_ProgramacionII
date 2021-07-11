using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public delegate void Actualizar();
    public class DomoDAO
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;
        public event Actualizar EActualizarEstado;

        /// <summary>
        /// Constructor estatico que contiene la informacion de la conexion
        /// </summary>
        static DomoDAO()
        {
            //Abrir conexion
            cadenaConexion = "Server = localhost ; Database = Master; Trusted_Connection = true;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        /// <summary>
        /// Metodo que guarda los domos en la base de datos
        /// </summary>
        /// <param name="domoGeodesico">Domo del tipo Domo Geodesico que se guardara en la base de datos</param>
        public void Guardar(DomoGeodesico domoGeodesico)
        {
            try
            {
                float auxM2 = 0;
                auxM2 = auxM2.RedondeoM2(domoGeodesico.M2);
                comando.Parameters.Clear();
                conexion.Open();
                //Armar consulta parametrizada
                comando.CommandText = "INSERT INTO PedidosDomos (Cliente, Radio, Frecuencia, [Tipo De Conexion], M2, Material, Estado) VALUES (@cliente, @radio, @frecuencia, @tipodeconexion, ROUND(@m2, 2), @material, @estado)";
                comando.Parameters.AddWithValue("@cliente", domoGeodesico.Cliente);
                comando.Parameters.AddWithValue("@radio", domoGeodesico.Radio);
                comando.Parameters.AddWithValue("@frecuencia", domoGeodesico.Frecuencia.ToString());
                comando.Parameters.AddWithValue("@tipodeconexion", domoGeodesico.TipoDeConexion.ToString());
                comando.Parameters.AddWithValue("@m2", auxM2);
                comando.Parameters.AddWithValue("@material", domoGeodesico.Material.ToString());
                comando.Parameters.AddWithValue("@estado", domoGeodesico.Estado.ToString());

                //Ejecutarla
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        /// <summary>
        /// Metodo que Lee desde la base de datos y devuelve una lista con los domos pendientes
        /// </summary>
        /// <returns>Retorna una lista con los domos pendientes</returns>
        public List<DomoGeodesico> Leer()
        {
            List<DomoGeodesico> domos = new List<DomoGeodesico>();
            DomoGeodesico domo = null;

            try
            {
                //Abrir conexion
                conexion.Open();

                //Armar consulta parametrizada
                comando.CommandText = $"SELECT * FROM PedidosDomos";
                SqlDataReader dataReader = comando.ExecuteReader();

                //Mientras haya para leer instancia personas
                while (dataReader.Read())
                {
                    Enum.TryParse(dataReader["Frecuencia"].ToString(), out EFrecuencia eFrecuencia);
                    Enum.TryParse(dataReader["Tipo de Conexion"].ToString(), out ETipoConexion eTipoConexion);
                    Enum.TryParse(dataReader["Estado"].ToString(), out EEstado eEstado);


                    string dataReaderMaterial = dataReader["Material"].ToString();
                    if (dataReaderMaterial == "PVC")
                    {
                        domo = new KitPVC(Convert.ToInt32(dataReader["Id"]), (float)Convert.ToDouble(dataReader["Radio"]), eFrecuencia, dataReader["Cliente"].ToString(), eTipoConexion, dataReader["Material"].ToString(), eEstado);
                        domos.Add(domo);
                    }
                    else
                    {
                        domo = new KitMadera(Convert.ToInt32(dataReader["Id"]), (float)Convert.ToDouble(dataReader["Radio"]), eFrecuencia, dataReader["Cliente"].ToString(), eTipoConexion, dataReader["Material"].ToString(), eEstado);
                        domos.Add(domo);
                    }
                }

                dataReader.Close();

            }
            catch (Exception ex)
            {
                throw new DomoException("No se puede abrir informe", "Clase DomoDAO", "Metodo Leer()", ex);
            }
            finally
            {
                conexion.Close();
            }
           return domos;
        }



        /// <summary>
        /// Metodo Eliminar que elimina de la base de datos el domo recibido por parametros
        /// </summary>
        /// <param name="domoId">Int con el ID del domo a eliminar</param>
        public void Eliminar(int domoId)
        {
            try
            {
                //Abrir conexion
                conexion.Open();

                //Armar consulta parametrizada
                comando.CommandText = $"DELETE FROM PedidosDomos WHERE Id ={domoId}";

                //Solo corre la consulta
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Metodo que realiza la consulta a la base de datos modificando el estado del domo
        /// </summary>
        /// <param name="domoId">Int del ID del domo a actualizar</param>
        public void ActualizarEstado(int domoId)
        {
            try
            {
                //Abrir conexion
                conexion.Open();

                //Armar consulta parametrizada
                comando.CommandText = $"UPDATE PedidosDomos SET Estado = 'Construido' WHERE Id ={domoId}";

                //Solo corre la consulta
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }



    }
}
