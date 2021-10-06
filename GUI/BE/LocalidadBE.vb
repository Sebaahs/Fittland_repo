Public Class LocalidadBE
    Inherits ID

    Public Property nombre_Localidad As String
    Public Property provincia As ProvinciaBE

    Public Overrides Function ToString() As String
        Return Me.Id
    End Function


End Class