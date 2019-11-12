@ModelType DateTime?
@Code

    Dim dx? As Date
    dx = Model
    Dim dt As Date = Date.Now
    If dx IsNot Nothing Then
        dt = CDate(Model)

    End If

End Code
@String.Format("{0:d}", dt.Date)
