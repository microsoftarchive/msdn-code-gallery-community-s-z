Imports System.Windows.Media.Media3D

Public Class CameraWindow
    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        group1.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), 0))
        group1.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Green), -2))

        group3.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Cyan), 0))
        group3.Children.Add(BuildTriangle(New DiffuseMaterial(Brushes.Green), -2))
    End Sub

    Private Function BuildTriangle(mat As Material, layer As Integer) As GeometryModel3D
        Dim group As New Model3DGroup()

        Dim m As New MeshGeometry3D()

        m.Positions.Add(New Point3D(-1, 0, layer))
        m.Positions.Add(New Point3D(0, 1, layer))
        m.Positions.Add(New Point3D(1, -1, layer))

        m.TriangleIndices.Add(0)
        m.TriangleIndices.Add(1)
        m.TriangleIndices.Add(2)

        Return New GeometryModel3D(m, mat) With { _
             .Transform = transform, _
             .BackMaterial = mat _
        }
    End Function

#Region "Bewegungen"

    Private mLastPos As Point
    Private transform As New Transform3DGroup()

    Private Sub Grid_MouseWheel(sender As Object, e As MouseWheelEventArgs)
        camera1.Position = New Point3D(camera1.Position.X, camera1.Position.Y, camera1.Position.Z - e.Delta / 250.0)
        camera3.Position = New Point3D(camera3.Position.X, camera3.Position.Y, camera3.Position.Z - e.Delta / 250.0)
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
