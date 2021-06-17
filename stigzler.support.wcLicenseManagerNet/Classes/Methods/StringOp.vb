Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Schema

Class StringOp

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

    Public Shared Function JsonMerge(json1 As String, json2 As String, mergeMethod As JsonMergeSettings) As String

        Dim jobj1 = JObject.Parse(json1)
        Dim jobj2 = JObject.Parse(json2)

        jobj1.Merge(jobj2, mergeMethod)

        Return jobj1.ToString

    End Function

    Public Shared Function JsonIsParsable(json As String) As Boolean

        Try
            Dim jobj As JObject = JObject.Parse(json)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


End Class
