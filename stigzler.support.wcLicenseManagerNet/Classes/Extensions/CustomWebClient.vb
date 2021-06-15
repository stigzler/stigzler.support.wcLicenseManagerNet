Imports System.Net

Public Class CustomWebClient
    Inherits WebClient
    Public Property WebClientTimeout = 100000 ' in ms
    Public Sub New()

    End Sub

    Public Sub New(Timeout As Integer)
        WebClientTimeout = Timeout
    End Sub
    Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest
        Dim w As WebRequest = MyBase.GetWebRequest(uri)
        w.Timeout = WebClientTimeout
        Return w
    End Function

End Class
