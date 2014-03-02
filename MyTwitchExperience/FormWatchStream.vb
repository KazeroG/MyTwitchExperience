Imports System.Text

Public Class FormWatchStream
    Private Sub FormWatchStream_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Watching " + MainForm.watch_user + ".."
        RichTextBox1.LoadFile("embed.txt", RichTextBoxStreamType.PlainText)
        RichTextBox1.Text = RichTextBox1.Text.Replace("REPLACEME", MainForm.watch_user)
        RichTextBox1.Text = RichTextBox1.Text.Replace("REPLACELOCALE", My.Settings.locale)
        RichTextBox1.Text = RichTextBox1.Text.Replace("REPLACEHEIGHT", WebBrowser1.Size.Height - 25)
        RichTextBox1.Text = RichTextBox1.Text.Replace("REPLACEWIDTH", WebBrowser1.Size.Width - 25)
        RichTextBox1.Text = RichTextBox1.Text.Replace("REPLACEAUTOPLAY", "true")
        WebBrowser1.DocumentText = RichTextBox1.Text
        WebBrowser2.Navigate("http://www.twitch.tv/chat/embed?channel=" + MainForm.watch_user + "&popout_chat=true")
    End Sub
End Class