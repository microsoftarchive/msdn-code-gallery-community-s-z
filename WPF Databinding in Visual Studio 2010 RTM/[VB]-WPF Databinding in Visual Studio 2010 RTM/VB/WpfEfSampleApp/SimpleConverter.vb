Public Class SimpleConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, _
                            ByVal targetType As System.Type, _
                            ByVal parameter As Object, _
                            ByVal culture As System.Globalization.CultureInfo) As Object _
                            Implements System.Windows.Data.IValueConverter.Convert

        If parameter IsNot Nothing Then
            Return String.Format(culture, parameter.ToString(), value)
        End If

        Return value

    End Function

    Public Function ConvertBack(ByVal value As Object, _
                                ByVal targetType As System.Type, _
                                ByVal parameter As Object, _
                                ByVal culture As System.Globalization.CultureInfo) As Object _
                                Implements System.Windows.Data.IValueConverter.ConvertBack

        If targetType Is GetType(Date) OrElse targetType Is GetType(Nullable(Of Date)) Then
            If IsDate(value) Then
                Return CDate(value)
            ElseIf value.ToString() = "" Then
                Return Nothing
            Else
                Return Now() 'invalid type was entered so just give a default.
            End If

        ElseIf targetType Is GetType(Integer) OrElse targetType Is GetType(Nullable(Of Integer)) Then
            If IsNumeric(value) Then
                Return CInt(value)
            ElseIf value.ToString() = "" Then
                Return Nothing
            Else
                Return 0
            End If

        ElseIf targetType Is GetType(Decimal) OrElse targetType Is GetType(Nullable(Of Decimal)) Then
            If IsNumeric(value) Then
                Return CDec(value)
            ElseIf value.ToString() = "" Then
                Return Nothing
            Else
                Return 0
            End If
        End If

        Return value
    End Function
End Class
