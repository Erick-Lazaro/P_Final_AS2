using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESERVACIONES
{
    public partial class TipoHabitacion : System.Web.UI.Page
    {
        private static TipoHabitacionBL serviceTipoHabitacion = new TipoHabitacionBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Entidades.TipoHabitacion GetTipoHabitacion(short id)
        {
            return serviceTipoHabitacion.GetTipoHabitacion(id);
        }

        [WebMethod]
        public static List<Entidades.TipoHabitacion> ConsultarTipoHabitacion()
        {
            return serviceTipoHabitacion.ListarTipoHabitacion();
        }

        [WebMethod]
        public static bool Registrar(Entidades.TipoHabitacion tipo)
        {
            var res = false;

            if (serviceTipoHabitacion.RegistrarTipoHabitacion(tipo))
            {
                res = true;
            }

            return res;
        }

        [WebMethod]
        public static bool Actualizar(Entidades.TipoHabitacion tipo)
        {
            var res = false;

            if (serviceTipoHabitacion.ActualizarTipoHabitacion(tipo))
            {
                res = true;
            }

            return res;
        }

        [WebMethod]
        public static bool Eliminar(short id)
        {
            var res = false;

            if (serviceTipoHabitacion.EliminarTipoHabitacion(id))
            {
                res = true;
            }

            return res;
        }
    }
}