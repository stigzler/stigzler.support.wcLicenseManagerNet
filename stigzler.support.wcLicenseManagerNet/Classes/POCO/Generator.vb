''' <summary>
''' An object representing the License Manager generator
''' </summary>
Public Class Generator
    Public Property ID As Int64?
    Public Property Name As String
    Public Property Charset As String
    Public Property Chunks As Integer?
    Public Property ChunkLength As Integer?
    Public Property TimesActivatedMax As Integer?
    Public Property Separator As String
    Public Property Prefix As String
    Public Property Suffix As String
    Public Property ExpiresIn As Integer?
    Public Property CreatedAt As DateTime?
    Public Property CreatedBy As Int64?
    Public Property UpdatedAt As DateTime?
    Public Property UpdatedBy As Int64?

End Class
