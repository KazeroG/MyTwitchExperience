Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO

Public Class FormBlockList

    Sub Get_Blocklist()
        Try
            Dim getblockClient As New System.Net.WebClient
            getblockClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
            getblockClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
            Dim result As String = getblockClient.DownloadString("https://api.twitch.tv/kraken/users/" + My.Settings.username + "/blocks?limit=100")
            RichTextBox1.AppendText(result)
            Dim blocklist As New JObject
            blocklist = JsonConvert.DeserializeObject(result)
            For x As Integer = 0 To blocklist.Item("blocks").Count - 1
                ListBox1.Items.Add(blocklist.Item("blocks").Item(x).Item("user").Item("name").ToString)
            Next
        Catch ex As Exception
            If ex.ToString.Contains("(503)") Then
                MsgBox("503 - Server unavailable. Try again soon.")
            ElseIf ex.ToString.Contains("(502)") Then
                MsgBox("502 - Gateway Error. Try again soon.")
            ElseIf ex.ToString.Contains("(401)") Then
                MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
            Else
                MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Get_Blocklist()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each user In ListBox1.SelectedItems
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("https://api.twitch.tv/kraken/users/" + My.Settings.username + "/blocks/" + user), HttpWebRequest)
                request.Method = "DELETE"
                request.Accept = "application/vnd.twitchtv.v2+json"
                request.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
                Dim result = request.GetResponse()
                Dim answer As String = result.ToString
                MsgBox("User " + user + " unblocked. Refreshing...")
                
            Catch ex As Exception
                If ex.ToString.Contains("(503)") Then
                    MsgBox("503 - Server unavailable. Try again soon.")
                ElseIf ex.ToString.Contains("(502)") Then
                    MsgBox("502 - Gateway Error. Try again soon.")
                ElseIf ex.ToString.Contains("(401)") Then
                    MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
                Else
                    MsgBox(ex.ToString)
                End If
            End Try
        Next
        ListBox1.Items.Clear()
        Get_Blocklist()
    End Sub
End Class