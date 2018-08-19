using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BOL
{
    class CategoriaDAL
    {
        //Singleton
        private static volatile CategoriaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private CategoriaDAL() { }

        public static CategoriaDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new TallaDAL();
            return instance;
        }

        public int Add(Categoria categoria)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@descripcion", categoria.descripcion);
                parametros[1] = new SqlParameter("@activo", categoria.activo);
                string query = "stp_tallas_updateadd";
                return dataAccess.Execute(query, parametros);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Add\n" + ex.Message);
            }
        }
    }
}
