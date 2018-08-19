using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Marca
    {
        public int idMarca { get; set; }

        public int descripcion { get; set; }

        public bool activo { get; set; }

        public Marca() { }

        public Marca(int idMarca, int descripcion, bool activo)
        {
            this.idMarca = idMarca;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
