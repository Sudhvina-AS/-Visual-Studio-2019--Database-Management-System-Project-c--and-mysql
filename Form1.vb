Public Class Form1
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If textBox1.Text = "1" And textBox2.Text = "2" Then
            MessageBox.Show("You Have logged successfully..")
            Home.Show()
            Hide()
        Else
            MessageBox.Show("login fail")
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        textBox1.Text = ""
        textBox2.Text = ""
    End Sub

    Private Sub label3_Click(sender As Object, e As EventArgs)

    End Sub
End Class
