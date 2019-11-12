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
    public interface IAxis
    {
        /// <summary>
        /// Gets or sets the axis location.
        /// </summary>
        AxisLocation Location { get; set; }

        /// <summary>
        /// This event is raised when the location property is changed.
        /// </summary>
        event RoutedPropertyChangedEventHandler<AxisLocation> LocationChanged;

        /// <summary>
        /// Gets or sets the orientation of the axis.
        /// </summary>
        AxisOrientation Orientation { get; set; }

        /// <summary>
        /// This event is raised when the Orientation property is changed.
        /// </summary>
        event RoutedPropertyChangedEventHandler<AxisOrientation> OrientationChanged;

        /// <summary>
        /// An event raised when the axis is invalidated.
        /// </summary>
        event RoutedEventHandler Invalidated;
  
        /// <summary>
        /// Returns a value indicating whether the axis can plot a value.
        /// </summary>
        /// <param name="value">The value to plot.</param>
        /// <returns>A value indicating whether the axis can plot a value.
        /// </returns>
        bool CanPlot(object value);

        /// <summary>
        /// Returns a value indicating whether a series can be registered with
        /// this axis.
        /// </summary>
        /// <param name="value">The object to register with the axis.</param>
        /// <returns>A value indicating whether the object can be registered 
        /// with this axis.</returns>
        bool CanRegister(object value);

        /// <summary>
        /// Returns a value indicating whether a series is registered with an
        /// axis.
        /// </summary>
        /// <param name="value">The object that may or may not be registered.
        /// </param>
        /// <returns>A value indicating whether an object is registered with the
        /// axis.</returns>
        bool IsObjectRegistered(object value);

        /// <summary>
        /// Gets a value indicating whether the axis is in use.
        /// </summary>
        bool IsUsed { get; }

        /// <summary>
        /// Indicates that series is using an axis.
        /// </summary>
        /// <param name="value">The series using the axis.</param>
        void Register(object value);

        /// <summary>
        /// Indicates that a series is no longer using an axis.
        /// </summary>
        /// <param name="value">The series no longer using the axis.</param>
        void Unregister(object value);
    }
}