using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class EmpleadoDAL
    {
        public Empleado GetEmpleado(short id)
        {
            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();
                Empleado empleado = new Empleado();
                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaEmpleado",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("ID", id);

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        empleado.IDEMPLEADO = Convert.ToInt16(dr[0]);
                        empleado.NOMBRE = dr[1].ToString();
                        empleado.TELEFONO = dr[2].ToString();
                        empleado.DIRECCION = dr[3].ToString();
                        empleado.SALARIO = Convert.ToDecimal(dr[4]);

                    }
                }

                return empleado;
            }
        }
        public List<Empleado> ListarEmpleados()
        {
            var empleados = new List<Empleado>();

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaEmpleado",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var empleado = new Empleado
                        {
                            IDEMPLEADO = Convert.ToInt16(dr[0]),
                            NOMBRE = dr[1].ToString(),
                            TELEFONO = dr[2].ToString(),
                            DIRECCION = dr[3].ToString(),
                            SALARIO = Convert.ToDecimal(dr[4])
                        };

                        empleados.Add(empleado);
                    }
                }
            }

            return empleados;
        }

        public bool RegistrarEmpleado(Empleado emp)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoEmpleado",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 1);
                comando.Parameters.AddWithValue("NOMBRE", emp.NOMBRE);
                comando.Parameters.AddWithValue("TELEFONO", emp.TELEFONO);
                comando.Parameters.AddWithValue("DIRECCION", emp.DIRECCION);
                comando.Parameters.AddWithValue("SALARIO", emp.SALARIO);


                try
                {
                    comando.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }


            return res;
        }

        public bool ActualizarEmpleado(Empleado emp)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoEmpleado",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 2);
                comando.Parameters.AddWithValue("NOMBRE", emp.NOMBRE);
                comando.Parameters.AddWithValue("TELEFONO", emp.TELEFONO);
                comando.Parameters.AddWithValue("DIRECCION", emp.DIRECCION);
                comando.Parameters.AddWithValue("SALARIO", emp.SALARIO);
                comando.Parameters.AddWithValue("IDEMPLEADO", emp.IDEMPLEADO);

                try
                {
                    comando.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }


            return res;
        }

        public bool EliminarEmpleado(short id)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoEmpleado",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 3);
                comando.Parameters.AddWithValue("IDEMPLEADO", id);

                try
                {
                    comando.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }


            return res;
        }
    }
}
