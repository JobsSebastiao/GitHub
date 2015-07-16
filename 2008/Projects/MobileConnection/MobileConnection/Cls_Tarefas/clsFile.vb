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

    Public Sub New() 'contrutor define caminho default de arquivo
        PathMobile() = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
        FileName() = "text" & Date.Now.DayOfYear & ".txt"
        setFullPath()
    End Sub

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
                    value += value + "\"
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
                    value = value.Substring(1)
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
    Public Function getArquivosDiretorio(ByVal extensao As String, ByVal strArquivo As String) As ArrayList

        Dim alArquivos As New ArrayList

        ''Recupera todos os arquivos do diretório
        For Each entry As String In IO.Directory.GetFiles(Path.GetDirectoryName(PathMobile()))
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
    ''' Utilizado para montar um arquivo de texto
    ''' </summary>
    ''' <param name="fs">FileStream</param>
    ''' <param name="value">Texto</param>
    ''' <remarks></remarks>
    Private Shared Sub AddText(ByVal fs As FileStream, ByVal value As String)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(value)
        fs.Write(info, 0, info.Length)
    End Sub


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
