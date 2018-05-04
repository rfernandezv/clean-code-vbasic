Public Class Speaker
    Public FirstName As String
    Public LastName As String
    Public Email As String
    Public Experience As Integer
    Public HasBlog As Boolean
    Public BlogURL As String
    Public Browser As WebBrowser
    Public Certifications As List(Of String)
    Public Employer As String
    Public RegistrationFee As Integer
    Public Sessions As List(Of Session)

    Function Register(repository As IRepository) As Integer
        Dim speakerId As Integer

        validateDataRegister()

        RegistrationFee = assigRegistrationFee(Experience)

        speakerId = repository.SaveSpeaker(Me)

        Return speakerId
    End Function



    Public Sub validateDataRegister()
        Dim haveStandard As Boolean
        Dim isApproved As Boolean = False
        Dim minimumExperience As Integer = 10
        Dim minimumCertification As Integer = 3
        Dim maximumVersionWebBrowser As Integer = 9

        If String.IsNullOrEmpty(FirstName) Then
            Throw New Exception("First Name is required")
        End If
        If String.IsNullOrEmpty(LastName) Then
            Throw New Exception("Last Name is required")
        End If
        If String.IsNullOrEmpty(Email) Then
            Throw New Exception("Email is required")
        End If
        If (Sessions.Count = 0) Then
            Throw New Exception("Can't register speaker with no sessions to present.")
        End If

        haveStandard = ((Experience > minimumExperience Or HasBlog Or Certifications.Count() > minimumCertification Or Company.companies.Contains(Employer)))
        If Not haveStandard Then
            Dim splitArray() = Strings.Split(Email, "@")
            Dim emailDomain = splitArray(1)
            haveStandard = (Not Domain.domains.Contains(emailDomain) And (Not (Browser.Name = WebBrowser.BrowserName.InternetExplorer And Browser.MajorVersion < maximumVersionWebBrowser)))
        End If
        If Not haveStandard Then
            Throw New HandlerException("Speaker doesn't meet our abitrary and capricious standards.")
        End If
        For Each session As Session In Sessions
            validateApprovedSession(session)
            If session.isApproved Then
                isApproved = True
            End If
        Next

        If Not isApproved Then
            Throw New HandlerException("No sessions approved.")
        End If

    End Sub

    Public Sub validateApprovedSession(session As Session)
        session.isApproved = True

        For Each tech As String In Technology.technologies
            If (session.title.Contains(tech) Or session.Description.Contains(tech)) Then
                session.isApproved = False
                Exit For
            End If
        Next
    End Sub

    Public Function assigRegistrationFee(experienceParameter As Integer) As Integer
        If experienceParameter <= 1 Then
            Return 500
        End If
        If experienceParameter >= 2 And experienceParameter <= 3 Then
            Return 250
        End If
        If experienceParameter >= 4 And experienceParameter <= 5 Then
            Return 100
        End If
        If (experienceParameter >= 6 And experienceParameter <= 9) Then
            Return 50
        End If

        Return 0
    End Function

    Public Sub New(ByVal FirstName As String)
        Me.FirstName = FirstName
    End Sub

    Public Sub New(ByVal FirstName As String,
                 ByVal LastName As String,
                 ByVal Email As String,
                 ByVal Employer As String,
                 ByVal HasBlog As Boolean,
                 ByVal Browser As WebBrowser,
                 ByVal Exp As Integer,
                 ByVal Certifications As List(Of String),
                 ByVal BlogURL As String,
                 ByVal Sessions As List(Of Session))
        Me.FirstName = FirstName
        Me.LastName = LastName
        Me.Email = Email
        Me.Experience = Exp
        Me.HasBlog = HasBlog
        Me.BlogURL = BlogURL
        Me.Browser = Browser
        Me.Certifications = Certifications
        Me.Employer = Employer
        Me.Sessions = Sessions
    End Sub

    Public Property _FirstName() As String
        Get
            Return Me.FirstName
        End Get
        Set(ByVal Value As String)
            Me.FirstName = Value
        End Set
    End Property

    Public Property _LastName() As String
        Get
            Return Me.LastName
        End Get
        Set(ByVal Value As String)
            Me.LastName = Value
        End Set
    End Property

    Public Property _Email() As String
        Get
            Return Me.Email
        End Get
        Set(ByVal Value As String)
            Me.Email = Value
        End Set
    End Property

    Public Property _Exp() As Integer
        Get
            Return Me.Experience
        End Get
        Set(ByVal Value As Integer)
            Me.Experience = Value
        End Set
    End Property

    Public Property _HasBlog() As Boolean
        Get
            Return Me.HasBlog
        End Get
        Set(ByVal Value As Boolean)
            Me.HasBlog = Value
        End Set
    End Property

    Public Property _BlogURL() As String
        Get
            Return Me.BlogURL
        End Get
        Set(ByVal Value As String)
            Me.BlogURL = Value
        End Set
    End Property

    Public Property _Browser() As WebBrowser
        Get
            Return Me.Browser
        End Get
        Set(ByVal Value As WebBrowser)
            Me.Browser = Value
        End Set
    End Property

    Public Property _Certifications() As List(Of String)
        Get
            Return Me.Certifications
        End Get
        Set(ByVal Value As List(Of String))
            Me.Certifications = Value
        End Set
    End Property

    Public Property _Employer() As String
        Get
            Return Me.Employer
        End Get
        Set(ByVal Value As String)
            Me.Employer = Value
        End Set
    End Property

    Public Property _RegistrationFee() As Integer
        Get
            Return Me.RegistrationFee
        End Get
        Set(ByVal Value As Integer)
            Me.RegistrationFee = Value
        End Set
    End Property

    Public Property _Sessions() As List(Of Session)
        Get
            Return Me.Sessions
        End Get
        Set(ByVal Value As List(Of Session))
            Me.Sessions = Value
        End Set
    End Property



End Class
