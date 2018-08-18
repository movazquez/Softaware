using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Producto
    {
        public int idProducto { get; set; }

        public String estilo { get; set; }

        public int idMarca { get; set; }

        public int idColor { get; set; }

        public String descripcion { get; set; }

        public decimal costo { get; set; }

        public String status { get; set; }

        public bool activo { get; set; }

        public int idLinea { get; set; }

        public DateTime fechaAlta { get; set; }

        public int tallaIni { get; set; }

        public int tallaFin { get; set; }

        public int pCentral { get; set; }

        public bool manejaMedio{ get; set; }

        public int idCategoria { get; set; }

        public String lateral { get; set; }

        public String superior { get; set; }

        public String inferior { get; set; }

        public String grafico { get; set; }

        public DateTime fechaMod { get; set; }

        public Producto() { }

        public Producto(int idProducto, string estilo, int idMarca, int idColor, string descripcion, decimal costo, string status, bool activo, int idLinea, DateTime fechaAlta, int tallaIni, int tallaFin, int pCentral, bool manejaMedio, int idCategoria, string lateral, string superior, string inferior, string grafico, DateTime fechaMod)
        {
            this.idProducto = idProducto;
            this.estilo = estilo;
            this.idMarca = idMarca;
            this.idColor = idColor;
            this.descripcion = descripcion;
            this.costo = costo;
            this.status = status;
            this.activo = activo;
            this.idLinea = idLinea;
            this.fechaAlta = fechaAlta;
            this.tallaIni = tallaIni;
            this.tallaFin = tallaFin;
            this.pCentral = pCentral;
            this.manejaMedio = manejaMedio;
            this.idCategoria = idCategoria;
            this.lateral = lateral;
            this.superior = superior;
            this.inferior = inferior;
            this.grafico = grafico;
            this.fechaMod = fechaMod;
        }
    }
}
