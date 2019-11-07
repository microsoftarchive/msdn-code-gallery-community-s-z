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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DrawTriangle2();
        }

        //? 1. Beispiel - Ein Dreieck zeichnen
        void DrawTriangle()
        {
            Model3DGroup group = new Model3DGroup();

            MeshGeometry3D m = new MeshGeometry3D();

            m.Positions.Add(new Point3D(1, 0, 0));
            m.Positions.Add(new Point3D(0, 1, 0));
            m.Positions.Add(new Point3D(0, 0, 1));

            m.TriangleIndices.Add(0);
            m.TriangleIndices.Add(1);
            m.TriangleIndices.Add(2);

            group.Children.Add(new GeometryModel3D(m, new DiffuseMaterial(Brushes.Cyan)));

            group.Children.Add(new DirectionalLight(Colors.White, new Vector3D(0, 0, -1)));

            model.Content = group;
        }

        //? 2. Beispiel - Eine Methode zum erstellen eines Vierecks
        GeometryModel3D BuildQuadrilateral(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Material material)
        {
            MeshGeometry3D m = new MeshGeometry3D();

            m.Positions.Add(p1);
            m.Positions.Add(p2);
            m.Positions.Add(p3);
            m.Positions.Add(p4);

            m.TriangleIndices.Add(0);
            m.TriangleIndices.Add(1);
            m.TriangleIndices.Add(2);

            m.TriangleIndices.Add(2);
            m.TriangleIndices.Add(3);
            m.TriangleIndices.Add(0);

            return new GeometryModel3D(m, material);
        }

        //? 2. Beispiel - Vierecke Zeichnen
        void DrawQuadrilateral()
        {
            Model3DGroup group = new Model3DGroup();

            group.Children.Add(BuildQuadrilateral(new Point3D(0, 0, 0), new Point3D(0.5, 0, 0), new Point3D(0.5, 1, 0), new Point3D(0, 1, 0), new DiffuseMaterial(Brushes.Cyan)));

            group.Children.Add(BuildQuadrilateral(new Point3D(0, 0, -1), new Point3D(-1, 0, -1), new Point3D(-1, -1, 0), new Point3D(0, -1, 0), new DiffuseMaterial(Brushes.Cyan)));

            group.Children.Add(new DirectionalLight(Colors.White, new Vector3D(0, 0, -1)));

            model.Content = group;
        }

        //? 3. Beispiel - Ein Dreieck mit RadialGradientBrush zeichnen
        void DrawTriangle2()
        {
            Model3DGroup group = new Model3DGroup();

            MeshGeometry3D m = new MeshGeometry3D();

            m.Positions.Add(new Point3D(1, 0, 0));
            m.Positions.Add(new Point3D(0, 1, 0));
            m.Positions.Add(new Point3D(0, 0, 1));

            m.TriangleIndices.Add(0);
            m.TriangleIndices.Add(1);
            m.TriangleIndices.Add(2);

            m.TextureCoordinates.Add(new Point(0, 0));
            m.TextureCoordinates.Add(new Point(1, 0));
            m.TextureCoordinates.Add(new Point(1, 1));
            m.TextureCoordinates.Add(new Point(0, 1));

            group.Children.Add(new GeometryModel3D(m, new DiffuseMaterial(new RadialGradientBrush(Colors.Green, Colors.Yellow ))));

            group.Children.Add(new DirectionalLight(Colors.White, new Vector3D(0, 0, -1)));

            model.Content = group;
        }


        //? Lights
        private void ShowLights(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            LightsWindow wnd = new LightsWindow();
            wnd.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
        }

        //? Materials
        private void ShowMaterials(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            MaterialWindow wnd = new MaterialWindow();
            wnd.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
        }

        //? Cameras
        private void ShowCameras(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            CameraWindow wnd = new CameraWindow();
            wnd.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
