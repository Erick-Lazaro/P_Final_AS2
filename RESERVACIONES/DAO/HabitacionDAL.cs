using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HabitacionDAL
    {
        public Habitacion GetHabitacion(short id)
        {
            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();
                Habitacion habitacion = new Habitacion();
                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("ID", id);

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        habitacion.Id = int.Parse(dr[0].ToString());
                        habitacion.CodigoHabitacion = dr[1].ToString();
                        habitacion.EstadoHabitacion = dr[2].ToString();
                        habitacion.TipoHabitacion = dr[3].ToString();

                    }
                }

                return habitacion;
            }
        }

        public List<Habitacion> ListarHabitaciones()
        {
            var habitaciones = new List<Habitacion>();

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var habitacion = new Habitacion
                        {
                            Id = int.Parse(dr[0].ToString()),
                            CodigoHabitacion = dr[1].ToString(),
                            EstadoHabitacion = dr[2].ToString(),
                            TipoHabitacion = dr[3].ToString(),

                        };

                        habitaciones.Add(habitacion);

                    };


                }
            }

            return habitaciones;
        }


        //Registrar
        public bool RegistrarHabitacion(Habitacion habitacion)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 1);
                comando.Parameters.AddWithValue("CODHAB", habitacion.CodigoHabitacion);
                comando.Parameters.AddWithValue("ESTADO", habitacion.EstadoHabitacion);
                comando.Parameters.AddWithValue("TIPOHAB", habitacion.TipoHabitacion);

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

        //Actualizar
        public bool ActualizarHabitacion(Habitacion habitacion)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 2);
                comando.Parameters.AddWithValue("CODHAB", habitacion.CodigoHabitacion);
                comando.Parameters.AddWithValue("ESTADO", habitacion.EstadoHabitacion);
                comando.Parameters.AddWithValue("TIPOHAB", habitacion.TipoHabitacion);

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

        //Eliminar
        public bool EliminarHabitacion(short id)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 3);
                comando.Parameters.AddWithValue("ID", id);

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
