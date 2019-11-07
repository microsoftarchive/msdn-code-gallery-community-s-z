using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace CSharp
{
    /// <summary>
    /// Interaktionslogik für LightsWindow.xaml
    /// </summary>
    public partial class LightsWindow : Window
    {
        public LightsWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            group1.Children.Add(BuildTriangle());
            group2.Children.Add(BuildTriangle());
            group3.Children.Add(BuildTriangle());
            group4.Children.Add(BuildTriangle());
        }

        GeometryModel3D BuildTriangle()
        {
            Model3DGroup group = new Model3DGroup();

            MeshGeometry3D m = new MeshGeometry3D();

            m.Positions.Add(new Point3D(-1, 0, 0));
            m.Positions.Add(new Point3D(0, 1, 0));
            m.Positions.Add(new Point3D(1, -1, 0));

            m.TriangleIndices.Add(0);
            m.TriangleIndices.Add(1);
            m.TriangleIndices.Add(2);

            return new GeometryModel3D(m, new DiffuseMaterial(Brushes.Cyan)) { Transform = transform, BackMaterial = new DiffuseMaterial(Brushes.Cyan), };
        }

        #region Bewegungen

        private Point mLastPos;
        Transform3DGroup transform = new Transform3DGroup();
        
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            camera1.Position = new Point3D(camera1.Position.X, camera1.Position.Y, camera1.Position.Z - e.Delta / 250D);
            camera2.Position = new Point3D(camera2.Position.X, camera2.Position.Y, camera2.Position.Z - e.Delta / 250D);
            camera3.Position = new Point3D(camera3.Position.X, camera3.Position.Y, camera3.Position.Z - e.Delta / 250D);
            camera4.Position = new Point3D(camera4.Position.X, camera4.Position.Y, camera4.Position.Z - e.Delta / 250D);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pos = Mouse.GetPosition(viewport1);
                Point actualPos = new Point(pos.X - viewport1.ActualWidth / 2, viewport1.ActualHeight / 2 - pos.Y);
                double dx = actualPos.X - mLastPos.X, dy = actualPos.Y - mLastPos.Y;

                double mouseAngle = 0;
                if (dx != 0 && dy != 0)
                {
                    mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
                    if (dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
                    else if (dx < 0 && dy < 0) mouseAngle += Math.PI;
                    else if (dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
                }
                else if (dx == 0 && dy != 0) mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
                else if (dx != 0 && dy == 0) mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;

                double axisAngle = mouseAngle + Math.PI / 2;

                Vector3D axis = new Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0);

                double rotation = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                Transform3DGroup group = transform;
                QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(axis, rotation * 180 / Math.PI));
                group.Children.Add(new RotateTransform3D(r));

                mLastPos = actualPos;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            Point pos = Mouse.GetPosition(viewport1);
            mLastPos = new Point(pos.X - viewport1.ActualWidth / 2, viewport1.ActualHeight / 2 - pos.Y);
        }

        #endregion
    }
}
