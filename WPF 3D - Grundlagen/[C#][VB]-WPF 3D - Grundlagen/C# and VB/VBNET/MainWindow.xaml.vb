Imports System.Windows.Media.Media3D

Class MainWindow
    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        DrawTriangle2()
    End Sub

    '? 1. Beispiel - Ein Dreieck zeichnen
    Private Sub DrawTriangle()
        Dim group As New Model3DGroup()

        Dim m As New MeshGeometry3D()

        m.Positions.Add(New Point3D(1, 0, 0))
        m.Positions.Add(New Point3D(0, 1, 0))
        m.Positions.Add(New Point3D(0, 0, 1))

        m.TriangleIndices.Add(0)
        m.TriangleIndices.Add(1)
        m.TriangleIndices.Add(2)

        group.Children.Add(New GeometryModel3D(m, New DiffuseMaterial(Brushes.Cyan)))

        group.Children.Add(New DirectionalLight(Colors.White, New Vector3D(0, 0, -1)))

        model.Content = group
    End Sub

    '? 2. Beispiel - Eine Methode zum erstellen eines Vierecks
    Private Function BuildQuadrilateral(p1 As Point3D, p2 As Point3D, p3 As Point3D, p4 As Point3D, material As Material) As GeometryModel3D
        Dim m As New MeshGeometry3D()

        m.Positions.Add(p1)
        m.Positions.Add(p2)
        m.Positions.Add(p3)
        m.Positions.Add(p4)

        m.TriangleIndices.Add(0)
        m.TriangleIndices.Add(1)
        m.TriangleIndices.Add(2)

        m.TriangleIndices.Add(2)
        m.TriangleIndices.Add(3)
        m.TriangleIndices.Add(0)

        Return New GeometryModel3D(m, material)
    End Function

    '? 2. Beispiel - Vierecke Zeichnen
    Private Sub DrawQuadrilateral()
        Dim group As New Model3DGroup()

        group.Children.Add(BuildQuadrilateral(New Point3D(0, 0, 0), New Point3D(0.5, 0, 0), New Point3D(0.5, 1, 0), New Point3D(0, 1, 0), New DiffuseMaterial(Brushes.Cyan)))

        group.Children.Add(BuildQuadrilateral(New Point3D(0, 0, -1), New Point3D(-1, 0, -1), New Point3D(-1, -1, 0), New Point3D(0, -1, 0), New DiffuseMaterial(Brushes.Cyan)))

        group.Children.Add(New DirectionalLight(Colors.White, New Vector3D(0, 0, -1)))

        model.Content = group
    End Sub

    '? 3. Beispiel - Ein Dreieck mit RadialGradientBrush zeichnen
    Private Sub DrawTriangle2()
        Dim group As New Model3DGroup()

        Dim m As New MeshGeometry3D()

        m.Positions.Add(New Point3D(1, 0, 0))
        m.Positions.Add(New Point3D(0, 1, 0))
        m.Positions.Add(New Point3D(0, 0, 1))

        m.TriangleIndices.Add(0)
        m.TriangleIndices.Add(1)
        m.TriangleIndices.Add(2)

        m.TextureCoordinates.Add(New Point(0, 0))
        m.TextureCoordinates.Add(New Point(1, 0))
        m.TextureCoordinates.Add(New Point(1, 1))
        m.TextureCoordinates.Add(New Point(0, 1))

        group.Children.Add(New GeometryModel3D(m, New DiffuseMaterial(New RadialGradientBrush(Colors.Green, Colors.Yellow))))

        group.Children.Add(New DirectionalLight(Colors.White, New Vector3D(0, 0, -1)))

        model.Content = group
    End Sub


    '? Lights
    Private Sub ShowLights(sender As Object, e As RoutedEventArgs)
        Me.Visibility = System.Windows.Visibility.Hidden
        Dim wnd As New LightsWindow()
        wnd.ShowDialog()
        Me.Visibility = System.Windows.Visibility.Visible
    End Sub

    '? Materials
    Private Sub ShowMaterials(sender As Object, e As RoutedEventArgs)
        Me.Visibility = System.Windows.Visibility.Hidden
        Dim wnd As New MaterialWindow()
        wnd.ShowDialog()
        Me.Visibility = System.Windows.Visibility.Visible
    End Sub

    '? Cameras
    Private Sub ShowCameras(sender As Object, e As RoutedEventArgs)
        Me.Visibility = System.Windows.Visibility.Hidden
        Dim wnd As New CameraWindow()
        wnd.ShowDialog()
        Me.Visibility = System.Windows.Visibility.Visible
    End Sub

End Class
