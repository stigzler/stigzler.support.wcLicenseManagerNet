Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization.Json
Imports Newtonsoft.Json
Public Class LicenseManagerApiInterface

#Region "Properties"

    Private _licenseStatusMap As New Dictionary(Of Integer, String) From {{1, "sold"}, {2, "delivered"}, {3, "active"}, {4, "inactive"}}

    Private _licenseEndpointsMap As New Dictionary(Of LicenseRequestType, String) From {{LicenseRequestType.List, "/wp-json/lmfwc/v2/licenses/"},
                                                                                     {LicenseRequestType.Retrieve, "/wp-json/lmfwc/v2/licenses/"},
                                                                                     {LicenseRequestType.Activate, "/wp-json/lmfwc/v2/licenses/activate/"},
                                                                                     {LicenseRequestType.Deactivate, "/wp-json/lmfwc/v2/licenses/deactivate"},
                                                                                     {LicenseRequestType.Validate, "/wp-json/lmfwc/v2/licenses/validate/"},
                                                                                     {LicenseRequestType.Create, "/wp-json/lmfwc/v2/licenses"},
                                                                                     {LicenseRequestType.Update, "/wp-json/lmfwc/v2/licenses/"}
                                                                                     }

    Private _propertyToDatabaseMap As New Dictionary(Of Type, Dictionary(Of String, String)) From {
                            {GetType(License), New Dictionary(Of String, String) From {
                                {"LicenseKey", "license_key"},
                                {"ValidFor", "valid_for"},
                                {"OrderID", "order_id"},
                                {"ProductID", "product_id"},
                                {"ExpiresAt", "expires_at"},
                                {"TimesActivated", "times_activated"},
                                {"TimesActivatedMax", "times_activated_max"},
                                {"CreatedAt", "created_at"},
                                {"CreatedBy", "created_by"},
                                {"UpdatedAt", "updated_at"},
                                {"UpdatedBy", "updated_by"},
                                {"Source", "source"},
                                {"Status", "status"},
                                {"ID", "id"}
                            }}
                            }
    Public Property LicenseEndpointsMap() As Dictionary(Of LicenseRequestType, String)
        Get
            Return _licenseEndpointsMap
        End Get
        Set(ByVal value As Dictionary(Of LicenseRequestType, String))
            _licenseEndpointsMap = value
        End Set
    End Property

    Public Property LicenseStatusMap() As Dictionary(Of Integer, String)
        Get
            Return _licenseStatusMap
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _licenseStatusMap = value
        End Set
    End Property

    Public Property PropertyToDatabaseMap() As Dictionary(Of Type, Dictionary(Of String, String))
        Get
            Return _propertyToDatabaseMap
        End Get
        Set(ByVal value As Dictionary(Of Type, Dictionary(Of String, String)))
            _propertyToDatabaseMap = value
        End Set
    End Property


    Public Property WebClientTimeout As Integer

#End Region

    Private _baseSiteURL As String
    Private _consumerKey As String
    Private _consumerSecret As String

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
                wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType)), HttpMethod.Get)
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
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType), LicenseKey), HttpMethod.Get)
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





                    Dim serializeSettings = New JsonSerializerSettings With {
                            .NullValueHandling = NullValueHandling.Ignore,
                            .ContractResolver = New DynamicMappingResolver(_propertyToDatabaseMap)}

                    Dim requestBody As String = JsonConvert.SerializeObject(LicenseChanges, serializeSettings)

                    If LicenseChanges.Status IsNot Nothing Then
                        requestBody = StringOp.JsonReplaceKeyValue(requestBody, "status", _licenseStatusMap.ToDictionary(Function(x) x.Key.ToString, Function(y) y.Value))
                    End If

                    If RequestType = LicenseRequestType.Update Then
                        wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType), LicenseKey), HttpMethod.Put, requestBody)

                    ElseIf RequestType = LicenseRequestType.Create Then
                        wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType)), HttpMethod.Post, requestBody)

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



