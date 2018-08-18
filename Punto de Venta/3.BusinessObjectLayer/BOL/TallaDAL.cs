using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BOL
{
    class TallaDAL
    {
        //Singleton
        private static volatile TallaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private TallaDAL() { }

        public static TallaDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new TallaDAL();
            return instance;
        }

        public int Add(Talla talla)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@descripcion", talla.descripcion);
                parametros[1] = new SqlParameter("@activo", talla.activo);
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
