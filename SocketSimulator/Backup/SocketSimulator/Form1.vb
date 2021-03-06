﻿'20150601 Mason Lin V1.0.0
'20150918 Mason Lin V1.1.0 for switch encode
'20151203 Mason Lin V1.2.0 for MESSAGE tag

Imports System
'Imports System.Threading
'Imports Apache.NMS
'Imports Apache.NMS.Util
'Imports System.Messaging
Imports System.Xml
Imports System.Net.Sockets
Imports System.Threading




Public Class from
    Dim sVersion As String = "1.2.0"    '1.1.0

    Declare Function WSACleanup Lib "wsock32.dll" () As Long

    'Dim consumer As IMessageConsumer
    'Dim destination_rcvd As IDestination
    'Dim destination_Send As IDestination
    'Dim producer As IMessageProducer
    'Dim session As ISession
    'Dim connection As IConnection
    'Dim factory As IConnectionFactory

    'Public message As ITextMessage = Nothing



    Private trxCollection As New Collection

    Private Delegate Sub UpdateUICallBack(ByVal intxt As String)

    '初始socket
    'Dim listener As New System.Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
    'Dim localEndPoint As System.Net.IPEndPoint

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

        'Try


        '    Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(txtListenerIP.Text)

        '    Dim IPV4Number As Integer
        '    IPV4Number = getIPV4(ipHostInfo)
        '    If IPV4Number = Nothing Then
        '        MsgBox("IPV4 is not found.")
        '        Exit Sub
        '    End If

        '    Dim ipAddress As System.Net.IPAddress = ipHostInfo.AddressList(IPV4Number)


        '    localEndPoint = New System.Net.IPEndPoint(ipAddress, txtListenerPort.Text)

        '    listener.Bind(localEndPoint)

        '    listener.Listen(100)


        '    picGreen.Visible = True
        '    picRed.Visible = False


        '    InitialTimeoutTimer()

        'Catch se As System.Net.Sockets.SocketException
        '    WriteToScreen(se.ToString)
        'Catch ex As Exception
        '    WriteToScreen(ex.ToString)
        'End Try

        picGreen.Visible = True
        picRed.Visible = False



        If SLA IsNot Nothing Then
            If SLA.listener.IsBound Then
                'SLA.listener.NoDelay = True
                SLA.listener.Close()

            End If
        End If
        'Dim lRtn As Long
        'lRtn = WSACleanup()


        SLA = New SocketListenAgent()
        SLA.Ini(txtListenerIP.Text, txtListenerPort.Text)


        'SSA = New SocketSendAgent(txtRemoteIP.Text, txtRemotePort.Text)
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
        Dim sCorrId As String

        Try
            tmrListener.Enabled = False
            SyncLock tmrListener


                '******** 暫時MARK **********
                data = SLA.GetReciveMsg()
                If data <> "" Then
                    iMsgCnt = iMsgCnt + 1
                    txtMsgRecv.Text = data


                    xMsg = "RcvMsgCnt:" & iMsgCnt.ToString & " --- " & data & " --- " & vbCrLf
                    ScreenLog.SelectionLength = Len(xMsg)
                    ScreenLog.SelectedText = (xMsg)
                End If

                'If Me.bResend = False Then

                '    '******** 暫時MARK **********
                '    'data = SLA.GetReciveMsg()
                '    'If data <> "" Then
                '    '    iMsgCnt = iMsgCnt + 1
                '    '    txtMsgRecv.Text = data


                '    '    xMsg = "RcvMsgCnt:" & iMsgCnt.ToString & vbCrLf
                '    '    ScreenLog.SelectionLength = Len(xMsg)
                '    '    ScreenLog.SelectedText = (xMsg)
                '    'End If

                'Else

                '    'S get Corr_id
                '    sCorrId = ""
                '    xd.LoadXml(txtMsg.Text)
                '    sCorrId = SetCorrID()
                '    xd.SelectSingleNode("//DOCUMENT/HEAD/CORR_ID").InnerText = sCorrId

                '    xMsg = "S: " & sCorrId & vbCrLf
                '    ScreenLog.SelectionLength = Len(xMsg)
                '    ScreenLog.SelectedText = (xMsg)

                '    txtMsg.Text = xd.InnerXml

                '    SSA.PreSendMsg(txtMsg.Text, txtRemoteIP.Text, txtRemotePort.Text)
                '    Dim Thread1 As New System.Threading.Thread(AddressOf SSA.SendMsg)
                '    Thread1.Start()


                '    data = SLA.GetReciveMsg()
                '    If data <> "" Then
                '        Me.txtMsgRecv.Text = data

                '        'R get Corr_id
                '        xd.LoadXml(data)
                '        sCorrId = xd.SelectSingleNode("//DOCUMENT/HEAD/CORR_ID").InnerText

                '        xMsg = "R: " & sCorrId & vbCrLf
                '        ScreenLog.SelectionLength = Len(xMsg)
                '        ScreenLog.SelectedText = (xMsg)
                '    End If

                'End If



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
            'Thread1.Start()
            Dim Thread1 As New System.Threading.Thread(AddressOf SSA.SendMsg)
            Thread1.Start()
            'Thread1.Abort()
            'Threading.Thread.Sleep(700)



            'Dim msg As Byte() = System.Text.Encoding.Unicode.GetBytes(txtMsg.Text)
            'If msg.Length = 0 Then
            '    Exit Sub
            'End If

            'Dim bytes(5120) As Byte '聲明位元組陣列
            'Dim sender1 As New System.Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)

            ''初始化socket
            ''Dim msg As Byte() = System.Text.Encoding.Unicode.GetBytes(txtMsg.Text)

            ''對發送的資料進行編碼
            ''***************************
            ''指定ip和埠

            'Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(txtRemoteIP.Text)

            'Dim IPV4Number As Integer
            'IPV4Number = getIPV4(ipHostInfo)
            'If IPV4Number = Nothing Then
            '    Exit Sub
            'End If


            'Dim ipAddress As System.Net.IPAddress = ipHostInfo.AddressList(IPV4Number)

            'Dim ipe As New System.Net.IPEndPoint(ipAddress, txtRemotePort.Text)

            ''**********************
            ''Dim xMsg As String
            ''If sender1.Connected() Then
            ''    xMsg = "Connect" & vbCrLf
            ''Else
            ''    xMsg = "DisConnect" & vbCrLf
            ''End If
            ''ScreenLog.SelectionLength = Len(xMsg)
            ''ScreenLog.SelectedText = (xMsg)


            'sender1.Connect(ipe) '建立連接

            'Dim bytesSent As Integer = sender1.Send(msg) '發送資料

            ''關閉socket
            'sender1.Shutdown(Net.Sockets.SocketShutdown.Both)
            'sender1.Close()


            txtMsg.Text = ""
            txtMsgRecv.Text = ""

            ''Timer1.Enabled = True

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

            If xd.SelectSingleNode("//DOCUMENT/HEAD/CORR_ID") IsNot Nothing Then

                If GetCorrID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//DOCUMENT/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//DOCUMENT/HEAD/CORR_ID").InnerText = GetCorrID()
                    End If
                End If

                If GetEQPID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//DOCUMENT/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//DOCUMENT/HEAD/EQP_ID").InnerText = GetEQPID()
                    End If
                End If
                txtMsg.Text = xd.OuterXml
            End If


            ''''''1.2.0 START''''''
            If xd.SelectSingleNode("//MESSAGE/HEAD/CORR_ID") IsNot Nothing Then

                If GetCorrID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//MESSAGE/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//MESSAGE/HEAD/CORR_ID").InnerText = GetCorrID()
                    End If
                End If

                If GetEQPID.CompareTo("") <> 0 Then
                    If MatchMsgID(xd.SelectSingleNode("//MESSAGE/HEAD/MESSAGE_ID").InnerText) Then
                        xd.SelectSingleNode("//MESSAGE/HEAD/EQP_ID").InnerText = GetEQPID()
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
                xnl = xd.GetElementsByTagName("DOCUMENT")

                For Each xnln As XmlElement In xnl
                    sCorrID = xnln.GetElementsByTagName("CORR_ID")(0).InnerText
                Next

                ''''''1.2.0 START''''''
                xnl = xd.GetElementsByTagName("MESSAGE")

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
                xnl = xd.GetElementsByTagName("DOCUMENT")

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
                xnl = xd.GetElementsByTagName("DOCUMENT")



                For Each xnln As XmlElement In xnl
                    If sSendMsgID.IndexOf(xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText) >= 0 Or _
                       (xnln.GetElementsByTagName("MESSAGE_ID")(0).InnerText).IndexOf(sSendMsgID) >= 0 Then
                        Return True
                    End If
                Next

                ''''''1.2.0 START''''''
                xnl = xd.GetElementsByTagName("MESSAGE")

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
                xnl = xd.GetElementsByTagName("DOCUMENT")

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


    'Public Function getIPV4(ByVal ipHostInfo As System.Net.IPHostEntry) As Integer
    '    Dim int As Integer = 0

    '    Try

    '        For i = 0 To ipHostInfo.AddressList.Length - 1
    '            If ipHostInfo.AddressList(i).AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
    '                Return i
    '            End If
    '        Next

    '        Return Nothing
    '    Catch ex As Exception

    '        Return Nothing
    '    End Try

    'End Function

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

            Me.Text = "Versopm: " & sVersion   '1.1.0
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

