Imports System.Data.SqlClient

Public Class Customer
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim dv As DataView
    Dim str As String
    Dim cust As Object
    Dim getmob As String
    Dim getcust As String
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CoffeeDataSet.cust' table. You can move, or remove it, as needed.
        Me.CustTableAdapter.Fill(Me.CoffeeDataSet.cust)
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getcust = "SELECT nextID=MAX(Id)+1 FROM cust"
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


        com = New SqlCommand("insert into cust(name,addr,city,contact,email) values('" & textBox2.Text & "','" & textBox3.Text & "','" & textBox4.Text & "','" & textBox5.Text & "','" & textBox6.Text & "')", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Customer Infromation Inserted Successfullyy..")



        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM cust"
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, cust)

        End Using

    End Sub



    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles textBox1.TextChanged

    End Sub



    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getmob = "select name,addr,city,contact,email from cust where id='" & textBox1.Text & "'"
            com = New SqlCommand(getmob, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox2.Text = dr.GetValue(0).ToString()
                textBox3.Text = dr.GetValue(1).ToString()
                textBox4.Text = dr.GetValue(2).ToString()
                textBox5.Text = dr.GetValue(3).ToString()
                textBox6.Text = dr.GetValue(4).ToString()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        com = New SqlCommand(" update cust set name='" + textBox2.Text + "',addr='" + textBox3.Text + "',city='" + textBox4.Text + "',contact='" + textBox5.Text + "',email='" + textBox6.Text + "' where id='" + textBox1.Text + "'", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Customer Record updated Successfully..")
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM cust "
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, cust)
        End Using
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""

        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            con.Open()
            str = "DELETE FROM cust WHERE id = '" & textBox1.Text & "'"

            com = New SqlCommand(str, con)
            com.ExecuteNonQuery()
            con.Close()
            MsgBox(" customer Record Delete Successfully")
            Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
                str = "SELECT * FROM cust"
                com = New SqlCommand(str, con)
                da = New SqlDataAdapter(com)
                dt = New DataTable()
                dv = New DataView()
                da.Fill(dt)

                DataGridView1.DataSource = New BindingSource(dt, cust)

            End Using
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            textBox5.Text = ""
            textBox6.Text = ""


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class