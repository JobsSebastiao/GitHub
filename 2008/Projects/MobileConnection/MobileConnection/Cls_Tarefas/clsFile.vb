Imports System
Imports System.IO
Imports System.Text
Imports System.Windows
Imports System.Reflection


Public Class clsFile

    Private _pathMobile As String 'path diretório onde está salva a aplicação.
    Private _fileName As String 'nome do arquivo a ser utilizado (ex : exemplo.txt)
    Private _fullPath As String 'caminho completo para o arquivo a ser utilizado

#Region "Contrutures Gets e Sets"

    ''' <summary>
    ''' 'Ao ser instanciada configura um caminho padrão e um arquivo padrão onde será buscado o arquivo .txt contendo a string de conexão
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New() 'contrutor define caminho default de arquivo
        PathMobile() = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
        FileName() = "strConn.txt"
        setFullPath()
    End Sub

    ''' <summary>
    ''' Ao ser instanciada configura um caminho e um nome de arquivo 
    ''' de acordo com os parâmetros informados. 
    ''' </summary>
    ''' <param name="strPathMobile">Path no dispositivo mobile</param>
    ''' <param name="strFileName">Nome de um arquivo de text existente no Path informado</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal strPathMobile As String, ByVal strFileName As String)
        PathMobile() = strPathMobile
        FileName() = strFileName
        setFullPath()
    End Sub

    Public Property PathMobile() As String
        Get
            Return _pathMobile
        End Get

        Set(ByVal value As String)
            If (value <> "") Then
                If (value.Substring(value.Length - 1) <> "\") Then
                    value = value + "\"
                End If
                _pathMobile = value
            Else
                _pathMobile = Nothing
            End If
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _fileName
        End Get

        Set(ByVal value As String)
            If (value <> "") Then
                If (value.Substring(0, 1) = "\") Then
                    value = Replace(Replace(value.Substring(1), "/", "_"), "\", "_")
                End If
                _fileName = value
            End If
        End Set

    End Property

    Public Function getFullPath() As String
        Return _fullPath
    End Function

    Public Sub setFullPath()

        If (PathMobile() <> "" And FileName() <> "") Then
            _fullPath = PathMobile() + FileName()
        ElseIf (PathMobile() <> "" And FileName() = "") Then
            _fullPath = PathMobile() & "text" & Date.Now.DayOfYear & ".txt"
        Else
            _fullPath = Nothing
        End If

    End Sub

    Public Sub setFullPath(ByVal pathMobile As String, ByVal fileName As String)

        If (pathMobile <> "" And fileName <> "") Then
            _fullPath = pathMobile + fileName
        ElseIf (pathMobile <> "" And fileName = "") Then
            _fullPath = pathMobile & "text" & Date.Now.DayOfYear & ".txt"
        Else
            _fullPath = Nothing
        End If

    End Sub

#End Region


    ''' <summary>
    ''' Criar um arquivo de texto
    ''' </summary>
    ''' <param name="strTexto">Texto a ser salvo no arquivo</param>
    ''' <remarks></remarks>
    Public Overloads Sub salvarArquivoTexto(ByVal strTexto As String)

        'caminho onde será salvo o arquivo
        Dim fullPath As String = Path.GetFullPath(PathMobile())

        'Deleta o arquivo caso ele já exista 
        If File.Exists(fullPath) Then
            File.Delete(fullPath)
        End If

        'Criar o novo arquivo e adiciona o texto.
        Dim fs As FileStream = File.Create(fullPath)
        AddText(fs, strTexto)
        fs.Close()

        'Open the stream and read it back.
        fs = File.OpenRead(fullPath)
        Dim b(1024) As Byte
        Dim temp As UTF8Encoding = New UTF8Encoding(True)

        Do While fs.Read(b, 0, b.Length) > 0
            Console.WriteLine(temp.GetByteCount(b.ToString))
        Loop

        fs.Close()

    End Sub

    ''' <summary>
    ''' Recebe um objeto Produto e salva um arquivo de texto separado por | entre cada parâmetro
    ''' </summary>
    ''' <param name="strTexto"></param>
    ''' <param name="listaProduto">Array list com objetos Produto.</param>
    ''' <remarks></remarks>
    Public Overloads Sub gerarTextFile(ByVal strTexto As String, ByVal listaProduto As ArrayList)

        Dim fullPath As String = Path.GetFullPath(PathMobile())

        Try

            'Deleta o arquivo caso ele já exista 
            If File.Exists(fullPath) Then
                File.Delete(fullPath)
            End If

            Dim fs As FileStream = File.Create(fullPath)

            For Each produto As clsProduto In listaProduto
                'Criar o novo arquivo e adiciona o texto.
                Dim str As String = produto.ToString
                AddText(fs, str)
            Next

            fs.Close()

            'Open the stream and read it back.
            fs = File.OpenRead(fullPath)
            Dim b(1024) As Byte
            Dim temp As UTF8Encoding = New UTF8Encoding(True)

            Do While fs.Read(b, 0, b.Length) > 0
                Console.WriteLine(temp.GetByteCount(b.ToString))
            Loop
            fs.Close()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Lê um arquivo de texto disponível na rede
    ''' </summary>
    ''' <returns>Um array list contendo os dados do arquivo de texto</returns>
    ''' <remarks></remarks>
    Public Overloads Function readTextFile() As ArrayList

        Dim fullPath As String = Path.GetFullPath(getFullPath())
        Dim alTextFile As New ArrayList()

        Try
            'instancia um streamReader que irá ler o arquivo informado
            Dim sr As StreamReader = New StreamReader(fullPath)
            Dim line As String

            Do
                line = sr.ReadLine()
                alTextFile.Add(line)
            Loop Until line Is Nothing
            sr.Close()
        Catch E As Exception
            MsgBox("O arquivo não pode ser lido.")
            Debug.WriteLine(E.Message)
        End Try

        Return alTextFile

    End Function

    ''' <summary>
    ''' Lê um arquivo de texto disponível na rede
    ''' </summary>
    ''' <returns>Um array list contendo os dados do arquivo de texto</returns>
    ''' <remarks></remarks>
    Public Overloads Function readTextFile(ByVal strPathMobile As String, ByVal strNomeArquivo As String) As ArrayList

        ''Seta o novo caminho para o parametro _fullPath
        setFullPath(strPathMobile, strNomeArquivo)

        Dim fullPath As String = Path.GetFullPath(getFullPath())
        Dim alTextFile As New ArrayList()

        Try
            'instancia um streamReader que irá ler o arquivo informado
            Dim sr As StreamReader = New StreamReader(fullPath)
            Dim line As String

            Do
                line = sr.ReadLine()
                alTextFile.Add(line)
            Loop Until line Is Nothing
            sr.Close()
        Catch E As Exception
            MsgBox("O arquivo não pode ser lido.")
            Debug.WriteLine(E.Message)
        End Try

        Return alTextFile

    End Function



    ''' <summary>
    ''' Recupera um arquivo em um caminho informado no parametro Fullpath do objeto
    ''' </summary>
    ''' <param name="extensao">tipo de extensão do arquivo a ser encontrado  EX= ".txt"</param>
    ''' <param name="strArquivo">String parte do nome do arquivo a ser buscado para que seja feita uma verificação antes de retornar o arquivo</param>
    ''' <returns>Arraylist de String contendo o nome dos arquivos encontrados no diretório</returns>
    ''' <remarks></remarks>
    Public Function getFileOnDirectory(ByVal extensao As String, ByVal strArquivo As String) As String

        Dim alArquivos As String = Nothing
        Dim caminho As String = PathMobile()

        If (caminho.Substring(caminho.Length - 1) <> "\") Then
            caminho = caminho & "\"
        End If

        ''Recupera todos os arquivos do diretório
        For Each entry As String In IO.Directory.GetFiles(Path.GetDirectoryName(caminho))
            'Verifica a extensão do arquivo
            If (Path.GetExtension(entry) = extensao) Then
                'Faz a verificação com base na variável strArquivo
                Dim str As String = Mid(Path.GetFileNameWithoutExtension(entry).ToString, 1, strArquivo.Length)
                If (str = strArquivo) Then
                    'adiciona o arquivo ao ArrayList
                    alArquivos = ((Path.GetFileNameWithoutExtension(entry)).ToString)
                End If
            End If
        Next

        Return alArquivos

    End Function


    ''' <summary>
    ''' Recupera um arquivo em um caminho informado no parametro Fullpath do objeto
    ''' </summary>
    ''' <param name="extensao">tipo de extensão do arquivo a ser encontrado  EX= ".txt"</param>
    ''' <param name="strArquivo">String parte do nome do arquivo a ser buscado para que seja feita uma verificação antes de retornar o arquivo</param>
    ''' <returns>Arraylist de String contendo o nome dos arquivos encontrados no diretório</returns>
    ''' <remarks></remarks>
    Public Function getArquivosDiretorio(ByVal extensao As String, ByVal strArquivo As String) As ArrayList

        Dim alArquivos As New ArrayList
        Dim caminho As String = PathMobile()

        If (caminho.Substring(caminho.Length - 1) <> "\") Then
            caminho = caminho & "\"
        End If

        ''Recupera todos os arquivos do diretório
        For Each entry As String In IO.Directory.GetFiles(Path.GetDirectoryName(caminho))
            'Verifica a extensão do arquivo
            If (Path.GetExtension(entry) = extensao) Then
                'Faz a verificação com base na variável strArquivo
                Dim str As String = Mid(Path.GetFileNameWithoutExtension(entry).ToString, 1, strArquivo.Length)
                If (str = strArquivo) Then
                    'adiciona o arquivo ao ArrayList
                    alArquivos.Add((Path.GetFileNameWithoutExtension(entry)).ToString)
                End If
            End If
        Next

        Return alArquivos

    End Function

    ''' <summary>
    ''' Retorna os diretórios existentes no caminho informado
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDiretorio() As ArrayList

        Dim alDiretorio As New ArrayList

        For Each entry As String In IO.Directory.GetDirectories(Path.GetDirectoryName(getFullPath()))
            alDiretorio.Add(New IO.FileInfo(entry).ToString)
        Next

        Return alDiretorio

    End Function


    ''' <summary>
    ''' Gera um array a partir de uma string sendo nescessário indicar apenas o tipo de caracter que irá servir como split
    ''' </summary>
    ''' <param name="strFile">String da qual será gerado a Array de string</param>
    ''' <param name="splitCaracter">Tipo de caracter a ser usado como separador no split</param>
    ''' <returns>Array preenchido com valores do tipo string de acordo com a quantidade de separadores encontrados na string </returns>
    ''' <remarks></remarks>
    ''' <exemplo>   
    ''' string = "text1/text2/text3/text4/text5" onde o separador e o caracter "/"
    ''' 
    ''' o retorno será um array com 5 posições
    ''' string(0)= text1
    ''' string(1)= text2
    ''' string(2)= text3
    ''' string(3)= text4
    ''' string(4)= text5
    ''' </exemplo>
    Public Function arrayOfTextFile(ByVal strFile As String, ByVal splitCaracter As splitType) As Array

        Dim arrayFile As String() = Nothing
        arrayFile = Split(strFile, defineSplitType(splitCaracter))

        Return arrayFile

    End Function

    ''' <summary>
    ''' Utilizado para montar um arquivo de texto
    ''' </summary>
    ''' <param name="fs">FileStream</param>
    ''' <param name="value">Texto</param>
    ''' <remarks></remarks>
    Private Shared Sub AddText(ByVal fs As FileStream, ByVal value As String)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(value)
        fs.Write(info, 0, info.Length)
    End Sub


    ''' <summary>
    ''' Define um caracter para ser usado como separador na função Split()
    ''' </summary>
    ''' <param name="splitType">Tipo de caracter a ser usado com separador (ENUM)</param>
    ''' <returns>o caracter a ser usado como separador</returns>
    ''' <remarks></remarks>
    Public Function defineSplitType(ByVal splitType) As String
        Dim splitCaracter As String = Nothing

        Select Case splitType
            Case 1
                splitCaracter = "/"
            Case 2
                splitCaracter = "\"
            Case 3
                splitCaracter = ":"
            Case 4
                splitCaracter = "|"
            Case 5
                splitCaracter = ";"
            Case 6
                splitCaracter = ","
            Case 7
                splitCaracter = "&"
            Case 8
                splitCaracter = "!"
            Case 9
                splitCaracter = "&"
            Case Else
                splitCaracter = "|"
        End Select

        Return splitCaracter

    End Function

    ''' <summary>
    ''' Tipos de caracteres que devem ser usados como separador
    ''' </summary>
    ''' <remarks></remarks>
    Enum splitType
        BARRA = 1
        BARRA_INVERTIDA = 2
        DOIS_PONTOS = 3
        PIPE = 4
        PONTO_VIRGULA = 5
        VIRGULA = 6
        E_COMERCIAL = 7
        EXCLAMACAO = 8
        CIFRAO = 9
    End Enum


#Region "sem uso"

    Public Function PreencheFileStream() As FileStream

        Dim fs As FileStream

        Dim fullPath As String = Path.GetFullPath(PathMobile())

        If File.Exists(fullPath) Then
            File.Delete(fullPath)
        End If

        fs = File.Create(fullPath)

        AddText(fs, "This is some text")
        AddText(fs, "This is some more text,")
        AddText(fs, Environment.NewLine & "and this is on a new line")
        AddText(fs, Environment.NewLine & Environment.NewLine)
        AddText(fs, "The following is a subset of characters:" & Environment.NewLine)

        Return fs
    End Function

#End Region

End Class
