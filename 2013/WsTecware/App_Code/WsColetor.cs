using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Xml;

/// <summary>
/// Summary description for WsColetor
/// </summary>
[WebService(Namespace = "http://www.tecwarebrasil.com.br/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WsColetor : System.Web.Services.WebService {


    public WsColetor () 
    {

    }

 
    [WebMethod]
    public String testeConnection()
    {
        System.Data.SqlClient.SqlConnection conn = ConnectionFactory.openConn();
        String teste = String.Format("Abertura de Conexão --> {0} \n", conn.State.ToString());
        conn.Close();
        teste += String.Format(" {0} Fechamento Conexão -->{1} " ,Environment.NewLine,conn.State); 
        return teste;

    }

    /// <summary>
    ///  Registra o acesso do usuário na Tabela tb0207_Acessos.
    ///  
    /// </summary>
    /// <param name="user">Usuario Object</param>
    /// <param name="statusLogin">Status a ser registrado</param>
    /// <param name="hostName">HostName da máquina que esá acessando o base de dados</param>
    /// <returns>LIst do tipo Object com informações sobre o Login (usuario,)</returns>
    [WebMethod]
    public List<Usuario> registrarAcesso(Usuario user,Usuario.statusLogin statusLogin,String hostName) 
    {
       UsuarioDAO usuarioDAO = new UsuarioDAO();
       List<Usuario> list = new List<Usuario>();

       list = (List<Usuario>)usuarioDAO.registrarAcesso(user, statusLogin, hostName);
       return list;

    }

    /// <summary>
    /// Prrenche um list com objetos do tipo Usuario
    /// </summary>
    /// <returns>List do tipo Usuario</returns>
    [WebMethod]
    public List<Usuario> loadListUsuarios() 
    {
       UsuarioDAO usuarioADO = new UsuarioDAO();
       return  (List<Usuario>)usuarioADO.loadListUsuarios();

    }

}
