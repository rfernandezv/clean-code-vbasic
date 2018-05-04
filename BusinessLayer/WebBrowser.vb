Public Class WebBrowser
    Public Name As BrowserName
    Public MajorVersion As Integer

    Public Sub New(ByVal browser As BrowserName,
                 ByVal MajorVersion As Integer)
        Me.Name = browser
        Me.MajorVersion = MajorVersion
    End Sub

    Public Enum BrowserName
        Unknown
        InternetExplorer
        Firefox
        Chrome
        Opera
        Safari
        Dolphin
        Konqueror
        Linx
    End Enum
End Class
