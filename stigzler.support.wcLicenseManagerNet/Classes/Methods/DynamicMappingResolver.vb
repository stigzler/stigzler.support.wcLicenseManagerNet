Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Class DynamicMappingResolver
    Inherits DefaultContractResolver

    Private memberNameToJsonNameMap As Dictionary(Of Type, Dictionary(Of String, String))

    Public Sub New(ByVal memberNameToJsonNameMap As Dictionary(Of Type, Dictionary(Of String, String)))
        Me.memberNameToJsonNameMap = memberNameToJsonNameMap
    End Sub

    Protected Overrides Function CreateProperty(ByVal member As MemberInfo, ByVal memberSerialization As MemberSerialization) As JsonProperty
        Dim prop As JsonProperty = MyBase.CreateProperty(member, memberSerialization)
        Dim dict As Dictionary(Of String, String)
        Dim jsonName As String

        If memberNameToJsonNameMap.TryGetValue(member.DeclaringType, dict) AndAlso dict.TryGetValue(member.Name, jsonName) Then
            prop.PropertyName = jsonName
        End If

        Return prop
    End Function

End Class
