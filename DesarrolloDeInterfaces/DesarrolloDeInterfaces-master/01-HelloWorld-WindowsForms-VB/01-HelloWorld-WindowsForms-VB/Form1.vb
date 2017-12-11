Public Class Form1

    ''' <summary>
    ''' Evento causado por el click del botón saludo, aparecerá un mensaje emergente
    ''' con el nombre "X" introducido en el TextBox pertinente.   
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaludo_Click(sender As Object, e As EventArgs) Handles btnSaludo.Click
        Dim nombre As String

        nombre = Me.txtNombre.Text

        'MessageBox.Show("Hola " + nombre + ", CRACK.", "Pepejava INC.")
        'MessageBox.Show(String.Format("Hola {0} {1}", nombre, "wapo."), "SALUDOS AMIGO")
        MessageBox.Show($"Hola {nombre}")




    End Sub

End Class
