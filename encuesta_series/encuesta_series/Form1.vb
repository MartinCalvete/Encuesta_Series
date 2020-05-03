Imports MySql.Data.MySqlClient
'Martin Calvete 3BF
Public Class Form1
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Dim conexion As MySqlConnection
        conexion = New MySqlConnection

        Dim cmd As New MySqlCommand
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Dim ds As New DataSet

        conexion.ConnectionString = "server=localhost; database=encuesta;Uid=root;Pwd=;"

        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "INSERT INTO encuesta_series(nombre, apellido, serie_favorita) VALUES (@nombre, @apellido, @serie_favorita )"
            cmd.Prepare()

            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text)
            cmd.Parameters.AddWithValue("@serie_favorita", txtSFavorita.Text)
            cmd.ExecuteNonQuery()

            conexion.Close()

            MsgBox("Felicitaciones, usted fue registrado con exito ")
            txtNombre.Clear()
            txtApellido.Clear()

            cmd.CommandText = "SELECT * FROM encuesta_series ORDER BY nombre ASC"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdEncuesta.DataSource = ds
            grdEncuesta.DataMember = "Tabla"


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        txtNombre.Clear()
        txtApellido.Clear()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub
End Class
