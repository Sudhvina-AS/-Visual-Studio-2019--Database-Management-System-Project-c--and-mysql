Imports System.Data.SqlClient

Public Class PlaceOrder
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim dv As DataView
    Dim str As String
    Dim order As Object
    Dim getmob As String
    Dim getcust As String
    Dim gen As String

    Private Sub PlaceOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CoffeeDataSet1.p_order' table. You can move, or remove it, as needed.
        Me.P_orderTableAdapter.Fill(Me.CoffeeDataSet1.p_order)
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getcust = "SELECT nextID=MAX(Id)+1 FROM p_order"
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
        com = New SqlCommand("insert into p_order(c_id,c_name,addr,city,name,price,date) values('" & textBox2.Text & "','" & textBox3.Text & "','" & textBox4.Text & "','" & textBox5.Text & "','" + comboBox1.Text + "','" & textBox6.Text & "','" & textBox7.Text & "')", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Place Order Successfullyy..")

        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM p_order"
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, order)

        End Using

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getmob = "select c_id,c_name,addr,city,name,price,date from p_order where id='" & textBox1.Text & "'"
            com = New SqlCommand(getmob, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox2.Text = dr.GetValue(0).ToString()
                textBox3.Text = dr.GetValue(1).ToString()
                textBox4.Text = dr.GetValue(2).ToString()
                textBox5.Text = dr.GetValue(3).ToString()
                comboBox1.Text = dr.GetValue(4).ToString()
                textBox6.Text = dr.GetValue(5).ToString()
                textBox7.Text = dr.GetValue(6).ToString()



            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        com = New SqlCommand(" update p_order set c_id='" + textBox1.Text + "',c_name='" + textBox4.Text + "',addr='" + textBox5.Text + "',city='" + textBox2.Text + "',name='" + textBox3.Text + "',price='" + textBox6.Text + "',date='" + textBox7.Text + "' where id='" + textBox1.Text + "'", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Place Order Changed Successfully..")
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM p_order "
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, order)
        End Using
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""
        textBox7.Text = ""
        comboBox1.Text = "--Select--"

        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            con.Open()
            str = "DELETE FROM p_order WHERE id = '" & textBox1.Text & "'"

            com = New SqlCommand(str, con)
            com.ExecuteNonQuery()
            con.Close()
            MsgBox(" Placed Order is Delete Successfully")
            Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
                str = "SELECT * FROM p_order"
                com = New SqlCommand(str, con)
                da = New SqlDataAdapter(com)
                dt = New DataTable()
                dv = New DataView()
                da.Fill(dt)

                DataGridView1.DataSource = New BindingSource(dt, order)

            End Using
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            textBox5.Text = ""
            textBox6.Text = ""
            textBox7.Text = ""
            textBox1.Text = ""
            comboBox1.Text = "--Select--"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub textBox2_TextChanged(sender As Object, e As EventArgs) Handles textBox2.TextChanged
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getmob = "select name,addr,city from cust where id='" & textBox2.Text & "'"
            com = New SqlCommand(getmob, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox3.Text = dr.GetValue(0).ToString()
                textBox4.Text = dr.GetValue(1).ToString()
                textBox5.Text = dr.GetValue(2).ToString()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub
End Class