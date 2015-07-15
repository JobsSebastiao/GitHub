Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Data
Imports System.Reflection

Module mdUtilitarios

    Public strUsuarioLogado As String
    Public intUsuarioLogado As Integer
    Public strSql01 As New StringBuilder()

    Public Sub GetIpAddressList(ByVal hostString As [String])

        Try
            ' Get 'IPHostEntry' object which contains information like host name, IP addresses, aliases 
            ' for specified url 
            Dim hostInfo As IPHostEntry = Dns.GetHostEntry(hostString)
            MsgBox(("Host name : " + hostInfo.HostName))
            MsgBox("IP address List : ")
            Dim index As Integer
            For index = 0 To hostInfo.AddressList.Length - 1
                MsgBox(hostInfo.AddressList(index))
            Next index
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.StackTrace))
            MsgBox(("Message : " + e.Message))
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.StackTrace))
            MsgBox(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.StackTrace))
            MsgBox(("Message : " + e.Message))
        End Try

    End Sub

    Public Sub preencheDataGrid(ByVal dt As DataTable, ByVal dg As DataGrid, ByVal sql01 As String)

        ''preenche um DataTable
        clsSqlServerConn.fillDataTable(dt, sql01)

        With dg
            .DataSource = Nothing
            .TableStyles.Clear()
            .DataSource = dt
        End With

        Dim tablestyle = New DataGridTableStyle()
        tablestyle.MappingName = dt.TableName

        Dim col As DataColumn

        For Each col In dt.Columns
            Dim dgtColumn = New DataGridTextBoxColumn()
            dgtColumn.HeaderText = col.ColumnName
            dgtColumn.MappingName = dgtColumn.HeaderText
            dgtColumn.Width = (dgtColumn.HeaderText.Length * 10)
            tablestyle.GridColumnStyles.Add(dgtColumn)
        Next

        dg.TableStyles.Clear()
        dg.TableStyles.Add(tablestyle)

    End Sub


    ''' <summary>
    ''' Preenche uma combo Utilizando um dataTable preenchido com um select na base de dados
    ''' </summary>
    ''' <param name="cb"></param>
    ''' <param name="sql01"></param>
    ''' <param name="dt"></param>
    ''' <param name="columnName"></param>
    ''' <remarks></remarks>
    Public Sub preencheComboBox(ByVal cb As ComboBox, ByVal sql01 As String, ByVal dt As DataTable, ByVal columnName As String)

        ''preenche um DataTable
        clsSqlServerConn.fillDataTable(dt, sql01)

        Dim dr As DataRow

        With cb
            .Items.Clear()
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DisplayMember = columnName
            .ValueMember = columnName
        End With

        For Each dr In dt.Rows()
            cb.Items.Add(dr.Item(columnName).ToString)
        Next

    End Sub

    ''' <summary>
    ''' Carrega um array list com objetos da classe clsUsuario
    ''' </summary>
    ''' <param name="dt">Data a ser preenchido com um commando Sql.</param>
    ''' <param name="sql01">Comando SqlServer</param>
    ''' <returns>Array List preenchido com objetos da classe clsUsuario</returns>
    ''' <remarks></remarks>
    Public Function fillArrayListUsuarios(ByVal dt As DataTable, ByVal sql01 As String)

        Dim al As New ArrayList
        Dim dr As DataRow

        ''preenche um DataTable
        clsSqlServerConn.fillDataTable(dt, sql01)

        For Each dr In dt.Rows()
            Dim objUsuario As New clsUsuario(CInt(dr.Item("Codigo")), CInt(dr.Item("Pasta")), dr.Item("Nome"), dr.Item("Senha"), dr.Item("NomeCompleto"))
            al.Add(objUsuario)
        Next

        Return al

    End Function

    ''' <summary>
    ''' Loop em todas as propriedades da instância de um objeto
    ''' </summary>
    ''' <param name="obj">Objeto ao qual será feito o loop em seus Atributos(Propriedades)</param>
    ''' <remarks></remarks>
    Public Sub DisplayAll(ByVal obj As Object)
        Dim _type As Type = obj.GetType()
        Dim properties() As PropertyInfo = _type.GetProperties()  'line 3
        For Each _property As PropertyInfo In properties
            Console.WriteLine("Name: " + _property.Name)
        Next
    End Sub


    Public Sub configPictureBox(ByVal pb As PictureBox, ByVal frm As Form, ByRef imglist As ImageList, ByVal imgIndex As Int32)

        imglist.ImageSize = New Size(frm.Size.Width, frm.Size.Height)

        With pb
            .BackColor = Color.Blue
            .Size() = New System.Drawing.Size(frm.Size.Width, frm.Size.Height)
            .Image = imglist.Images.Item(imgIndex)
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Valida o item selecionado na Combo e impede que o foco seja alterado caso
    ''' o texto digitado não pertença aos itens contidos na combobox
    ''' </summary>
    ''' <param name="cb">ComboBox a ser verificado</param>
    ''' <param name="control">Controle que recebera o foco após a válidação</param>
    ''' <param name="eKey">tecla pressionada (o enter(13) é o validador)</param>
    ''' <history>[Sebastiao Martins] 15/07/2015 Criado</history>
    ''' <remarks>A validação do ComboBox ocorre quando a tecla ENTER(13) for passada no parametro eKey</remarks>
    Public Sub validaComboBox(ByVal cb As ComboBox, ByVal control As Control, ByVal eKey As KeyEventArgs)

        If Not (cb.Text Is Nothing) Then
            Select Case eKey.KeyValue
                Case Keys.Enter
                    If (cb.SelectedItem <> Nothing) Then
                        If (cb.Items.IndexOf(cb.Text) <> -1) Then
                            control.Text = Nothing
                            control.Enabled = True
                            control.Focus()
                        Else
                            control.Text = Nothing
                            control.Enabled = False
                            cb.Focus()
                        End If
                    Else
                        control.Enabled = False
                        cb.Focus()
                    End If
                Case Keys.Delete
                Case Keys.Back
                    cb.Text = Nothing
            End Select
        End If

    End Sub

    'SELECT top 100 codigoPEDIDOCOMPRA AS Codigo,sistemaPEDIDOCOMPRA AS Sistema,statusPEDIDOCOMPRA AS Status,dataPEDIDOCOMPRA AS Data,
    'fornecedorPEDIDOCOMPRA AS Fornecedor,transportadoraPEDIDOCOMPRA AS Transportadora,quantidadeprodutosPEDIDOCOMPRA AS Quantidade
    'FROM tb1402_Pedidos 
    'WHERE statusPEDIDOCOMPRA = 1 
    'ORDER BY codigoPEDIDOCOMPRA DESC

    'SELECT top 1 codigoPEDIDOCOMPRA AS Codigo,sistemaPEDIDOCOMPRA AS Sistema,statusPEDIDOCOMPRA AS Status,dataPEDIDOCOMPRA AS Data,
    'fornecedorPEDIDOCOMPRA AS CodigoFornecedor,F.nomeEmpresa AS Fornecedor,
    'transportadoraPEDIDOCOMPRA AS CodigoTransportadora,T.nomeEMPRESA AS Transportadora,
    'quantidadeprodutosPEDIDOCOMPRA AS Quantidade
    'FROM tb1402_Pedidos
    'INNER JOIN tb0301_Empresas F ON F.codigoEMPRESA = fornecedorPEDIDOCOMPRA
    'INNER JOIN tb0301_Empresas T ON T.codigoEMPRESA = transportadoraPEDIDOCOMPRA
    'WHERE statusPEDIDOCOMPRA = 1 
    'ORDER BY codigoPEDIDOCOMPRA DESC



End Module
