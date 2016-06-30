Imports System.Net.Sockets
Imports System

Public Class Socket2
    Inherits Socket
    Implements IDisposable

    Public Sub New()

        MyBase.New(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
    End Sub


#Region " IDisposable Support "
    ' Do not change or add Overridable to these methods.
    ' Put cleanup code in Dispose(ByVal disposing As Boolean).
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region

End Class
