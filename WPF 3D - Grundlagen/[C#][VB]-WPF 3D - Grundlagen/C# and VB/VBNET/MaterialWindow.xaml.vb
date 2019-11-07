Imports System.Windows.Media.Media3D

Public Class MaterialWindow
    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        group1.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), New DiffuseMaterial(Brushes.Green)))
        group2.Children.Add(BuildTriangle(New DiffuseMaterial(New LinearGradientBrush(Colors.Red, Colors.Yellow, 45)), Nothing))
        group3.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), New SpecularMaterial(Brushes.Blue, 0.2)))
        group4.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), New SpecularMaterial(Brushes.Blue, 0.8)))
        group5.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), New EmissiveMaterial(Brushes.Blue)))
        group6.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), New EmissiveMaterial(New LinearGradientBrush(Colors.Red, Colors.Yellow, 45))))
    End Sub

    Private Function BuildTriangle(mat As Material, mat2 As Material) As GeometryModel3D
        Dim group As New Model3DGroup()

        Dim m As New MeshGeometry3D()

        m.Positions.Add(New Point3D(-1, 0, 0))
        m.Positions.Add(New Point3D(0, 1, 0))
        m.Positions.Add(New Point3D(1, -1, 0))

        m.TriangleIndices.Add(0)
        m.TriangleIndices.Add(1)
        m.TriangleIndices.Add(2)

        m.TextureCoordinates.Add(New Point(0, 0))
        m.TextureCoordinates.Add(New Point(0, 1))
        m.TextureCoordinates.Add(New Point(1, 1))
        m.TextureCoordinates.Add(New Point(1, 0))

        Dim mg As New MaterialGroup()
        mg.Children.Add(mat)
        If mat2 IsNot Nothing Then
            mg.Children.Add(mat2)
        End If

        Return New GeometryModel3D(m, mg) With { _
             .Transform = transform, _
             .BackMaterial = mg _
        }
    End Function

#Region "Bewegungen"

    Private mLastPos As Point
    Private transform As New Transform3DGroup()

    Private Sub Grid_MouseWheel(sender As Object, e As MouseWheelEventArgs)
        camera1.Position = New Point3D(camera1.Position.X, camera1.Position.Y, camera1.Position.Z - e.Delta / 250.0)
        camera2.Position = New Point3D(camera2.Position.X, camera2.Position.Y, camera2.Position.Z - e.Delta / 250.0)
        camera3.Position = New Point3D(camera3.Position.X, camera3.Position.Y, camera3.Position.Z - e.Delta / 250.0)
        camera4.Position = New Point3D(camera4.Position.X, camera4.Position.Y, camera4.Position.Z - e.Delta / 250.0)
    End Sub

    Private Sub Grid_MouseMove(sender As Object, e As MouseEventArgs)
        If e.LeftButton = MouseButtonState.Pressed Then
            Dim pos As Point = Mouse.GetPosition(viewport1)
            Dim actualPos As New Point(pos.X - viewport1.ActualWidth / 2, viewport1.ActualHeight / 2 - pos.Y)
            Dim dx As Double = actualPos.X - mLastPos.X, dy As Double = actualPos.Y - mLastPos.Y

            Dim mouseAngle As Double = 0
            If dx <> 0 AndAlso dy <> 0 Then
                mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)))
                If dx < 0 AndAlso dy > 0 Then
                    mouseAngle += Math.PI / 2
                ElseIf dx < 0 AndAlso dy < 0 Then
                    mouseAngle += Math.PI
                ElseIf dx > 0 AndAlso dy < 0 Then
                    mouseAngle += Math.PI * 1.5
                End If
            ElseIf dx = 0 AndAlso dy <> 0 Then
                mouseAngle = If(Math.Sign(dy) > 0, Math.PI / 2, Math.PI * 1.5)
            ElseIf dx <> 0 AndAlso dy = 0 Then
                mouseAngle = If(Math.Sign(dx) > 0, 0, Math.PI)
            End If

            Dim axisAngle As Double = mouseAngle + Math.PI / 2

            Dim axis As New Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0)

            Dim rotation As Double = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2))

            Dim group As Transform3DGroup = transform
            Dim r As New QuaternionRotation3D(New Quaternion(axis, rotation * 180 / Math.PI))
            group.Children.Add(New RotateTransform3D(r))

            mLastPos = actualPos
        End If
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If e.LeftButton <> MouseButtonState.Pressed Then
            Return
        End If
        Dim pos As Point = Mouse.GetPosition(viewport1)
        mLastPos = New Point(pos.X - viewport1.ActualWidth / 2, viewport1.ActualHeight / 2 - pos.Y)
    End Sub

#End Region

End Class
