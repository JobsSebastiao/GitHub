using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace TitaniumColector.SqlServer
{
    static class SqlServerConn
    {
        private static SqlConnection  conn = null;
        private static SqlTransaction transaction = null;

        private static string strPassword;
        private static string strUserId;
        private static string booSecurity;
        private static string strCatalog;
        private static string strDataSource;
        private static string strConnection;



        #region "Get & Set"


        public static string Password
        {
            get { return strPassword; }

            set
            {
                if ((!string.IsNullOrEmpty(value)))
                {
                    strPassword = value.Trim();
                }
            }
        }

        public static string Security
        {
            get { return booSecurity; }

            set
            {
                if ((!string.IsNullOrEmpty(value)))
                {
                    booSecurity = value;
                }
            }
        }

        public static string UserId
        {
            get { return strUserId; }

            set
            {
                if ((!string.IsNullOrEmpty(value)))
                {
                    strUserId =  value.Trim();
                }
            }
        }

        public static string Catalog
        {
            get { return strCatalog; }

            set
            {
                if ((!string.IsNullOrEmpty(value)))
                {
                    strCatalog = value.Trim();
                }
            }
        }

        public static string DataSource
        {
            get { return strDataSource; }

            set
            {
                if ((!string.IsNullOrEmpty(value)))
                {
                    strDataSource = value.Trim();
                }
            }
        }

        public static string StringConection
        {
            get { return strConnection; }
        }


        #endregion //Get & Set


        private static void setStrConnection()
        {
            SqlServerConn.strConnection = "Password=" + Password + ";Persist Security Info=" + Security + ";User ID=" + UserId + ";Initial Catalog=" + Catalog + ";Data Source=" + DataSource;
        }


        public static SqlConnection openConn()
        {
            conn = new SqlConnection(StringConection);

            try
            {
                conn.Open();
            }
            catch (SqlException sqlEx)
            {
                conn = null;
                StringBuilder bdMsg = new StringBuilder();
                bdMsg.Append("Ocorreu um problema durante a tentativa de conexão com a base de dados!");
                bdMsg.AppendLine();
                bdMsg.Append("Description :" + sqlEx.Message);
                bdMsg.AppendLine();
                bdMsg.Append("Source :" + sqlEx.Source);
                string msg = bdMsg.ToString();

                MessageBox.Show(msg, "Conection Error.");
                throw;
            }

            return conn;
        }

        //public static void openConn()
        //{
        //    try
        //    {
        //        if ((conn.State == Data.ConnectionState.Closed))
        //        {
        //            string strConn = StringConection();
        //            conn = new connection(strConn);
        //            conn.Open();
        //        }

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        throw new Exception("Ocorre um problema durante a conexão com a base de dados. " + Environment.NewLine + " Erro: " + sqlEx.Message + " Source: " + sqlEx.Source + " Number: " + sqlEx.Number);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ocorre um problema durante a interação com a base de dados" + Environment.NewLine + "Erro: " + ex.Message);
        //    }

        //}


        public static void closeConn()
        {
            try
            {
                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorre um problema na conexão com a base de dados." +  "Erro : " + ex.Message);
            }

        }


        public static void fillDataSet(DataSet ds, string sql01)
        {

            openConn();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql01, conn);
                da.Fill(ds);
                closeConn();
            }
            catch (Exception ex)
            {
                closeConn();
                throw new Exception("Ocorre um problema na conexão com a base de dados." + Environment.NewLine + "Erro : " + ex.Message);
            }

        }


        public static void fillDataTable(DataTable dt, string sql01)
        {
            openConn();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql01, conn);
                da.Fill(dt);

            }
            catch (SqlException sqlEx)
            {
                if ((sqlEx.Number == 11))
                {
                    throw new Exception("Não foi possível se comunicar com a base de dados devido problemas com a rede." + Environment.NewLine  + "Erro : " + sqlEx.Message + Environment.NewLine + "Number:" + sqlEx.Number);
                }
                else
                {
                    throw new Exception("Problemas durante a carga do DataTable:" + Environment.NewLine + "Erro : " + sqlEx.Message + Environment.NewLine + "Number:" + sqlEx.Number);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorre um problema na conexão com a base de dados." + Environment.NewLine + "Erro : " + ex.Message);

            }
            finally
            {
                closeConn();
            }

        }


        public static SqlDataReader fillDataReader(string sql01)
        {

            openConn();
            SqlCommand cmd = new SqlCommand(sql01, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.FieldCount > 0)
            {
            }

            return dr;

            closeConn();

        }

        public static void execCommandSql(string sql01)
        {
            openConn();

            try
            {
                SqlCommand cmd = new SqlCommand(sql01, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorre um problema na conexão com a base de dados." + Environment.NewLine + "Erro : " + ex.Message);
            }
            finally
            {
                closeConn();
            }

        }


        public static void beginTransaction()
        {
            openConn();

            try
            {
                if ((conn.State == ConnectionState.Open))
                {
                    transaction= conn.BeginTransaction(IsolationLevel.ReadCommitted);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorre um problema na conexão com a base de dados." + Environment.NewLine + "Erro : " + ex.Message);
            }
            finally
            {
                closeConn();
            }

        }


        public static void EndTransaction(ref bool flag)
        {
            if (flag == false)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

        }

                
        public static void configStringConnection()
        {
	        setStrConnection();
        }


        /// <summary>
        /// Monta a string de conexão a partir de um array contendo os dados nescessários.
        /// </summary>
        /// <param name="array"> Array preenchido com o padrão sql de string de conexão</param>
        /// <exemplo>
        /// 
        ///  Itens padrão a ser usada : 
        ///  Provider=SQLOLEDB.1
        ///  Password=senha
        ///  Persist Security Info=False/True
        ///  User ID=usuario
        ///  Initial Catalog=basededados
        ///  Data Source=ip
        /// 
        /// </exemplo>

        public static void configStringConnection(string[] array)
        {
	        foreach (string item in array) {
		        switch (item.Substring(0, item.IndexOf("=",0) - 1)) {
			        case "Password":
                        Password = item.Substring (item.IndexOf("=",0));
				        break;
			        case "Persist Security Info":
                        Security = item.Substring(item.IndexOf("=", 0));
				        break;
			        case "User ID":
                        UserId = item.Substring(item.IndexOf("=", 0));
				        break;
			        case "Initial Catalog":
                        Catalog = item.Substring(item.IndexOf("=", 0));
				        break;
			        case "Data Source":
                        DataSource = item.Substring(item.IndexOf("=", 0));
				        break;
		        }
	        }

	        //'Monta a string de conexão
	        setStrConnection();

        }


        /// <summary>
        /// Redefine os atributos da string de conexão
        /// </summary>
        /// <param name="strPassword"></param>
        /// <param name="strUserID"></param>
        /// <param name="strInitialCatalog"></param>
        /// <param name="strDataSource"></param>
        /// <param name="booSecurity">Optional ---True or False</param>
        /// <remarks></remarks>
        public static void configStringConnection(string strPassword, string strUserID, string strInitialCatalog, string strDataSource,string booSecurity)
        {
	        //'Monta a string de conexão
	        Password= strPassword;
	        UserId = strUserID;
	        Catalog = strCatalog;
	        DataSource = strDataSource;
	        Security = booSecurity;
	        setStrConnection();

        }

    }  
}
