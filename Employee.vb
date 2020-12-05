Imports System.Data.SqlClient


Public Class Employee
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim dv As DataView
    Dim str As String
    Dim emp As Object
    Dim getmob As String
    Dim getcust As String
    Dim gen As String

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CoffeeDataSet3.emp' table. You can move, or remove it, as needed.
        Me.EmpTableAdapter.Fill(Me.CoffeeDataSet3.emp)
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getcust = "SELECT nextID=MAX(Id)+1 FROM emp"
            com = New SqlCommand(getcust, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                TextBox8.Text = dr.GetValue(0).ToString()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")

        If radioButton1.Checked Then
            gen = "Male"
        ElseIf radioButton2.Checked Then
            gen = "Female"
        End If
        com = New SqlCommand("insert into emp(name,addr,city,contact,gender,email,doj,salary) values('" & textBox1.Text & "','" & textBox4.Text & "','" & textBox5.Text & "','" & textBox2.Text & "','" + gen + "','" & textBox3.Text & "','" & textBox6.Text & "','" & textBox7.Text & "')", con)
        con.Open()
        Try
            com.ExecuteNonQuery()

        Catch ee As Exception

            Console.WriteLine()


        End Try

        MsgBox("Employee Infromation Inserted Successfullyy..")

        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM emp"
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, emp)

        End Using

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        con.Open()

        Try
            getmob = "select name,addr,city,contact,email,doj,salary from emp where id='" & TextBox8.Text & "'"
            com = New SqlCommand(getmob, con)
            dr = com.ExecuteReader()
            If dr.Read() Then

                textBox1.Text = dr.GetValue(0).ToString()
                textBox4.Text = dr.GetValue(1).ToString()
                textBox5.Text = dr.GetValue(2).ToString()
                textBox2.Text = dr.GetValue(3).ToString()
                textBox3.Text = dr.GetValue(4).ToString()
                textBox6.Text = dr.GetValue(5).ToString()
                textBox7.Text = dr.GetValue(6).ToString()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
        com = New SqlCommand(" update emp set name='" + textBox1.Text + "',addr='" + textBox4.Text + "',city='" + textBox5.Text + "',contact='" + textBox2.Text + "',email='" + textBox3.Text + "',doj='" + textBox6.Text + "',salary='" + textBox7.Text + "' where id='" + TextBox8.Text + "'", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Employee Record updated Successfully..")
        Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            str = "SELECT * FROM emp "
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)

            DataGridView1.DataSource = New BindingSource(dt, emp)
        End Using
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        textBox5.Text = ""
        textBox6.Text = ""
        textBox7.Text = ""
        textBox1.Text = ""
        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
            con.Open()
            str = "DELETE FROM emp WHERE id = '" & TextBox8.Text & "'"

            com = New SqlCommand(str, con)
            com.ExecuteNonQuery()
            con.Close()
            MsgBox(" Employee Record Delete Successfully")
            Using con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sudhvina A.S\Documents\BluebayCoffee\CoffeeShopManagementSystemVB\CoffeeShopManagementSystemVB\coffee.mdf")
                str = "SELECT * FROM emp"
                com = New SqlCommand(str, con)
                da = New SqlDataAdapter(com)
                dt = New DataTable()
                dv = New DataView()
                da.Fill(dt)

                DataGridView1.DataSource = New BindingSource(dt, emp)

            End Using
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            textBox5.Text = ""
            textBox6.Text = ""
            textBox7.Text = ""
            textBox1.Text = ""


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
End Class