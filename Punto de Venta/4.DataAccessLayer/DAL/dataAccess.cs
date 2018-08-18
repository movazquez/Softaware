using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;

namespace DAL
{
    public class DataAccess
    {
        #region "Singleton Patron"
        private static volatile DataAccess instance = null;
        private static readonly object padlock = new object();
        public string InitialCatalog = "";
        public string DataSource = "";
        public string UserID = "";
        public string Password = "";
        public string conString = "";
        private byte[] Clave = Encoding.ASCII.GetBytes("Maa56327328");//Propia
        private byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");


        private DataAccess() { }

        public static DataAccess Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new DataAccess();
            return instance;
        }
        #endregion
        #region "Query/Execute"
        public DataTable Query(string query)//consultas
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 })
            {
                con.Open();
                DataTable resultado = new DataTable();
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public DataTable Query(string query, SqlParameter[] parametros)//consultas con parametros
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 })
            {
                con.Open();
                DataTable resultado = new DataTable();
                cmd.Parameters.AddRange(parametros);
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public int Execute(string query, SqlParameter[] parametros)//insert/update/delete
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 })
            {
                con.Open();
                cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region "MIsc"
        public bool TryCon()
        {
            try
            {
                conString = string.Format("Data Source={0};Initial Catalog?{1};Persist Security Info=True;User ID={2};Password={3}",
                    DecryptText(DataSource), DecryptText(InitialCatalog), DecryptText(UserID), DecryptText(Password));
                var con = new SqlConnection(conString);
                con.Open();
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public string GetIPServer()
        {
            return conString;
        }

        private string DecryptText(string textencrypted)
        {
            byte[] inputBytes = Convert.FromBase64String(textencrypted);
            byte[] resultBytes = new byte[inputBytes.Length];
            string decrypted = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        decrypted = sr.ReadToEnd();
                    }
                }
            }
            return decrypted;
        }
        #endregion
    }
}