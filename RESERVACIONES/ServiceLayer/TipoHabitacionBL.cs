using DAO;
using Entidades;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class TipoHabitacionBL
    {
        private TipoHabitacionDAL tipoHabitacionDAL = new TipoHabitacionDAL();

        public List<TipoHabitacion> ListarTipoHabitacion()
        {
            return tipoHabitacionDAL.ListarTipoHabitacion();
        }

        public bool RegistrarTipoHabitacion(TipoHabitacion tipo)
        {
            return tipoHabitacionDAL.RegistrarTipoHabitacion(tipo);
        }

        public TipoHabitacion GetTipoHabitacion(short id)
        {
            return tipoHabitacionDAL.GetTipoHabitacion(id);
        }

        public bool ActualizarTipoHabitacion(TipoHabitacion tipo)
        {
            return tipoHabitacionDAL.ActualizarTipoHabitacion(tipo);
        }

        public bool EliminarTipoHabitacion(short id)
        {
            return tipoHabitacionDAL.EliminarTipoHabitacion(id);
        }
    }
}
