using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Color
    {
        public int idColor { get; set; }

        public int descripcion { get; set; }

        public bool activo { get; set; }

        public Color() { }

        public Color(int idColor, int descripcion, bool activo)
        {
            this.idColor = idColor;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
