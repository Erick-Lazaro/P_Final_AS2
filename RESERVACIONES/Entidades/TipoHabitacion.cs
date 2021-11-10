using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoHabitacion
    {
        public short IdTipo { get; set; }
        public string Descripcion { get; set; }
        public decimal TarifaNormal { get; set; }
        public decimal TarifaFin { get; set; }
        public byte CantidadPersonas { get; set; }
        public byte Estado { get; set; }
    }
}
