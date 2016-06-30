<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class from
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(from))
        Me.ScreenLog = New System.Windows.Forms.RichTextBox()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInitial = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSendMsg = New System.Windows.Forms.Button()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.btnLoadMsgSet = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbMsgSet = New System.Windows.Forms.ListBox()
        Me.txtMsgRecv = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picGreen = New System.Windows.Forms.PictureBox()
        Me.picRed = New System.Windows.Forms.PictureBox()
        Me.txtListenerPort = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtListenerIP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRemotePort = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRemoteIP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnLoopSend = New System.Windows.Forms.Button()
        Me.txtLoopCnt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTimerReSend = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTimerMs = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ckbAutoReply = New System.Windows.Forms.CheckBox()
        Me.btnTimerStop = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnCode2 = New System.Windows.Forms.RadioButton()
        Me.rbtnCode1 = New System.Windows.Forms.RadioButton()
        Me.rbtnCode = New System.Windows.Forms.RadioButton()
        CType(Me.picGreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ScreenLog
        '
        Me.ScreenLog.Location = New System.Drawing.Point(17, 549)
        Me.ScreenLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScreenLog.Name = "ScreenLog"
        Me.ScreenLog.Size = New System.Drawing.Size(797, 104)
        Me.ScreenLog.TabIndex = 0
        Me.ScreenLog.Text = ""
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(17, 29)
        Me.txtMsg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(800, 222)
        Me.txtMsg.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Tag = ""
        Me.Label2.Text = "Message_Send"
        '
        'btnInitial
        '
        Me.btnInitial.Location = New System.Drawing.Point(651, 44)
        Me.btnInitial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInitial.Name = "btnInitial"
        Me.btnInitial.Size = New System.Drawing.Size(136, 42)
        Me.btnInitial.TabIndex = 1
        Me.btnInitial.Text = "Start Listen"
        Me.btnInitial.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Tag = ""
        Me.Label3.Text = "Message_Recv"
        '
        'btnSendMsg
        '
        Me.btnSendMsg.Location = New System.Drawing.Point(528, 259)
        Me.btnSendMsg.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSendMsg.Name = "btnSendMsg"
        Me.btnSendMsg.Size = New System.Drawing.Size(143, 42)
        Me.btnSendMsg.TabIndex = 10
        Me.btnSendMsg.Text = "Send"
        Me.btnSendMsg.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Location = New System.Drawing.Point(675, 259)
        Me.btnClean.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(143, 42)
        Me.btnClean.TabIndex = 11
        Me.btnClean.Text = "Clean"
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'btnLoadMsgSet
        '
        Me.btnLoadMsgSet.Location = New System.Drawing.Point(12, 11)
        Me.btnLoadMsgSet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoadMsgSet.Name = "btnLoadMsgSet"
        Me.btnLoadMsgSet.Size = New System.Drawing.Size(136, 42)
        Me.btnLoadMsgSet.TabIndex = 13
        Me.btnLoadMsgSet.Text = "Load Msg Set"
        Me.btnLoadMsgSet.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Tag = ""
        Me.Label5.Text = "Msg Set"
        '
        'lbMsgSet
        '
        Me.lbMsgSet.FormattingEnabled = True
        Me.lbMsgSet.ItemHeight = 15
        Me.lbMsgSet.Location = New System.Drawing.Point(11, 82)
        Me.lbMsgSet.Margin = New System.Windows.Forms.Padding(4)
        Me.lbMsgSet.Name = "lbMsgSet"
        Me.lbMsgSet.Size = New System.Drawing.Size(537, 574)
        Me.lbMsgSet.TabIndex = 14
        '
        'txtMsgRecv
        '
        Me.txtMsgRecv.Location = New System.Drawing.Point(19, 309)
        Me.txtMsgRecv.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMsgRecv.Multiline = True
        Me.txtMsgRecv.Name = "txtMsgRecv"
        Me.txtMsgRecv.Size = New System.Drawing.Size(799, 210)
        Me.txtMsgRecv.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 529)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Tag = ""
        Me.Label6.Text = "Log"
        '
        'picGreen
        '
        Me.picGreen.Image = CType(resources.GetObject("picGreen.Image"), System.Drawing.Image)
        Me.picGreen.Location = New System.Drawing.Point(924, 45)
        Me.picGreen.Margin = New System.Windows.Forms.Padding(4)
        Me.picGreen.Name = "picGreen"
        Me.picGreen.Size = New System.Drawing.Size(45, 38)
        Me.picGreen.TabIndex = 17
        Me.picGreen.TabStop = False
        Me.picGreen.Visible = False
        '
        'picRed
        '
        Me.picRed.Image = CType(resources.GetObject("picRed.Image"), System.Drawing.Image)
        Me.picRed.Location = New System.Drawing.Point(925, 46)
        Me.picRed.Margin = New System.Windows.Forms.Padding(4)
        Me.picRed.Name = "picRed"
        Me.picRed.Size = New System.Drawing.Size(43, 35)
        Me.picRed.TabIndex = 18
        Me.picRed.TabStop = False
        '
        'txtListenerPort
        '
        Me.txtListenerPort.Location = New System.Drawing.Point(508, 49)
        Me.txtListenerPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtListenerPort.Name = "txtListenerPort"
        Me.txtListenerPort.Size = New System.Drawing.Size(135, 25)
        Me.txtListenerPort.TabIndex = 26
        Me.txtListenerPort.Text = "6000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(409, 54)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Listener Port:"
        '
        'txtListenerIP
        '
        Me.txtListenerIP.Location = New System.Drawing.Point(121, 48)
        Me.txtListenerIP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtListenerIP.Name = "txtListenerIP"
        Me.txtListenerIP.Size = New System.Drawing.Size(276, 25)
        Me.txtListenerIP.TabIndex = 24
        Me.txtListenerIP.Text = "192.168.1.101"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 58)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Listener IP:"
        '
        'txtRemotePort
        '
        Me.txtRemotePort.Location = New System.Drawing.Point(508, 10)
        Me.txtRemotePort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemotePort.Name = "txtRemotePort"
        Me.txtRemotePort.Size = New System.Drawing.Size(135, 25)
        Me.txtRemotePort.TabIndex = 22
        Me.txtRemotePort.Text = "6001"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(408, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Remote Port:"
        '
        'txtRemoteIP
        '
        Me.txtRemoteIP.Location = New System.Drawing.Point(119, 9)
        Me.txtRemoteIP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemoteIP.Name = "txtRemoteIP"
        Me.txtRemoteIP.Size = New System.Drawing.Size(280, 25)
        Me.txtRemoteIP.TabIndex = 20
        Me.txtRemoteIP.Text = "192.168.1.101"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(36, 15)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Remote IP:"
        '
        'btnLoopSend
        '
        Me.btnLoopSend.Location = New System.Drawing.Point(780, 120)
        Me.btnLoopSend.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoopSend.Name = "btnLoopSend"
        Me.btnLoopSend.Size = New System.Drawing.Size(136, 35)
        Me.btnLoopSend.TabIndex = 27
        Me.btnLoopSend.Text = "Loop Send"
        Me.btnLoopSend.UseVisualStyleBackColor = True
        '
        'txtLoopCnt
        '
        Me.txtLoopCnt.Location = New System.Drawing.Point(1019, 126)
        Me.txtLoopCnt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLoopCnt.Name = "txtLoopCnt"
        Me.txtLoopCnt.Size = New System.Drawing.Size(129, 25)
        Me.txtLoopCnt.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(924, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Loop Count:"
        '
        'btnTimerReSend
        '
        Me.btnTimerReSend.Location = New System.Drawing.Point(780, 169)
        Me.btnTimerReSend.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTimerReSend.Name = "btnTimerReSend"
        Me.btnTimerReSend.Size = New System.Drawing.Size(143, 30)
        Me.btnTimerReSend.TabIndex = 30
        Me.btnTimerReSend.Text = "Timer ReSend"
        Me.btnTimerReSend.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(789, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Timer ns:"
        '
        'txtTimerMs
        '
        Me.txtTimerMs.Location = New System.Drawing.Point(863, 58)
        Me.txtTimerMs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimerMs.Name = "txtTimerMs"
        Me.txtTimerMs.Size = New System.Drawing.Size(53, 25)
        Me.txtTimerMs.TabIndex = 32
        Me.txtTimerMs.Text = "1000"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SplitContainer1.Location = New System.Drawing.Point(16, 208)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnLoadMsgSet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbMsgSet)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ckbAutoReply)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ScreenLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtMsg)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSendMsg)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClean)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtMsgRecv)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1133, 666)
        Me.SplitContainer1.SplitterDistance = 283
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 33
        Me.SplitContainer1.Tag = ""
        '
        'ckbAutoReply
        '
        Me.ckbAutoReply.AutoSize = True
        Me.ckbAutoReply.Location = New System.Drawing.Point(416, 271)
        Me.ckbAutoReply.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbAutoReply.Name = "ckbAutoReply"
        Me.ckbAutoReply.Size = New System.Drawing.Size(94, 19)
        Me.ckbAutoReply.TabIndex = 16
        Me.ckbAutoReply.Text = "Auto Reply"
        Me.ckbAutoReply.UseVisualStyleBackColor = True
        Me.ckbAutoReply.Visible = False
        '
        'btnTimerStop
        '
        Me.btnTimerStop.Location = New System.Drawing.Point(925, 169)
        Me.btnTimerStop.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTimerStop.Name = "btnTimerStop"
        Me.btnTimerStop.Size = New System.Drawing.Size(143, 30)
        Me.btnTimerStop.TabIndex = 34
        Me.btnTimerStop.Text = "Timer ReSend Stop"
        Me.btnTimerStop.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnCode2)
        Me.GroupBox1.Controls.Add(Me.rbtnCode1)
        Me.GroupBox1.Controls.Add(Me.rbtnCode)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 92)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(139, 106)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message Encode"
        '
        'rbtnCode2
        '
        Me.rbtnCode2.AutoSize = True
        Me.rbtnCode2.Location = New System.Drawing.Point(25, 79)
        Me.rbtnCode2.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCode2.Name = "rbtnCode2"
        Me.rbtnCode2.Size = New System.Drawing.Size(62, 19)
        Me.rbtnCode2.TabIndex = 2
        Me.rbtnCode2.TabStop = True
        Me.rbtnCode2.Text = "UTF8"
        Me.rbtnCode2.UseVisualStyleBackColor = True
        '
        'rbtnCode1
        '
        Me.rbtnCode1.AutoSize = True
        Me.rbtnCode1.Location = New System.Drawing.Point(25, 54)
        Me.rbtnCode1.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCode1.Name = "rbtnCode1"
        Me.rbtnCode1.Size = New System.Drawing.Size(65, 19)
        Me.rbtnCode1.TabIndex = 1
        Me.rbtnCode1.TabStop = True
        Me.rbtnCode1.Text = "ASCII"
        Me.rbtnCode1.UseVisualStyleBackColor = True
        '
        'rbtnCode
        '
        Me.rbtnCode.AutoSize = True
        Me.rbtnCode.Location = New System.Drawing.Point(25, 29)
        Me.rbtnCode.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCode.Name = "rbtnCode"
        Me.rbtnCode.Size = New System.Drawing.Size(75, 19)
        Me.rbtnCode.TabIndex = 0
        Me.rbtnCode.TabStop = True
        Me.rbtnCode.Text = "Unicode"
        Me.rbtnCode.UseVisualStyleBackColor = True
        '
        'from
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 889)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnTimerStop)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtTimerMs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnTimerReSend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLoopCnt)
        Me.Controls.Add(Me.btnLoopSend)
        Me.Controls.Add(Me.txtListenerPort)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtListenerIP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRemotePort)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRemoteIP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.picRed)
        Me.Controls.Add(Me.picGreen)
        Me.Controls.Add(Me.btnInitial)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "from"
        Me.Text = "MasonLin Socket Simulator V 1.0"
        CType(Me.picGreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ScreenLog As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnInitial As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSendMsg As System.Windows.Forms.Button
    Friend WithEvents btnClean As System.Windows.Forms.Button
    Friend WithEvents btnLoadMsgSet As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbMsgSet As System.Windows.Forms.ListBox
    Friend WithEvents txtMsgRecv As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picGreen As System.Windows.Forms.PictureBox
    Friend WithEvents picRed As System.Windows.Forms.PictureBox
    Friend WithEvents txtListenerPort As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtListenerIP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemotePort As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRemoteIP As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnLoopSend As System.Windows.Forms.Button
    Friend WithEvents txtLoopCnt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTimerReSend As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTimerMs As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ckbAutoReply As System.Windows.Forms.CheckBox
    Friend WithEvents btnTimerStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnCode1 As RadioButton
    Friend WithEvents rbtnCode As RadioButton
    Friend WithEvents rbtnCode2 As RadioButton
End Class
