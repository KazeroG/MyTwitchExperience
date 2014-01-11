Public Class FormGetAuth

    Private Sub FormGetAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim authurl As String
        authurl = "https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=24ajtuzk8rsb0c0iofgcmtlts2zzya&redirect_uri=http%3A%2F%2Fraw-raw.de%2Fmte&scope=user_read+user_blocks_edit+user_blocks_read+user_subscriptions+channel_subscriptions+channel_check_subscription"
        'MsgBox(authurl)
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Navigate(authurl)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If WebBrowser1.Url.AbsoluteUri.ToString.Contains("access_token") Then
            'MsgBox(WebBrowser1.Url.AbsoluteUri.ToString)
            Dim newauthkey As String
            newauthkey = WebBrowser1.Url.AbsoluteUri.ToString.Remove(0, WebBrowser1.Url.AbsoluteUri.ToString.IndexOf("=") + 1)
            newauthkey = newauthkey.Remove(newauthkey.IndexOf("&"), newauthkey.Length - newauthkey.IndexOf("&"))
            MsgBox("OAuth Token " + newauthkey + " successfully retrieved...")
            'My.Settings.authkey = newauthkey
            'My.Settings.Save()
            FormSetup.LabelOAuthToken.Text = newauthkey
            Me.Close()
        Else
            MsgBox("Something went wrong.. Did the website really tell you to click here?")
        End If

        
    End Sub
End Class