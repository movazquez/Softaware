using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Linea
    {
        public int idLinea { get; set; }

        public int descripcion { get; set; }

        public bool activo { get; set; }

        public Linea() { }

        public Linea(int idLinea, int descripcion, bool activo)
        {
            this.idLinea = idLinea;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
