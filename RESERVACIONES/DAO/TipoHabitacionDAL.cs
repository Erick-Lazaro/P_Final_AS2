using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class TipoHabitacionDAL
    {
        public TipoHabitacion GetTipoHabitacion(short id)
        {
            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();
                TipoHabitacion habitacion = new TipoHabitacion();
                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaTipoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("ID", id);

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        habitacion.IdTipo = Convert.ToInt16(dr[0]);
                        habitacion.Descripcion = dr[1].ToString();
                        habitacion.TarifaNormal = decimal.Parse(dr[2].ToString());
                        habitacion.TarifaFin = decimal.Parse(dr[3].ToString());
                        habitacion.CantidadPersonas = byte.Parse(dr[4].ToString());

                    }
                }

                return habitacion;
            }
        }

        public List<TipoHabitacion> ListarTipoHabitacion()
        {
            var tipos = new List<TipoHabitacion>();

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_ConsultaTipoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var habitacion = new TipoHabitacion
                        {
                            IdTipo = Convert.ToInt16(dr[0]),
                            Descripcion = dr[1].ToString(),
                            TarifaNormal = decimal.Parse(dr[2].ToString()),
                            TarifaFin = decimal.Parse(dr[3].ToString()),
                            CantidadPersonas = byte.Parse(dr[4].ToString()),
                        };

                        tipos.Add(habitacion);

                    };


                }
            }

            return tipos;
        }


        //Registrar
        public bool RegistrarTipoHabitacion(TipoHabitacion tipo)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoTipoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 1);
                comando.Parameters.AddWithValue("DESCRIPCION", tipo.Descripcion);
                comando.Parameters.AddWithValue("TARIFAN", tipo.TarifaNormal);
                comando.Parameters.AddWithValue("TARIFAFIN", tipo.TarifaFin);
                comando.Parameters.AddWithValue("PERSONAS", tipo.CantidadPersonas);


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
        public bool ActualizarTipoHabitacion(TipoHabitacion tipo)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoTipoHabitacion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                };

                comando.Parameters.AddWithValue("OPCION", 2);
                comando.Parameters.AddWithValue("DESCRIPCION", tipo.Descripcion);
                comando.Parameters.AddWithValue("TARIFAN", tipo.TarifaNormal);
                comando.Parameters.AddWithValue("TARIFAFIN", tipo.TarifaFin);
                comando.Parameters.AddWithValue("PERSONAS", tipo.CantidadPersonas);
                comando.Parameters.AddWithValue("ID", tipo.IdTipo);

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
        public bool EliminarTipoHabitacion(short id)
        {
            var res = false;

            using (var conn = new SqlConnection(Connection.getConnectionString()))
            {
                conn.Open();

                var comando = new SqlCommand
                {
                    CommandText = "sp_MantenimientoTipoHabitacion",
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

