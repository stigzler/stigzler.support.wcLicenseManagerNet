Public Class LicenseRequestOutcome
    Public Property ProcessOutcome As ProcessOutcome = Nothing
    Public Property WebClientException As Exception = Nothing
    Public Property APISuccessResponse As Boolean = False
    Public Property APIReturnedJsonString As String = Nothing
    Public Property Licences As New List(Of License)

End Class
