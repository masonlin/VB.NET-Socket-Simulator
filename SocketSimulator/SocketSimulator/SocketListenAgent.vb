Imports System
Imports System.Xml
Imports System.Net.Sockets
Imports System.Threading
Imports System.ComponentModel


Public Class SocketListenAgent

    Public listener As New Socket2()
    Public localEndPoint As System.Net.IPEndPoint


    Public Sub New()

    End Sub

    Public Function Ini(ByVal sIP As String, ByVal sPort As String) As String

        Try

            Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(sIP)

            Dim IPV4Number As Integer
            IPV4Number = getIPV4(ipHostInfo)
            If IPV4Number = Nothing Then
                MsgBox("IPV4 is not found.")
                Return "IPV4 is not found."
            End If

            Dim ipAddress As System.Net.IPAddress = ipHostInfo.AddressList(IPV4Number)


            localEndPoint = New System.Net.IPEndPoint(ipAddress, sPort)

            Dim a As Boolean
            a = listener.Connected
            'listener.
            listener.Close()
            listener.Dispose()

            GC.Collect()


            listener = New Socket2()

            listener.Bind(localEndPoint)

            listener.Listen(10000)



            Return "OK"

        Catch se As System.Net.Sockets.SocketException
            Return (se.ToString)
        Catch ex As Exception
            Return (ex.ToString)
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

            Return Nothing
        Catch ex As Exception

            Return Nothing
        End Try

    End Function


    Public Function GetReciveMsg() As String


        Try
            Dim bytes() As Byte
            Dim handler As System.Net.Sockets.Socket = listener.Accept() '建連            

            Dim data As String = Nothing

            bytes = New Byte(5120) {}

            Dim bytesRec As Integer = handler.Receive(bytes) '接資

            If bytesRec > 0 Then
                ''''''1.1.0 START''''''
                If from.rbtnCode.Checked Then
                    data = System.Text.Encoding.Unicode.GetString(bytes, 0, bytesRec)
                ElseIf from.rbtnCode1.Checked Then
                    data = System.Text.Encoding.ASCII.GetString(bytes)
                ElseIf from.rbtnCode2.Checked Then
                    data = System.Text.Encoding.UTF8.GetString(bytes)
                End If
                ''''''1.1.0 END''''''
            Else
                Return ""
            End If

            handler.Shutdown(Net.Sockets.SocketShutdown.Both)
            handler.Close()

            Return data

        Catch se As System.Net.Sockets.SocketException
            'WriteToScreen(se.ToString)
            Return se.Message & " --- " & se.StackTrace
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return ex.Message & " --- " & ex.StackTrace
        End Try

    End Function



   

End Class
