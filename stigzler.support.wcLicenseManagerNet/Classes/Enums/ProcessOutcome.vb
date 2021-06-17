''' <summary>
''' The outcome of the API Interface process
''' </summary>
Public Enum ProcessOutcome
    ''' <summary>
    ''' Result returned from API successfully
    ''' </summary>
    Success
    ''' <summary>
    ''' The API request process requires a License object to be passed to it. Both Update and Create License require this.
    ''' </summary>
    LicenceObjectRequiredError
    ''' <summary>
    ''' The API request process requires a License key to be passed to it. Retrieve, Update, Activate, Deactivate and Validate License require this.
    ''' </summary>
    LicenseKeyNotPassedError
    ''' <summary>
    ''' The API request process requires a Generator object to be passed to it. Both Update and Create License require this.
    ''' </summary>
    GeneratorObjectRequiredError
    ''' <summary>
    ''' The API request process requires a Generator ID to be passed to it. Retrieve and Update require this.
    ''' </summary>
    GeneratorIdNotPassedError
    ''' <summary>
    ''' The json string passed for additional parameters could not be parsed
    ''' </summary>
    AdditionalParametersJsonNonParsable
    ''' <summary>
    ''' API request resulted in a WebClient Error. View this and the returned json string to discern causes.
    ''' </summary>
    ''' <remarks>A WebClientError can be thrown by the API (e.g. Retrieve License where the License Key doesn't exist) or by a http error (not connected to internet etc).</remarks>
    WebClientError
    ''' <summary>
    ''' Outcome unclear (blame coder!)
    ''' </summary>
    Indeterminate

End Enum
