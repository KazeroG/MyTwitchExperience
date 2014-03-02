<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWatchStream
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWatchStream))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(749, 540)
        Me.WebBrowser1.TabIndex = 0
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(220, 308)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser2.Location = New System.Drawing.Point(749, 0)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.ScrollBarsEnabled = False
        Me.WebBrowser2.Size = New System.Drawing.Size(363, 540)
        Me.WebBrowser2.TabIndex = 2
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(100, 308)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox2.TabIndex = 3
        Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        Me.RichTextBox2.Visible = False
        '
        'FormWatchStream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1112, 540)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormWatchStream"
        Me.Text = "Watching "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
End Class
