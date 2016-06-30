'20150601 Mason Lin V1.0.0
'20150918 Mason Lin V1.1.0 for switch encode
'20151203 Mason Lin V1.2.0 for MESSAGE tag

Imports System
Imports System.Xml
Imports System.Net.Sockets
Imports System.Threading




Public Class from
    Dim sVersion As String = "1.2.0"    '1.1.0

    Declare Function WSACleanup Lib "wsock32.dll" () As Long


    Private trxCollection As New Collection

    Private Delegate Sub UpdateUICallBack(ByVal intxt As String)

    Dim WithEvents tmrListener As System.Timers.Timer
    Dim bResend As Boolean = False

    Dim SLA As SocketListenAgent
    Dim SSA As SocketSendAgent


    Dim iMsgCnt As Integer



    Dim Thread1() As System.Threading.Thread

    Private Sub InitialTimeoutTimer()
        tmrListener = New System.Timers.Timer
        tmrListener.Interval = Convert.ToInt32(txtTimerMs.Text)
        tmrListener.Start()

    End Sub

    Public Sub WriteToScreen(ByVal intxt As String)
        If InvokeRequired() Then
            Dim cb As New UpdateUICallBack(AddressOf AddLog)
            Invoke(cb, intxt)
        Else
            AddLog(intxt)
        End If

    End Sub

    Public Sub WriteToMsgRecv(ByVal intxt As String)
        If InvokeRequired() Then
            Dim cb As New UpdateUICallBack(AddressOf AddMsgRecv)
            Invoke(cb, intxt)
        Else
            AddMsgRecv(intxt)
        End If

    End Sub



    Private Sub btnInitial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitial.Click

        picGreen.Visible = True
        picRed.Visible = False



        If SLA IsNot Nothing Then
            If SLA.listener.IsBound Then
                SLA.listener.Close()

            End If
        End If

        SLA = New SocketListenAgent()
        SLA.Ini(txtListenerIP.Text, txtListenerPort.Text)

        SSA = New SocketSendAgent()

        InitialTimeoutTimer()

    End Sub



    Private Sub AddLog(ByVal xMsg As String)
        xMsg = xMsg & vbCrLf
        ScreenLog.SelectionLength = Len(xMsg)
        ScreenLog.SelectedText = (xMsg)
    End Sub

    Private Sub AddMsgRecv(ByVal xMsg As String)
        txtMsgRecv.Text = xMsg
    End Sub


    Private Sub tmrListener_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrListener.Elapsed
        Dim data As String
        Dim xMsg As String
        Dim xd As New XmlDocument

        Try
            tmrListener.Enabled = False
            SyncLock tmrListener

                data = SLA.GetReciveMsg()
                If data <> "" Then
                    iMsgCnt = iMsgCnt + 1
                    txtMsgRecv.Text = data

                    xMsg = "RcvMsgCnt:" & iMsgCnt.ToString & " --- " & data & " --- " & vbCrLf
                    ScreenLog.SelectionLength = Len(xMsg)
                    ScreenLog.SelectedText = (xMsg)
                End If



            End SyncLock
            tmrListener.Enabled = True


        Catch se As System.Net.Sockets.SocketException
            WriteToScreen(se.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub











    Private Sub btnLoadMsgSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadMsgSet.Click
        Dim xd As XmlDocument
        Dim xnl As XmlNodeList
        Dim MSG_ID, TYPE, colKey As String
        Dim i As Integer = 0

        Try
            xd = New XmlDocument
            xd.Load("xTRX_Simulator.ini")
            lbMsgSet.Items.Clear()
            trxCollection.Clear()


            xnl = xd.GetElementsByTagName("DOCUMENT")
            If xnl Is Nothing Then                          '1.2.0
                xnl = xd.GetElementsByTagName("MESSAGE")    '1.2.0
            End If                                          '1.2.0 


            trxCollection.Add(New String(""), " ")

            For Each xnln As XmlElement In xnl
                i = i + 1

                MSG_ID = xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText

                colKey = Format(i, "000") & "   " & MSG_ID
                lbMsgSet.Items.Add(colKey)
                trxCollection.Add(New String(xnln.OuterXml), colKey)
            Next


            '1.2.0            xnl = xd.GetElementsByTagName("DOCUMENT")

            ''''''1.2.0 START''''''
            xnl = xd.GetElementsByTagName("MESSAGE")

            For Each xnln As XmlElement In xnl
                i = i + 1

                MSG_ID = xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText

                colKey = Format(i, "000") & "   " & MSG_ID
                lbMsgSet.Items.Add(colKey)
                trxCollection.Add(New String(xnln.OuterXml), colKey)
            Next
            ''''''1.2.0 END''''''

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSendMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMsg.Click

        Try

            'SSA.SendMsg(txtMsg.Text, txtRemoteIP.Text, txtRemotePort.Text)
            SSA.PreSendMsg(txtMsg.Text, txtRemoteIP.Text, txtRemotePort.Text)
            'Dim Thread1 As New System.Threading.Thread(AddressOf SSA.SendMsg)
            Dim Thread1 As New System.Threading.Thread(AddressOf SSA.SendMsg)
            Thread1.Start()

            txtMsg.Text = ""
            txtMsgRecv.Text = ""


        Catch se As System.Net.Sockets.SocketException
            WriteToScreen(se.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub lbMsgSet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMsgSet.SelectedIndexChanged
        Dim trxStr, trxSelected As String
        Dim xd As New XmlDocument


        Try
            trxSelected = lbMsgSet.SelectedItem.ToString
            trxStr = trxCollection.Item(trxSelected)
            xd.LoadXml(trxStr)

            If xd.SelectSingleNode("//DOC/HEAD/CORR_ID") IsNot Nothing Then

                If GetCorrID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//DOC/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//DOC/HEAD/CORR_ID").InnerText = GetCorrID()
                    End If
                End If

                If GetEQPID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//DOC/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//DOC/HEAD/EQP_ID").InnerText = GetEQPID()
                    End If
                End If
                txtMsg.Text = xd.OuterXml
            End If


            ''''''1.2.0 START''''''
            If xd.SelectSingleNode("//MES/HEAD/CORR_ID") IsNot Nothing Then

                If GetCorrID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//MES/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//MES/HEAD/CORR_ID").InnerText = GetCorrID()
                    End If
                End If

                If GetEQPID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//MES/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//MES/HEAD/EQP_ID").InnerText = GetEQPID()
                    End If
                End If
                txtMsg.Text = xd.OuterXml
            End If
            ''''''1.2.0 END''''''


            xd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetCorrID() As String
        Dim sCorrID As String = ""
        Dim xd As XmlDocument
        Dim xnl As XmlNodeList
        Dim oTR As System.IO.TextReader

        Try
            If txtMsgRecv.Text.CompareTo("") <> 0 Then
                xd = New XmlDocument
                xd.LoadXml(txtMsgRecv.Text)
                xnl = xd.GetElementsByTagName("DOC")

                For Each xnln As XmlElement In xnl
                    sCorrID = xnln.GetElementsByTagName("CORR_ID")(0).InnerText
                Next

                ''''''1.2.0 START''''''
                xnl = xd.GetElementsByTagName("MES")

                For Each xnln As XmlElement In xnl
                    sCorrID = xnln.GetElementsByTagName("CORR_ID")(0).InnerText
                Next
                ''''''1.2.0 END''''''

            End If

            Return sCorrID
        Catch ex As Exception
            MsgBox("ERR INFO:" & ex.Message)
            Return ""
        End Try

    End Function

    Public Function GetEQPID() As String
        Dim sEQPID As String = ""
        Dim xd As XmlDocument
        Dim xnl As XmlNodeList

        Try
            If txtMsgRecv.Text.CompareTo("") <> 0 Then
                xd = New XmlDocument
                xd.LoadXml(txtMsgRecv.Text)
                xnl = xd.GetElementsByTagName("DOC")

                For Each xnln As XmlElement In xnl
                    sEQPID = xnln.GetElementsByTagName("EQP_ID")(0).InnerText
                Next

            End If

            Return sEQPID
        Catch ex As Exception
            MsgBox("ERR INFO:" & ex.Message)
            Return ""
        End Try

    End Function

    Public Function MatchMsgID(ByVal sSendMsgID As String) As Boolean
        Dim xd As XmlDocument
        Dim xnl As XmlNodeList


        Try
            If txtMsgRecv.Text.CompareTo("") <> 0 Then
                xd = New XmlDocument
                xd.LoadXml(txtMsgRecv.Text)
                xnl = xd.GetElementsByTagName("DOC")



                For Each xnln As XmlElement In xnl
                    If sSendMsgID.IndexOf(xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText) >= 0 Or _
                       (xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText).IndexOf(sSendMsgID) >= 0 Then
                        Return True
                    End If
                Next

                ''''''1.2.0 START''''''
                xnl = xd.GetElementsByTagName("MES")

                For Each xnln As XmlElement In xnl
                    If sSendMsgID.IndexOf(xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText) >= 0 Or _
                       (xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText).IndexOf(sSendMsgID) >= 0 Then
                        Return True
                    End If
                Next
                ''''''1.2.0 END''''''
            End If

            Return False
        Catch ex As Exception
            MsgBox("ERR INFO:" & ex.Message)
            Return False
        End Try

    End Function



    Public Function GetMsgIDFilterR() As String
        Dim sMsgID As String = ""
        Dim xd As XmlDocument
        Dim xnl As XmlNodeList

        Try
            If txtMsgRecv.Text.CompareTo("") <> 0 Then
                xd = New XmlDocument
                xd.LoadXml(txtMsgRecv.Text)
                xnl = xd.GetElementsByTagName("DOC")

                For Each xnln As XmlElement In xnl
                    sMsgID = xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText
                Next

                If sMsgID <> "" Then
                    If sMsgID.Substring(-2, 2).CompareTo("_R") = 1 Then
                        sMsgID = sMsgID.Substring(0, sMsgID.Length - 2)
                    End If
                End If

            End If

            Return sMsgID
        Catch ex As Exception
            MsgBox("ERR INFO:" & ex.Message)
            Return ""
        End Try

    End Function

    ' 以目前時間產生 2010/11/09 12:00:00:001 格式的時間字串
    Private Function GenTrxDateTime() As String
        Dim tempDate As Date
        Dim tempStr As String
        tempDate = Now()
        'tempStr = Format(Now, "yyyy/MM/dd HH:mm:ss:fff")
        tempStr = Format(Now, "yyyyMMddHHmmss")
        Return tempStr
    End Function



    Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
        txtMsg.Text = ""
        txtMsgRecv.Text = ""
    End Sub


    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'listener.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Form.CheckForIllegalCrossThreadCalls = False

            Me.Text = "MasonLin Socket Simulator: " & sVersion   '1.1.0
            rbtnCode.Checked = True            '1.1.0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnLoopSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoopSend.Click
        Dim i As Int32
        Dim j As Int32
        Dim xMsg As String

        j = Convert.ToInt32(txtLoopCnt.Text)

        Try

            iMsgCnt = 0

            Dim Thread1(j) As System.Threading.Thread

            For i = 1 To j
                'Threading.Thread.Sleep(500)
                Threading.Thread.Sleep(Convert.ToInt32(txtTimerMs.Text))
                'SSA.SendMsg(txtMsg.Text + i.ToString, txtRemoteIP.Text, txtRemotePort.Text)

                'SyncLock SSA

                SSA.PreSendMsg(txtMsg.Text + i.ToString, txtRemoteIP.Text, txtRemotePort.Text)
                Dim Thread2 As New System.Threading.Thread(AddressOf SSA.SendMsg)
                Thread2.Start()

                'End SyncLock

                'Thread1(j) = New System.Threading.Thread(AddressOf SSA.SendMsg)
                'Thread1(j).Start()
                'Threading.Thread.Sleep(100)
                'Thread1(j).Abort()

                xMsg = i.ToString & vbCrLf
                ScreenLog.SelectionLength = Len(xMsg)
                ScreenLog.SelectedText = (xMsg)
            Next



        Catch se As System.Net.Sockets.SocketException
            WriteToScreen(se.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub btnTimerReSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerReSend.Click
        bResend = True
    End Sub

    Public Function SetCorrID() As String
        SetCorrID = Format(System.DateTime.Now, "yyyyMMddHHmmssfff")
    End Function

    Private Sub btnTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStop.Click
        bResend = False
    End Sub

End Class

