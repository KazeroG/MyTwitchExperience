Public Class FormDonate

    Private Sub FormDonate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WebBrowser1.DocumentText = "<form action=""https://www.paypal.com/cgi-bin/webscr"" method=""post"" target=""_top""><input type=""hidden"" name=""cmd"" value=""_s-xclick""><input type=""hidden"" name=""hosted_button_id"" value=""9B6MXU9LLED68""><input type=""image"" src=""https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif"" border=""0"" name=""submit"" alt=""PayPal - The safer, easier way to pay online!""><img alt="""" border=""0"" src=""https://www.paypalobjects.com/de_DE/i/scr/pixel.gif"" width=""1"" height=""1""></form>"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class