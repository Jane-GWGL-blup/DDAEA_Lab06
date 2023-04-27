using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Datos
{
    public class DProducto { 
    private string connectionString = "Data Source=NICOLEC\\SQLEXPRESS;Initial Catalog=BDLab06;Integrated Security=True;";

        
            public List<Producto> Listar2()
            {

                //Obtengo la conexión
                SqlConnection connection = null;
                SqlParameter param = null;
                SqlCommand command = null;
                List<Producto> productos = null;
                try
                {
                    connection = new SqlConnection(connectionString);

                    connection.Open();

                    //Hago mi consulta
                    command = new SqlCommand("USP_GetProducto", connection);
                    command.CommandType = CommandType.StoredProcedure;


                    SqlDataReader reader = command.ExecuteReader();
                    productos = new List<Producto>();


                    while (reader.Read())
                    {

                        Producto producto = new Producto();
                        producto.IdProducto= (int)reader["Id"];
                        producto.Nombre = reader["Nombre"].ToString();
                        producto.Precio = Convert.ToDouble( reader["Precio"]);
                        producto.FechaCreacion =Convert.ToDateTime( reader["FechaCreacion"]);

                        productos.Add(producto);

                    }

                    connection.Close();

                    //Muestro la información
                    return productos;


                }
                catch (Exception)
                {
                    connection.Close();
                    throw;
                }
                finally
                {
                    connection = null;
                    command = null;
                    param = null;
                    productos = null;

                }


            }
        


        public List<Producto> Listar()
        {
            List<Producto> productos;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter param1;
                SqlParameter param2;

                param1 = new SqlParameter();
                param1.ParameterName = "@Nombre";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = "";

                param2 = new SqlParameter();
                param2.ParameterName = "@Estado";
                param2.SqlDbType = SqlDbType.Bit;
                param2.Value = true;

                parameters.Add(param1);
                parameters.Add(param2);




                SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, "USP_GetProducto", CommandType.StoredProcedure, parameters.ToArray());
                productos = new List<Producto>();
                

                while (reader.Read())
                {

                    Producto producto = new Producto();
                    producto.IdProducto = (int)reader["IdProducto"];
                    producto.Nombre = reader["Nombre"].ToString();
                    producto.Precio = Convert.ToDouble(reader["Precio"]);
                    producto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    producto.Estado = Convert.ToBoolean(reader["Estado"]);

                    productos.Add(producto);

                }

                return productos;

            }
            catch (Exception)
            {
                
                throw;
            }

        }





        public void Insertar1(Producto producto)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_InsProducto", connection); // Nombre del procedimiento almacenado
                command.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado                
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                //command.Parameters.AddWithValue("@FechaCreacion", producto.FechaCreacion);

                    command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


        public void Insertar(Producto producto)
        {


            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter param1,param2,param3,param4,param5;


                param1 = new SqlParameter();
                param1.ParameterName = "@IdProducto";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.IdProducto;

                param2 = new SqlParameter();
                param2.ParameterName = "@Nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = producto.Nombre;

                param3 = new SqlParameter();
                param3.ParameterName = "@Precio";
                param3.SqlDbType = SqlDbType.Decimal;
                param3.Value = producto.Precio;

                param4 = new SqlParameter();
                param4.ParameterName = "@FechaCreacion";
                param4.SqlDbType = SqlDbType.DateTime;
                param4.Value = producto.FechaCreacion;

                param5 = new SqlParameter();
                param5.ParameterName = "@Estado";
                param5.SqlDbType = SqlDbType.Bit;
                param5.Value = producto.Estado;

                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);
                parameters.Add(param5);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_InsProducto", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void Actualizar(Producto producto)
        {


            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter param1, param2, param3, param4, param5;


                param1 = new SqlParameter();
                param1.ParameterName = "@IdProducto";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.IdProducto;

                param2 = new SqlParameter();
                param2.ParameterName = "@Nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = producto.Nombre;

                param3 = new SqlParameter();
                param3.ParameterName = "@Precio";
                param3.SqlDbType = SqlDbType.Decimal;
                param3.Value = producto.Precio;

                param4 = new SqlParameter();
                param4.ParameterName = "@FechaCreacion";
                param4.SqlDbType = SqlDbType.DateTime;
                param4.Value = producto.FechaCreacion;

                param5 = new SqlParameter();
                param5.ParameterName = "@Estado";
                param5.SqlDbType = SqlDbType.Bit;
                param5.Value = producto.Estado;

                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);
                parameters.Add(param5);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_UpdProducto", CommandType.StoredProcedure, parameters.ToArray());

                
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void Delete(Producto producto)
        {


            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter param1, param2;


                param1 = new SqlParameter();
                param1.ParameterName = "@IdProducto";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.IdProducto;

                param2 = new SqlParameter();
                param2.ParameterName = "@Estado";
                param2.SqlDbType = SqlDbType.Bit;
                param2.Value = false;

                parameters.Add(param1);
                parameters.Add(param2);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_DelProducto", CommandType.StoredProcedure, parameters.ToArray());


            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
