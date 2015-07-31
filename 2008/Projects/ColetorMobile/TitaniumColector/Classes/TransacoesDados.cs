using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using TitaniumColector.SqlServer;
using TitaniumColector.Classes.SqlServer;
using System.Data;
using System.Data.SqlServerCe;

namespace TitaniumColector.Classes
{
    class TransacoesDados
    {
        private String sql01;
        private ProdutoProposta objItemProposta;
        private DataTable dt;

        #region "SELECTS"


        /// <summary>
        /// Recupera a proposta TOP 1 e devolve um objeto do tipo Proposta com as informações resultantes.
        /// </summary>
        /// <returns>Objeto do tipo Proposta</returns>
        public Proposta top1PropostaServidor()
        {
            Proposta objProposta = new Proposta();

            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            sbSql01.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = sbSql01.ToString();


            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                             Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"]);

                }
            }

            SqlServerConn.closeConn();

            return objProposta;

        }
         
        /// <summary>
        ///  Carrega uma List com objetos da classe ItemProposta preenchida com dados sobre os itens de uma determinada Proposta 
        /// </summary>
        /// <param name="codigoProposta">Código da proposta da qual serão recuperados os itens.</param>
        /// <returns>List do tipo ItemProposta </returns>
        public IEnumerable<ProdutoProposta> fillListItensProposta(int codigoProposta)
        {
            objItemProposta = new ProdutoProposta();

            List<ProdutoProposta> listItensProposta = new List<ProdutoProposta>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,");
            query.Append("ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD,loteRESERVA,localLOTELOCAL,nomeLOCAL ");
            query.Append("FROM tb1206_Reservas (NOLOCK) ");
            query.Append("INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA ");
            query.Append("INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO ");
            query.Append("INNER JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL ");
            query.Append("INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL ");
            query.AppendFormat("WHERE propostaITEMPROPOSTA = {0} ", codigoProposta);     //78527
            query.Append("AND tipodocRESERVA = 1602 ");
            query.Append("AND statusITEMPROPOSTA = 3 ");
            query.Append("AND separadoITEMPROPOSTA = 0  ");
            query.Append("GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,");
            query.Append("nomePRODUTO,partnumberPRODUTO,loteRESERVA,localLOTELOCAL,nomeLOCAL ");
            query.Append("ORDER BY nomeLOCAL ASC");
            this.sql01 = query.ToString();

            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    objItemProposta = new ProdutoProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]), Convert.ToInt32(dr["propostaITEMPROPOSTA"]), Convert.ToDouble(dr["QTD"]), ProdutoProposta.statusSeparado.NAOSEPARADO, Convert.ToInt32(dr["loteRESERVA"]),
                                                     Convert.ToInt32(dr["codigoPRODUTO"]), (string)dr["ean13PRODUTO"], (string)dr["partnumberPRODUTO"], (string)(dr["nomePRODUTO"]), Convert.ToInt32(dr["localLOTELOCAL"]), (String)dr["nomeLOCAL"]);


                    //Carrega a lista de itens que será retornada ao fim do procedimento.
                    listItensProposta.Add(objItemProposta);
                }
            }

            dr.Close();

            SqlServerConn.closeConn();

            return listItensProposta;
        }


        /// <summary>
        /// Preenche um objeto list com objetos da classe Produto 
        /// </summary>
        /// <param name="codigoProposta"></param>
        /// <returns></returns>
        public IEnumerable<Produto>  fillListProduto(Int32 codigoProposta) 
        {

            Produto objProd = new Produto();

            List<Produto> listProduto = new List<Produto>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT codigoPRODUTO,partnumberPRODUTO,nomePRODUTO,ean13PRODUTO,codigolotePRODUTO,identificacaolotePRODUTO,codigolocalPRODUTO,nomelocalPRODUTO ");
            query.AppendFormat("FROM dbo.fn0003_informacoesProdutos({0})", codigoProposta);
            query.Append(" ORDER BY nomelocalPRODUTO ASC ");

            SqlDataReader dr = SqlServerConn.fillDataReader(query.ToString());

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    objProd = new Produto(Convert.ToInt32(dr["codigoPRODUTO"]), (String)dr["ean13PRODUTO"], (String)dr["partnumberPRODUTO"],
                                         (String)dr["nomePRODUTO"], Convert.ToInt32(dr["codigolocalPRODUTO"]), (String)dr["nomelocalPRODUTO"],
                                          Convert.ToInt64(dr["codigolotePRODUTO"]), (String)dr["identificacaolotePRODUTO"]);


                    //Carrega a lista de itens que será retornada ao fim do procedimento.
                    listProduto.Add(objProd);
                }
            }

            dr.Close();

            SqlServerConn.closeConn();

            return listProduto;
        }


        private void buscaItensBaseMobile()
        {
            dt = new DataTable();

            StringBuilder stb = new StringBuilder();
            stb.Append("SELECT codigoITEMPROPOSTA, propostaITEMPROPOSTA, partnumberITEMPROPOSTA, nomeITEMPROPOSTA,");
            stb.Append("produtopedidoITEMPROPOSTA, quantidadeITEMPROPOSTA, ean13ITEMPROPOSTA,statusseparadoITEMPROPOSTA ");
            stb.Append(" FROM  tb0011_ItensProposta");
            CeSqlServerConn.fillDataTableCe(dt, stb.ToString());

        }

        public List<String> informacoesProposta() 
        {
            List<String> list = new List<String>();
 
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT PROP.codigoPROPOSTA AS CodProp, PROP.numeroPROPOSTA as NumProp, PROP.razaoclientePROPOSTA AS nomeCLIENTE, ");
            sbQuery.Append("SUM(ITEMPROP.quantidadeITEMPROPOSTA) AS qtdPECAS, ");
            sbQuery.Append("COUNT(*) AS qtdITENS ");
            sbQuery.Append("FROM tb0001_Propostas AS PROP ");        
            sbQuery.Append("INNER JOIN tb0002_ItensProposta AS ITEMPROP ON PROP.codigoPROPOSTA = ITEMPROP.propostaITEMPROPOSTA ");
            sbQuery.Append("GROUP BY PROP.codigoPROPOSTA, PROP.numeroPROPOSTA, PROP.razaoclientePROPOSTA ");
            sbQuery.ToString();

             SqlCeDataReader dr = CeSqlServerConn.fillDataReaderCe(sbQuery.ToString());

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    list.Add((String)dr["CodProp"]);
                    list.Add((String)dr["NumProp"]);
                    list.Add((String)dr["nomeCLIENTE"]);
                    list.Add((String)dr["qtdPECAS"]);
                    list.Add((String)dr["qtdITENS"]);

                }
            }

            SqlServerConn.closeConn();

            return list;
        }


        #endregion 

        #region "INSERTS"


        /// <summary>
        ///  Efetua carga na base mobile tb0001_Propostas com informações sobre a 
        ///  proposta top1 atualmente liberada no picking
        /// </summary>
        /// <param name="cat">Gatinho do método. </param>
        /// <remarks>Após realizar a consulta realiza a carga dos dados  na base mobile tabela TB0001_Propostas</remarks>
        public void insertTop1PropostaServidor(String cat)
        {

            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            sbSql01.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = sbSql01.ToString();


            SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {

                    this.insertProposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                             Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (int)(Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"], MainConfig.CodigoUsuarioLogado);

                }
            }

            SqlServerConn.closeConn();

        }

        /// <summary>
        /// Realiza o insert na tabela de Propostas
        /// </summary>
        /// <param name="codigoProposta">Código da Proposta</param>
        /// <param name="numeroProposta">Número da Proposta</param>
        /// <param name="dataliberacaoProposta">data de liberação da Proposta</param>
        /// <param name="clienteProposta">Código do cliente</param>
        /// <param name="razaoEmpreza">Nome da empreza cliente</param>
        /// <param name="ordemseparacaoimpresaProposta">Status 0 ou 1</param>
        /// <param name="usuarioLogado">Usuário logado</param>
        public void insertProposta(Int64 codigoProposta, string numeroProposta, string dataliberacaoProposta, Int32 clienteProposta,
                                    string razaoEmpreza, int ordemseparacaoimpresaProposta, int usuarioLogado)
        {

            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0001_Propostas");

            //Query de insert na Base Mobile
            StringBuilder query = new StringBuilder();
            query.Append("Insert INTO tb0001_Propostas VALUES (");
            query.AppendFormat("{0},", codigoProposta);
            query.AppendFormat("\'{0}\',", numeroProposta);
            query.AppendFormat("\'{0}\',", dataliberacaoProposta);
            query.AppendFormat("{0},", clienteProposta);
            query.AppendFormat("\'{0}\',", razaoEmpreza);
            query.AppendFormat("{0},", ordemseparacaoimpresaProposta);
            query.AppendFormat("{0})", usuarioLogado);
            sql01 = query.ToString();

            CeSqlServerConn.execCommandSqlCe(sql01);
        }

        /// <summary>
        /// Insert na base Mobile tabela de itens da proposta
        /// </summary>
        /// <param name="listProposta">List com objetos do tipo ItemProposta </param>
        public void insertItemProposta(List<ProdutoProposta> listProdutoProposta)
        {

            try
            {
                //Limpa a tabela..
                CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");

                foreach (var item in listProdutoProposta)
                {

                    //Query de insert na Base Mobile
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO tb0002_ItensProposta");
                    query.Append("(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,");
                    query.Append("statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA,localloteITEMPROPOSTA) ");
                    query.Append("VALUES (");
                    query.AppendFormat("{0},", item.CodigoItemProposta);
                    query.AppendFormat("{0},", item.PropostaItemProposta);
                    query.AppendFormat("{0},", item.Quantidade);
                    query.AppendFormat("{0},", (int)item.StatusSeparado);
                    query.AppendFormat("{0},", item.CodigoProduto);
                    query.AppendFormat("{0},", item.LotereservaItemProposta);
                    query.AppendFormat("{0})", item.CodigoLocalLote);
                    sql01 = query.ToString();

                    CeSqlServerConn.execCommandSqlCe(sql01);
                }

            }
            catch (SqlException sqlEx)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
                strBuilder.Append("O procedimento não pode ser concluído");
                strBuilder.AppendFormat("Erro : {0}", sqlEx.Errors);
                strBuilder.AppendFormat("Description : {0}", sqlEx.Message);

                MainConfig.errorMessage(strBuilder.ToString(), "SqlException!!");
            }
            catch (Exception Ex)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
                strBuilder.Append("O procedimento não pode ser concluído \n");
                strBuilder.AppendFormat("Description : {0}", Ex.Message);

                MainConfig.errorMessage(strBuilder.ToString(), "Error in Query!!");
            }
            
        }

        /// <summary>
        /// Realiza Insert na base Mobile table tb0002_ItensProposta
        /// </summary>
        /// <param name="codigoItem">Código do Item da Proposta</param>
        /// <param name="propostaItemProposta">Proposta (ForeingKey)</param>
        /// <param name="quantidade">Qunatidade de itens</param>
        /// <param name="statusSeparado">status (Separado ou não)</param>
        /// <param name="codigoProduto">Código do produto </param>
        /// <param name="loteReserva">Lote referente a reserva do item</param>
        public void insertItemProposta(Int64 codigoItem, Int64 propostaItemProposta, Double quantidade , ProdutoProposta.statusSeparado statusSeparado,
                                        Int64 codigoProduto,Int64 loteReserva, Int64 codigoLocalItemProposta)
        {
            try
            {
                //Limpa a tabela..
                CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");

                //Query de insert na Base Mobile
                StringBuilder query = new StringBuilder();
                query.Append("INSERT INTO tb0002_ItensProposta");
                query.Append("(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,");
                query.Append("statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA,localloteITEMPROPOSTA) ");
                query.Append("VALUES (");
                query.AppendFormat("{0},", codigoItem);
                query.AppendFormat("{0},", propostaItemProposta);
                query.AppendFormat("{0},", quantidade);
                query.AppendFormat("{0},", (int)statusSeparado);
                query.AppendFormat("{0},", codigoProduto);
                query.AppendFormat("{0},", loteReserva);
                query.AppendFormat("{0})", codigoLocalItemProposta);
                sql01 = query.ToString();

                CeSqlServerConn.execCommandSqlCe(sql01);

            }
            catch(SqlException sqlEx)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
                strBuilder.Append("O procedimento não pode ser concluído");
                strBuilder.AppendFormat("Erro : {0}", sqlEx.Errors);
                strBuilder.AppendFormat("Description : {0}", sqlEx.Message);
                System.Windows.Forms.MessageBox.Show(strBuilder.ToString(),"Error:",System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Exclamation,System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                throw;
            }

        }

         
        /// <summary>
        /// Efetua o insert na base mobile tb0003_Produtos 
        /// </summary>
        /// <param name="listProduto">List preenchida com objetos da classe Produto</param>
        public void insertProduto(List<Produto> listProduto)
        {

            try
            {
                //Limpa a tabela..
                CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0003_Produtos");

                foreach (var item in listProduto)
                {

                    //Query de insert na Base Mobile
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO tb0003_Produtos ");
                    query.Append("(codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,");
                    query.Append("identificacaolotePRODUTO, codigolocalPRODUTO, nomelocalPRODUTO)");
                    query.Append("VALUES (");
                    query.AppendFormat("{0},", item.CodigoProduto );
                    query.AppendFormat("\'{0}\',", item.Ean13);
                    query.AppendFormat("\'{0}\',", item.Partnumber);
                    query.AppendFormat("\'{0}\',", item.Descricao);
                    query.AppendFormat("{0},", item.CodigoLoteProduto);
                    query.AppendFormat("\'{0}\',", item.IdentificacaoLoteProduto);
                    query.AppendFormat("{0},", item.CodigoLocalLote);
                    query.AppendFormat("\'{0}\')", item.NomeLocalLote);
                    sql01 = query.ToString();

                    CeSqlServerConn.execCommandSqlCe(sql01);
                }

            }
            catch (SqlException sqlEx)
            {
                System.Windows.Forms.MessageBox.Show("Erro durante a carga de dados na base Mobile tb0003_Produtos.\n Erro : " + sqlEx.Message);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion 


   #region "DELETES"


        public void clearBaseMobile()
        {

            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0001_Propostas");
            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");
            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0003_Produtos");

        }


   #endregion


    #region "CRIACAO BASE MOBILE "


        public static String CriarDataBaseMobile()
        {
            if (System.IO.File.Exists("\\Program File\\TitaniumColector\\EngineMobile.sdf"))
            {
                return String.Format("{0},{1}", "\\Program Files\\Connections\\EngineMobile.sdf", "tec9TIT16");
            }
            else
            {
                String dataSource = "\\Program Files\\Connections\\EngineMobile.sdf";
                String senha = "tec9TIT16";
                String connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", dataSource, senha);
                SqlCeEngine SqlEng = new SqlCeEngine(connectionString);
                SqlEng.CreateDatabase();
                return String.Format("{0},{1}", dataSource, senha);
            }

        }


    #endregion

        //SELECT        codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA, statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA
        //FROM            tb0002_ItensProposta


        //UPDATE       tb0002_ItensProposta
        //SET                codigoITEMPROPOSTA =, propostaITEMPROPOSTA =, quantidadeITEMPROPOSTA =, statusseparadoITEMPROPOSTA =, codigoprodutoITEMPROPOSTA =, lotereservaITEMPROPOSTA =


        //
        //SELECT * from dbo.fn0003_informacoesProdutos(75899) ORDER BY nomelocalPRODUTO ASC


    }
}
