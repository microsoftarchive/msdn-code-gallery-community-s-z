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

namespace MasaSam.Controls
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        #region Ctor

        public Rating()
        {
            InitializeComponent();

            this.Loaded += this.Rating_Loaded;
        }

        static Rating()
        {
            ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(Rating), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnValueChanged), new CoerceValueCallback(CoerceValueValue)));
            MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(Rating), new FrameworkPropertyMetadata(5));
            MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(Rating), new FrameworkPropertyMetadata(0));
            StarOnColorProperty = DependencyProperty.Register("StarOnColor", typeof(Brush), typeof(Rating), new FrameworkPropertyMetadata(Brushes.Yellow, new PropertyChangedCallback(OnStarOnColorChanged)));
            StarOffColorProperty = DependencyProperty.Register("StarOffColor", typeof(Brush), typeof(Rating), new FrameworkPropertyMetadata(Brushes.White, new PropertyChangedCallback(OnStarOffColorChanged)));
        }

        #endregion

        #region Events

        /// <summary>
        /// Notifies when rating has been changed.
        /// </summary>
        public event EventHandler<RatingChangedEventArgs> RatingChanged;

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Value dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty;

        /// <summary>
        /// Maximum dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximumProperty;

        /// <summary>
        /// Minimum dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimumProperty;

        /// <summary>
        /// Star on color dependency property.
        /// </summary>
        public static readonly DependencyProperty StarOnColorProperty;

        /// <summary>
        /// Star off color dependency property.
        /// </summary>
        public static readonly DependencyProperty StarOffColorProperty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the star on color.
        /// </summary>
        public Brush StarOnColor
        {
            get { return (Brush)GetValue(StarOnColorProperty); }
            set { SetValue(StarOnColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the star off color.
        /// </summary>
        public Brush StarOffColor
        {
            get { return (Brush)GetValue(StarOffColorProperty); }
            set { SetValue(StarOffColorProperty, value); }
        }
          
        #endregion

        #region Event Handlers

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Rating rating = obj as Rating;

            if (rating != null)
            {
                rating.OnRatingChanged();
            }
        }

        private static object CoerceValueValue(DependencyObject obj, object value)
        {
            Rating rating = (Rating)obj;

            int current = (int)value;

            if (current < rating.Minimum)
            {
                current = rating.Minimum;
            }

            if (current > rating.Maximum)
            {
                current = rating.Maximum;
            }

            return current;
        }

        private static void OnStarOffColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Rating rating = obj as Rating;

            if (rating != null)
            {
                Brush offColor = (Brush)e.NewValue;

                foreach (Star star in rating.stackPanelStars.Children)
                {
                    star.OffColor = offColor;
                }
            }
        }

        private static void OnStarOnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Rating rating = obj as Rating;

            if (rating != null)
            {
                Brush onColor = (Brush)e.NewValue;

                foreach (Star star in rating.stackPanelStars.Children)
                {
                    star.OnColor = onColor;
                }
            }
        }

        private void Rating_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeStars();
        }

        private void star_MouseLeave(object sender, MouseEventArgs e)
        {
            Star star = (Star)sender;

            if (!star.IsOn)
            {
                int current = (int)star.Tag;
                int value;

                foreach (Star str in this.stackPanelStars.Children)
                {
                    DisableStateChange(str);

                    value = (int)str.Tag;

                    if (value < current && value > Value)
                    {
                        str.State = StarState.Off;
                    }

                    EnableStateChange(str);
                }
            }
        }

        private void star_MouseEnter(object sender, MouseEventArgs e)
        {
            Star star = (Star)sender;

            if (!star.IsOn)
            {
                int current = (int)star.Tag;
                int value;

                foreach (Star str in this.stackPanelStars.Children)
                {
                    DisableStateChange(str);

                    value = (int)str.Tag;

                    if (value < current)
                    {
                        str.State = StarState.On;
                    }

                    EnableStateChange(str);
                }
            }
        }

        private void star_StateChanged(object sender, StarStateChangedEventArgs e)
        {
            Star star = (Star)sender;

            int current = (int)star.Tag;

            bool reset = (current < Value);

            int value;

            foreach (Star str in this.stackPanelStars.Children)
            {
                value = (int)str.Tag;

                DisableStateChange(str);

                if (value < current)
                {
                    str.State = StarState.On;
                }
                else if (value > current)
                {
                    str.State = StarState.Off;
                }
                else if (value == current && reset)
                {
                    str.State = StarState.On;
                }

                EnableStateChange(str);
            }

            this.Value = current;
        }

        #endregion

        #region Methods

        private void InitializeStars()
        {
            this.stackPanelStars.Children.Clear();

            int value = 1;

            for (int i = 0; i < this.Maximum; i++)
            {
                Star star = new Star();
                star.OnColor = this.StarOnColor;
                star.OffColor = this.StarOffColor;
                star.Tag = value;
                star.StateChanged += star_StateChanged;
                star.MouseEnter += star_MouseEnter;
                star.MouseLeave += star_MouseLeave;

                value++;

                this.stackPanelStars.Children.Insert(i, star);
            }
        }

        private void EnableStateChange(Star str)
        {
            str.StateChanged += this.star_StateChanged;
        }

        private void DisableStateChange(Star str)
        {
            str.StateChanged -= this.star_StateChanged;
        }

        private void OnRatingChanged()
        {
            if (RatingChanged != null)
            {
                RatingChanged(this, new RatingChangedEventArgs(this.Value));
            }
        }

        #endregion
    }

    /// <summary>
    /// Event arguments for the rating change.
    /// </summary>
    public class RatingChangedEventArgs
    {
        /// <summary>
        /// Gets the value of the rating.
        /// </summary>
        public int Value { get; private set; }

        public RatingChangedEventArgs(int value)
            : base()
        {
            this.Value = value;
        }
    }
}
