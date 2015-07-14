Imports System
Imports System.IO
Imports System.Text
Imports System.Windows
Imports System.Reflection


Public Class clsServices

    Private _arquivoPedido As String 'path diretório mobile
    Private _fullPath As String

#Region "Contrutures Gets e Sets"

    Public Sub New() 'contrutor define caminho default de arquivo
        ArquivoPedido = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\Pedido_2.txt"
        FullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\"
    End Sub

    Public Sub New(ByVal strDiretorio As String)
        ArquivoPedido = strDiretorio
    End Sub

    Public Property ArquivoPedido() As String
        Get
            Return _arquivoPedido
        End Get

        Set(ByVal value As String)
            If (value <> "") Then
                _arquivoPedido = value
            Else
                _arquivoPedido = Nothing
            End If
        End Set
    End Property

    Public Property FullPath() As String
        Get
            Return _fullPath
        End Get

        Set(ByVal value As String)
            If (value <> "") Then
                _fullPath = value
            Else
                _fullPath = Nothing
            End If
        End Set
    End Property


#End Region

    ''' <summary>
    ''' Criar um arquivo de texto
    ''' </summary>
    ''' <param name="strTexto">Texto a ser salvo no arquivo</param>
    ''' <remarks></remarks>
    Public Overloads Sub salvarArquivoTexto(ByVal strTexto As String)

        'caminho onde será salvo o arquivo
        Dim fullPath As String = Path.GetFullPath(ArquivoPedido())

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
    Public Overloads Sub gerarTextFilePedido(ByVal strTexto As String, ByVal listaProduto As ArrayList)

        Dim fullPath As String = Path.GetFullPath(ArquivoPedido())

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
    Public Function readTextFile() As ArrayList

        Dim fullPath As String = Path.GetFullPath(ArquivoPedido())
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
        For Each entry As String In IO.Directory.GetFiles(Path.GetDirectoryName(Me.FullPath))
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

        For Each entry As String In IO.Directory.GetDirectories(Path.GetDirectoryName(Me.FullPath))
            alDiretorio.Add(New IO.FileInfo(entry).ToString)
        Next

        Return alDiretorio

    End Function

    ''' <summary>
    ''' Detalha os dados de um datagrid
    ''' </summary>
    ''' <param name="datagrid"> DataGrid</param>
    ''' <param name="e">Evento</param>
    ''' <param name="lbValor"></param>
    ''' <param name="lbRow"></param>
    ''' <param name="lbColuna"></param>
    ''' <param name="lbTipo"></param>
    ''' <remarks></remarks>
    Public Sub datagridDetail(ByVal datagrid As DataGrid, ByVal e As System.Windows.Forms.MouseEventArgs, _
                              ByVal lbValor As Label, ByVal lbRow As Label, ByVal lbColuna As Label, _
                              ByVal lbTipo As Label)

        Dim hitInfo As System.Windows.Forms.DataGrid.HitTestInfo
        hitInfo = datagrid.HitTest(e.X, e.Y)

        lbValor.Text = String.Empty
        lbRow.Text = String.Format("Row: {0}", hitInfo.Row)
        lbColuna.Text = String.Format("Column: {0}", hitInfo.Column)
        lbTipo.Text = String.Format("Type: {0}", hitInfo.Type.ToString())

        If hitInfo.Type = System.Windows.Forms.DataGrid.HitTestType.Cell Then
            Dim selCell As Object
            selCell = datagrid.Item(hitInfo.Row, hitInfo.Column)
            If Not selCell Is Nothing Then
                lbValor.Text = selCell.ToString()
            End If
        End If

    End Sub

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

        Dim fullPath As String = Path.GetFullPath(ArquivoPedido())

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
