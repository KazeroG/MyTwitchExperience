Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Diagnostics.Process

Public Class ChannelInfo
    Dim channelname As String = ""

    Private Sub loadchannelinfo()
        Dim getchannelinfoClient As New System.Net.WebClient
        getchannelinfoClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        getchannelinfoClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        Dim channelinfo As New JObject
        Try
            Dim result As String = getchannelinfoClient.DownloadString("https://api.twitch.tv/kraken/channels/" + channelname)
            RichTextBox1.AppendText(result)
            channelinfo = JsonConvert.DeserializeObject(result)
            'MsgBox(channelinfo.Item("display_name").ToString)
            Label14.Text = channelinfo.Item("display_name").ToString
            Label15.Text = channelinfo.Item("status").ToString
            If Not channelinfo.Item("game") = "" Then
                Label16.Text = channelinfo.Item("game").ToString
            Else
                Label16.Text = "-none-"
            End If
            Label17.Text = channelinfo.Item("_id").ToString
            Label18.Text = channelinfo.Item("mature").ToString
            Label19.Text = channelinfo.Item("created_at").ToString
            Label20.Text = channelinfo.Item("updated_at").ToString
            Label21.Text = channelinfo.Item("logo").ToString
            If Not channelinfo.Item("banner").ToString = "" Then
                Label22.Text = channelinfo.Item("banner").ToString
            Else
                Label22.Text = "-none-"
            End If
            If Not channelinfo.Item("video_banner").ToString = "" Then
                Label23.Text = channelinfo.Item("video_banner").ToString
            Else
                Label23.Text = "-none-"
            End If
            If Not channelinfo.Item("background").ToString = "" Then
                Label24.Text = channelinfo.Item("background").ToString
            Else
                Label24.Text = "-none-"
            End If
            Label25.Text = channelinfo.Item("url").ToString
            Label26.Text = "http://www.twitch.tv/message/compose?to=" + channelinfo.Item("name").ToString
        Catch ex As Exception
            If ex.ToString.Contains("(503)") Then
                MsgBox("503 - Server unavailable. Try again soon.")
            ElseIf ex.ToString.Contains("(502)") Then
                MsgBox("502 - Gateway Error. Try again soon.")
            ElseIf ex.ToString.Contains("(401)") Then
                MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
            ElseIf ex.ToString.Contains("(422)") Then
                MsgBox("422- USER NO EXIST. WTF DID YOU JUST DO?")
            Else
                MsgBox(ex.ToString)
            End If
            Me.Close()
        End Try
        Me.Text = "Detailed info for channel: " + channelname
    End Sub

    Private Sub ChannelInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.donothingonload Then
            MainForm.donothingonload = False
        Else
            channelname = MainForm.selectedchannelname
            Me.Text = "Detailed info for channel: " + channelname
            Dim getchannelinfoClient As New System.Net.WebClient
            getchannelinfoClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
            getchannelinfoClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
            Dim channelinfo As New JObject
            Try
                Dim result As String = getchannelinfoClient.DownloadString("https://api.twitch.tv/kraken/channels/" + channelname)
                RichTextBox1.AppendText(result)
                channelinfo = JsonConvert.DeserializeObject(result)
                'MsgBox(channelinfo.Item("display_name").ToString)
                Label14.Text = channelinfo.Item("display_name").ToString
                Label15.Text = channelinfo.Item("status").ToString
                If Not channelinfo.Item("game") = "" Then
                    Label16.Text = channelinfo.Item("game").ToString
                Else
                    Label16.Text = "-none-"
                End If
                Label17.Text = channelinfo.Item("_id").ToString
                Label18.Text = channelinfo.Item("mature").ToString
                Label19.Text = channelinfo.Item("created_at").ToString
                Label20.Text = channelinfo.Item("updated_at").ToString
                Label21.Text = channelinfo.Item("logo").ToString
                If Not channelinfo.Item("banner").ToString = "" Then
                    Label22.Text = channelinfo.Item("banner").ToString
                Else
                    Label22.Text = "-none-"
                End If
                If Not channelinfo.Item("video_banner").ToString = "" Then
                    Label23.Text = channelinfo.Item("video_banner").ToString
                Else
                    Label23.Text = "-none-"
                End If
                If Not channelinfo.Item("background").ToString = "" Then
                    Label24.Text = channelinfo.Item("background").ToString
                Else
                    Label24.Text = "-none-"
                End If
                Label25.Text = channelinfo.Item("url").ToString
                Label26.Text = "http://www.twitch.tv/message/compose?to=" + channelinfo.Item("name").ToString
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
                Me.Close()
            End Try
        End If
        
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        If Label21.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label21.Text)
        End If
    End Sub
    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        If Label22.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label22.Text)
        End If
    End Sub
    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        If Label23.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label23.Text)
        End If
    End Sub
    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        If Label24.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label24.Text)
        End If
    End Sub
    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        If Label25.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label25.Text)
        End If
    End Sub
    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        If Label26.Text = "-none-" Then
            MsgBox("Why problem make when you no problem have you don't want to make?", MsgBoxStyle.Critical)
        Else
            Process.Start(Label26.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not TextBox1.Text = "" Then
            channelname = TextBox1.Text
            Me.Text = "Loading info for channel """ + channelname + """"
            loadchannelinfo()
        End If

    End Sub
End Class