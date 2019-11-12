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
    /// Interaction logic for Star.xaml
    /// </summary>
    public partial class Star : UserControl
    {
        #region Ctor

        public Star()
        {
            InitializeComponent();
        }

        static Star()
        {
            StateProperty = DependencyProperty.Register("State", typeof(StarState), typeof(Star), new FrameworkPropertyMetadata(StarState.Off, new PropertyChangedCallback(OnStateChanged)));
            OnColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(Star), new FrameworkPropertyMetadata(Brushes.Yellow, new PropertyChangedCallback(OnStarOnColorChanged)));
            OffColorProperty = DependencyProperty.Register("OffColor", typeof(Brush), typeof(Star), new FrameworkPropertyMetadata(Brushes.White, new PropertyChangedCallback(OnStarOffColorChanged), new CoerceValueCallback(CoerceOnStarOffColor)));
        }

        #endregion

        #region Events

        /// <summary>
        /// Notifies when <see cref="State"/> has been changed.
        /// </summary>
        public event EventHandler<StarStateChangedEventArgs> StateChanged;

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Star on color dependency property.
        /// </summary>
        public static readonly DependencyProperty OnColorProperty;

        /// <summary>
        /// Star off color dependency property.
        /// </summary>
        public static readonly DependencyProperty OffColorProperty;

        /// <summary>
        /// Star state dependency property.
        /// </summary>
        public static readonly DependencyProperty StateProperty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of star fill when <see cref="State"/> is <see cref="StarState.On"/>.
        /// </summary>
        public Brush OnColor
        {
            get { return (Brush)GetValue(OnColorProperty); }
            set { SetValue(OnColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of star fill when <see cref="State"/> is <see cref="StarState.Off"/>.
        /// </summary>
        public Brush OffColor
        {
            get { return (Brush)GetValue(OffColorProperty); }
            set { SetValue(OffColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the state of the star.
        /// </summary>
        public StarState State
        {
            get { return (StarState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        /// <summary>
        /// Gets whether or not <see cref="State"/> is <see cref="StarState.On"/>.
        /// </summary>
        public bool IsOn
        {
            get { return (this.State == StarState.On); }
        }

        /// <summary>
        /// Gets or sets the star fill brush.
        /// </summary>
        private Brush StarFill
        {
            get { return this.pathFill.Fill; }
            set { this.pathFill.Fill = value; }
        }

        #endregion

        #region Event Handlers

        private void OnGridMouseEnter(object sender, MouseEventArgs e)
        {
            //// if star is not on, set fill to on color
            if (!IsOn)
            {
                this.StarFill = OnColor;
            }
        }

        private void OnGridMouseLeave(object sender, MouseEventArgs e)
        {
            //// if star is not on, set fill to off color
            if (!IsOn)
            {
                this.StarFill = OffColor;
            }
        }

        private void OnGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            //// change state if left mouse button was released
            if (e.ChangedButton == MouseButton.Left)
            {
                State = (State == StarState.On) ? StarState.Off : StarState.On;
            }
        }

        private void OnStateChanged(StarStateChangedEventArgs e)
        {
            if (StateChanged != null)
            {
                StateChanged(this, e);
            }
        }

        private static void OnStateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Star star = obj as Star;

            if (star != null)
            {
                StarState newState = (StarState)e.NewValue;

                //// set the fill based on the state
                star.StarFill = (newState == StarState.On) ? star.OnColor : star.OffColor;

                //// raise state change event
                star.OnStateChanged(new StarStateChangedEventArgs(star.State));
            }
        }

        private static void OnStarOnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Star star = obj as Star;

            //// if star is on, set fill color to on color
            if (star != null && star.IsOn)
            {
                star.StarFill = star.OnColor;
            }
        }

        private static void OnStarOffColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Star star = obj as Star;

            //// if star is off, set fill color to off color
            if (star != null && !star.IsOn)
            {
                star.StarFill = star.OffColor;
            }
        }

        private static object CoerceOnStarOffColor(DependencyObject obj, object value)
        {
            Star star = obj as Star;

            if (star != null)
            {
                Brush brush = (Brush)value;

                //// if brush is solid brush and color is transparent,
                //// replace it with white brush
                if (brush is SolidColorBrush)
                {
                    SolidColorBrush solid = (SolidColorBrush)brush;

                    if (solid.Color == Colors.Transparent)
                    {
                        return Brushes.White;
                    }
                }

                return brush;
            }

            return Brushes.White;
        }

        #endregion
    }

    /// <summary>
    /// Event args for star state change.
    /// </summary>
    public class StarStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the state before change.
        /// </summary>
        public StarState OldState { get; private set; }

        /// <summary>
        /// GEts the state after change. Same as current state.
        /// </summary>
        public StarState NewState { get; private set; }

        public StarStateChangedEventArgs(StarState current)
        {
            if (current == StarState.On)
            {
                this.OldState = StarState.Off;
                this.NewState = StarState.On;
            }
            else
            {
                this.OldState = StarState.On;
                this.NewState = StarState.Off;
            }
        }
    }

    public enum StarState
    {
        /// <summary>
        /// Star is off
        /// </summary>
        Off = 0,

        /// <summary>
        /// Star is on
        /// </summary>
        On = 1
    }
}
