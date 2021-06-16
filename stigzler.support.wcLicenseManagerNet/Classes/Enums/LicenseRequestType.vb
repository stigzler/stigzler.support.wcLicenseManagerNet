''' <summary>
''' The Type of License request to use
''' </summary>
Public Enum LicenseRequestType
    ''' <summary>
    ''' No requirements
    ''' </summary>
    List
    ''' <summary>
    ''' Requires License Key
    ''' </summary>
    Retrieve
    ''' <summary>
    ''' Requires License
    ''' </summary>
    Create
    ''' <summary>
    ''' Requires License Key and License
    ''' </summary>
    Update
    ''' <summary>
    ''' Requires License Key
    ''' </summary>
    Activate
    ''' <summary>
    ''' Requires License Key
    ''' </summary>
    Deactivate
    ''' <summary>
    ''' Requires License Key
    ''' </summary>
    Validate
End Enum
