﻿Imports System
Imports System.Xml
Imports System.Net.Sockets
Imports System.Threading

Public Class SocketSendAgent
    Dim sMsg As String
    Dim sIP As String
    Dim sPort As String


    Public Sub New()
    End Sub

    Public Sub PreSendMsg(ByVal strMsg As String, ByVal strIP As String, ByVal strPort As String)
        sMsg = strMsg
        sIP = strIP
        sPort = strPort
    End Sub

    Public Function SendMsg() As String

        Try
            ''''''1.1.0 START''''''
            Dim msg As Byte()

            If from.rbtnCode.Checked Then
                msg = System.Text.Encoding.Unicode.GetBytes(sMsg)
            ElseIf from.rbtnCode1.Checked Then
                msg = System.Text.Encoding.ASCII.GetBytes(sMsg)
            ElseIf from.rbtnCode2.Checked Then
                msg = System.Text.Encoding.UTF8.GetBytes(sMsg)
            End If
            ''''''1.1.0 END''''''

            If msg.Length = 0 Then
                Return "NG-No Msg"
            End If

            Dim bytes(5120) As Byte '位元組
            Dim sender1 As New System.Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)



            Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(sIP)

            Dim IPV4Number As Integer
            IPV4Number = getIPV4(ipHostInfo)

            If IPV4Number = -9999 Then
                Return "IPV4 is not found."
            End If

            Dim ipAddress As System.Net.IPAddress = ipHostInfo.AddressList(IPV4Number)

            Dim ipe As New System.Net.IPEndPoint(ipAddress, sPort)



            sender1.Connect(ipe) '建連

            Dim bytesSent As Integer = sender1.Send(msg) '發送

            '關socket
            sender1.Shutdown(Net.Sockets.SocketShutdown.Both)
            sender1.Close()


            Return ""

        Catch se As System.Net.Sockets.SocketException
            'WriteToScreen(se.ToString)
            Return se.Message & " --- " & se.StackTrace

        Catch ex As Exception
            'MsgBox(ex.Message)
            Return ex.Message & " --- " & ex.StackTrace
        End Try

    End Function

    Public Function getIPV4(ByVal ipHostInfo As System.Net.IPHostEntry) As Integer
        Dim int As Integer = 0

        Try

            For i = 0 To ipHostInfo.AddressList.Length - 1
                If ipHostInfo.AddressList(i).AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    Return i
                End If
            Next

            'Return Nothing
            Return -9999
        Catch ex As Exception

            'Return Nothing
            Return -9999
        End Try

    End Function


End Class
