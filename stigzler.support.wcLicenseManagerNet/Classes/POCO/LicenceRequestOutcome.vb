''' <summary>
''' An object representing the result of the API request.
''' </summary>
Public Class LicenseRequestOutcome
    ''' <summary>
    ''' Outcome of the method. This will include any errors prior to the API request (e.g. not passing a required parameter).
    ''' </summary>
    Public Property ProcessOutcome As ProcessOutcome = Nothing
    ''' <summary>
    ''' If API request results in a WebClient exception, then this is passed via this property. NOTE: these should be viewed with the APIReturnedJsonString as an error here can be an exception thrown by the API itself (e.g. a 404 if a LicenseKey is not found) or due to other http errors (e.g. no internet connection).
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WebClientException As Exception = Nothing
    ''' <summary>
    ''' Corresponds to the "Success" key in the API json return, if present.
    ''' </summary>
    Public Property APISuccessResponse As Boolean = False
    ''' <summary>
    ''' The original json string returned by the API
    ''' </summary>
    Public Property APIReturnedJsonString As String = Nothing
    ''' <summary>
    ''' Generated list of Licence objects. Can contain one or many.
    ''' </summary>
    Public Property Licences As New List(Of License)

End Class
