using DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EmpleadoBL
    {
        private EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public List<Empleado> ListarEmpleados()
        {
            return empleadoDAL.ListarEmpleados();
        }

        public bool RegistrarEmpleado(Empleado emp)
        {
            return empleadoDAL.RegistrarEmpleado(emp);
        }

        public Empleado GetEmpleado(short id)
        {
            return empleadoDAL.GetEmpleado(id);
        }

        public bool ActualizarEmpleado(Empleado emp)
        {
            return empleadoDAL.ActualizarEmpleado(emp);
        }

        public bool EliminarEmpleado(short id)
        {
            return empleadoDAL.EliminarEmpleado(id);
        }
    }
}
