Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports EntidadesNegocio

Public Class daUsuario

    Public Function listarUsuarios() As List(Of beUsuario)
        Dim lista As List(Of beUsuario) = Nothing
        Dim cadena As String = ConfigurationManager.ConnectionStrings("conexion").ConnectionString

        Using conexion As New SqlConnection(cadena)
            conexion.Open()
            Dim query As String = "listarUsuario"
            Dim cmd As SqlCommand = New SqlCommand(query, conexion)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader IsNot Nothing Then
                lista = New List(Of beUsuario)()
                Dim usr As beUsuario
                Dim posNombre = reader.GetOrdinal("Nombre")
                Dim posCodigo = reader.GetOrdinal("Codigo")
                While reader.Read()
                    usr = New beUsuario()
                    usr.Nombre = reader.GetString(posNombre)
                    usr.codigo = reader.GetInt32(posCodigo)
                    lista.Add(usr)
                End While
            End If

        End Using

        Return lista
    End Function

    Sub insertUsuario(ByVal nombre As String)
        Dim cadena As String = ConfigurationManager.ConnectionStrings("conexion").ConnectionString
        Using conexion As New SqlConnection(cadena)
            conexion.Open()
            Dim query As String = "insertarUsuario"
            Dim cmd As SqlCommand = New SqlCommand(query, conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre

            Dim i = cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
