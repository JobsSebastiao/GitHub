using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using ColetorMobileTecware.ConnectionFactory;
using ColetorMobileTecware.Modelo;
using System.Web.Services.Protocols;


namespace ColetorMobileTecware
{
    public partial class frmLogin : Form
    {
 
        private void button1_Click(object sender, EventArgs e)
        {

        }

        public frmLogin()
        {
            InitializeComponent();
        }

        public void frmLogin_Load(object sender, EventArgs e)
        {
            configurarBaseMobile();
            insertProduto();

            DataTable dt = new DataTable ();

            CeSqlServerConn.fillDataTableCe(dt,"SELECT * FROM tb0001_Propostas");

            dataGrid1.DataSource=dt;
            
        }

        /// <summary>
        /// Configura a conexão com a base mobile.
        /// Caso a base de dados ainda não exista ela será criada
        /// </summary>
        public static void configurarBaseMobile()
        {
            //"\\Storage Cardw\\BaseMobile\\EngineMobile.sdf"
            if (System.IO.File.Exists("\\Program Files\\coletormobiletecware\\EngineMobile.sdf"))
            {
                //Configura a string de conexão com a base mobile.
                CeSqlServerConn.createStringConectionCe("\\Program Files\\coletormobiletecware\\EngineMobile.sdf", "tec9TIT16");
            }
            else
            {
                String dataSource = "\\Program Files\\coletormobiletecware\\EngineMobile.sdf";
                String senha = "tec9TIT16";
                String connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", dataSource, senha);
                SqlCeEngine SqlEng = new SqlCeEngine(connectionString);
                SqlEng.CreateDatabase();
                //Configura a string de conexão com a base mobile.
                CeSqlServerConn.createStringConectionCe(dataSource,senha);
                criarTabelas();
            }
        }
 
        /// <summary>
        /// Cria tabelas na base mobile.
        /// </summary>
        /// <remarks>A conexão com a base mobile já deve estar configurada.</remarks>
        public static void criarTabelas()
        {

            //TABELAS tb0001_Propostas
            StringBuilder sbQuery = new StringBuilder();
             sbQuery.Append("CREATE TABLE tb0001_Propostas (");
            sbQuery.Append("codigoPROPOSTA int not null CONSTRAINT PKPropostas Primary key,");
            sbQuery.Append("numeroPROPOSTA nvarchar(20) not null,");
            sbQuery.Append("dataliberacaoPROPOSTA nvarchar(20) not null,");
            sbQuery.Append("clientePROPOSTA int not null,");
            sbQuery.Append("razaoclientePROPOSTA nvarchar(200),");
            sbQuery.Append("volumesPROPOSTA smallint,");
            sbQuery.Append("operadorPROPOSTA int) ");
            CeSqlServerConn.execCommandSqlCe(sbQuery.ToString());

            //TABELAS tb0002_ItensProposta
            sbQuery.Length = 0;
            sbQuery.Append("CREATE TABLE tb0002_ItensProposta (");
            sbQuery.Append("codigoITEMPROPOSTA int not null CONSTRAINT PKItensProposta PRIMARY KEY,");
            sbQuery.Append("propostaITEMPROPOSTA int ,");
            sbQuery.Append("quantidadeITEMPROPOSTA real,");
            sbQuery.Append("statusseparadoITEMPROPOSTA smallint,");
            sbQuery.Append("codigoprodutoITEMPROPOSTA int,");
            sbQuery.Append("lotereservaITEMPROPOSTA int,");
            sbQuery.Append("xmlSequenciaITEMPROPOSTA nvarchar(500))");
            CeSqlServerConn.execCommandSqlCe(sbQuery.ToString());

            //TABELAS tb0003_Produtos
            sbQuery.Length = 0;
            sbQuery.Append("CREATE TABLE tb0003_Produtos (");
            sbQuery.Append("codigoPRODUTO				INT NOT NULL ,");
            sbQuery.Append("ean13PRODUTO				NVARCHAR(15) NOT NULL ,");
            sbQuery.Append("partnumberPRODUTO			NVARCHAR(100) ,");
            sbQuery.Append("descricaoPRODUTO			NVARCHAR(100) ,");
            sbQuery.Append("codigolotePRODUTO			INT,");
            sbQuery.Append("identificacaolotePRODUTO	NVARCHAR(100) ,");
            sbQuery.Append("codigolocalPRODUTO			INT , ");
            sbQuery.Append("nomelocalPRODUTO			NVARCHAR(100) )");
            CeSqlServerConn.execCommandSqlCe(sbQuery.ToString());

            //TABELAS tb0004_ETIQUETA
            sbQuery.Length = 0;
            sbQuery.Append("CREATE TABLE tb0004_Etiquetas (");
            sbQuery.Append("codigoETIQUETA				    INT IDENTITY(1,1) NOT NULL CONSTRAINT PKSequencia PRIMARY KEY,");
            sbQuery.Append("itempropostaETIQUETA			INT NOT NULL,");
            sbQuery.Append("volumeETIQUETA	      			INT NOT NULL,");
            sbQuery.Append("quantidadeETIQUETA	      		REAL NOT NULL,");
            sbQuery.Append("sequenciaETIQUETA    			INT NOT NULL)");
            CeSqlServerConn.execCommandSqlCe(sbQuery.ToString());

        }


        public void insertProduto()
        {

            try
            {
                //Limpa a tabela..
                CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0003_Produtos");

                for (int i = 0; i < 3;i++ )
                {
                    //Query de insert na Base Mobile
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO tb0003_Produtos ");
                    query.Append("(codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,");
                    query.Append("identificacaolotePRODUTO, codigolocalPRODUTO, nomelocalPRODUTO)");
                    query.Append("VALUES (");
                    query.AppendFormat("{0},", 12315);
                    query.AppendFormat("\'{0}\',", "01010101001101");
                    query.AppendFormat("\'{0}\',", "1510");
                    query.AppendFormat("\'{0}\',", "descricao louca ");
                    query.AppendFormat("{0},", 7854854);
                    query.AppendFormat("\'{0}\',", "1afsdadfa");
                    query.AppendFormat("{0},", 14251);
                    query.AppendFormat("\'{0}\')", "12adf");

                    CeSqlServerConn.execCommandSqlCe(query.ToString());
                }

            }
            catch (SqlCeException sqlEx)
            {
                System.Windows.Forms.MessageBox.Show("Erro durante a carga de dados na base Mobile tb0003_Produtos.\n Erro : " + sqlEx.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private Proposta fillTop1PropostaServidor()
        {

            SqlServerConn.makeStrConnection(true);

            Proposta objProposta = new Proposta();

            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            sbSql01.Append("clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA");
            sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
    

           System.Data.SqlClient.SqlDataReader dr = SqlServerConn.fillDataReader(sbSql01.ToString());

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                             Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], Convert.ToInt32(dr["volumesPROPOSTA"]));

                }
            }

            SqlServerConn.closeConn();

            return objProposta;

        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
             
        }

    }

}