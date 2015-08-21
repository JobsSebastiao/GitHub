using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using System.IO;
using Microsoft.VisualBasic;
using System.Configuration;


/// <summary>
/// Summary description for ConnctionFactory
/// </summary>
public class ConnectionFactory
{
	
        private static SqlConnection  conn = null;
        private static SqlTransaction transaction = null;
        private static string strPassword;
        private static string strUserId;
        private static string booSecurity;
        private static string strCatalog;
        private static string strDataSource;
        private static string strConnection;

        public ConnectionFactory() 
        {
           
        }

    #region "Get & Set"

        private static string Password
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

        private static string Security
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

        private static string UserId
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

        private static string Catalog
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

        private static string DataSource
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

        private static string StringConection
        {
            get { return strConnection; }
        }


        #endregion //Get & Set

        /// <summary>
        /// Recupera todos aos parâmetros informados e configura a string de conexão.
        /// </summary>
        private static void makeStrConnection()
        {
            ConnectionFactory.strConnection = "Password=" + Password + ";Persist Security Info=" + Security + ";User ID=" + UserId + ";Initial Catalog=" + Catalog + ";Data Source=" + DataSource;
        }

        private static void makeStrConnection(String strConn) 
        {
            ConnectionFactory.strConnection = strConn;
        }

        public static SqlConnection openConn()
        {
            configuraStrConnection();
            //makeStrConnection(ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString);
            conn = new SqlConnection(StringConection);

            try
            {
                conn.Open();
            }  
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }

            return conn;
        }

        /// <summary>
        /// Testa a conexão com o banco de dados SQLSERVER.
        /// </summary>
        /// <returns>True caso a conexão esteja OK.</returns>
        /// <exception cref="System.SqlException">Caso não seja possível se comunicar com o banco de dados.</exception>
        public static bool testConnection() 
        {
            bool result = false;

            try
            {
                if (openConn().State == ConnectionState.Open)
                {
                    result = true;
                }

                if (result == true) 
                {
                    closeConn();

                    if (conn.State == ConnectionState.Closed)
                    {
                        result = true;
                    }

                }

                return result;
            }
            catch(SqlException) 
            {
                conn = null;
                throw;
            }
            
        }

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
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql01, openConn());
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

        public static void fillDataTable(DataTable dt, string sql01,SqlConnection conn)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql01, conn);
                da.Fill(dt);

            }
            catch (SqlException sqlEx)
            {
                if ((sqlEx.Number == 11))
                {
                    throw new Exception("Não foi possível se comunicar com a base de dados devido problemas com a rede." + Environment.NewLine + "Erro : " + sqlEx.Message + Environment.NewLine + "Number:" + sqlEx.Number);
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
            try
            {
                SqlCommand cmd = new SqlCommand(sql01, openConn());
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }

        public static void execCommandSql(string sql01)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql01, openConn());
                cmd.ExecuteNonQuery();
            }
            catch (SqlException )
            {
                throw new Exception();
                //throw new SqlQueryExceptions("Error durante acesso a base de dados!!");
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


        public static void configuraStrConnection(String StringConexao)
        {
            string strConnection = StringConexao;
            string[] arrayStrConnection = FileUtility.arrayOfTextFile(strConnection, FileUtility.splitType.PONTO_VIRGULA);
            setParametersStringConnection(arrayStrConnection);
        }

        public static void configuraStrConnection() 
        {
            string strConnection = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
            string[] arrayStrConnection = FileUtility.arrayOfTextFile(strConnection,FileUtility.splitType.PONTO_VIRGULA);
            setParametersStringConnection(arrayStrConnection);
        }

        /// <summary>
        /// Monta a string de conexão a partir de um array contendo os dados nescessários.
        /// </summary>
        /// 
        /// <param name="array"> Array preenchido com o padrão sql de string de conexão</param>
        /// 
        /// <exemplo>
        ///  Itens padrão a ser usada : 
        ///  Provider=SQLOLEDB.1
        ///  Password=senha
        ///  Persist Security Info=False/True
        ///  User ID=usuario
        ///  Initial Catalog=basededados
        ///  Data Source=ip
        /// </exemplo>
        public static void setParametersStringConnection(string[] array)
        {
            foreach (string item in array)
            {

                string strItem = item.Substring(0, item.IndexOf("=", 0));

                if (strItem == "Password")
                {
                    Password = item.Substring(item.IndexOf("=", 0) + 1);
                }
                else if (strItem == "Persist Security Info")
                {
                    Security = item.Substring(item.IndexOf("=", 0) + 1);
                }
                else if (strItem == "User ID")
                {
                    UserId = item.Substring(item.IndexOf("=", 0) + 1);
                }
                else if (strItem == "Initial Catalog")
                {
                    Catalog = item.Substring(item.IndexOf("=", 0) + 1);
                }
                else if (strItem == "Data Source")
                {
                    DataSource = item.Substring(item.IndexOf("=", 0) + 1);
                }
            }

	        //'Monta a string de conexão
	        makeStrConnection();

        }


        /// <summary>
        /// Redefine os atributos da string de conexão
        /// </summary>
        /// <param name="strPassword">Senha</param>
        /// <param name="strUserID">Usuário</param>
        /// <param name="strInitialCatalog">Base de dados</param>
        /// <param name="strDataSource">IP/HostName</param>
        /// <param name="booSecurity">True ou False</param>
        /// <remarks></remarks>
        public static void setParametersStringConnection(string strPassword, string strUserID, string strInitialCatalog, string strDataSource, string booSecurity)
        {
	        //'Monta a string de conexão
	        Password= strPassword;
	        UserId = strUserID;
	        Catalog = strCatalog;
	        DataSource = strDataSource;
	        Security = booSecurity;
	        makeStrConnection();

        }

}
