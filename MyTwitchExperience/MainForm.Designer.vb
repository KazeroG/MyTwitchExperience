﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.lw_streamer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lw_viewers = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lw_game = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lw_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lw_software = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InVLCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JustCopyStreamURLToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailedInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabFollowing = New System.Windows.Forms.TabPage()
        Me.PictureBoxPreview = New System.Windows.Forms.PictureBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderPrev = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderLogo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.TabGames = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.ListView4 = New System.Windows.Forms.ListView()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeaderGame = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderViewers = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditBlockListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RawrawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelStreamerName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelGame = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabFollowing.SuspendLayout()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGames.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(108, 224)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(75, 74)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 224)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(99, 69)
        Me.ListBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lw_streamer, Me.lw_viewers, Me.lw_game, Me.lw_status, Me.lw_software})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(-4, 35)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(683, 302)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'lw_streamer
        '
        Me.lw_streamer.Text = "Streamer"
        Me.lw_streamer.Width = 100
        '
        'lw_viewers
        '
        Me.lw_viewers.Text = "Viewers"
        '
        'lw_game
        '
        Me.lw_game.Text = "Game"
        Me.lw_game.Width = 150
        '
        'lw_status
        '
        Me.lw_status.Text = "Status"
        Me.lw_status.Width = 300
        '
        'lw_software
        '
        Me.lw_software.Text = "Software"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.DetailedInfoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(142, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InBrowserToolStripMenuItem, Me.InVLCToolStripMenuItem, Me.JustCopyStreamURLToClipboardToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.ToolStripMenuItem1.Text = "Play!"
        '
        'InBrowserToolStripMenuItem
        '
        Me.InBrowserToolStripMenuItem.Name = "InBrowserToolStripMenuItem"
        Me.InBrowserToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.InBrowserToolStripMenuItem.Text = "In Browser"
        '
        'InVLCToolStripMenuItem
        '
        Me.InVLCToolStripMenuItem.Name = "InVLCToolStripMenuItem"
        Me.InVLCToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.InVLCToolStripMenuItem.Text = "In VLC"
        '
        'JustCopyStreamURLToClipboardToolStripMenuItem
        '
        Me.JustCopyStreamURLToClipboardToolStripMenuItem.Enabled = False
        Me.JustCopyStreamURLToClipboardToolStripMenuItem.Name = "JustCopyStreamURLToClipboardToolStripMenuItem"
        Me.JustCopyStreamURLToClipboardToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.JustCopyStreamURLToClipboardToolStripMenuItem.Text = "Just copy stream URL to Clipboard"
        '
        'DetailedInfoToolStripMenuItem
        '
        Me.DetailedInfoToolStripMenuItem.Name = "DetailedInfoToolStripMenuItem"
        Me.DetailedInfoToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DetailedInfoToolStripMenuItem.Text = "Detailed Info"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabFollowing)
        Me.TabControl1.Controls.Add(Me.TabGames)
        Me.TabControl1.Location = New System.Drawing.Point(12, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(683, 549)
        Me.TabControl1.TabIndex = 5
        '
        'TabFollowing
        '
        Me.TabFollowing.Controls.Add(Me.Label2)
        Me.TabFollowing.Controls.Add(Me.Button5)
        Me.TabFollowing.Controls.Add(Me.LabelGame)
        Me.TabFollowing.Controls.Add(Me.Label1)
        Me.TabFollowing.Controls.Add(Me.LabelStreamerName)
        Me.TabFollowing.Controls.Add(Me.PictureBoxPreview)
        Me.TabFollowing.Controls.Add(Me.ListView2)
        Me.TabFollowing.Controls.Add(Me.PictureBoxLogo)
        Me.TabFollowing.Controls.Add(Me.ListView1)
        Me.TabFollowing.Controls.Add(Me.Button1)
        Me.TabFollowing.Controls.Add(Me.ListBox1)
        Me.TabFollowing.Controls.Add(Me.RichTextBox1)
        Me.TabFollowing.Location = New System.Drawing.Point(4, 22)
        Me.TabFollowing.Name = "TabFollowing"
        Me.TabFollowing.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFollowing.Size = New System.Drawing.Size(675, 523)
        Me.TabFollowing.TabIndex = 0
        Me.TabFollowing.Text = "Following"
        Me.TabFollowing.UseVisualStyleBackColor = True
        '
        'PictureBoxPreview
        '
        Me.PictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxPreview.Location = New System.Drawing.Point(479, 367)
        Me.PictureBoxPreview.Name = "PictureBoxPreview"
        Me.PictureBoxPreview.Size = New System.Drawing.Size(190, 150)
        Me.PictureBoxPreview.TabIndex = 6
        Me.PictureBoxPreview.TabStop = False
        '
        'ListView2
        '
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderPrev, Me.ColumnHeaderLogo, Me.ColumnHeaderURL})
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(189, 224)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(462, 97)
        Me.ListView2.TabIndex = 5
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        Me.ListView2.Visible = False
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "streamer"
        Me.ColumnHeaderName.Width = 67
        '
        'ColumnHeaderPrev
        '
        Me.ColumnHeaderPrev.Text = "preview"
        Me.ColumnHeaderPrev.Width = 154
        '
        'ColumnHeaderLogo
        '
        Me.ColumnHeaderLogo.Text = "logo"
        Me.ColumnHeaderLogo.Width = 148
        '
        'ColumnHeaderURL
        '
        Me.ColumnHeaderURL.Text = "url"
        Me.ColumnHeaderURL.Width = 59
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxLogo.Location = New System.Drawing.Point(6, 343)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(96, 92)
        Me.PictureBoxLogo.TabIndex = 4
        Me.PictureBoxLogo.TabStop = False
        '
        'TabGames
        '
        Me.TabGames.Controls.Add(Me.Button4)
        Me.TabGames.Controls.Add(Me.Button3)
        Me.TabGames.Controls.Add(Me.RichTextBox2)
        Me.TabGames.Controls.Add(Me.ListView4)
        Me.TabGames.Controls.Add(Me.ListView3)
        Me.TabGames.Controls.Add(Me.Button2)
        Me.TabGames.Location = New System.Drawing.Point(4, 22)
        Me.TabGames.Name = "TabGames"
        Me.TabGames.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGames.Size = New System.Drawing.Size(675, 617)
        Me.TabGames.TabIndex = 1
        Me.TabGames.Text = "Games"
        Me.TabGames.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(81, 403)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox2.TabIndex = 4
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'ListView4
        '
        Me.ListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView4.FullRowSelect = True
        Me.ListView4.GridLines = True
        Me.ListView4.Location = New System.Drawing.Point(338, 37)
        Me.ListView4.MultiSelect = False
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(331, 293)
        Me.ListView4.TabIndex = 3
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.Details
        '
        'ListView3
        '
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderGame, Me.ColumnHeaderViewers})
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(7, 37)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(325, 293)
        Me.ListView3.TabIndex = 2
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderGame
        '
        Me.ColumnHeaderGame.Text = "Game"
        Me.ColumnHeaderGame.Width = 239
        '
        'ColumnHeaderViewers
        '
        Me.ColumnHeaderViewers.Text = "Viewers"
        Me.ColumnHeaderViewers.Width = 80
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(7, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Get list / Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.AboutToolStripMenuItem, Me.RawrawToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(707, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditBlockListToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'EditBlockListToolStripMenuItem
        '
        Me.EditBlockListToolStripMenuItem.Enabled = False
        Me.EditBlockListToolStripMenuItem.Name = "EditBlockListToolStripMenuItem"
        Me.EditBlockListToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.EditBlockListToolStripMenuItem.Text = "Edit Block List *SOON*"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'RawrawToolStripMenuItem
        '
        Me.RawrawToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RawrawToolStripMenuItem.Enabled = False
        Me.RawrawToolStripMenuItem.Name = "RawrawToolStripMenuItem"
        Me.RawrawToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
        Me.RawrawToolStripMenuItem.Text = "© 2014 - raw_raw"
        '
        'LabelStreamerName
        '
        Me.LabelStreamerName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelStreamerName.AutoSize = True
        Me.LabelStreamerName.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStreamerName.Location = New System.Drawing.Point(222, 350)
        Me.LabelStreamerName.Name = "LabelStreamerName"
        Me.LabelStreamerName.Size = New System.Drawing.Size(36, 25)
        Me.LabelStreamerName.TabIndex = 7
        Me.LabelStreamerName.Text = "lol"
        Me.LabelStreamerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelStreamerName.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(233, 375)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "is playing"
        Me.Label1.Visible = False
        '
        'LabelGame
        '
        Me.LabelGame.AutoSize = True
        Me.LabelGame.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGame.Location = New System.Drawing.Point(224, 389)
        Me.LabelGame.Name = "LabelGame"
        Me.LabelGame.Size = New System.Drawing.Size(70, 13)
        Me.LabelGame.TabIndex = 9
        Me.LabelGame.Text = "LabelGame"
        Me.LabelGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelGame.Visible = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(166, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Previous 100"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(252, 15)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Next 100"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Streamer"
        Me.ColumnHeader1.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Viewers"
        Me.ColumnHeader2.Width = 52
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Title"
        Me.ColumnHeader3.Width = 196
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(6, 441)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(150, 23)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Open Stream and Chat"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(476, 351)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Video Thumb:"
        Me.Label2.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 583)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "MyTwitchExperience BibleThump"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabFollowing.ResumeLayout(False)
        Me.TabFollowing.PerformLayout()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGames.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents lw_streamer As System.Windows.Forms.ColumnHeader
    Friend WithEvents lw_viewers As System.Windows.Forms.ColumnHeader
    Friend WithEvents lw_game As System.Windows.Forms.ColumnHeader
    Friend WithEvents lw_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents lw_software As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InVLCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JustCopyStreamURLToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailedInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabFollowing As System.Windows.Forms.TabPage
    Friend WithEvents TabGames As System.Windows.Forms.TabPage
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RawrawToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderPrev As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderLogo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditBlockListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents ListView4 As System.Windows.Forms.ListView
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents ColumnHeaderGame As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderViewers As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelStreamerName As System.Windows.Forms.Label
    Friend WithEvents LabelGame As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class