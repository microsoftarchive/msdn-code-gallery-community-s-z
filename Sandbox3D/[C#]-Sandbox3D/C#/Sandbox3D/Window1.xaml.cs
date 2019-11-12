using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

using _3DTools; 

namespace Sandbox3D
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private GeometryModel3D cylinder;
        private GeometryModel3D sphere;
        private GeometryModel3D plane;
        private GeometryModel3D torus;
        private GeometryModel3D cube;
        private GeometryModel3D axis;
        private Material materialGreen = new DiffuseMaterial(new SolidColorBrush(Colors.Green));
        private Material materialGray = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));
        private Mesh3DObjects.Cylinder cylinderFactory = new Mesh3DObjects.Cylinder();
        private Mesh3DObjects.Sphere sphereFactory = new Mesh3DObjects.Sphere();
        private Mesh3DObjects.Plane planeFactory = new Mesh3DObjects.Plane();
        private Mesh3DObjects.Torus torusFactory = new Mesh3DObjects.Torus(0.7f, 0.3f);
        private Mesh3DObjects.Cube cubeFactory  = new Mesh3DObjects.Cube();
		
		private Transform3DGroup transformGroup3D = new Transform3DGroup();
        private Trackball _trackball;

        private VideoDrawing vd = new VideoDrawing();
		private void WindowLoaded(object sender, EventArgs e)
		{
            BuildAxes();

            //add a torus to start
			//torus = new GeometryModel3D(torusFactory.Mesh, materialGreen);
            ModelVisual3D mv3d = myViewPort3D.Children[1] as ModelVisual3D;
            mv3d.Content = torus;
            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(myViewPort3D);
            _trackball.Enabled = true;
           // myViewPort3D.Models.Children.Add(BuildAxes());

        }

        private ScreenSpaceLines3D BuildScreenSpaceLines3D(Point3D point1, Point3D point2)
        {
            ScreenSpaceLines3D line = new ScreenSpaceLines3D();
            line.Points.Add(point1);
            line.Points.Add(point2);
            line.Thickness = 2;
            line.Color = Colors.Black;
            
            return line;

        }
		
        private void BuildAxes()
        {
            ScreenSpaceLines3D _axisX = BuildScreenSpaceLines3D(new Point3D(5, 0, 0), new Point3D(-5, 0, 0));
            ScreenSpaceLines3D _axisY = BuildScreenSpaceLines3D(new Point3D(0, 5, 0), new Point3D(0, -5, 0));
            ScreenSpaceLines3D _axisZ = BuildScreenSpaceLines3D(new Point3D(0, 0, 10), new Point3D(0, 0, -10));
            myViewPort3D.Children.Add(_axisX);
            myViewPort3D.Children.Add(_axisY);
            myViewPort3D.Children.Add(_axisZ);
            //return _axes;


        }   

		public string menuValue = "";
        private void ResetTransforms()
        {
            ModelVisual3D mv3d = myViewPort3D.Children[1] as ModelVisual3D;
            Transform3DGroup t3dg = mv3d.Transform as Transform3DGroup;
            ScaleTransform3D st3d = t3dg.Children[0] as ScaleTransform3D;
            st3d.ScaleX = 1;
            st3d.ScaleY = 1;
            st3d.ScaleZ = 1;
            RotateTransform3D rt3d = t3dg.Children[1] as RotateTransform3D;
            AxisAngleRotation3D aa3d = rt3d.Rotation as AxisAngleRotation3D;
            aa3d.Angle = 0;
            aa3d.Axis = new Vector3D(0, 1, 0);
            TranslateTransform3D tt3d = t3dg.Children[2] as TranslateTransform3D;
            tt3d.OffsetX = 0;
            tt3d.OffsetY = 0;
            tt3d.OffsetZ = 0;

               
        }
		private void ResetPrimitive(object sender, RoutedEventArgs e)
        {

            //get reference to model
            ModelVisual3D mv3d = myViewPort3D.Children[1] as ModelVisual3D;
            ResetTransforms();
            //grab value from listbox
            menuValue = ((sender as MenuItem).Header.ToString());

            switch (menuValue)
            {
                case "Sphere":
                    sphere = new GeometryModel3D(sphereFactory.Mesh, materialGreen);
					mv3d.Content = sphere;
                    break;

                case "Cylinder":
                    cylinder = new GeometryModel3D(cylinderFactory.Mesh, materialGreen);
					mv3d.Content = cylinder;
					break;

                case "Plane":
					plane = new GeometryModel3D(planeFactory.Mesh, materialGreen);
					mv3d.Content = plane;
					break;

                case "Torus":
                    torus = new GeometryModel3D(torusFactory.Mesh, materialGreen);
					mv3d.Content = torus;
					break;

                case "Cube":
                    cube = new GeometryModel3D(cubeFactory.Mesh, materialGreen);
					mv3d.Content = cube;
                    break;

            }


        }

        private void PaintImage(object sender, RoutedEventArgs e)
        {
            ModelVisual3D mv3d = myViewPort3D.Children[1] as ModelVisual3D;
            System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
            dlgOpen.InitialDirectory = System.Environment.SystemDirectory + "\\oobe\\images";
            dlgOpen.CheckFileExists = true;
            dlgOpen.Multiselect = false;
            dlgOpen.Title = "Select a file...";
            if (dlgOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                // user canceled
                return;
            }

            DrawImageOnMesh(mv3d.Content as GeometryModel3D, new Uri(dlgOpen.FileName, UriKind.Absolute));

        }
        private void PaintVideo(object sender, RoutedEventArgs e)
        {
           
            ModelVisual3D mv3d = myViewPort3D.Children[1] as ModelVisual3D;
            System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
            dlgOpen.InitialDirectory = System.Environment.SystemDirectory + "\\oobe\\images";
            dlgOpen.CheckFileExists = true;
            dlgOpen.Multiselect = false;
            dlgOpen.Filter = "Windows Media Files|*.wmv|All files|*.*";
            dlgOpen.Title = "Select a file...";
            if (dlgOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                // user canceled
                return;
            }

            //two techniques for video on 3d
            MenuItem mi = (MenuItem)sender;
		    if (mi.Header.ToString() == "VideoDrawing")
    			DrawVideoOnMesh(vd, mv3d.Content as GeometryModel3D, new Uri(dlgOpen.FileName, UriKind.Absolute));
            else
                DrawVisualBrushOnMesh(mv3d.Content as GeometryModel3D, new Uri(dlgOpen.FileName, UriKind.Absolute));
		}


        private void DrawImageOnMesh(GeometryModel3D gm3d, Uri uri)
        {
            ImageSource isrc = new BitmapImage(uri);
            ImageBrush ib = new ImageBrush(isrc);
            MaterialGroup mg = new MaterialGroup();
            mg.Children.Add(new DiffuseMaterial(ib));
            gm3d.Material = mg;
        }
        private void DrawVideoOnMesh(VideoDrawing vd, GeometryModel3D gm3d, Uri uri)
        {
            MediaPlayer mp = new MediaPlayer();
            mp.Open(uri);
            mp.MediaEnded += new EventHandler(mp_MediaEnded);
            vd.Player = mp;
            vd.Rect = new Rect(0, 0, 5, 10);
            DrawingBrush db = new DrawingBrush();
            db.Drawing = vd;
            Brush br = db as Brush;
            MaterialGroup mg = new MaterialGroup();
            mg.Children.Add(new DiffuseMaterial(br));
            gm3d.Material = mg;
            vd.Player.Play();
        }

        void mp_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer mp = (MediaPlayer)sender;
            mp.Stop();
            mp.Position = TimeSpan.Zero;
            mp.Play();
        }

        private void DrawVisualBrushOnMesh(GeometryModel3D gm3d, Uri uri)
        {
            myMedia.Source = uri;
            myMedia.MediaEnded += new RoutedEventHandler(myMedia_MediaEnded);
            VisualBrush vb = new VisualBrush(myMedia);
            MaterialGroup mg = new MaterialGroup();
            mg.Children.Add(new DiffuseMaterial(vb));
            gm3d.Material = mg;
            myMedia.Play();
        }

        void myMedia_MediaEnded(object sender, RoutedEventArgs e)
        {
            myMedia.Stop();
            myMedia.Position = TimeSpan.Zero;
            myMedia.Play();
        }



    }

}