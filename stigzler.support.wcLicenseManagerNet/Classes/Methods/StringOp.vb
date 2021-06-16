Imports Newtonsoft.Json.Linq

Public Class StringOp

    Public Shared Function UrlCombine(ByVal baseUrl As String, ParamArray segments As String()) As String
        Return String.Join("/", {baseUrl.TrimEnd("/"c)}.Concat(segments.[Select](Function(s) s.Trim("/"c))))
    End Function

    Public Shared Function JsonReplaceKeyValue(json As String, key As String, values As Dictionary(Of String, String)) As String

        Dim jobj As JObject = JObject.Parse(json)

        Dim presentValue = jobj(key).ToString

        If values.ContainsKey(presentValue) Then
            jobj(key) = values(presentValue)
        End If

        Return jobj.ToString

    End Function
End Class
