using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using TitaniumColector.SqlServer;
using TitaniumColector.Classes.SqlServer;

namespace TitaniumColector.Classes
{
    class Carga
    {
        private String sql01;
        private ItemProposta objItemProposta;

        /// <summary>
        ///  Efetua carga na base mobile tb0001_Propostas com informações sobre a 
        ///  proposta top1 atualmente liberada no picking
        /// </summary>
        /// <param name="cat">Gatinho do método. </param>
        /// <remarks>Após realizar a consulta realiza a carga dos dados  na base mobile tabela TB0001_Propostas</remarks>
        
        public void top1PropostaServidor(String cat)
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

                    this.insertProposta(Convert.ToInt64(dr["codigoPROPOSTA"]),(string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                             Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (int)(Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"],MainConfig.CodigoUsuarioLogado);
                    
                }
            }

            SqlServerConn.closeConn();

        }


        public void teste() 
        {
            Produto produ = new Produto();
           
        }
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
        public IEnumerable<ItemProposta> recuperaItensProposta(int codigoProposta)
        {
            objItemProposta = new ItemProposta();

            List<ItemProposta> listItensProposta = new List<ItemProposta>();

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
                    objItemProposta = new ItemProposta(Convert.ToInt32(dr["codigoITEMPROPOSTA"]), Convert.ToInt32(dr["propostaITEMPROPOSTA"]), Convert.ToDouble(dr["QTD"]), ItemProposta.statusSeparado.NAOSEPARADO, Convert.ToInt32(dr["loteRESERVA"]),
                                                     Convert.ToInt32(dr["codigoPRODUTO"]), (string)dr["ean13PRODUTO"], (string)dr["partnumberPRODUTO"], (string)(dr["nomePRODUTO"]), Convert.ToInt32(dr["localLOTELOCAL"]), (String)dr["nomeLOCAL"]);


                    //Carrega a lista de itens que será retornada ao fim do procedimento.
                    listItensProposta.Add(objItemProposta);
                }
            }

            dr.Close();

            SqlServerConn.closeConn();

            return listItensProposta;
        }


//SELECT        codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA, statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA
//FROM            tb0002_ItensProposta

//INSERT INTO tb0002_ItensProposta
//(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA, statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, lotereservaITEMPROPOSTA)
//VALUES        (,,,,,)


//UPDATE       tb0002_ItensProposta
//SET                codigoITEMPROPOSTA =, propostaITEMPROPOSTA =, quantidadeITEMPROPOSTA =, statusseparadoITEMPROPOSTA =, codigoprodutoITEMPROPOSTA =, lotereservaITEMPROPOSTA =



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
        private void insertItensProposta(List<ItemProposta> listItensProposta)
        {

            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0002_ItensProposta");

            foreach (var item in listItensProposta)
            {
                //Query de insert na Base Mobile
                StringBuilder query = new StringBuilder();
                query.Append("Insert INTO tb0002_ItensProposta VALUES (");
                query.AppendFormat("{0},", item.CodigoItemProposta);
                query.AppendFormat("\'{0}\',", item.PropostaItemProposta);
                query.AppendFormat("\'{0}\',", item.Partnumber);
                query.AppendFormat("\'{0}\',", item.Descricao);
                query.AppendFormat("{0},", item.CodigoProduto);
                query.AppendFormat("{0},", item.Quantidade);
                query.AppendFormat("\'{0}\',", item.Ean13);
                query.AppendFormat("{0})", (int)item.StatusSeparado);
                sql01 = query.ToString();

                CeSqlServerConn.execCommandSqlCe(sql01);
            }
        }


        /// <summary>
        /// Insert na base Mobile tabela ItensProposta.
        /// </summary>
        /// <param name="codigoITEMPROPOSTA"> Código do item da proposta</param>
        /// <param name="propostaITEMPROPOSTA">código da proposta ao qual o item está vínculado</param>
        /// <param name="nomePRODUTO">Nome(Descrição ) do item.</param>
        /// <param name="partnumberPRODUTO"> Partnumber do item</param>
        /// <param name="ean13PRODUTO">Ean 13 do item</param>
        /// <param name="PRODUTO"> produto separado</param>
        /// <param name="quantidade">quantidade do item  </param>
        /// <param name="statusseparadoPROPODUTO"> Status indicando se o item está separado ou não.</param>
        private void insertItemProposta(Int64 codigoITEMPROPOSTA, Int32 propostaITEMPROPOSTA, string nomePRODUTO, string partnumberPRODUTO,
                                        string ean13PRODUTO, int PRODUTO, double quantidade, int statusseparadoPROPODUTO)
        {

            //Limpa a tabela..
            CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0011_ItensProposta");

            //Query de insert na Tabela de itens da prosposta
            StringBuilder query = new StringBuilder();
            query.Append("Insert INTO tb0011_ItensProposta VALUES (");
            query.AppendFormat("{0},", codigoITEMPROPOSTA);
            query.AppendFormat("\'{0}\',", propostaITEMPROPOSTA);
            query.AppendFormat("\'{0}\',", partnumberPRODUTO);
            query.AppendFormat("\'{0}\',", nomePRODUTO);
            query.AppendFormat("{0},", PRODUTO);
            query.AppendFormat("{0},", quantidade);
            query.AppendFormat("\'{0}\',", ean13PRODUTO);
            query.AppendFormat("{0})", statusseparadoPROPODUTO);
            sql01 = query.ToString();

            CeSqlServerConn.execCommandSqlCe(sql01);

        }





    }
}
