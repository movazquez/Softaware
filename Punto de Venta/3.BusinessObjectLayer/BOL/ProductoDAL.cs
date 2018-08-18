using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class ProductoDAL
    {
        //Singleton
        private static volatile ProductoDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private ProductoDAL() { }

        public static ProductoDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ProductoDAL();
            return instance;
        }

        public int Add(Producto producto)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[19];
                parametros[0] = new SqlParameter("@estilo", producto.estilo);
                parametros[1] = new SqlParameter("@idmarca", producto.idMarca);
                parametros[2] = new SqlParameter("@idcolor", producto.idColor);
                parametros[3] = new SqlParameter("@descripcion", producto.descripcion);
                parametros[4] = new SqlParameter("@costo", producto.costo);
                parametros[5] = new SqlParameter("@status", producto.status);
                parametros[6] = new SqlParameter("@activo", producto.activo);
                parametros[7] = new SqlParameter("@idlinea", producto.idLinea);
                parametros[8] = new SqlParameter("@fechaalta", producto.fechaAlta);
                parametros[9] = new SqlParameter("@tallaini", producto.tallaIni);
                parametros[10] = new SqlParameter("@tallafin", producto.tallaFin);
                parametros[11] = new SqlParameter("@pcentral", producto.pCentral);
                parametros[12] = new SqlParameter("@manejamedio", producto.manejaMedio);
                parametros[13] = new SqlParameter("@idcategoria", producto.idCategoria);
                parametros[14] = new SqlParameter("@lateral", producto.lateral);
                parametros[15] = new SqlParameter("@superior", producto.superior);
                parametros[16] = new SqlParameter("@inferior", producto.inferior);
                parametros[17] = new SqlParameter("@grafico", producto.grafico);
                parametros[18] = new SqlParameter("@fechamod", producto.fechaMod);
                string query = "stp_productos_updateadd";
                return dataAccess.Execute(query, parametros);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Add\n" + ex.Message);
            }
        }
    }
}
