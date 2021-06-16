Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization.Json
Imports Newtonsoft.Json
''' <summary>
''' The main method for making requests of the License Manager API. The base URL (e.g. https://mysite.com) and API Keys must be provided at instantiation.
''' </summary>
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

    Private _licensePropertyToDatabaseMap As New Dictionary(Of Type, Dictionary(Of String, String)) From {
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
    ''' <summary>
    ''' A dictionary containing the relevant url segments to add to the base url to make the resource path.
    ''' </summary>
    ''' <remarks>Allows editing to accommodate future changes to the API</remarks>
    Public Property LicenseEndpointsMap() As Dictionary(Of LicenseRequestType, String)
        Get
            Return _licenseEndpointsMap
        End Get
        Set(ByVal value As Dictionary(Of LicenseRequestType, String))
            _licenseEndpointsMap = value
        End Set
    End Property

    ''' <summary>
    ''' Maps the various License status to its Integer representation.
    ''' </summary>
    ''' <remarks>Allows editing to accommodate future changes to the API</remarks>
    Public Property LicenseStatusMap() As Dictionary(Of Integer, String)
        Get
            Return _licenseStatusMap
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _licenseStatusMap = value
        End Set
    End Property

    ''' <summary>
    ''' Maps the License property names to the License Manager internal databse field names.
    ''' </summary>
    ''' <remarks>Used in Update and Create routines. Allows editing to accommodate future changes to the API</remarks>
    Public Property LicensePropertyToDatabaseMap() As Dictionary(Of Type, Dictionary(Of String, String))
        Get
            Return _licensePropertyToDatabaseMap
        End Get
        Set(ByVal value As Dictionary(Of Type, Dictionary(Of String, String)))
            _licensePropertyToDatabaseMap = value
        End Set
    End Property


    ''' <summary>
    ''' (Optional) Sets the timeout for the http request (in ms). Default = 100s
    ''' </summary>
    Public Property WebClientTimeout As Integer = 100000

#End Region

    Private _baseSiteURL As String
    Private _consumerKey As String
    Private _consumerSecret As String

    ''' <param name="BaseSiteURL">The base URL (e.g. https://MySite.com)</param>
    ''' <param name="ConsumerKey">The Consumer Key of the API (gained in plugin settings)</param>
    ''' <param name="ConsumerSecret">The Consumer Secret of the API (gained in plugin settings)</param>
    Public Sub New(BaseSiteURL As String, ConsumerKey As String, ConsumerSecret As String)

        _baseSiteURL = BaseSiteURL
        _consumerKey = ConsumerKey
        _consumerSecret = ConsumerSecret

    End Sub

    ''' <summary>
    ''' This makes License Requests of the API. Depending on the Request type, you will need to provide different parameters. Null properties are ignored in Update.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <param name="RequestType">The type of License Request you wish to make</param>
    ''' <param name="LicenseKey">The License Key of the Licence (required for Retrieve, Update, Activate, Deactivate and Validate)</param>
    ''' <param name="License">A License object used in Update and Create</param>
    ''' <returns>LicenseRequestOutcome object</returns>
    Public Function LicenseRequest(RequestType As LicenseRequestType, Optional LicenseKey As String = Nothing, Optional License As License = Nothing) As LicenseRequestOutcome

        Dim wcp As New WebClientProcessor(_consumerKey, _consumerSecret)
        wcp.WebClientTimeout = WebClientTimeout

        Dim wcr As New WebClientResponse
        Dim lro As New LicenseRequestOutcome

        Dim mappingSettings = New JsonSerializerSettings With {
                            .NullValueHandling = NullValueHandling.Ignore,
                            .ContractResolver = New DynamicMappingResolver(_propertyToDatabaseMap)}

        Select Case RequestType

            Case LicenseRequestType.List
                wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType)), HttpMethod.Get)
                If wcr.Success Then
                    Dim lr As New LicenseResponseCollection
                    lr = JsonConvert.DeserializeObject(Of LicenseResponseCollection)(wcr.ReturnedString)
                    With lro
                        .ProcessOutcome = ProcessOutcome.Success
                        .APIJsonString = wcr.ReturnedString
                        .APIReturnedSuccess = lr.Success
                        .Licences = lr.Data
                    End With
                Else
                    With lro
                        .ProcessOutcome = ProcessOutcome.WebClientError
                        .WebClientException = wcr.Exception
                    End With
                End If

            Case LicenseRequestType.Retrieve, LicenseRequestType.Activate, LicenseRequestType.Deactivate, LicenseRequestType.Validate ' requires License
                If LicenseKey = "" OrElse LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                Else
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType), LicenseKey), HttpMethod.Get)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

            Case LicenseRequestType.Update ' requires Key and License
                If LicenseKey = "" OrElse LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                ElseIf License Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenceObjectRequiredError
                Else
                    Dim requestBody As String = JsonConvert.SerializeObject(License, mappingSettings) ' converts Porperty names to db names in json
                    requestBody = StringOp.JsonReplaceKeyValue(requestBody, "status", _licenseStatusMap.ToDictionary(Function(x) x.Key.ToString, Function(y) y.Value)) ' replaces Status Enum int With text (required by db)
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType), LicenseKey), HttpMethod.Put, requestBody)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

            Case LicenseRequestType.Create ' requires License
                If License Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenceObjectRequiredError
                Else
                    Dim requestBody As String = JsonConvert.SerializeObject(License, mappingSettings) ' converts Porperty names to db names in json
                    requestBody = StringOp.JsonReplaceKeyValue(requestBody, "status", _licenseStatusMap.ToDictionary(Function(x) x.Key.ToString, Function(y) y.Value)) ' replaces Status enum int with text (required by db)
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(RequestType)), HttpMethod.Post, requestBody)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

        End Select


        Return lro

    End Function

    Private Function ProcessLicenseWebClientResponse(wcr As WebClientResponse) As LicenseRequestOutcome

        Dim lro As New LicenseRequestOutcome

        If wcr.Success Then
            Dim lr As New LicenseResponseSingle
            lr = JsonConvert.DeserializeObject(Of LicenseResponseSingle)(wcr.ReturnedString)
            With lro
                .ProcessOutcome = ProcessOutcome.Success
                .APIJsonString = wcr.ReturnedString
                .APIReturnedSuccess = lr.Success
                .Licences = New List(Of License) From {lr.Data}
            End With
        Else
            With lro
                .ProcessOutcome = ProcessOutcome.WebClientError
                .APIJsonString = wcr.ReturnedString
                .WebClientException = wcr.Exception
            End With
        End If

        Return lro

    End Function

    Public Function GeneratorRequest(requestType As GeneratorRequestType, Optional generatorID As String = Nothing, Optional generastor As Generator = Nothing) As GeneratorRequestOutcome

        Dim wcp As New WebClientProcessor(_consumerKey, _consumerSecret)
        wcp.WebClientTimeout = WebClientTimeout

        Dim wcr As New WebClientResponse
        Dim gro As New GeneratorRequestOutcome

        Dim mappingSettings = New JsonSerializerSettings With {
                            .NullValueHandling = NullValueHandling.Ignore,
                            .ContractResolver = New DynamicMappingResolver(_propertyToDatabaseMap)}

        Select Case requestType

            Case LicenseRequestType.List
                wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(requestType)), HttpMethod.Get)
                If wcr.Success Then
                    Dim lr As New LicenseResponseCollection
                    lr = JsonConvert.DeserializeObject(Of LicenseResponseCollection)(wcr.ReturnedString)
                    With gro
                        .ProcessOutcome = ProcessOutcome.Success
                        .APIJsonString = wcr.ReturnedString
                        .APIReturnedSuccess = lr.Success
                        .Licences = lr.Data
                    End With
                Else
                    With lro
                        .ProcessOutcome = ProcessOutcome.WebClientError
                        .WebClientException = wcr.Exception
                    End With
                End If

            Case LicenseRequestType.Retrieve, LicenseRequestType.Activate, LicenseRequestType.Deactivate, LicenseRequestType.Validate ' requires License
                If LicenseKey = "" OrElse LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                Else
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(requestType), LicenseKey), HttpMethod.Get)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

            Case LicenseRequestType.Update ' requires Key and License
                If LicenseKey = "" OrElse LicenseKey Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenseKeyNotPassedError
                ElseIf License Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenceObjectRequiredError
                Else
                    Dim requestBody As String = JsonConvert.SerializeObject(License, mappingSettings) ' converts Porperty names to db names in json
                    requestBody = StringOp.JsonReplaceKeyValue(requestBody, "status", _licenseStatusMap.ToDictionary(Function(x) x.Key.ToString, Function(y) y.Value)) ' replaces Status Enum int With text (required by db)
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(requestType), LicenseKey), HttpMethod.Put, requestBody)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

            Case LicenseRequestType.Create ' requires License
                If License Is Nothing Then
                    lro.ProcessOutcome = ProcessOutcome.LicenceObjectRequiredError
                Else
                    Dim requestBody As String = JsonConvert.SerializeObject(License, mappingSettings) ' converts Porperty names to db names in json
                    requestBody = StringOp.JsonReplaceKeyValue(requestBody, "status", _licenseStatusMap.ToDictionary(Function(x) x.Key.ToString, Function(y) y.Value)) ' replaces Status enum int with text (required by db)
                    wcr = wcp.HttpAction(StringOp.UrlCombine(_baseSiteURL, _licenseEndpointsMap(requestType)), HttpMethod.Post, requestBody)
                    lro = ProcessLicenseWebClientResponse(wcr)
                End If

        End Select


        Return lro

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



