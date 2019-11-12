@ModelType DateTime?

@Code

    Dim dx? As Date
    dx = Model
    Dim dt As Date = Date.Now
    If dx IsNot Nothing Then
        dt = CDate(Model)

    End If

End Code



@Html.TextBox("", String.Format("{0:d}", dt.ToShortDateString()),
                   New With {.class = "datefield", .type = "date"})

                   