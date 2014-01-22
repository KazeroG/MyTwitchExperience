Imports System.Net
Imports System.Text
Imports System.IO

Public Class FormAddBlock

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim link As String = "https://api.twitch.tv/kraken/users/" + My.Settings.username + "/blocks/" + TextBox1.Text
        MsgBox(link)
        Dim data As Byte() = Encoding.UTF8.GetBytes(link)
        Dim request As HttpWebRequest = CType(WebRequest.Create("https://api.twitch.tv/kraken/users/" + My.Settings.username + "/blocks/" + TextBox1.Text), HttpWebRequest)
        request.Method = "PUT"
        request.Accept = "application/vnd.twitchtv.v2+json"
        request.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        request.ContentLength = data.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(data, 0, data.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        MsgBox("User " + TextBox1.Text + " BLOCKED.")
        Me.Close()
    End Sub
End Class