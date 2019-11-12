Imports System.Windows
Imports System.Windows.Media

Namespace WpfSampleVB
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Friend Sub SetColor(ByVal color As Color)
            mainText.Background = New SolidColorBrush(color)
        End Sub

        Private Sub OnWindowLoaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
            DirectCast(Application.Current, App).CreateJumpList()
        End Sub
    End Class
End Namespace
