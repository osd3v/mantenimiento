Imports AccesoDatos
Imports EntidadesNegocio

Public Class frmUsuario
    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = New daUsuario().listarUsuarios()

    End Sub

    Private Sub btninsertarUsuario(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Dim acceso As daUsuario = New daUsuario()
        acceso.insertUsuario(txtNombre.Text)
        MessageBox.Show("Usuario Ingresado")
        DataGridView1.DataSource = New daUsuario().listarUsuarios()
    End Sub
End Class
