using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TitaniumColector.Classes.Model;
using System.Data.SqlClient;
using TitaniumColector.Classes.Exceptions;
using TitaniumColector.SqlServer;
using TitaniumColector.Classes.SqlServer;
using System.Data.SqlServerCe;

namespace TitaniumColector.Classes.Dao
{
    class DaoEmbalagem
    {
        StringBuilder sql01;
        private Embalagem embalagem = null;

        public DaoEmbalagem() 
        {

        }

        public List<Embalagem> cargaEmbalagensProduto(int codigoProposta) 
        {
            sql01 = new StringBuilder();
            List<Embalagem> listaEmbalagens = new List<Embalagem>();

            try
            {
                sql01.Append(" SELECT codigoEMBALAGEMPRODUTO,COALESCE(nomeEMBALAGEMPRODUTO,'ND') AS nomeEMBALAGEMPRODUTO,produtoEMBALAGEMPRODUTO,quantidadeEMBALAGEMPRODUTO,padraoEMBALAGEMPRODUTO,embalagemEMBALAGEMPRODUTO,codigobarrasEMBALAGEMPRODUTO");
                sql01.Append(" FROM tb0504_Embalagens_Produtos");
                sql01.Append(" INNER JOIN tb0501_Produtos ON codigoPRODUTO = produtoEMBALAGEMPRODUTO");
                sql01.Append(" WHERE produtoEMBALAGEMPRODUTO IN(");
                sql01.Append("						                SELECT produtoRESERVA AS codigoPRODUTO");
                sql01.Append("						                FROM tb1206_Reservas (NOLOCK)");
                sql01.Append("						                INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA");
                sql01.Append("						                INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO");
                sql01.AppendFormat("						        WHERE propostaITEMPROPOSTA = {0}",codigoProposta);
                sql01.Append("						                AND tipodocRESERVA = 1602 ");
                sql01.Append("						                AND statusITEMPROPOSTA = 3");
                sql01.Append("						                AND separadoITEMPROPOSTA = 0");
                sql01.Append("						                GROUP BY produtoRESERVA");
                sql01.Append("                                 )");
                sql01.Append(" AND lixeiraPRODUTO = 0");
                sql01.Append(" ORDER BY produtoEMBALAGEMPRODUTO");

                SqlDataReader dr = SqlServerConn.fillDataReader(sql01.ToString());

                while ((dr.Read()))
                {
                    {
                        embalagem = new Embalagem(Convert.ToInt32(dr["codigoEMBALAGEMPRODUTO"]), (string)dr["nomeEMBALAGEMPRODUTO"],
                                                  Convert.ToInt32(dr["produtoEMBALAGEMPRODUTO"]), Convert.ToDouble(dr["quantidadeEMBALAGEMPRODUTO"]),
                                                 (Embalagem.PadraoEmbalagem)dr["padraoEMBALAGEMPRODUTO"], Convert.ToInt32(dr["embalagemEMBALAGEMPRODUTO"]),
                                                  (string)dr["codigobarrasEMBALAGEMPRODUTO"]);



                        //Carrega a lista de itens que será retornada ao fim do procedimento.
                        listaEmbalagens.Add(embalagem);

                    }

                }

                dr.Close();
                SqlServerConn.closeConn();

                if (listaEmbalagens.Count == 0)
                {
                    throw new SqlQueryExceptions("Não foi possível recuperar informações sobre embalagens para esta proposta :  " + codigoProposta);
                }

                return listaEmbalagens;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertEmbalagemBaseMobile(List<Embalagem> listaEmbalagens) 
        {
            try
            {
                //Limpa a tabela..
                CeSqlServerConn.execCommandSqlCe("DELETE FROM tb0005_Embalagens");

                foreach (var item in listaEmbalagens)
                {

                    //Query de insert na Base Mobile
                    sql01 = new StringBuilder();
                    sql01.Append("INSERT INTO tb0005_Embalagens");
                    sql01.Append("(codigoEMBALAGEM, nomeEMBALAGEM, produtoEMBALAGEM, quantidadeEMBALAGEM, padraoEMBALAGEM, embalagemEMBALAGEM, ean13EMBALAGEM)");
                    sql01.Append("VALUES (");
                    sql01.AppendFormat("{0},", item.Codigo);
                    sql01.AppendFormat("'{0}',", item.Nome);
                    sql01.AppendFormat("{0},", item.ProdutoEmbalagem);
                    sql01.AppendFormat("{0},", item.Quantidade);
                    sql01.AppendFormat("{0},", (int)item.IsPadrao);
                    sql01.AppendFormat("{0},", item.TipoEmbalagem);
                    sql01.AppendFormat("'{0}')", item.Ean13Embalagem);

                    CeSqlServerConn.execCommandSqlCe(sql01.ToString());
                }

            }
            catch (SqlCeException sqlEx)
            {
                throw sqlEx;

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

    }
}
