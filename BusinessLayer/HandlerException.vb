Public Class HandlerException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal format As String, ByVal param As List(Of String))
        MyBase.New(String.Format(format, param))
    End Sub
End Class
