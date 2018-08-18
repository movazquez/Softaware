using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BOL
{
    public class ColorDAL
    {
        //Singleton
        private static volatile ColorDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();
  
        private ColorDAL() { }

        public static ColorDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ColorDAL();
            return instance;
        }

        public int Add(Color color)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@descripcion", color.descripcion);
                parametros[1] = new SqlParameter("@activo", color.activo);
                string query = "stp_colores_updateadd";
                return dataAccess.Execute(query, parametros);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Add\n" + ex.Message);
            }
        }
    }
}
