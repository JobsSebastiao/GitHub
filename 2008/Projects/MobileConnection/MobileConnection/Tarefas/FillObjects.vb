Imports System.Data

Public NotInheritable Class FillObjects

    Public Shared Sub preencheDataGrid(ByVal dt As DataTable, ByVal dg As DataGrid, ByVal sql01 As String)

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

    Public Shared Sub preencheComboBox(ByVal cb As ComboBox, ByVal sql01 As String, ByVal dt As DataTable, ByVal columnName As String)

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
            cb.Items.Add(dr.ItemArray(0).ToString)
        Next

    End Sub

End Class
