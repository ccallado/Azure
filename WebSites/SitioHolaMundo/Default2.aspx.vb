
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Label1.Text = "Hola Mundo en VB .....!"
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Puedo utilizar Page o Me en VB y C# Page o this
        If Page.IsPostBack Then
            Label2.Text = "Recarga"
        Else
            Label2.Text = "Carga"
        End If

        If Page.PreviousPage IsNot Nothing Then
            Label2.Text = Label2.Text & "<br />Página anterior: " & Page.PreviousPage.Title

            'Voy a buscar un control en la página anterior.
            If Page.PreviousPage.FindControl("TextBox1") IsNot Nothing Then
                Dim caja As TextBox = Page.PreviousPage.FindControl("TextBox1")

                Label2.Text = Label2.Text & "<br />TextBox1: " & IIf(caja.Text.Trim() <> "", caja.Text, "Caja vacía")
            End If
        End If
    End Sub
End Class
