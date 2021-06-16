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
    <Description("(1) Sold  (2) Delivered  (3) Active  (4) Inactive")>
    Public Property Status As Integer?
    Public Property TimesActivated As Integer?
    Public Property TimesActivatedMax As Integer?

    <Description("Only populated during the License Validate request")>
    Public Property RemainingActivations As Integer?
    Public Property CreatedAt As DateTime?
    Public Property CreatedBy As Int64?
    Public Property UpdatedAt As DateTime?
    Public Property UpdatedBy As Int64?

End Class
