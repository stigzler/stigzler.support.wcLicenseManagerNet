Imports System.ComponentModel

''' <summary>
''' An object representing the License Manager license
''' </summary>
Public Class License
    Public Property ID As Int64?
    Public Property OrderID As Int64?
    Public Property ProductID As Int64?
    Public Property LicenseKey As String
    Public Property ExpiresAt As DateTime?
    Public Property ValidFor As Int32?
    Public Property Source As String

    ''' <summary>
    ''' Integer representation of the status. See LicenceManagerApiInterface.LicenseStatusMap for mappings of the integer to status type.
    ''' </summary>
    ''' <value>1</value>
    <Description("(1) Sold  (2) Delivered  (3) Active  (4) Inactive")>
    Public Property Status As LicenseStatus
    Public Property TimesActivated As Integer?
    Public Property TimesActivatedMax As Integer?

    ''' <summary>
    ''' NOTE: only returned with the Validate request. Null otherwise.
    ''' </summary>
    <Description("Only populated during the License Validate request")>
    Public Property RemainingActivations As Integer?
    Public Property CreatedAt As DateTime?
    Public Property CreatedBy As Int64?
    Public Property UpdatedAt As DateTime?
    Public Property UpdatedBy As Int64?

    Public Overrides Function ToString() As String
        Return "Key: " & LicenseKey & " | Status: " & Status.ToString & " | Activation Count: " & TimesActivated & "/" & TimesActivatedMax & " | Expires: " & ExpiresAt
    End Function

End Class
