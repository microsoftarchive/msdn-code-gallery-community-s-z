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

            m.TextureCoordinates.Add(tp1);
            m.TextureCoordinates.Add(tp2);
            m.TextureCoordinates.Add(tp3);
            m.TextureCoordinates.Add(tp4);

            return new GeometryModel3D(m, texture) { Transform = tr, };
        }
    }
}
