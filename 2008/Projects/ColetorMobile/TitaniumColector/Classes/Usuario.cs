using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes
{
    class Usuario
    {

        private int intCodigo;
        private int intPasta;
        private string strNome;
        private string strSenha;
        private string strNomeCompleto;

        public Usuario()
        {
        }

        public Usuario(int codigoUsuario, int pastaUsuario, string nomeUsuario, string senhaUsuario, string nomeCompletoUsuario)
        {
	        Codigo = codigoUsuario;
	        Pasta = pastaUsuario;
	        Nome = nomeUsuario;
	        Senha = senhaUsuario;
	        NomeCompleto = nomeCompletoUsuario;
        }

        public int Codigo {
	        get 
            { 
                return this.intCodigo; 
            }

	        set 
            {

		        if ((value  != this.intCodigo)) 
                {
			        intCodigo = value;
		        }

	        }
        }
        

        public int Pasta {
	        get 
            { 
                return intPasta; 
            }

	        set 
            {
		        if ((value != this.intPasta)) 
                {
			        intPasta = value;
		        }
	        }
        }


        public string Nome {
	        get 
            { 
                return strNome; 
            }

	        set 
            {
		        if ((value != null )) 
                {
			        strNome = value.Trim();
		        }
	        }
        }


        public string Senha {
	        get 
            { 
                return strSenha; 
            }

	        set 
            {
		        if ((value != null) )
                {
			        strSenha = value.Trim();
		        }
	        }
        }


        public string NomeCompleto {

	        get { return strNomeCompleto; }

	        set 
            {
		        if ((value != null)) 
                {
			        strNomeCompleto = value.Trim();
		        }
	        }
        }


        public bool validaSenha(object obj,string strSenha) 
        {
            //System.Type type = obj.GetType();
            bool retorno = false;

            if (obj == null || (obj.GetType() != typeof(Usuario)))
            {
                retorno = false;
            }
            else
            {
                if (strSenha == ((Usuario)obj).Senha)
                {
                    retorno = true;
                }  
            }
            return retorno;
        }



        public bool validaNome(object obj,string strNome)
        {
            //System.Type type = obj.GetType();
            bool retorno = false;

            if (obj == null || (obj.GetType() != typeof(Usuario)))
            {
                retorno = false;
            }
            else
            {
                if (strNome == ((Usuario)obj).Nome)
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

            return " Código : " + Codigo + "\n" + Environment.NewLine +
                   " Pasta : " + Pasta + Environment.NewLine + 
                   " Senha : " + Senha + Environment.NewLine +
                   " Nome : " + Nome + Environment.NewLine +
                   " Nome Completo :" + NomeCompleto;
        }

        public override bool Equals(object obj)
        {
            System.Type type = obj.GetType();
            if (obj == null || (type != typeof(Usuario)))
            {
		        return false;
	        } else {
		        return Codigo == ((Usuario)obj).Codigo;
	        }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public enum usuarioProperty
        {
	        Codigo = 1,
	        Pasta = 2,
	        Nome = 3,
	        Senha = 4,
	        NomeCompleto = 5
        }

    }
}
