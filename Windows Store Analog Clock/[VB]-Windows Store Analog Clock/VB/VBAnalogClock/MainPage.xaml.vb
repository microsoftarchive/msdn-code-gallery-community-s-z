' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Dim timer As New DispatcherTimer


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        timer.Interval = TimeSpan.FromSeconds(1)
        AddHandler timer.Tick, AddressOf Timer_Tick

        timer.Start()
    End Sub

    Public Sub Timer_Tick(sender As Object, e As EventArgs)
        secondHand.Angle = DateTime.Now.Second * 6
        minuteHand.Angle = DateTime.Now.Minute * 6
        hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5)
    End Sub

End Class
