Public Class Home
    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        Customer.ShowDialog()
    End Sub

    Private Sub CoffeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoffeeToolStripMenuItem.Click
        AddCoffee.ShowDialog()
    End Sub

    Private Sub PlaceOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaceOrderToolStripMenuItem.Click
        PlaceOrder.ShowDialog()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        Employee.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Hide()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class