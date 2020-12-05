Imports System.Data.SqlClient

Public Class AddCoffee
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim dv As DataView
    Dim str As String
    Dim coffee As Object
    Dim getmob As String
    Dim getcust As String
    Dim gen As String

    Private Sub AddCoffee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CoffeeDataSet2.acoffee' table. You can move, or remove it, as needed.
        Me.AcoffeeTableAdapter.Fill(Me.CoffeeDataSet2.acoffee)
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getcust = "SELECT nextID=MAX(Id)+1 FROM acoffee"
            com = New SqlCommand(getcust, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox1.Text = dr.GetValue(0).ToString()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")


        com = New SqlCommand("insert into acoffee(Id,name,type,price) values('" & textBox1.Text & " ','" & textBox2.Text & "','" & textBox3.Text & "','" & textBox4.Text & "')", con)
        con.Open()
        Try
            com.ExecuteNonQuery()
            MsgBox("New Coffee Infromation Inserted Successfullyy..")
        Catch ee As Exception
            MsgBox(ee.ToString)
        End Try




        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""

        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM acoffee"
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, coffee)

        End Using

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getmob = "select name,type,price from acoffee where id='" & textBox1.Text & "'"
            com = New SqlCommand(getmob, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox2.Text = dr.GetValue(0).ToString()
                textBox3.Text = dr.GetValue(1).ToString()
                textBox4.Text = dr.GetValue(2).ToString()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        com = New SqlCommand(" update acoffee set name='" + textBox2.Text + "',type='" + textBox3.Text + "',price='" + textBox4.Text + "' where id='" + textBox1.Text + "'", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Coffee Record updated Successfully..")
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM acoffee "
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, coffee)
        End Using
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""

        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "DELETE FROM coffee WHERE id = '" & textBox1.Text & "'"

            com = New SqlCommand(str, con)

            com.ExecuteNonQuery()
            con.Close()
            MsgBox(" Coffee Record Delete Successfully")
            Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
                str = "SELECT * FROM acoffee"
                com = New SqlCommand(str, con)
                da = New SqlDataAdapter(com)
                dt = New DataTable()
                dv = New DataView()
                da.Fill(dt)

                DataGridView1.DataSource = New BindingSource(dt, coffee)

            End Using
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub textBox4_TextChanged(sender As Object, e As EventArgs) Handles textBox4.TextChanged

    End Sub



End Class


