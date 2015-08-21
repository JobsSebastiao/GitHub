using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Utility
/// </summary>
public class FileUtility
{
	
    //nome do arquivo a ser utilizado (ex : exemplo.txt)
    private string _fileName;


    #region "Contrutures Gets e Sets"


    /// <summary>
    /// 'Ao ser instanciada configura um caminho padrão e um arquivo padrão onde será buscado o arquivo .txt contendo a string de conexão
    /// </summary>
    /// <remarks></remarks>
    //contrutor define caminho default de arquivo
    public FileUtility()
    {

    }

    public string FileName {
        get { return _fileName; }

        set {
            if ((!string.IsNullOrEmpty(value))) {
                if ((value.Substring(0, 1) == "\\")) {
                    value = value.Substring(1).Replace("/", "_").Replace("\\","_");
                }
                _fileName = value;
            }
        }
    }

    #endregion


    /// <summary>
    /// Lê um arquivo de texto disponível na rede
    /// </summary>
    /// <returns>Um array list contendo os dados do arquivo de texto</returns>
    /// <remarks></remarks>
    public List <string> readTextFile(String caminhoArquivo)
    {

        string fullPath = caminhoArquivo;
        List<string> alTextFile = new List<string>();

        try {
            //instancia um streamReader que irá ler o arquivo informado
            StreamReader sr = new StreamReader(fullPath);
            string line = null;

            do {
                line = sr.ReadLine();
                alTextFile.Add(line);
            } while (!(line == null));
            sr.Close();
        } catch (Exception ex) {
            Debug.WriteLine(ex.Message);
        }

        return alTextFile;

    }


    /// <summary>
    /// Gera um array a partir de uma string sendo nescessário indicar apenas o 
    /// tipo de caracter que irá servir como split e a string a ser trabalhada no array.
    /// </summary>
    /// <param name="strFile">String da qual será gerado a Array de string</param>
    /// <param name="splitCaracter">Tipo de caracter a ser usado como separador no split</param>
    /// <returns>Array preenchido com valores do tipo string de acordo com a Quantidade de separadores encontrados na string </returns>
    /// <remarks></remarks>
    /// <exemplo>
    /// 
    /// string = "text1/text2/text3/text4/text5" onde o separador e o caracter "/"
    /// 
    /// o retorno será um array com 5 posições
    /// string(0)= text1
    /// string(1)= text2
    /// string(2)= text3
    /// string(3)= text4
    /// string(4)= text5
    /// </exemplo>
    public static String[] arrayOfTextFile(string strFile, splitType splitCaracter)
    {
        try
        {
            string[] arrayFile = null;
             char  splitCarac = (char)defineSplitType(splitCaracter);
            arrayFile = strFile.Split(splitCarac);
            return arrayFile;
        }
        catch(Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Utilizado para montar um arquivo de texto
    /// </summary>
    /// <param name="fs">FileStream</param>
    /// <param name="value">Texto</param>
    /// <remarks></remarks>
    private static void AddText(System.IO.FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }


    /// <summary>
    /// Define um caracter para ser usado como separador na função Split()
    /// </summary>
    /// <param name="splitType">Tipo de caracter a ser usado com separador (ENUM)</param>
    /// <returns>o caracter a ser usado como separador</returns>
    /// <remarks></remarks>
    public static char defineSplitType(splitType st)
    {
        char splitCaracter;

        switch (st) {
            case splitType.BARRA:
                splitCaracter = '/';
                break;
            case splitType.BARRA_INVERTIDA :
                splitCaracter = '\\';
                break;
            case splitType.DOIS_PONTOS :
                splitCaracter = ':';
                break;
            case splitType.PIPE :
                splitCaracter = '|';
                break;
            case splitType.PONTO_VIRGULA:
                splitCaracter = ';';
                break;
            case splitType.VIRGULA:
                splitCaracter = ',';
                break;
            case splitType.E_COMERCIAL :
                splitCaracter = '&';
                break;
            case splitType.EXCLAMACAO :
                splitCaracter = '!';
                break;
            case splitType.CIFRAO :
                splitCaracter = '$';
                break;
            default:
                splitCaracter = '|';
                break;
        }

        return splitCaracter;

    }

    /// <summary>
    /// Tipos de caracteres que devem ser usados como separador
    /// </summary>
    /// <remarks></remarks>
    public enum splitType
    {
        BARRA = 1,
        BARRA_INVERTIDA = 2,
        DOIS_PONTOS = 3,
        PIPE = 4,
        PONTO_VIRGULA = 5,
        VIRGULA = 6,
        E_COMERCIAL = 7,
        EXCLAMACAO = 8,
        CIFRAO = 9
    }

}
