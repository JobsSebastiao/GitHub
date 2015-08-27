using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using TitaniumColector.SqlServer;
using TitaniumColector.Classes.SqlServer;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using TitaniumColector.Classes.Exceptions;

namespace TitaniumColector.Classes
{
    class  BaseMobile
    {
        private static StringBuilder sql01;

    #region "TRANSFIRIDOS PARA CLASSES DAO"

        ///// <summary>
        ///// Preenche um objeto do tipo Proposta com todas as suas informações e com o item Top 1 da base de dados MOBILE
        ///// de acordo com o campo Nome Local e o status de separado = 0; (NAOSEPARADO)
        ///// </summary>
        ///// <returns>Objeto do tipo Proposta</returns>
        //public Proposta fillPropostaWithTop1Item()
        //{
        //    Proposta objProposta = null;

        //    List<ProdutoProposta> listProd = new List<ProdutoProposta>();

        //    StringBuilder sbQuery = new StringBuilder();

        //    //ESTAVA CAUSANDO DUPLICIDADE DE ITENS DA PROPOSTA>

        //    //sbQuery.Append(" SELECT TOP (1) TB_PROP.codigoPROPOSTA, TB_PROP.numeroPROPOSTA, TB_PROP.dataliberacaoPROPOSTA,TB_PROP.clientePROPOSTA, TB_PROP.razaoclientePROPOSTA,TB_PROP.ordemseparacaoimpressaPROPOSTA,");
        //    //sbQuery.Append(" TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA, TB_ITEMPROPOP.statusseparadoITEMPROPOSTA,");
        //    //sbQuery.Append(" TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA,");
        //    //sbQuery.Append(" TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, TB_PROD.identificacaolotePRODUTO, TB_PROD.codigolotePRODUTO, TB_PROD.codigolocalPRODUTO,");
        //    //sbQuery.Append(" TB_PROD.nomelocalPRODUTO");
        //    //sbQuery.Append(" FROM   tb0001_Propostas AS TB_PROP ");
        //    //sbQuery.Append(" INNER JOIN tb0002_ItensProposta AS TB_ITEMPROPOP ON TB_PROP.codigoPROPOSTA = TB_ITEMPROPOP.propostaITEMPROPOSTA");
        //    //sbQuery.Append(" INNER JOIN tb0003_Produtos AS TB_PROD ON TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA = TB_PROD.codigoPRODUTO");
        //    //sbQuery.Append(" WHERE TB_ITEMPROPOP.statusseparadoITEMPROPOSTA = 0");
        //    //sbQuery.Append(" ORDER BY TB_PROD.nomelocalPRODUTO ASC");
        //    //sql01 =  sbQuery.ToString();

        //    sbQuery.Append(" SELECT TOP (1) TB_PROP.codigoPROPOSTA, TB_PROP.numeroPROPOSTA, TB_PROP.dataliberacaoPROPOSTA,TB_PROP.clientePROPOSTA, TB_PROP.razaoclientePROPOSTA,");
        //    sbQuery.Append("TB_PROP.volumesPROPOSTA,");
        //    sbQuery.Append("TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA, TB_ITEMPROPOP.statusseparadoITEMPROPOSTA,");
        //    sbQuery.Append("TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA,");
        //    sbQuery.Append("TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, TB_PROD.identificacaolotePRODUTO, TB_PROD.codigolotePRODUTO,TB_PROD.nomelocalPRODUTO");
        //    sbQuery.Append(" FROM   tb0001_Propostas AS TB_PROP ");
        //    sbQuery.Append(" INNER JOIN tb0002_ItensProposta AS TB_ITEMPROPOP ON TB_PROP.codigoPROPOSTA = TB_ITEMPROPOP.propostaITEMPROPOSTA ");
        //    sbQuery.Append(" INNER JOIN tb0003_Produtos AS TB_PROD ON TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA = TB_PROD.codigoPRODUTO ");
        //    sbQuery.Append(" WHERE TB_ITEMPROPOP.statusseparadoITEMPROPOSTA = 0 ");
        //    sbQuery.Append(" GROUP BY TB_PROP.codigoPROPOSTA, TB_PROP.numeroPROPOSTA, TB_PROP.dataliberacaoPROPOSTA,TB_PROP.clientePROPOSTA, TB_PROP.razaoclientePROPOSTA,");
        //    sbQuery.Append("TB_PROP.volumesPROPOSTA,");
        //    sbQuery.Append("TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA, TB_ITEMPROPOP.statusseparadoITEMPROPOSTA,");
        //    sbQuery.Append("TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA,");
        //    sbQuery.Append("TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, TB_PROD.identificacaolotePRODUTO, TB_PROD.codigolotePRODUTO,TB_PROD.nomelocalPRODUTO");
        //    sbQuery.Append(" ORDER BY nomelocalPRODUTO ASC");
        //    sql01 = sbQuery.ToString();

        //    SqlCeDataReader dr = CeSqlServerConn.fillDataReaderCe(sql01);

        //    int i = 0;

        //    if ((dr != null))
        //    {
        //        while ((dr.Read()))
        //        {
        //            i++;
        //            if (i == 1)
        //            {
        //                objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
        //                                           Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoclientePROPOSTA"], Convert.ToInt32(1));

        //            }

        //            int statusSeparadoItem = Convert.ToInt32(dr["statusseparadoITEMPROPOSTA"]);
        //            ProdutoProposta objProdProp = new ProdutoProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]),
        //                                                                Convert.ToInt32(objProposta.Codigo),
        //                                                                Convert.ToDouble(dr["quantidadeITEMPROPOSTA"]),
        //                                                                (ProdutoProposta.statusSeparado)statusSeparadoItem,
        //                                                                Convert.ToInt32(dr["lotereservaITEMPROPOSTA"]),
        //                                                                Convert.ToInt32(dr["codigoprodutoITEMPROPOSTA"]),
        //                                                                (string)dr["ean13PRODUTO"],
        //                                                                (string)dr["partnumberPRODUTO"],
        //                                                                (string)dr["descricaoPRODUTO"],
        //                                                                (string)dr["nomelocalPRODUTO"],
        //                                                                Convert.ToInt32(dr["codigolotePRODUTO"]),
        //                                                                (string)dr["identificacaolotePRODUTO"]);

        //            listProd.Add(objProdProp);
        //        }

        //        objProposta = new Proposta(objProposta, listProd);

        //    }

        //    CeSqlServerConn.closeConnCe();

        //    return objProposta;
        //}


        ///// <summary>
        ///// Preenche um objeto List com informações sobre a proposta que está sendo trabalhada.
        ///// </summary>
        ///// <returns>Objeto List do tipo String com informações da atual proposta na base de dados mobile.</returns>
        ///// <remarks>
        /////            O list contém as seguintes informações
        /////            list.Add(dr["CodProp"].ToString());
        /////            list.Add(dr["NumProp"].ToString());
        /////            list.Add(dr["nomeCLIENTE"].ToString());
        /////            list.Add(dr["qtdPECAS"].ToString());
        /////            list.Add(dr["qtdITENS"].ToString());
        ///// </remarks>
        //public List<String> fillInformacoesProposta()
        //{
        //    List<String> list = new List<String>();

        //    StringBuilder sbQuery = new StringBuilder();
        //    sbQuery.Append("SELECT PROP.codigoPROPOSTA AS CodProp, PROP.numeroPROPOSTA as NumProp, PROP.razaoclientePROPOSTA AS nomeCLIENTE, ");
        //    sbQuery.Append("SUM(ITEMPROP.quantidadeITEMPROPOSTA) AS qtdPECAS, ");
        //    sbQuery.Append("COUNT(*) AS qtdITENS,PROP.volumesPROPOSTA AS qtdVOLUMES ");
        //    sbQuery.Append("FROM tb0001_Propostas AS PROP ");
        //    sbQuery.Append("INNER JOIN tb0002_ItensProposta AS ITEMPROP ON PROP.codigoPROPOSTA = ITEMPROP.propostaITEMPROPOSTA ");
        //    sbQuery.Append("GROUP BY PROP.codigoPROPOSTA, PROP.numeroPROPOSTA, PROP.razaoclientePROPOSTA,PROP.volumesPROPOSTA");
        //    sbQuery.ToString();

        //    SqlCeDataReader dr = CeSqlServerConn.fillDataReaderCe(sbQuery.ToString());

        //    if ((dr.FieldCount > 0))
        //    {
        //        while ((dr.Read()))
        //        {
        //            list.Add(dr["CodProp"].ToString());
        //            list.Add(dr["NumProp"].ToString());
        //            list.Add(dr["nomeCLIENTE"].ToString());
        //            list.Add(dr["qtdPECAS"].ToString());
        //            list.Add(dr["qtdITENS"].ToString());
        //            list.Add(dr["qtdVOLUMES"].ToString());

        //        }
        //    }

        //    SqlServerConn.closeConn();

        //    return list;
        //}



        //public String recuperarLocalEstoqueProduto(int produto, int lote)
        //{
        //    string nomesLocais = "";
        //    StringBuilder sbQuery = new StringBuilder();
        //    sbQuery.Append(" SELECT nomeLOCAL ");
        //    sbQuery.Append(" FROM tb1205_Lotes ");
        //    sbQuery.Append(" INNER JOIN tb1212_Lotes_Locais ON codigoLOTE = loteLOTELOCAL ");
        //    sbQuery.Append(" INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL ");
        //    sbQuery.AppendFormat(" WHERE produtoLOTE ={0} AND codigoLOTE = {1} ", produto, lote);

        //    SqlDataReader dr = SqlServerConn.fillDataReader(sbQuery.ToString());

        //    while ((dr.Read()))
        //    {
        //        nomesLocais += dr["nomeLOCAL"];
        //    }
        //    return nomesLocais;
        //}


        ///// <summary>
        ///// Preenche um objeto list com objetos da classe Produto 
        ///// </summary>
        ///// <param name="codigoProposta"></param>
        ///// <returns></returns>
        //public IEnumerable<Produto> fillListProduto(Int32 codigoProposta)
        //{
        //    Produto objProd = new Produto();
        //    List<Produto> listProduto = new List<Produto>();


        //    try
        //    {
        //        StringBuilder query = new StringBuilder();
        //        query.Append("SELECT codigoPRODUTO,partnumberPRODUTO,nomePRODUTO,ean13PRODUTO,codigolotePRODUTO,identificacaolotePRODUTO,dbo.fn1211_LocaisLoteProduto(codigoPRODUTO,codigolotePRODUTO) AS nomelocalPRODUTO");
        //        query.AppendFormat(" FROM dbo.fn0003_informacoesProdutos({0})", codigoProposta);
        //        query.Append("GROUP BY codigoPRODUTO,partnumberPRODUTO,nomePRODUTO,ean13PRODUTO,codigolotePRODUTO,identificacaolotePRODUTO,dbo.fn1211_LocaisLoteProduto(codigoPRODUTO,codigolotePRODUTO)");
        //        query.Append("ORDER BY nomelocalPRODUTO ASC");

        //        SqlDataReader dr = SqlServerConn.fillDataReader(query.ToString());

        //        while ((dr.Read()))
        //        {
        //            objProd = new Produto(Convert.ToInt32(dr["codigoPRODUTO"]),
        //                                    (String)dr["ean13PRODUTO"],
        //                                    (String)dr["partnumberPRODUTO"],
        //                                    (String)dr["nomePRODUTO"],
        //                                    (String)dr["nomelocalPRODUTO"],
        //                                    Convert.ToInt64(dr["codigolotePRODUTO"]),
        //                                    (String)dr["identificacaolotePRODUTO"]);

        //            //Carrega a lista de itens que será retornada ao fim do procedimento.
        //            listProduto.Add(objProd);
        //        }

        //        if (listProduto == null || listProduto.Count == 0)
        //        {
        //            throw new TitaniumColector.Classes.Exceptions.SqlQueryExceptions("Query não retornou valor.");
        //        }

        //        return listProduto;
        //    }
        //    catch (SqlQueryExceptions queryEx)
        //    {
        //        SqlServerConn.closeConn();
        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendFormat("Não foi possível obter informações sobre a proposta {0}", codigoProposta);
        //        sb.Append("\nError :" + queryEx.Message);
        //        sb.Append("\nFavor contate o administrador do sistema.");
        //        MainConfig.errorMessage(sb.ToString(), "Carga Base Mobile.");
        //        return listProduto = null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// Efetua o insert na base mobile tb0003_Produtos 
        ///// </summary>
        ///// <param name="listProduto">List preenchida com objetos da classe Produto</param>
        //public void insertProduto(List<Produto> listProduto)
        //{

        //    try
        //    {
        //        //Limpa a tabela..
        //        CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0003_Produtos");

        //        foreach (var item in listProduto)
        //        {
        //            //Query de insert na Base Mobile
        //            StringBuilder query = new StringBuilder();
        //            query.Append("INSERT INTO tb0003_Produtos ");
        //            query.Append("(codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,");
        //            query.Append("identificacaolotePRODUTO, codigolocalPRODUTO, nomelocalPRODUTO)");
        //            query.Append("VALUES (");
        //            query.AppendFormat("{0},", item.CodigoProduto);
        //            query.AppendFormat("\'{0}\',", item.Ean13);
        //            query.AppendFormat("\'{0}\',", item.Partnumber);
        //            query.AppendFormat("\'{0}\',", item.Descricao);
        //            query.AppendFormat("{0},", item.CodigoLoteProduto);
        //            query.AppendFormat("\'{0}\',", item.IdentificacaoLoteProduto);
        //            query.AppendFormat("{0},", item.CodigoLocalLote);
        //            query.AppendFormat("\'{0}\')", item.NomeLocalLote);
        //            sql01 = query.ToString();

        //            CeSqlServerConn.execCommandSqlCe(sql01);
        //        }

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Erro durante a carga de dados na base Mobile tb0003_Produtos.\n Erro : " + sqlEx.Message);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Realiza o insert na tabela de Propostas
        ///// </summary>
        ///// <param name="codigoProposta">Código da Proposta</param>
        ///// <param name="numeroProposta">Número da Proposta</param>
        ///// <param name="dataliberacaoProposta">data de liberação da Proposta</param>
        ///// <param name="clienteProposta">Código do cliente</param>
        ///// <param name="razaoEmpreza">Nome da empreza cliente</param>
        ///// <param name="ordemseparacaoimpresaProposta">Status 0 ou 1</param>
        ///// <param name="usuarioLogado">Usuário logado</param>
        //public void insertProposta(Int64 codigoProposta, string numeroProposta, string dataliberacaoProposta, Int32 clienteProposta,
        //                            string razaoEmpresa, int volumesProposta, int usuarioLogado)
        //{

        //    CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0001_Propostas");

        //    //Query de insert na Base Mobile
        //    StringBuilder query = new StringBuilder();
        //    query.Append("Insert INTO tb0001_Propostas");
        //    query.Append("(codigoPROPOSTA,numeroPROPOSTA,dataliberacaoPROPOSTA,clientePROPOSTA,razaoclientePROPOSTA,volumesPROPOSTA,operadorPROPOSTA)");
        //    query.Append(" VALUES (");
        //    query.AppendFormat("{0},", codigoProposta);
        //    query.AppendFormat("\'{0}\',", numeroProposta);
        //    query.AppendFormat("\'{0}\',", dataliberacaoProposta);
        //    query.AppendFormat("{0},", clienteProposta);
        //    query.AppendFormat("\'{0}\',", razaoEmpresa);
        //    query.AppendFormat("{0},", volumesProposta);
        //    query.AppendFormat("{0})", usuarioLogado);
        //    sql01 = query.ToString();

        //    CeSqlServerConn.execCommandSqlCe(sql01);

        //}

        ///// <summary>
        ///// Recupera a proposta TOP 1 e devolve um objeto do tipo Proposta com as informações resultantes.
        ///// </summary>
        ///// <returns>Objeto do tipo Proposta</returns>
        //public Proposta fillTop1PropostaServidor()
        //{
        //    Proposta objProposta = new Proposta();

        //    StringBuilder sbSql01 = new StringBuilder();
        //    sbSql01.Append("SELECT TOP (1) codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
        //    sbSql01.Append("clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA");
        //    sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
        //    sbSql01.Append(" ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC ");
        //    sql01 = sbSql01.ToString();


        //    SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

        //    if ((dr.FieldCount > 0))
        //    {
        //        while ((dr.Read()))
        //        {
        //            objProposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
        //                                     Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], Convert.ToInt32(dr["volumesPROPOSTA"]));

        //        }
        //    }

        //    SqlServerConn.closeConn();

        //    return objProposta;

        //}



        ///// <summary>
        ///// Identifica qual o próximo item com status de NAOSEPARADO e o retorna.
        ///// </summary>
        ///// 
        ///// <returns>Objeto ProdutoProposta com o próximo item da sequência da base mobile.</returns>
        ///// 
        ///// <remarks>
        /////       Caso a query não retorne valores da base mobile o método retorna um valor NULL
        ///// </remarks>
        //public ProdutoProposta fillTop1ItemProposta()
        //{
        //    Object obj = null;
        //    StringBuilder sbQuery = new StringBuilder();

        //    sbQuery.Append(" SELECT TOP (1) TB_PROP.codigoPROPOSTA,");
        //    sbQuery.Append(" TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA, TB_ITEMPROPOP.statusseparadoITEMPROPOSTA,");
        //    sbQuery.Append(" TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA,");
        //    sbQuery.Append(" TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, TB_PROD.identificacaolotePRODUTO, TB_PROD.codigolotePRODUTO,");
        //    sbQuery.Append(" TB_PROD.nomelocalPRODUTO");
        //    sbQuery.Append(" FROM   tb0001_Propostas AS TB_PROP ");
        //    sbQuery.Append(" INNER JOIN tb0002_ItensProposta AS TB_ITEMPROPOP ON TB_PROP.codigoPROPOSTA = TB_ITEMPROPOP.propostaITEMPROPOSTA");
        //    sbQuery.Append(" INNER JOIN tb0003_Produtos AS TB_PROD ON TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA = TB_PROD.codigoPRODUTO");
        //    sbQuery.Append(" WHERE TB_ITEMPROPOP.statusseparadoITEMPROPOSTA = 0");
        //    sbQuery.Append(" ORDER BY TB_PROD.nomelocalPRODUTO ASC");
        //    sql01 = sbQuery.ToString();

        //    SqlCeDataReader dr = CeSqlServerConn.fillDataReaderCe(sql01);

        //    if ((dr != null))
        //    {
        //        while ((dr.Read()))
        //        {
        //            int statusSeparadoItem = Convert.ToInt32(dr["statusseparadoITEMPROPOSTA"]);
        //            ProdutoProposta produto = new ProdutoProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]),
        //                                                                Convert.ToInt32(dr["codigoPROPOSTA"]),
        //                                                                Convert.ToDouble(dr["quantidadeITEMPROPOSTA"]),
        //                                                                (ProdutoProposta.statusSeparado)statusSeparadoItem,
        //                                                                Convert.ToInt32(dr["lotereservaITEMPROPOSTA"]),
        //                                                                Convert.ToInt32(dr["codigoprodutoITEMPROPOSTA"]),
        //                                                                (string)dr["ean13PRODUTO"],
        //                                                                (string)dr["partnumberPRODUTO"],
        //                                                                (string)dr["descricaoPRODUTO"],
        //                                                                (string)dr["nomelocalPRODUTO"],
        //                                                                Convert.ToInt32(dr["codigolotePRODUTO"]),
        //                                                                (string)dr["identificacaolotePRODUTO"]);
        //            obj = produto;

        //        }


        //    }

        //    //fecha a conexão
        //    CeSqlServerConn.closeConnCe();

        //    if (obj != null)
        //    {
        //        return (ProdutoProposta)obj;
        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}

        ///// <summary>
        /////  Carrega uma List com objetos da classe ItemProposta preenchida com dados sobre os itens de uma determinada Proposta 
        ///// </summary>
        ///// <param name="codigoProposta">Código da proposta da qual serão recuperados os itens.</param>
        ///// <returns>List do tipo ItemProposta </returns>
        //public IEnumerable<ProdutoProposta> fillListItensProposta(int codigoProposta)
        //{
        //    objItemProposta = new ProdutoProposta();

        //    List<ProdutoProposta> listItensProposta = new List<ProdutoProposta>();

        //    try
        //    {

        //        StringBuilder query = new StringBuilder();
        //        query.Append("SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,");
        //        query.Append("ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD");
        //        query.Append(" FROM tb1206_Reservas (NOLOCK) ");
        //        query.Append("INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA ");
        //        query.Append("INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO ");
        //        query.Append("LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL ");
        //        query.Append("LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL ");
        //        query.AppendFormat("WHERE propostaITEMPROPOSTA = {0} ", codigoProposta);
        //        query.Append("AND tipodocRESERVA = 1602 ");
        //        query.Append("AND statusITEMPROPOSTA = 3 ");
        //        query.Append("AND separadoITEMPROPOSTA = 0  ");
        //        query.Append("GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,");
        //        query.Append("nomePRODUTO,partnumberPRODUTO");

        //        sql01 = query.ToString();

        //        SqlDataReader dr = SqlServerConn.fillDataReader(sql01);

        //        while ((dr.Read()))
        //        {
        //            {
        //                objItemProposta = new ProdutoProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]),
        //                                                        Convert.ToInt32(dr["propostaITEMPROPOSTA"]),
        //                                                        Convert.ToDouble(dr["QTD"]),
        //                                                        ProdutoProposta.statusSeparado.NAOSEPARADO,
        //                                                        Convert.ToInt32(dr["codigoPRODUTO"]),
        //                                                        (string)dr["ean13PRODUTO"],
        //                                                        (string)dr["partnumberPRODUTO"],
        //                                                        (string)(dr["nomePRODUTO"]));

        //                //Carrega a lista de itens que será retornada ao fim do procedimento.
        //                listItensProposta.Add(objItemProposta);

        //            }

        //        }

        //        dr.Close();

        //        SqlServerConn.closeConn();

        //        return listItensProposta;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// Insert na base Mobile tabela de itens da proposta
        ///// </summary>
        ///// <param name="listProposta">List com objetos do tipo ItemProposta </param>
        //public void insertItemProposta(List<ProdutoProposta> listProdutoProposta)
        //{

        //    try
        //    {
        //        //Limpa a tabela..
        //        CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");

        //        foreach (var item in listProdutoProposta)
        //        {

        //            //Query de insert na Base Mobile
        //            StringBuilder query = new StringBuilder();
        //            query.Append("INSERT INTO tb0002_ItensProposta");
        //            query.Append("(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,");
        //            query.Append("statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA) ");
        //            query.Append("VALUES (");
        //            query.AppendFormat("{0},", item.CodigoItemProposta);
        //            query.AppendFormat("{0},", item.PropostaItemProposta);
        //            query.AppendFormat("{0},", item.Quantidade);
        //            query.AppendFormat("{0},", (int)item.StatusSeparado);
        //            query.AppendFormat("{0},", item.CodigoProduto);
        //            query.AppendFormat("{0})", item.LotereservaItemProposta);
        //            sql01 = query.ToString();

        //            CeSqlServerConn.execCommandSqlCe(sql01);
        //        }

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        StringBuilder strBuilder = new StringBuilder();
        //        strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
        //        strBuilder.Append("O procedimento não pode ser concluído");
        //        strBuilder.AppendFormat("Erro : {0}", sqlEx.Errors);
        //        strBuilder.AppendFormat("Description : {0}", sqlEx.Message);

        //        MainConfig.errorMessage(strBuilder.ToString(), "SqlException!!");
        //    }
        //    catch (Exception Ex)
        //    {
        //        StringBuilder strBuilder = new StringBuilder();
        //        strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
        //        strBuilder.Append("O procedimento não pode ser concluído \n");
        //        strBuilder.AppendFormat("Description : {0}", Ex.Message);

        //        MainConfig.errorMessage(strBuilder.ToString(), "Error in Query!!");
        //    }

        //}

        ///// <summary>
        ///// Realiza Insert na base Mobile table tb0002_ItensProposta
        ///// </summary>
        ///// <param name="codigoItem">Código do Item da Proposta</param>
        ///// <param name="propostaItemProposta">Proposta (ForeingKey)</param>
        ///// <param name="quantidade">Qunatidade de itens</param>
        ///// <param name="statusSeparado">status (Separado ou não)</param>
        ///// <param name="codigoProduto">Código do produto </param>
        ///// <param name="loteReserva">Lote referente a reserva do item</param>
        //public void insertItemProposta(Int64 codigoItem, Int64 propostaItemProposta, Double quantidade, ProdutoProposta.statusSeparado statusSeparado,
        //                                Int64 codigoProduto, Int64 loteReserva, Int64 codigoLocalItemProposta)
        //{
        //    try
        //    {
        //        //Limpa a tabela..
        //        CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");

        //        //Query de insert na Base Mobile
        //        StringBuilder query = new StringBuilder();
        //        query.Append("INSERT INTO tb0002_ItensProposta");
        //        query.Append("(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,");
        //        query.Append("statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA,localloteITEMPROPOSTA) ");
        //        query.Append("VALUES (");
        //        query.AppendFormat("{0},", codigoItem);
        //        query.AppendFormat("{0},", propostaItemProposta);
        //        query.AppendFormat("{0},", quantidade);
        //        query.AppendFormat("{0},", (int)statusSeparado);
        //        query.AppendFormat("{0},", codigoProduto);
        //        query.AppendFormat("{0},", loteReserva);
        //        query.AppendFormat("{0})", codigoLocalItemProposta);
        //        sql01 = query.ToString();

        //        CeSqlServerConn.execCommandSqlCe(sql01);

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        StringBuilder strBuilder = new StringBuilder();
        //        strBuilder.Append("Ocorreram problemas durante a carga de dados na tabela tb0002_ItensProposta. \n");
        //        strBuilder.Append("O procedimento não pode ser concluído");
        //        strBuilder.AppendFormat("Erro : {0}", sqlEx.Errors);
        //        strBuilder.AppendFormat("Description : {0}", sqlEx.Message);
        //        System.Windows.Forms.MessageBox.Show(strBuilder.ToString(), "Error:", System.Windows.Forms.MessageBoxButtons.OK,
        //                       System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}


        //public void insertSequencia(List<Etiqueta> listEtiquetas) 
        //{
        //    try
        //    {
        //        //Limpa a tabela..
        //        CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0004_Etiquetas");

        //        foreach (var item in listEtiquetas)
        //        {
        //            //INSERT BASE MOBILE
        //            StringBuilder query = new StringBuilder();
        //            query.Append(" INSERT INTO tb0004_Etiquetas ");
        //            query.Append("(eanitempropostaETIQUETA, volumeETIQUETA, quantidadeETIQUETA, sequenciaETIQUETA)");
        //            query.Append("VALUES (");
        //            query.AppendFormat("{0},", item.Ean13Etiqueta);
        //            query.AppendFormat("\'{0}\',", item.VolumeEtiqueta);
        //            query.AppendFormat("\'{0}\',", item.QuantidadeEtiqueta);
        //            query.AppendFormat("\'{0}\')", item.SequenciaEtiqueta);
        //            sql01 = query.ToString();

        //            CeSqlServerConn.execCommandSqlCe(sql01);
        //        }

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Erro durante a carga de dados na base Mobile tb0004_Etiquetas.\n Erro : " + sqlEx.Message);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// Altera o status de separado do item na Base mobile.
        ///// </summary>
        ///// <param name="item">O status será alterado de acordo com o atual statdo so item passado com parâmetro.</param>
        //public void updateItemProposta(ProdutoProposta item)
        //{
        //    try
        //    {
        //        StringBuilder sbQuery = new StringBuilder();
        //        sbQuery.Append(" UPDATE      tb0002_ItensProposta");
        //        sbQuery.AppendFormat("  SET   statusseparadoITEMPROPOSTA ={0}", (int)item.StatusSeparado);
        //        sbQuery.AppendFormat(" WHERE (tb0002_ItensProposta.codigoITEMPROPOSTA = {0})", item.CodigoItemProposta);
        //        sql01 = sbQuery.ToString();

        //        CeSqlServerConn.execCommandSqlCe(sql01);
        //    }
        //    catch (SqlCeException)
        //    {
        //        MessageBox.Show("errror.");
        //    }

        //}

        ///// <summary>
        ///// Altera o status de separado do item na Base mobile.
        ///// </summary>
        ///// <param name="status">Status para qual será atualizado</param>
        ///// <param name="codigoItem">código so item da proposta a ser alterado</param>
        ///// <remarks>  
        /////             Os status são:
        /////             ProdutoProposta.statusSeparado.NAOSEPARADO       / 0
        /////             ProdutoProposta.statusSeparado.SEPARADO          / 1
        ///// </remarks>
        //public void updateItemProposta(ProdutoProposta.statusSeparado status, int codigoItem)
        //{
        //    StringBuilder sbQuery = new StringBuilder();
        //    sbQuery.Append("UPDATE      tb0002_ItensProposta");
        //    sbQuery.AppendFormat("SET   statusseparadoITEMPROPOSTA ={0}", status);
        //    sbQuery.AppendFormat("WHERE tb0002_ItensProposta.codigoITEMPROPOSTA = {0})", codigoItem);
        //    sql01 = sbQuery.ToString();

        //    CeSqlServerConn.execCommandSqlCe(sql01);
        //}

        #endregion


    #region "CRIACAO BASE MOBILE "

        public void clearBaseMobile()
        {
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0004_Etiquetas");
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0003_Produtos");
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0001_Propostas");
        }

        /// <summary>
        /// Configura a conexão com a base mobile.
        /// Caso a base de dados ainda não exista ela será criada
        /// </summary>
        public static void configurarBaseMobile()
        {
            //"\\Storage Cardw\\BaseMobile\\EngineMobile.sdf"
            if (System.IO.File.Exists("\\Program Files\\TitaniumColector\\EngineMobile.sdf"))
            {
                //Configura a string de conexão com a base mobile.
                CeSqlServerConn.createStringConectionCe("\\Program Files\\TitaniumColector\\EngineMobile.sdf", "tec9TIT16");
            }
            else
            {
                String dataSource = "\\Program Files\\TitaniumColector\\EngineMobile.sdf";
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
            sql01 = new StringBuilder();
            sql01.Append("CREATE TABLE tb0001_Propostas (");
            sql01.Append("codigoPROPOSTA int not null CONSTRAINT PKPropostas Primary key,");
            sql01.Append("numeroPROPOSTA nvarchar(20) not null,");
            sql01.Append("dataliberacaoPROPOSTA nvarchar(20) not null,");
            sql01.Append("clientePROPOSTA int not null,");
            sql01.Append("razaoclientePROPOSTA nvarchar(200),");
            sql01.Append("volumesPROPOSTA smallint,");
            sql01.Append("operadorPROPOSTA int) ");
            CeSqlServerConn.execCommandSqlCe(sql01.ToString());

            //TABELAS tb0002_ItensProposta
            sql01.Length = 0;
            sql01.Append("CREATE TABLE tb0002_ItensProposta (");
            sql01.Append("codigoITEMPROPOSTA int not null CONSTRAINT PKItensProposta PRIMARY KEY,");
            sql01.Append("propostaITEMPROPOSTA int ,");
            sql01.Append("quantidadeITEMPROPOSTA real,");
            sql01.Append("statusseparadoITEMPROPOSTA smallint,");
            sql01.Append("codigoprodutoITEMPROPOSTA int,");
            sql01.Append("lotereservaITEMPROPOSTA int,");
            sql01.Append("xmlSequenciaITEMPROPOSTA nText)");
            CeSqlServerConn.execCommandSqlCe(sql01.ToString());

            //TABELAS tb0003_Produtos
            sql01.Length = 0;
            sql01.Append("CREATE TABLE tb0003_Produtos (");
            sql01.Append("codigoPRODUTO				INT NOT NULL ,");
            sql01.Append("ean13PRODUTO				NVARCHAR(15) NOT NULL ,");
            sql01.Append("partnumberPRODUTO			NVARCHAR(100) ,");
            sql01.Append("descricaoPRODUTO			NVARCHAR(100) ,");
            sql01.Append("codigolotePRODUTO			INT,");
            sql01.Append("identificacaolotePRODUTO	NVARCHAR(100) ,");
            sql01.Append("codigolocalPRODUTO			INT , ");
            sql01.Append("nomelocalPRODUTO			NVARCHAR(100) )");
            CeSqlServerConn.execCommandSqlCe(sql01.ToString());

            //TABELAS tb0004_ETIQUETA
            sql01.Length = 0;
            sql01.Append("CREATE TABLE tb0004_Etiquetas (");
            sql01.Append("codigoETIQUETA				    INT IDENTITY(1,1) NOT NULL CONSTRAINT PKSequencia PRIMARY KEY,");
            sql01.Append("eanitempropostaETIQUETA			NVARCHAR(20) NOT NULL,");
            sql01.Append("volumeETIQUETA	      			INT NOT NULL,");
            sql01.Append("quantidadeETIQUETA	      		REAL NOT NULL,");
            sql01.Append("sequenciaETIQUETA    			INT NOT NULL)");
            CeSqlServerConn.execCommandSqlCe(sql01.ToString());

        }

    #endregion

    }
}
