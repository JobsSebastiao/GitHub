using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace TitaniumColector.Classes.SqlServer
{
    static class CeSqlServerConn
    {

	    //'sqlCE
	    private static SqlCeConnection sqlCeConn = new SqlCeConnection();
        private static SqlCeTransaction transacaoCe;
        private static string nomeDataBase;
        private static string strConnectionCe;
        private static string strPasswordCe;

	    #region "SqlCE"

	    private static string BancoCe {
		    get { return nomeDataBase; }
		    set {
			    if ((!string.IsNullOrEmpty(value))) {
				    nomeDataBase = value;
			    }
		    }
	    }

	    private static string  PasswordCe {
		    get { return strPasswordCe; }
		    set {
			    if ((!string.IsNullOrEmpty(value))) {
				    strPasswordCe = value;
			    }
		    }
	    }

	    public static string StringConectionCe {
		    get { return strConnectionCe; }
	    }

	    public static void createStringConectionCe( string dataBaseName,string password)
	    {
            BancoCe = dataBaseName;
            PasswordCe = password;

		    if ((!string.IsNullOrEmpty(BancoCe) & !string.IsNullOrEmpty(PasswordCe))) {
			    strConnectionCe = "Persist Security Info = False;" + "data source = " + BancoCe + ";" + "Password = " + PasswordCe + ";" + "Max Database Size = 256;" + "Max Buffer Size = 1024;";
		    }
	    }


	    public static SqlCeConnection openConnCe()
	    {
		    try {
                if ((sqlCeConn.State == ConnectionState.Closed))
                {
                    string strConn = StringConectionCe;
                    sqlCeConn = new SqlCeConnection(strConn);
                    sqlCeConn.Open();
                    return sqlCeConn;
                }
                else 
                {
                    throw new Exception("Error.");
                }
		    } catch (Exception ex) {
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }

	    public static void closeConnCe()
	    {
		    try {
			    if ((sqlCeConn.State == ConnectionState.Open)) {
				    sqlCeConn.Close();
				    
			    }
		    } catch (Exception ex) {
			  
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }

	    public static void createBDCe(string dataBase)
	    {
		    if (string.IsNullOrEmpty(dataBase)) {
			    MessageBox.Show("O dataBase não foi setado.");
		    } else {
			    BancoCe = dataBase;
		    }

		    try {
			    SqlCeEngine sqlEngine = new SqlCeEngine("data source=\\Temp\\" + BancoCe + ".sdf");
			    sqlEngine.CreateDatabase();
		    } catch (Exception ex) {
			    MessageBox.Show("Erro durante a criação da base de dados!! Motivo:" + ex.Message,"CreateDataBase",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
		    }
	    }

	    public static void fillDataSetCe(DataSet ds, string sql01)
	    {
		    try {
			    SqlCeDataAdapter da = new SqlCeDataAdapter(sql01, sqlCeConn);
			    da.Fill(ds);
		    } catch (Exception ex) {
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }


        public static void fillDataTableCe(DataTable dt, string sql01)
	    {
		    try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql01, openConnCe());
			    da.Fill(dt);
		    } catch (Exception ex) {
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }

	    public static SqlCeDataReader fillDataReaderCe(string sql01)
	    {

		    SqlCeCommand cmd = new SqlCeCommand(sql01, sqlCeConn);
		    SqlCeDataReader dr = cmd.ExecuteReader();
		    return dr;

	    }
        
	    public static void execCommandSqlCe(string sql01)
	    {
		    try {
			    SqlCeCommand cmd = new SqlCeCommand(sql01, openConnCe());
			    cmd.ExecuteNonQuery();
                closeConnCe();
		    } catch (Exception ex) {
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }

	    public static void beginTransactionCe()
	    {
		    try {
			    if ((sqlCeConn.State == ConnectionState.Open)) {
				    transacaoCe = sqlCeConn.BeginTransaction(IsolationLevel.ReadCommitted);
			    }
		    } catch (Exception ex) {
			    throw new Exception("Ocorre um problema na conexão com a base de dados." + Constants.vbCrLf + "Erro : " + ex.Message);
		    }

	    }


	    public static  void EndTransactionCe(ref bool flag)
	    {
		    if (flag == false) {
			    transacaoCe.Commit();
		    } else {
			    transacaoCe.Rollback();
		    }

	    }

	    #endregion

    }

}


