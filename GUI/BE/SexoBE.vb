Public Class SexoBE

    Inherits ID

    Public Property sexo As String

    Public Overrides Function ToString() As String
        Return Me.Id
    End Function
End Class
