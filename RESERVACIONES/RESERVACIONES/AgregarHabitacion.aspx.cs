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
    public partial class AgregarHabitacion : System.Web.UI.Page
    {
        private static HabitacionBL serviceHabitacion = new HabitacionBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Entidades.Habitacion> ConsultarHabitacion()
        {
            return serviceHabitacion.ListarHabitacion();
        }
    }
}