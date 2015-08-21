using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
        
        private int _Codigo;
        private int _Pasta;
        private string _Nome;
        private string _Senha;
        private string _NomeCompleto;
        private Int64  _codigoAcesso;
        private String _hostAcesso;
        private statusUsuario _StatusUsuario;
        private statusLogin _StatusLogin;


        public Usuario()
        {
        }

        public Usuario(int codigo, int pasta, string nome, string senha, string nomeCompleto, statusUsuario status)
        {
            Codigo = codigo;
            Pasta = pasta;
            Nome = nome;
            Senha = senha;
            NomeCompleto = nomeCompleto;
            StatusUsuario = status;
            StatusLogin = statusLogin.NAOLOGADO;
            CodigoAcesso = 0;
            HostAcesso = "n/d";
        }

        public enum usuarioProperty
        {
            CODIGO = 1,
            PASTA = 2,
            NOME = 3,
            SENHA = 4,
            NOMECOMPLETO = 5,
            STATUSUSUARIO = 6
        }

        public enum statusLogin
        {
            LOGADO = 0,
            NAOLOGADO = 1
        }

        public enum statusUsuario 
        {   
            DESATIVADO =0,
            ATIVO =1
        }

    #region "GETS E SETS"
        public int Codigo {
	        get 
            { 
                return this._Codigo; 
            }

	        set 
            {

		        if ((value  != this._Codigo)) 
                {
			        _Codigo = value;
		        }

	        }
        }
        
        public int Pasta {
            
	        get 
            { 
                return _Pasta; 
            }

	        set 
            {
		        if ((value != this._Pasta)) 
                {
			        _Pasta = value;
		        }
	        }
        }

        public string Nome {
	        get 
            { 
                return _Nome; 
            }

	        set 
            {
		        if ((value != null )) 
                {
			        _Nome = value.Trim();
		        }
	        }
        }

        public string Senha {
	        get 
            { 
                return _Senha; 
            }

	        set 
            {
		        if ((value != null) )
                {
			        _Senha = value.Trim();
		        }
	        }
        }

        public string NomeCompleto {

	        get { return _NomeCompleto; }

	        set 
            {
		        if ((value != null)) 
                {
			        _NomeCompleto = value.Trim();
		        }
	        }
        }

        public long CodigoAcesso
        {
            get { return _codigoAcesso; }
            set { _codigoAcesso = value; }
        }

        public String HostAcesso
        {
            get { return _hostAcesso; }
            set { _hostAcesso = value; }
        }

        internal statusLogin StatusLogin
        {
            get         
            { 
                return _StatusLogin; 
            }
            set 
            { 
                _StatusLogin = value; 
            }
        }

        internal statusUsuario StatusUsuario
        {
            get 
            { 
                return _StatusUsuario; 
            }
            set 
            { 
                _StatusUsuario = value; 
            }
        }
       
    #endregion

        public bool validaSenha(object obj,string strSenha) 
        {
            
            bool retorno = false;

            if (obj == null || (obj.GetType() != typeof(Usuario)))
            {
                retorno = false;
            }
            else
            {
                if (strSenha == ((Usuario)obj)._Senha)
                {
                    retorno = true;
                }  
            }
            return retorno;
        }

        public bool validaNome(object obj,string strNome)
        {
            
            bool retorno = false;

            if (obj == null || (obj.GetType() != typeof(Usuario)))
            {
                retorno = false;
            }
            else
            {
                if (strNome == ((Usuario)obj)._Nome)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public bool validaUsuario(object obj,string usuario,string senha) 
        {
            bool retorno = false;
            if (Equals(obj)) 
            {
                if (validaNome(obj,usuario)) 
                {
                    if (validaSenha(obj,senha))
                    {
                        retorno = true;
                    }
                    else 
                    {
                        retorno = false;
                    }
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                retorno = false;
            }
            return retorno;
        }

        public override string ToString()
        {

            StringBuilder sbString = new StringBuilder();

            return sbString.AppendFormat("Codigo:{0} \n Pasta:{1} \n Nome:{2} \n NomeCompleto:{3} \n StatusUsuário:{4} \n CódigoAcesso:{5} \n HostAcesso:{6} \n StatusLogin:{7}",
                                   Codigo,Pasta,Nome,NomeCompleto,StatusUsuario,CodigoAcesso,HostAcesso,StatusLogin).ToString();
           
        }

        public override bool Equals(object obj)
        {
            System.Type type = obj.GetType();
            if (obj == null || (type != typeof(Usuario)))
            {
		        return false;
	        } else {
		        return _Codigo == ((Usuario)obj)._Codigo;
	        }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

	}