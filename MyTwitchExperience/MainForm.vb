Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics.Process

Public Class MainForm

    Dim busy As Boolean
    Dim timerison As Boolean = False
    Public donothingonload As Boolean = False
    Dim keyword As String = ""
    Dim searchmode As String = "channels"
    Dim gamelistoffset As Integer = 0
    Dim streamlistoffset As Integer = 0
    Dim chansearchoffset As Integer = 0
    Dim selectedgame As String = ""
    Public selectedchannelname As String
    Public watch_user As String

    

    Sub Get_Following_Live()
        Dim getlivefollowingClient As New System.Net.WebClient
        getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        Dim streamlist As New JObject
        Try
            Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/streams/followed?limit=100")
            RichTextBox1.AppendText(result)
            streamlist = JsonConvert.DeserializeObject(result)
            For x As Integer = 0 To streamlist.Item("streams").Count - 1
                ListView1.BeginUpdate()
                Dim li As ListViewItem
                li = ListView1.Items.Add(streamlist.Item("streams").Item(x).Item("channel").Item("name").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("viewers").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("game").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("status").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("broadcaster").ToString)
                ListView1.EndUpdate()
                ListView1.Update()
                ListView2.BeginUpdate()
                Dim li2 As ListViewItem
                li2 = ListView2.Items.Add(streamlist.Item("streams").Item(x).Item("channel").Item("name").ToString)
                li2.SubItems.Add(streamlist.Item("streams").Item(x).Item("preview").ToString)
                li2.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("logo").ToString)
                li2.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("url").ToString.Replace("www", My.Settings.locale))
                ListView2.EndUpdate()
                ListView2.Update()
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

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.username = Nothing Then
            FormSetup.Show()
        End If
        If Not My.Settings.autorefresh = 0 Then
            Button11.Text = My.Settings.autorefresh.ToString + " Minutes"
            Button11.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonRefreshLiveFollowing.Click
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        Get_Following_Live()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim previewlink As String
            Dim logolink As String
            Dim streamerlabeltext As String
            Dim game As String
            Dim statusmessage As String
            logolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            previewlink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            For Each item As ListViewItem In ListView1.SelectedItems()
                'MsgBox(ListView2.Items(item.Index).SubItems(1).ToString)
                previewlink = ListView2.Items(item.Index).SubItems(1).ToString
                logolink = ListView2.Items(item.Index).SubItems(2).ToString
                streamerlabeltext = ListView2.Items(item.Index).ToString
                game = ListView1.Items(item.Index).SubItems(2).ToString
                statusmessage = ListView1.Items(item.Index).SubItems(3).ToString
            Next
            'FORMAT LABELS
            If IsNothing(game) Then
                Exit Sub 'catching some error.. it tries to run this sub with no info once. aborting then.
            End If
            game = game.Substring(game.IndexOf("{") + 1)
            game = game.Remove(game.IndexOf("}"), 1)
            streamerlabeltext = streamerlabeltext.Substring(streamerlabeltext.IndexOf("{") + 1)
            streamerlabeltext = streamerlabeltext.Remove(streamerlabeltext.IndexOf("}"), 1)
            statusmessage = statusmessage.Substring(statusmessage.IndexOf("{") + 1)
            statusmessage = statusmessage.Remove(statusmessage.IndexOf("}"), 1)
            'FORMAT IMAGE LINK
            logolink = logolink.Substring(logolink.IndexOf("{") + 1)
            logolink = logolink.Remove(logolink.IndexOf("}"), 1)
            previewlink = previewlink.Substring(previewlink.IndexOf("{") + 1)
            previewlink = previewlink.Remove(previewlink.IndexOf("}"), 1)
            'DOWNLOAD AND PLACE IMAGES
            Dim PreviewDownloader As New System.Net.WebClient
            Dim ImageInBytes() As Byte = PreviewDownloader.DownloadData(previewlink)
            Dim ImageStream As New IO.MemoryStream(ImageInBytes)
            PictureBoxPreview.Image = New System.Drawing.Bitmap(ImageStream)
            PictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage
            If logolink = "" Then
                logolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png" 'For missing avatars
            End If
            Dim logodownloader As New System.Net.WebClient
            Dim ImageInBytes2() As Byte = logodownloader.DownloadData(logolink)
            Dim ImageStream2 As New IO.MemoryStream(ImageInBytes2)
            PictureBoxLogo.Image = New System.Drawing.Bitmap(ImageStream2)
            PictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage
            'SET LABEL TEXT AND VISIBILITY
            Button5.Visible = True
            Button6.Visible = True
            Button7.Visible = True
            LabelGame.Text = game
            LabelStreamerName.Text = streamerlabeltext
            LabelStatus.Text = statusmessage
            Label1.Visible = True
            Label2.Visible = True
            LabelGame.Visible = True
            LabelStreamerName.Visible = True
            LabelStatus.Visible = True
        Catch ex As Exception
            If ex.ToString.Contains("(503)") Then
                MsgBox("503 - Server unavailable. Try again soon.")
            ElseIf ex.ToString.Contains("(502)") Then
                MsgBox("502 - Gateway Error. Try again soon.")
            ElseIf ex.ToString.Contains("(401)") Then
                MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
            Else
                'MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        For Each item As ListViewItem In ListView1.SelectedItems()
            MsgBox(item.ToString)
        Next
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(System.Windows.Forms.Cursor.Position)
        End If
    End Sub

    Private Sub InBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InBrowserToolStripMenuItem.Click
        Try
            Dim x As Integer
            x = ListView1.FocusedItem.Index
            Dim getlivefollowingClient As New System.Net.WebClient
            getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
            getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
            Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/streams/followed?limit=100")
            RichTextBox1.AppendText(result)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            Process.Start(streamlist.Item("streams").Item(x).Item("channel").Item("url").ToString.Replace("www", My.Settings.locale))
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

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        FormSetup.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        FormSetup.Show()
    End Sub

    Private Sub InVLCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InVLCToolStripMenuItem.Click
        If Not My.Settings.vlcdir = Nothing Then
            Dim streamname As String = "dummy"
            For Each item As ListViewItem In ListView1.SelectedItems()
                streamname = item.ToString
            Next
            streamname = streamname.Substring(streamname.IndexOf("{") + 1)
            streamname = streamname.Remove(streamname.IndexOf("}"), 1)
            Dim cmdargs As String = "-p """ + My.Settings.vlcdir + "\vlc.exe"" " + My.Settings.locale + ".twitch.tv/" + streamname + " " + My.Settings.quality
            Dim path As String = "livestreamer\livestreamer.exe"
            Dim VideoPlayer As New System.Diagnostics.Process()
            VideoPlayer.StartInfo.UseShellExecute = False
            VideoPlayer.StartInfo.CreateNoWindow = True
            VideoPlayer.StartInfo.FileName = path
            VideoPlayer.StartInfo.Arguments = cmdargs
            VideoPlayer.Start()
        End If
    End Sub

    Sub Get_Gameslist()
        Try
            Dim getlivegamesClient As New System.Net.WebClient
            Dim result As String = getlivegamesClient.DownloadString("https://api.twitch.tv/kraken/games/top?limit=100&offset=" + gamelistoffset.ToString)
            RichTextBox2.AppendText(result)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            For x As Integer = 0 To streamlist.Item("top").Count - 1
                ListView3.BeginUpdate()
                Dim li As ListViewItem
                li = ListView3.Items.Add(streamlist.Item("top").Item(x).Item("game").Item("name").ToString.Replace("Ã©", "é"))
                li.SubItems.Add(streamlist.Item("top").Item(x).Item("viewers").ToString)
                ListView3.EndUpdate()
                ListView3.Update()
            Next
            Dim offsetmax As Integer = gamelistoffset + 99
            LabelOffsetGL.Visible = True
            LabelOffsetGL.Text = ("(Showing " + gamelistoffset.ToString + " to " + offsetmax.ToString + " out of " + streamlist.Item("_total").ToString + ")")

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

    Sub Get_Channels_For_Game(ByRef formattedgamename As String)
        Try
            Dim getchannelsClient As New System.Net.WebClient
            Dim result As String = getchannelsClient.DownloadString("https://api.twitch.tv/kraken/streams?game=" + formattedgamename + "&limit=100&offset=" + streamlistoffset.ToString)
            RichTextBox2.AppendText(result)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            For x As Integer = 0 To streamlist.Item("streams").Count - 1
                ListView4.BeginUpdate()
                Dim li As ListViewItem
                li = ListView4.Items.Add(streamlist.Item("streams").Item(x).Item("channel").Item("name").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("viewers").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("status").ToString.Replace("Ã©", "é"))
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("preview").Item("medium").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("logo").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("game").ToString)
                ListView4.EndUpdate()
                ListView4.Update()
            Next
            If CInt(streamlist.Item("_total")) >= 100 Then
                Button9.Enabled = True
            End If
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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ListView3.Items.Clear()
        'ListView4.Items.Clear()
        Get_Gameslist()
    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged
        ListView4.Items.Clear()
        Button8.Enabled = False
        Button9.Enabled = False

        streamlistoffset = 0
        Dim gamename As String
        For Each item As ListViewItem In ListView3.SelectedItems()
            gamename = item.ToString
        Next
        selectedgame = gamename
        Try
            selectedgame = selectedgame.Substring(selectedgame.IndexOf("{") + 1)
            selectedgame = selectedgame.Remove(selectedgame.IndexOf("}"), 1)
        Catch ex As Exception

        End Try
        

        Try
            gamename = gamename.Substring(gamename.IndexOf("{") + 1)
            gamename = gamename.Remove(gamename.IndexOf("}"), 1)
            gamename = gamename.Replace(" ", "%20")
            gamename = gamename.Replace("Ã©", "é") 'FOR POKEMON TRANSODING ERROR
            gamename = gamename.Replace("Â²", "²") 'FOR TRACKMANIA² TRANSCODING ERROR
            gamename = gamename.Replace("&", "%26")
            gamename = gamename.Replace("+", "%2B")
        Catch ex As Exception
        End Try
        RichTextBox2.Clear()
        If IsNothing(gamename) Then
            Exit Sub 'preventing request being made with no data. happens once every reselection
        Else
            Get_Channels_For_Game(gamename)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        streamlistoffset += 100
        ListView4.Items.Clear()
        Button8.Enabled = True
        Get_Channels_For_Game(selectedgame)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        streamlistoffset -= 100
        If streamlistoffset = 0 Then
            Button8.Enabled = False
        End If
        ListView4.Items.Clear()
        Get_Channels_For_Game(selectedgame)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gamelistoffset += 100
        ListView3.Items.Clear()
        Button3.Enabled = True
        Get_Gameslist()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gamelistoffset -= 100
        If gamelistoffset = 0 Then
            Button3.Enabled = False
        End If
        ListView3.Items.Clear()
        Get_Gameslist()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        watch_user = LabelStreamerName.Text
        FormWatchStream.Show()
    End Sub

    Private Sub ListView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView4.SelectedIndexChanged
        Try
            Dim GLpreviewlink As String
            Dim GLlogolink As String
            Dim GLstreamer As String
            Dim GLgame As String
            Dim GLstatusmessage As String
            GLlogolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            GLpreviewlink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            For Each item As ListViewItem In ListView4.SelectedItems()
                GLpreviewlink = ListView4.Items(item.Index).SubItems(3).ToString
                GLlogolink = ListView4.Items(item.Index).SubItems(4).ToString
                GLstreamer = ListView4.Items(item.Index).ToString
                GLgame = ListView4.Items(item.Index).SubItems(5).ToString
                GLstatusmessage = ListView4.Items(item.Index).SubItems(2).ToString
            Next
            'FORMAT LABELS
            If IsNothing(GLgame) Then
                Exit Sub
            End If
            GLgame = GLgame.Substring(GLgame.IndexOf("{") + 1)
            GLgame = GLgame.Remove(GLgame.IndexOf("}"), 1)
            GLstreamer = GLstreamer.Substring(GLstreamer.IndexOf("{") + 1)
            GLstreamer = GLstreamer.Remove(GLstreamer.IndexOf("}"), 1)
            GLstatusmessage = GLstatusmessage.Substring(GLstatusmessage.IndexOf("{") + 1)
            GLstatusmessage = GLstatusmessage.Remove(GLstatusmessage.IndexOf("}"), 1)
            'FORMAT IMAGE LINK
            GLlogolink = GLlogolink.Substring(GLlogolink.IndexOf("{") + 1)
            GLlogolink = GLlogolink.Remove(GLlogolink.IndexOf("}"), 1)
            GLpreviewlink = GLpreviewlink.Substring(GLpreviewlink.IndexOf("{") + 1)
            GLpreviewlink = GLpreviewlink.Remove(GLpreviewlink.IndexOf("}"), 1)
            'DOWNLOAD AND PLACE IMAGES
            Dim PreviewDownloader As New System.Net.WebClient
            Dim ImageInBytes() As Byte = PreviewDownloader.DownloadData(GLpreviewlink)
            Dim ImageStream As New IO.MemoryStream(ImageInBytes)
            PictureBoxGLpreview.Image = New System.Drawing.Bitmap(ImageStream)
            PictureBoxGLpreview.SizeMode = PictureBoxSizeMode.StretchImage
            If GLlogolink = "" Then
                GLlogolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png" 'For missing avatars
            End If
            Dim logodownloader As New System.Net.WebClient
            Dim ImageInBytes2() As Byte = logodownloader.DownloadData(GLlogolink)
            Dim ImageStream2 As New IO.MemoryStream(ImageInBytes2)
            PictureBoxGLlogo.Image = New System.Drawing.Bitmap(ImageStream2)
            PictureBoxGLlogo.SizeMode = PictureBoxSizeMode.StretchImage
            'SET LABEL TEXT AND VISIBILITY
            ButtonGLOpenBrowserandChat.Visible = True
            ButtonGLOpenStream.Visible = True
            ButtonGLAddToMulti.Visible = True
            LabelGLGame.Text = GLgame
            LabelGLStreamer.Text = GLstreamer
            LabelGLStatus.Text = GLstatusmessage
            Label4.Visible = True
            Label6.Visible = True
            LabelGLGame.Visible = True
            LabelGLStreamer.Visible = True
            LabelGLStatus.Visible = True
        Catch ex As Exception
            If ex.ToString.Contains("(503)") Then
                MsgBox("503 - Server unavailable. Try again soon.")
            ElseIf ex.ToString.Contains("(502)") Then
                MsgBox("502 - Gateway Error. Try again soon.")
            ElseIf ex.ToString.Contains("(401)") Then
                MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
            Else
                'MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub ButtonGLOpenBrowserandChat_Click(sender As Object, e As EventArgs) Handles ButtonGLOpenBrowserandChat.Click
        watch_user = LabelGLStreamer.Text
        FormWatchStream.Show()
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        FormDonate.Show()
    End Sub

    Private Sub EditBlockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditBlockListToolStripMenuItem.Click
        FormBlockList.Show()
    End Sub

    Private Sub LabelStreamerName_Click(sender As Object, e As EventArgs) Handles LabelStreamerName.Click
        selectedchannelname = LabelStreamerName.Text
        ChannelInfo.Show()
    End Sub

    Private Sub DetailedInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailedInfoToolStripMenuItem.Click
        selectedchannelname = LabelStreamerName.Text
        ChannelInfo.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        Get_Following_Live()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.ForeColor = Color.Red Then
            If Not timerison Then
                Timer1.Interval = 300000
                Timer1.Start()
                timerison = True
                Button1.ForeColor = Color.Green
            End If
        Else
            timerison = False
            Timer1.Stop()
            Button1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Button10.ForeColor = Color.Red Then
            If Not timerison Then
                Timer1.Interval = 600000
                Timer1.Start()
                timerison = True
                Button10.ForeColor = Color.Green
            End If
        Else
            timerison = False
            Timer1.Stop()
            Button10.ForeColor = Color.Red
        End If
    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Button11.ForeColor = Color.Red Then
            If Not timerison Then
                Timer1.Interval = CInt(My.Settings.autorefresh) * 60000
                Timer1.Start()
                timerison = True
                Button11.ForeColor = Color.Green
            End If
        Else
            timerison = False
            Timer1.Stop()
            Button11.ForeColor = Color.Red
        End If
    End Sub

    Private Sub MinimizeToTrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeToTrayToolStripMenuItem.Click
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
        Me.NotifyIcon1.Visible = True
    End Sub


    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.ShowInTaskbar = True
        Me.NotifyIcon1.Visible = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        If AlwaysOnTopToolStripMenuItem.ForeColor = Color.Red Then
            AlwaysOnTopToolStripMenuItem.ForeColor = Color.Green
            Me.TopMost = True
        Else
            AlwaysOnTopToolStripMenuItem.ForeColor = Color.Red
            Me.TopMost = False
        End If
    End Sub

    Private Sub LookupChannelInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LookupChannelInfoToolStripMenuItem.Click
        donothingonload = True
        ChannelInfo.Show()
    End Sub
    Sub Find_Channels()
        Try
            Dim gettopchannelsClient As New System.Net.WebClient
            Dim result As String = gettopchannelsClient.DownloadString("https://api.twitch.tv/kraken/search/streams?limit=100&offset" + chansearchoffset.ToString + "&q=" + keyword)
            RichTextBox3.AppendText(result)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            For x As Integer = 0 To streamlist.Item("streams").Count - 1
                ListView5.BeginUpdate()
                Dim li As ListViewItem
                li = ListView5.Items.Add(streamlist.Item("streams").Item(x).Item("channel").Item("display_name").ToString.Replace("Ã©", "é"))
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("viewers").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("game").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("status").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("mature").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("preview").Item("medium").ToString)
                li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("logo").ToString)
                ' MsgBox(streamlist.Item("streams").Item(x).Item("viewers").ToString)
                ListView5.EndUpdate()
                ListView5.Update()
            Next
            'Dim offsetmax As Integer = gamelistoffset + 99
            'LabelOffsetGL.Visible = True
            'LabelOffsetGL.Text = ("(Showing " + gamelistoffset.ToString + " to " + offsetmax.ToString + " out of " + streamlist.Item("_total").ToString + ")")

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

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        RichTextBox3.Clear()
        ListView5.Items.Clear()
        keyword = TextBoxSearch.Text
        Find_Channels()
    End Sub

    Private Sub ListView5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView5.SelectedIndexChanged
        Try
            Dim GLpreviewlink As String
            Dim GLlogolink As String
            Dim GLstreamer As String
            Dim GLgame As String
            Dim GLstatusmessage As String
            GLlogolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            GLpreviewlink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            For Each item As ListViewItem In ListView5.SelectedItems()
                GLpreviewlink = ListView5.Items(item.Index).SubItems(5).ToString
                GLlogolink = ListView5.Items(item.Index).SubItems(6).ToString
                GLstreamer = ListView5.Items(item.Index).ToString
                GLgame = ListView5.Items(item.Index).SubItems(2).ToString
                GLstatusmessage = ListView5.Items(item.Index).SubItems(3).ToString
            Next
            'FORMAT LABELS
            If IsNothing(GLgame) Then
                Exit Sub
            End If
            GLgame = GLgame.Substring(GLgame.IndexOf("{") + 1)
            GLgame = GLgame.Remove(GLgame.IndexOf("}"), 1)
            GLstreamer = GLstreamer.Substring(GLstreamer.IndexOf("{") + 1)
            GLstreamer = GLstreamer.Remove(GLstreamer.IndexOf("}"), 1)
            GLstatusmessage = GLstatusmessage.Substring(GLstatusmessage.IndexOf("{") + 1)
            GLstatusmessage = GLstatusmessage.Remove(GLstatusmessage.IndexOf("}"), 1)
            'FORMAT IMAGE LINK
            GLlogolink = GLlogolink.Substring(GLlogolink.IndexOf("{") + 1)
            GLlogolink = GLlogolink.Remove(GLlogolink.IndexOf("}"), 1)
            GLpreviewlink = GLpreviewlink.Substring(GLpreviewlink.IndexOf("{") + 1)
            GLpreviewlink = GLpreviewlink.Remove(GLpreviewlink.IndexOf("}"), 1)
            'DOWNLOAD AND PLACE IMAGES
            Dim PreviewDownloader As New System.Net.WebClient
            Dim ImageInBytes() As Byte = PreviewDownloader.DownloadData(GLpreviewlink)
            Dim ImageStream As New IO.MemoryStream(ImageInBytes)
            PictureBoxSearch.Image = New System.Drawing.Bitmap(ImageStream)
            PictureBoxSearch.SizeMode = PictureBoxSizeMode.StretchImage
            If GLlogolink = "" Then
                GLlogolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png" 'For missing avatars
            End If
            Dim logodownloader As New System.Net.WebClient
            Dim ImageInBytes2() As Byte = logodownloader.DownloadData(GLlogolink)
            Dim ImageStream2 As New IO.MemoryStream(ImageInBytes2)
            PictureBoxSearchLogo.Image = New System.Drawing.Bitmap(ImageStream2)
            PictureBoxSearchLogo.SizeMode = PictureBoxSizeMode.StretchImage
            'SET LABEL TEXT AND VISIBILITY
            ButtonSearchOpenBrowserAndChat.Visible = True
            LabelSearchGame.Text = GLgame
            LabelSearchStreamer.Text = GLstreamer
            LabelSearchStatus.Text = GLstatusmessage
            Label7.Visible = True
            Label9.Visible = True
            LabelSearchGame.Visible = True
            LabelSearchStreamer.Visible = True
            LabelSearchStatus.Visible = True
        Catch ex As Exception
            If ex.ToString.Contains("(503)") Then
                MsgBox("503 - Server unavailable. Try again soon.")
            ElseIf ex.ToString.Contains("(502)") Then
                MsgBox("502 - Gateway Error. Try again soon.")
            ElseIf ex.ToString.Contains("(401)") Then
                MsgBox("401 Unauthorized - Authentication Error. Request a new Token in Settings!")
            Else
                'MsgBox(ex.ToString)
            End If
        End Try
    End Sub

   
    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        selectedchannelname = LabelSearchStreamer.Text
        ChannelInfo.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Try
            Dim getlivefollowingClient As New System.Net.WebClient
            getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
            getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
            Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/channels/" + LabelSearchStreamer.Text)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            Process.Start(streamlist.Item("url").ToString.Replace("www", My.Settings.locale))
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

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim getlivefollowingClient As New System.Net.WebClient
            getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
            getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
            Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/channels/" + LabelGLStreamer.Text)
            Dim streamlist As New JObject
            streamlist = JsonConvert.DeserializeObject(result)
            Process.Start(streamlist.Item("url").ToString.Replace("www", My.Settings.locale))
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

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        If Not My.Settings.vlcdir = Nothing Then
            Dim streamname As String = LabelSearchStreamer.Text
            Dim cmdargs As String = "-p """ + My.Settings.vlcdir + "\vlc.exe"" " + My.Settings.locale + ".twitch.tv/" + streamname + " " + My.Settings.quality
            Dim path As String = "livestreamer\livestreamer.exe"
            Dim VideoPlayer As New System.Diagnostics.Process()
            VideoPlayer.StartInfo.UseShellExecute = False
            VideoPlayer.StartInfo.CreateNoWindow = True
            VideoPlayer.StartInfo.FileName = path
            VideoPlayer.StartInfo.Arguments = cmdargs
            VideoPlayer.Start()
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If Not My.Settings.vlcdir = Nothing Then
            Dim streamname As String = LabelGLStreamer.Text
            Dim cmdargs As String = "-p """ + My.Settings.vlcdir + "\vlc.exe"" " + My.Settings.locale + ".twitch.tv/" + streamname + " " + My.Settings.quality
            Dim path As String = "livestreamer\livestreamer.exe"
            Dim VideoPlayer As New System.Diagnostics.Process()
            VideoPlayer.StartInfo.UseShellExecute = False
            VideoPlayer.StartInfo.CreateNoWindow = True
            VideoPlayer.StartInfo.FileName = path
            VideoPlayer.StartInfo.Arguments = cmdargs
            VideoPlayer.Start()
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        selectedchannelname = LabelGLStreamer.Text
        ChannelInfo.Show()
    End Sub
End Class
