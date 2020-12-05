Partial Class coffeeDataSet1
    Partial Public Class p_orderDataTable
        Private Sub p_orderDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.c_idColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
