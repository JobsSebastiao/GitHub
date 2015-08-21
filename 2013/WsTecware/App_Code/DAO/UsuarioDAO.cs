using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for UsuarioDAO
/// </summary>
public class UsuarioDAO
{
    private SqlConnection conn;
    private StringBuilder sbSql01 = null;
  
	public UsuarioDAO()
	{
        conn = new SqlConnection();
        conn = ConnectionFactory.openConn();
        this.sbSql01 = null;
	}

    /// <summary>
    /// Registra o acesso do usuário na Tabela tb0207_Acessos.
    /// E define o status de Login do usuário como Usuario.StatusLogin.LOGADO OU NAOLOGADO
    /// </summary>
    /// <param name="user">Código do usuário.</param>
    /// <param name="tipodeAcao"> ENUM Usuario.StatusLogin da classe usuário</param>
    /// <returns>Retorna o código do acesso atual do usuário.</returns>
    public IEnumerable<Usuario> registrarAcesso(Usuario user, Usuario.statusLogin tipodeAcao,String hostName)
    {

        List<Usuario> list= new List<Usuario>();

        string sql01 = null;
        //Insere o acesso e inicia a transação
        sql01 = "INSERT INTO tb0207_Acessos (usuarioACESSO, maquinaACESSO)";
        sql01 = sql01 + " VALUES (" + user.Codigo + ",'" + hostName + "')";
        ConnectionFactory.execCommandSql(sql01);

        //Recupera o código do acesso
        sql01 = "SELECT MAX(codigoACESSO) AS novoACESSO";
        sql01 = sql01 + " FROM tb0207_Acessos";
        System.Data.SqlClient.SqlDataReader dr = ConnectionFactory.fillDataReader(sql01);
        if ((dr.FieldCount > 0))
        {
            while ((dr.Read()))
            {
                user.CodigoAcesso = ((Int32)dr["novoACESSO"]);
            }
        }

        user.StatusLogin = tipodeAcao;
        user.HostAcesso = hostName;
        list.Add(user);
        ConnectionFactory.closeConn();
        dr.Close();

        return list ;
    }

    public IEnumerable<Usuario> loadListUsuarios() 
    {

        DataTable dt = new DataTable("Usuarios");
        Usuario user = null;
        List<Usuario> listUsuario = new List<Usuario>();

        Usuario.statusUsuario status;
        DataRow dr = null;

        sbSql01 = new StringBuilder();
        sbSql01.Append(" SELECT codigoUSUARIO as Codigo,pastaUSUARIO as Pasta,nomeUSUARIO as Nome,");
        sbSql01.Append(" senhaUSUARIO as Senha,nomecompletoUSUARIO as NomeCompleto,ativoUSUARIO as StatusUsuario");
        sbSql01.Append(" FROM tb0201_usuarios ");
        sbSql01.Append(" ORDER BY nomeUSUARIO ");

        ConnectionFactory.fillDataTable(dt, sbSql01.ToString(),this.conn);

        foreach (DataRow dr_loopVariable in dt.Rows)
        {
            dr = dr_loopVariable;

            if (Convert.ToInt32(dr["StatusUsuario"]) == 0)
            {
                status = Usuario.statusUsuario.DESATIVADO;
            }
            else
            {
                status = Usuario.statusUsuario.ATIVO;
            }

            user = new Usuario(Convert.ToInt32(dr["Codigo"]), Convert.ToInt32(dr["Pasta"]), (string)dr["Nome"], (string)dr["Senha"], (string)dr["NomeCompleto"], status);
            
            listUsuario.Add(user);
        }

        return listUsuario;

    }

}