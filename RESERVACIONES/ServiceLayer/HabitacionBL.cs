using DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class HabitacionBL
    {
        private HabitacionDAL habitacionDAL = new HabitacionDAL();

        public List<Habitacion> ListarHabitacion()
        {
            return habitacionDAL.ListarHabitaciones();
        }

        public bool RegistrarHabitacion(Habitacion habitacion)
        {
            return habitacionDAL.RegistrarHabitacion(habitacion);
        }

        public Habitacion GetHabitacion(short id)
        {
            return habitacionDAL.GetHabitacion(id);
        }

        public bool ActualizarHabitacion(Habitacion habitacion)
        {
            return habitacionDAL.ActualizarHabitacion(habitacion);
        }

        public bool EliminarHabitacion(short id)
        {
            return habitacionDAL.EliminarHabitacion(id);
        }
    }
}
