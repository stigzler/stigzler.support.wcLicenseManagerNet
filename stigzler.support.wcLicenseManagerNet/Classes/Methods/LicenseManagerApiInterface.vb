Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization.Json
Imports Newtonsoft.Json
Public Class LicenseManagerApiInterface

#Region "Properties"
    Private _baseSiteURL As String
    Private _consumerKey As String
    Private _consumerSecret As String


    Public Property WebClientTimeout As Integer

    Private _licenseEndpoints As New Dictionary(Of LicenseRequestType, String) From {{LicenseRequestType.List, "/wp-json/lmfwc/v2/licenses/"},
                                                                                     {LicenseRequestType.Retrieve, "/wp-json/lmfwc/v2/licenses/"},
                                                                                     {LicenseRequestType.Activate, "/wp-json/lmfwc/v2/licenses/activate/"},
                                                                                     {LicenseRequestType.Deactivate, "/wp-json/lmfwc/v2/licenses/deactivate"},
                                                                                     {LicenseRequestType.Validate, "/wp-json/lmfwc/v2/licenses/validate/"},
                                                                                     {LicenseRequestType.Create, "/wp-json/lmfwc/v2/licenses"},
                                                                                     {LicenseRequestType.Update, "/wp-json/lmfwc/v2/licenses/"}
                                                                                     }
    Public Property LicenseEndpoints() As Dictionary(Of LicenseRequestType, String)
        Get
            Return _licenseEndpoints
        End Get
        Set(ByVal value As Dictionary(Of LicenseRequestType, String))
            _licenseEndpoints = value
        End Set
    End Property



#End Region
    Public Sub New(BaseSiteURL As String, ConsumerKey As String, ConsumerSecret As String)

        _baseSiteURL = BaseSiteURL
        _consumerKey = ConsumerKey
        _consumerSecret = ConsumerSecret

    End Sub

    Public Function LicenseRequest(RequestType As LicenseRequestType, Optional LicenseKey As String = Nothing, Optional LicenseChanges As License = Nothing) As LicenseRequestOutcome

        Dim wcp As New WebClientProcessor(_consumerKey, _consumerSecret)
        wcp.WebClientTimeout = WebClientTimeout

        Dim wcr As New WebClientResponse
        Dim lro As New LicenseRequestOutcome

        Select Case RequestType

            Case LicenseRequestType.List
                wcr = wcp.HttpAction(UrlCombine(_baseSiteURL, _licenseEndpoints(RequestType)), HttpMethod.Get)
                If wcr.Success Then
                    Dim lr As New LicenseResponseCollection
                    lr = JsonConvert.DeserializeObject(Of LicenseResponseCollection)(wcr.ReturnedString)
                    With lro
                        .ProcessOutcome = ProcessOutcome.Success
                        .APIReturnedJsonString = wcr.ReturnedString
                        .APISuccessResponse = lr.Success
                        .Licences = lr.Data
                    End With
                Else
                    With lro
                        .ProcessOutcome = ProcessOutcome.WebClientError
                        .WebClientException = wcr.Exception
                    End With
                End If

            Case LicenseRequestType.Retrieve, LicenseRequestType.Activate, LicenseRequestType.Deactivate, LicenseRequestType.Validate
                If LicenseKey = "" OrElse LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                Else
                    wcr = wcp.HttpAction(UrlCombine(_baseSiteURL, _licenseEndpoints(RequestType), LicenseKey), HttpMethod.Get)
                    If wcr.Success Then
                        Dim lr As New LicenseResponseSingle
                        lr = JsonConvert.DeserializeObject(Of LicenseResponseSingle)(wcr.ReturnedString)
                        With lro
                            .ProcessOutcome = ProcessOutcome.Success
                            .APIReturnedJsonString = wcr.ReturnedString
                            .APISuccessResponse = lr.Success
                            .Licences = New List(Of License) From {lr.Data}
                        End With
                    Else
                        With lro
                            .ProcessOutcome = ProcessOutcome.WebClientError
                            .WebClientException = wcr.Exception
                        End With
                    End If
                End If

            Case LicenseRequestType.Update, LicenseRequestType.Create
                If LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                ElseIf LicenseChanges Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenceObjectRequiredError
                Else
                    Dim requestBody As String = JsonConvert.SerializeObject(LicenseChanges, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})

                    If RequestType = LicenseRequestType.Update Then
                        wcr = wcp.HttpAction(UrlCombine(_baseSiteURL, _licenseEndpoints(RequestType), LicenseKey), HttpMethod.Put, requestBody)
                    ElseIf RequestType = LicenseRequestType.Create Then
                        wcr = wcp.HttpAction(UrlCombine(_baseSiteURL, _licenseEndpoints(RequestType)), HttpMethod.Post, requestBody)
                    End If

                    If wcr.Success Then
                        Dim lr As New LicenseResponseSingle
                        lr = JsonConvert.DeserializeObject(Of LicenseResponseSingle)(wcr.ReturnedString)
                        With lro
                            .ProcessOutcome = ProcessOutcome.Success
                            .APIReturnedJsonString = wcr.ReturnedString
                            .APISuccessResponse = lr.Success
                            .Licences = New List(Of License) From {lr.Data}
                        End With
                    Else
                        With lro
                            .ProcessOutcome = ProcessOutcome.WebClientError
                            .APIReturnedJsonString = wcr.ReturnedString
                            .WebClientException = wcr.Exception
                        End With
                    End If
                End If
                Dim userLicense As New License With {.LicenseKey = "D780F-CD87E"}
        End Select


        Return lro

    End Function

    Public Function GeneratorRequest() As GeneratorRequestOutcome



    End Function

    Public Function UrlCombine(ByVal baseUrl As String, ParamArray segments As String()) As String
        Return String.Join("/", {baseUrl.TrimEnd("/"c)}.Concat(segments.[Select](Function(s) s.Trim("/"c))))
    End Function


    Private Class LicenseResponseSingle

        <JsonProperty("success")>
        Public Property Success As Boolean = False

        <JsonProperty("data")>
        Public Property Data As License

    End Class
    Private Class LicenseResponseCollection

        <JsonProperty("success")>
        Public Property Success As Boolean = False

        <JsonProperty("data")>
        Public Property Data As IList(Of License)

    End Class


End Class



