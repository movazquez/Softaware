using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Categoria
    {
        public int idCategoria { get; set; }

        public int descripcion { get; set; }

        public bool activo { get; set; }

        public Categoria() { }

        public Categoria(int idCategoria, int descripcion, bool activo)
        {
            this.idCategoria = idCategoria;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
