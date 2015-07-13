Imports System.Data
Imports System.IO

Public Class frmPrincipal

    Private dtProduto As New DataTable("Produto")
    Private objProduto As clsProduto()
    Private objServices As New clsServices()

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carregaDataGridProduto()
        carregarComboPedido()
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgPrincipal.MouseUp
        objServices.datagridDetail(Me.dgPrincipal, e, Me.lbValor, Me.lb_row, Me.lbColuna, Me.lbTipo)
    End Sub

    Public Sub carregarComboPedido()
        Dim alPedido As New ArrayList(objServices.getArquivosDiretorio(".txt", "Pedido_"))

        For Each lista As String In alPedido
            cbPedido.Items.Add(lista)
        Next

    End Sub
    Public Sub carregaDataGridProduto()

        preencherDataTableProduto()

        With Me.dgPrincipal
            .DataSource = Nothing
            .TableStyles.Clear()
            .DataSource = dtProduto
        End With

        Dim tablestyle = New DataGridTableStyle()
        tablestyle.MappingName = dtProduto.TableName
        Dim col As DataColumn

        For Each col In dtProduto.Columns
            Dim dtgColumn = New DataGridTextBoxColumn()
            dtgColumn.HeaderText = col.ColumnName
            dtgColumn.MappingName = dtgColumn.HeaderText
            dtgColumn.Width = (dtgColumn.HeaderText.Length * 10)
            tablestyle.GridColumnStyles.Add(dtgColumn)
        Next

        dgPrincipal.TableStyles.Clear()
        dgPrincipal.TableStyles.Add(tablestyle)

    End Sub

    ''' <summary>
    ''' Preenche um data table com uma lista de produtos
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub preencherDataTableProduto()

        'Lê um arquivo de texto em um diretório
        Dim alListaProduto As New ArrayList(objServices.readTextFile())
        Dim strArrayProduto() As String
        Dim intFimArray As Integer = alListaProduto.Count - 2

        Try
            'Cria as colunas do datatable
            dtProduto.Clear()
            dtProduto.Columns.Clear()
            dtProduto.Columns.Add("Código")
            dtProduto.Columns.Add("Produto")
            dtProduto.Columns.Add("Qtd")
            dtProduto.Columns.Add("Local")
            dtProduto.Columns.Add("Ean13")
            dtProduto.Columns.Add("PartNumber")

            'Preenche o datatable com o valor contido no arquivo de texto
            For i As Integer = 0 To intFimArray
                strArrayProduto = Split(alListaProduto.Item(i).ToString, "|")
                dtProduto.Rows.Add(strArrayProduto)
            Next
            'Me.dgPrincipal.DataSource = dt

        Catch ex As ArgumentException
            If (ex.[GetType].Name = "ArgumentException") Then
                MsgBox("Descrição: " + ex.Message + Environment.NewLine + "Erro durante a passagem de valores para o datagrid!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Carga do Datagrid")
            End If
        Catch e As Exception
            MsgBox("Descrição: " + e.Message + Environment.NewLine + "Contate o administrador do sistema!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Carga do Datagrid")
        End Try

    End Sub

    Public Function geraPedidos() As ArrayList

        Dim al As New ArrayList()
        For i As Integer = 1 To 10
            al.Add(New clsProduto(i, i.ToString, i + (i * 2) + ((i / 2) Mod 2), "Local: " & i, "ean", "R07" & (i * 10 + 30 * 50).ToString))
        Next
        Return al

    End Function

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuGerarArquivo.Click
        objServices.gerarTextFilePedido("", geraPedidos())
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuReload.Click
        carregaDataGridProduto()
    End Sub

End Class
