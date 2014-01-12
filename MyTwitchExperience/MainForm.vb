Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics.Process

Public Class MainForm

    Dim busy As Boolean
    Dim gamelistoffset As Integer = 0
    Public watch_user As String


    Sub Get_Blocklist()
        Dim getblockClient As New System.Net.WebClient
        getblockClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        getblockClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        'Dim jaysson As 
        Dim result As String = getblockClient.DownloadString("https://api.twitch.tv/kraken/users/" + My.Settings.username + "/blocks?limit=100")
        RichTextBox1.AppendText(result)
        Dim blocklist As New JObject
        blocklist = JsonConvert.DeserializeObject(result)
        'Dim tropical As String = o.Item("blocks").Item(2).Item("user").Item("name").ToString
        For x As Integer = 0 To blocklist.Item("blocks").Count - 1
            ListBox1.Items.Add(blocklist.Item("blocks").Item(x).Item("user").Item("name").ToString)
        Next
    End Sub

    Sub Get_Following_Live()
        Dim getlivefollowingClient As New System.Net.WebClient
        getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/streams/followed?limit=100")
        RichTextBox1.AppendText(result)
        Dim streamlist As New JObject
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
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.username = Nothing Then
            FormSetup.Show()
        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Items.Clear()


        Get_Following_Live()
        'ListView1.BeginUpdate()
        'ListView1.Items.Add()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim previewlink As String
            Dim logolink As String
            Dim streamerlabeltext As String
            Dim game As String
            logolink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"
            previewlink = "http://www-cdn.jtvnw.net/images/xarth/header_logo.png"

            For Each item As ListViewItem In ListView1.SelectedItems()
                'MsgBox(ListView2.Items(item.Index).SubItems(1).ToString)
                previewlink = ListView2.Items(item.Index).SubItems(1).ToString
                logolink = ListView2.Items(item.Index).SubItems(2).ToString
                streamerlabeltext = ListView2.Items(item.Index).ToString
                game = ListView1.Items(item.Index).SubItems(2).ToString


            Next
            'FORMAT LABELS
            game = game.Substring(game.IndexOf("{") + 1)
            game = game.Remove(game.IndexOf("}"), 1)
            streamerlabeltext = streamerlabeltext.Substring(streamerlabeltext.IndexOf("{") + 1)
            streamerlabeltext = streamerlabeltext.Remove(streamerlabeltext.IndexOf("}"), 1)
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
            Try
                Dim logodownloader As New System.Net.WebClient
                Dim ImageInBytes2() As Byte = logodownloader.DownloadData(logolink)
                Dim ImageStream2 As New IO.MemoryStream(ImageInBytes2)
                PictureBoxLogo.Image = New System.Drawing.Bitmap(ImageStream2)
                PictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage
            Catch ex As Exception
                MsgBox("DEBUG - No avatar?")
            End Try
            
            'SET LABEL TEXT AND VISIBILITY
            Button5.Visible = True
            LabelGame.Text = game
            LabelStreamerName.Text = streamerlabeltext
            Label1.Visible = True
            Label2.Visible = True
            LabelGame.Visible = True
            LabelStreamerName.Visible = True
            'PREPARE SOURCE FOR SMALL VIEDO WINDOW
            'RichTextBox3.Clear()
            'RichTextBox3.LoadFile("embed.txt", RichTextBoxStreamType.PlainText)
            'RichTextBox3.Text = RichTextBox3.Text.Replace("REPLACEME", streamerlabeltext)
            'RichTextBox3.Text = RichTextBox3.Text.Replace("REPLACELOCALE", My.Settings.locale)
            'RichTextBox3.Text = RichTextBox3.Text.Replace("REPLACEHEIGHT", "190")
            'RichTextBox3.Text = RichTextBox3.Text.Replace("REPLACEWIDTH", "385")
            'WebBrowser1.DocumentText = RichTextBox3.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
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
        'TODO: -Remove request and use 2nd Listview instead
        Dim x As Integer
        x = ListView1.FocusedItem.Index
        Dim getlivefollowingClient As New System.Net.WebClient
        getlivefollowingClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        getlivefollowingClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        Dim result As String = getlivefollowingClient.DownloadString("https://api.twitch.tv/kraken/streams/followed?limit=100")
        RichTextBox1.AppendText(result)
        Dim streamlist As New JObject
        streamlist = JsonConvert.DeserializeObject(result)
        'MsgBox(streamlist.Item("streams").Item(x).Item("channel").Item("url").ToString.Replace("www", My.Settings.locale))
        Process.Start(streamlist.Item("streams").Item(x).Item("channel").Item("url").ToString.Replace("www", My.Settings.locale))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        FormSetup.Show()

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        FormSetup.Show()

    End Sub

    Private Sub InVLCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InVLCToolStripMenuItem.Click
        If Not My.Settings.vlcdir = Nothing Then
            Dim streamname As String = "lel"
            For Each item As ListViewItem In ListView1.SelectedItems()
                streamname = item.ToString
                'MsgBox(item.ToString)
            Next
            streamname = streamname.Substring(streamname.IndexOf("{") + 1)
            streamname = streamname.Remove(streamname.IndexOf("}"), 1)
            Dim cmdargs As String = "-p """ + My.Settings.vlcdir + "\vlc.exe"" " + My.Settings.locale + ".twitch.tv/" + streamname + " " + My.Settings.quality

            Dim path As String = "livestreamer\livestreamer.exe"
            'MsgBox(path + streamname)
            Dim VideoPlayer As New System.Diagnostics.Process()
            VideoPlayer.StartInfo.UseShellExecute = False
            VideoPlayer.StartInfo.CreateNoWindow = True
            VideoPlayer.StartInfo.FileName = path
            VideoPlayer.StartInfo.Arguments = cmdargs
            VideoPlayer.Start()

        End If
    End Sub

    Sub Get_Gameslist()
        Dim getlivegamesClient As New System.Net.WebClient
        'getlivegamesClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        'getlivegamesClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
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

        ''NEXT UP: On lv3 selection change do -Download artwork -download Channels
    End Sub

    Sub Get_Channels_For_Game(ByRef formattedgamename As String)
        'MsgBox(formattedgamename)
        Dim getchannelsClient As New System.Net.WebClient
        'getlivegamesClient.Headers.Add("Accept", "application/vnd.twitchtv.v2+json")
        'MsgBox("https://api.twitch.tv/kraken/streams/channel?game=" + formattedgamename + "&limit=100")
        'getlivegamesClient.Headers.Add("Authorization", "OAuth " + My.Settings.authkey)
        Dim result As String = getchannelsClient.DownloadString("https://api.twitch.tv/kraken/streams?game=" + formattedgamename + "&limit=100")
        RichTextBox2.AppendText(result)
        Dim streamlist As New JObject
        streamlist = JsonConvert.DeserializeObject(result)
        For x As Integer = 0 To streamlist.Item("streams").Count - 1
            ListView4.BeginUpdate()
            Dim li As ListViewItem
            li = ListView4.Items.Add(streamlist.Item("streams").Item(x).Item("channel").Item("name").ToString)
            li.SubItems.Add(streamlist.Item("streams").Item(x).Item("viewers").ToString)
            li.SubItems.Add(streamlist.Item("streams").Item(x).Item("channel").Item("status").ToString.Replace("Ã©", "é"))
            ListView4.EndUpdate()
            ListView4.Update()

        Next
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ListView3.Items.Clear()
        'ListView4.Items.Clear()
        Get_Gameslist()

    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged
        ListView4.Items.Clear()
        Dim gamename As String
        For Each item As ListViewItem In ListView3.SelectedItems()
            gamename = item.ToString

        Next
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
        
        Get_Channels_For_Game(gamename)
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
End Class
