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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF3DImageCarousel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String[] IMAGES = { "images/image1.png", "images/image2.png", "images/image3.png", "images/image4.png", "images/image5.png", "images/image6.png", "images/image7.png", "images/image8.png", "images/image9.png" };    // images
        private static double IMAGE_WIDTH = 128;        // Image Width
        private static double IMAGE_HEIGHT = 128;       // Image Height        
        private static double SPRINESS = 0.4;		    // Control the Spring Speed
        private static double DECAY = 0.5;			    // Control the bounce Speed
        private static double SCALE_DOWN_FACTOR = 0.5;  // Scale between images
        private static double OFFSET_FACTOR = 100;      // Distance between images
        private static double OPACITY_DOWN_FACTOR = 0.4;    // Alpha between images
        private static double MAX_SCALE = 2;            // Maximum Scale


        private double _xCenter;
        private double _yCenter;

        private double _target = 0;		// Target moving position
        private double _current = 0;	// Current position
        private double _spring = 0;		// Temp used to store last moving 
        private List<Image> _images = new List<Image>();	// Store the added images

        private static int FPS = 24;                // fps of the on enter frame event
        private DispatcherTimer _timer = new DispatcherTimer(); // on enter frame simulator
        public MainWindow()
        {
            InitializeComponent();
            // Save the center position
            _xCenter = Width / 2;
            _yCenter = Height / 2;

            addImages();
            
        }

        private void carouselwindow_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }



        /////////////////////////////////////////////////////        
        // Handlers 
        /////////////////////////////////////////////////////	

        // reposition the images
        void _timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _images.Count; i++)
            {
                Image image = _images[i];
                posImage(image, i);
            }


            // compute the current position
            // added spring effect
            if (_target == _images.Count)
                _target = 0;
            _spring = (_target - _current) * SPRINESS + _spring * DECAY;
            _current += _spring;
        }

        /////////////////////////////////////////////////////        
        // Private Methods 
        /////////////////////////////////////////////////////	


        // add images to the stage
        private void addImages()
        {
            for (int i = 0; i < IMAGES.Length; i++)
            {
                // get the image resources from the xap
                string url = IMAGES[i];
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(url, UriKind.Relative));

                // add and reposition the image
                LayoutRoot.Children.Add(image);
                posImage(image, i);
                _images.Add(image);
            }
        }

        // move the index
        private void moveIndex(int value)
        {
            _target += value;
            _target = Math.Max(0, _target);
            _target = Math.Min(_images.Count - 1, _target);
        }

        // reposition the image
        private void posImage(Image image, int index)
        {
            double diffFactor = index - _current;


            // scale and position the image according to their index and current position
            // the one who closer to the _current has the larger scale
            ScaleTransform scaleTransform = new ScaleTransform();
            scaleTransform.ScaleX = MAX_SCALE - Math.Abs(diffFactor) * SCALE_DOWN_FACTOR;
            scaleTransform.ScaleY = MAX_SCALE - Math.Abs(diffFactor) * SCALE_DOWN_FACTOR;
            image.RenderTransform = scaleTransform;

            // reposition the image
            double left = _xCenter - (IMAGE_WIDTH * scaleTransform.ScaleX) / 2 + diffFactor * OFFSET_FACTOR;
            double top = _yCenter - (IMAGE_HEIGHT * scaleTransform.ScaleY) / 2;
            image.Opacity = 1 - Math.Abs(diffFactor) * OPACITY_DOWN_FACTOR;

            image.SetValue(Canvas.LeftProperty, left);
            image.SetValue(Canvas.TopProperty, top);

            // order the element by the scaleX
            image.SetValue(Canvas.ZIndexProperty, (int)Math.Abs(scaleTransform.ScaleX * 100));
        }

        /////////////////////////////////////////////////////        
        // Public Methods
        /////////////////////////////////////////////////////	

        // start the timer
        public void Start()
        {
            // start the enter frame event
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / FPS);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            moveIndex(1);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            moveIndex(-1);
        }
  

    }
}
