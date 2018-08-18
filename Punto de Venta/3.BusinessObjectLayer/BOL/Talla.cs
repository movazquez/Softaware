using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Talla
    {
        public int idTalla { get; set; }

        public int descripcion { get; set; }

        public bool activo { get; set; }

        public Talla() { }

        public Talla(int idTalla, int descripcion, bool activo)
        {
            this.idTalla = idTalla;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
