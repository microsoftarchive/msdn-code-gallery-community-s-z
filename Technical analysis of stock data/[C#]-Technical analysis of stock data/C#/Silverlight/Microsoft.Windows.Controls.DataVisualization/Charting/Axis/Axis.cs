// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis class used to determine the plot area coordinate of values.
    /// </summary>
    public abstract class Axis : Control, IAxis
    {
        #region public AxisLocation Location
        /// <summary>
        /// Gets or sets the axis location.
        /// </summary>
        public AxisLocation Location
        {
            get { return (AxisLocation)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        /// <summary>
        /// Identifies the Location dependency property.
        /// </summary>
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register(
                "Location",
                typeof(AxisLocation),
                typeof(Axis),
                new PropertyMetadata(AxisLocation.Auto, OnLocationPropertyChanged));

        /// <summary>
        /// LocationProperty property changed handler.
        /// </summary>
        /// <param name="d">Axis that changed its Location.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnLocationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Axis source = (Axis)d;
            AxisLocation oldValue = (AxisLocation)e.OldValue;
            AxisLocation newValue = (AxisLocation)e.NewValue;
            source.OnLocationPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// LocationProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        protected virtual void OnLocationPropertyChanged(AxisLocation oldValue, AxisLocation newValue)
        {
            RoutedPropertyChangedEventHandler<AxisLocation> handler = this.LocationChanged;
            if (handler != null)
            {
                handler(this, new RoutedPropertyChangedEventArgs<AxisLocation>(oldValue, newValue));
            }
        }

        /// <summary>
        /// This event is raised when the location property is changed.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<AxisLocation> LocationChanged;

        #endregion public AxisLocation Location

        #region public AxisOrientation Orientation
        /// <summary>
        /// Gets or sets the orientation of the axis.
        /// </summary>
        public AxisOrientation Orientation
        {
            get { return (AxisOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Identifies the Orientation dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(
                "Orientation",
                typeof(AxisOrientation),
                typeof(Axis),
                new PropertyMetadata(AxisOrientation.Vertical, OnOrientationPropertyChanged));

        /// <summary>
        /// OrientationProperty property changed handler.
        /// </summary>
        /// <param name="d">Axis that changed its Orientation.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnOrientationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Axis source = (Axis)d;
            AxisOrientation oldValue = (AxisOrientation)e.OldValue;
            AxisOrientation newValue = (AxisOrientation)e.NewValue;
            source.OnOrientationPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// OrientationProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        protected virtual void OnOrientationPropertyChanged(AxisOrientation oldValue, AxisOrientation newValue)
        {
            if (IsUsed)
            {
                this.Orientation = oldValue;
                throw new InvalidOperationException(Properties.Resources.Axis_OnOrientationPropertyChanged_TheOrientationOfAnAxisCannotBeChangedWhenItIsInUse);
            }
            else
            {
                RoutedPropertyChangedEventHandler<AxisOrientation> handler = OrientationChanged;
                if (handler != null)
                {
                    handler(this, new RoutedPropertyChangedEventArgs<AxisOrientation>(oldValue, newValue));
                }
            }
        }

        /// <summary>
        /// This event is raised when the Orientation property is changed.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<AxisOrientation> OrientationChanged;

        #endregion public AxisOrientation Orientation

        /// <summary>
        /// An event raised when the axis is invalidated.
        /// </summary>
        public event RoutedEventHandler Invalidated;

        /// <summary>
        /// Raises the invalidated event.
        /// </summary>
        /// <param name="args">Information about the event.</param>
        protected virtual void OnInvalidated(RoutedEventArgs args)
        {
            RoutedEventHandler handler = this.Invalidated;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Gets or the collection of series that are using the Axis.
        /// </summary>
        protected IList<object> RegisteredObjects { get; private set; }
  
        /// <summary>
        /// Returns a value indicating whether the axis can plot a value.
        /// </summary>
        /// <param name="value">The value to plot.</param>
        /// <returns>A value indicating whether the axis can plot a value.
        /// </returns>
        public abstract bool CanPlot(object value);

        /// <summary>
        /// Returns a value indicating whether a series can be registered with
        /// this axis.
        /// </summary>
        /// <param name="value">The series to register with the axis.</param>
        /// <returns>A value indicating whether a series can be registered with
        /// this axis.</returns>
        public virtual bool CanRegister(object value)
        {
            return true;
        }

        /// <summary>
        /// Returns a value indicating whether a series is registered with an
        /// axis.
        /// </summary>
        /// <param name="value">The series that may or may not be registered.
        /// </param>
        /// <returns>A value indicating whether a series is registered with an
        /// axis.</returns>
        public bool IsObjectRegistered(object value)
        {
            return RegisteredObjects.Contains(value);
        }

        #region public bool IsUsed
        /// <summary>
        /// Gets a value indicating whether the axis is in use.
        /// </summary>
        public bool IsUsed
        {
            get { return (bool)GetValue(IsUsedProperty); }
            protected set { SetValue(IsUsedProperty, value); }
        }

        /// <summary>
        /// Identifies the IsUsed dependency property.
        /// </summary>
        public static readonly DependencyProperty IsUsedProperty =
            DependencyProperty.Register(
                "IsUsed",
                typeof(bool),
                typeof(Axis),
                new PropertyMetadata(false));

        #endregion public bool IsUsed

        /// <summary>
        /// Instantiates a new instance of the Axis class.
        /// </summary>
        internal Axis()
        {
            RegisteredObjects = new List<object>();
        }

        /// <summary>
        /// Indicates that series is using an axis.
        /// </summary>
        /// <param name="value">The series using the axis.</param>
        internal void Register(object value)
        {
            Debug.Assert(value != null, "object cannot be null.");
            Debug.Assert(!RegisteredObjects.Contains(value), "object has already been registered with the axis.");

            RegisteredObjects.Add(value);
            IsUsed = true;

            OnObjectRegistered(value);
        }

        /// <summary>
        /// Indicates that a series is no longer using an axis.
        /// </summary>
        /// <param name="value">The series no longer using the axis.</param>
        internal void Unregister(object value)
        {
            Debug.Assert(value != null, "object cannot be null.");
            Debug.Assert(RegisteredObjects.Contains(value), "object is not registered with the axis.");

            RegisteredObjects.Remove(value);
            if (RegisteredObjects.Count == 0)
            {
                IsUsed = false;
            }

            OnObjectUnregistered(value);
        }

        /// <summary>
        /// This method is invoked when a series is registered.
        /// </summary>
        /// <param name="series">The series that has been registered.</param>
        protected virtual void OnObjectRegistered(object series)
        {
        }

        /// <summary>
        /// This method is invoked when a series is unregistered.
        /// </summary>
        /// <param name="series">The series that has been unregistered.</param>
        protected virtual void OnObjectUnregistered(object series)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the axis is in use.
        /// </summary>
        bool IAxis.IsUsed
        {
            get { return this.IsUsed; }
        }

        /// <summary>
        /// Indicates that series is using an axis.
        /// </summary>
        /// <param name="value">The series using the axis.</param>
        void IAxis.Register(object value)
        {
            Register(value);
        }

        /// <summary>
        /// Indicates that a series is no longer using an axis.
        /// </summary>
        /// <param name="value">The series no longer using the axis.</param>
        void IAxis.Unregister(object value)
        {
            Unregister(value);
        }
    }
}