using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BOL
{
    class MarcaDAL
    {
        //Singleton
        private static volatile MarcaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private MarcaDAL() { }

        public static MarcaDAL Instace()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new TallaDAL();
            return instance;
        }

        public int Add(Marca marca)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@descripcion", marca.descripcion);
                parametros[1] = new SqlParameter("@activo", marca.activo);
                string query = "stp_marcas_updateadd";
                return dataAccess.Execute(query, parametros);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Add\n" + ex.Message);
            }
        }
    }
}
