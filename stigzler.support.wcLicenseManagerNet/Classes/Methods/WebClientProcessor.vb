Imports System.IO
Imports System.Net
Imports System.Text

Class WebClientProcessor

    Public Property Credentials As New NetworkCredential
    Public Property WebClientTimeout As Integer = 100000

    Public Sub New(Username As String, Password As String)
        Credentials = New NetworkCredential(Username, Password)
    End Sub
    Public Function HttpAction(netquery As String, method As HttpMethod, Optional json As String = Nothing) As WebClientResponse

        Dim response As New WebClientResponse

        Using client As New CustomWebClient(WebClientTimeout)

            With client
                .Encoding = Encoding.UTF8
                .Credentials = Credentials
                .Headers(HttpRequestHeader.ContentType) = "application/json"
            End With

            Try
                With response
                    Select Case method
                        Case HttpMethod.Get
                            .ReturnedString = client.DownloadString(netquery)
                        Case HttpMethod.Put
                            .ReturnedString = client.UploadString(netquery, "PUT", json)
                        Case HttpMethod.Post
                            .ReturnedString = client.UploadString(netquery, "POST", json)
                    End Select
                    .Success = True
                End With

            Catch ex As Exception

                With response
                    If response IsNot Nothing Then
                        .ReturnedString = New StreamReader(DirectCast(ex, WebException).Response.GetResponseStream()).ReadToEnd
                    End If
                    .Success = False
                    .Exception = ex
                End With

            End Try

        End Using

        Return response

    End Function


End Class
