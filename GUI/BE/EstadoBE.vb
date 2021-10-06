Public Class EstadoBE

    Inherits ID

    Public Property estado As String

    Public Overrides Function ToString() As String
        Return Me.Id
    End Function
End Class
