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
    public partial class Empleado : System.Web.UI.Page
    {
        public static EmpleadoBL serviceEmpleado = new EmpleadoBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Entidades.Empleado GetEmpleado(short IDEMPLEADO)
        {
            return serviceEmpleado.GetEmpleado(IDEMPLEADO);
        }

        [WebMethod]
        public static List<Entidades.Empleado> ConsultarEmpleado()
        {
            return serviceEmpleado.ListarEmpleados();
        }

        [WebMethod]
        public static bool Registrar(Entidades.Empleado emp)
        {
            var res = false;

            if (serviceEmpleado.RegistrarEmpleado(emp))
            {
                res = true;
            }

            return res;
        }

        [WebMethod]
        public static bool Actualizar(Entidades.Empleado emp)
        {
            var res = false;

            if (serviceEmpleado.ActualizarEmpleado(emp))
            {
                res = true;
            }

            return res;
        }

        [WebMethod]
        public static bool Eliminar(short IDEMPLEADO)
        {
            var res = false;

            if (serviceEmpleado.EliminarEmpleado(IDEMPLEADO))
            {
                res = true;
            }

            return res;
        }
    }
}