// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// A class that rotates through a list of styles.
    /// </summary>
    internal class StyleDispenser : IStyleDispenser
    {
        /// <summary>
        /// The list of styles of rotate.
        /// </summary>
        private IList _styles;

        /// <summary>
        /// Styles that have already been used by a series.
        /// </summary>
        private IDictionary<Style, bool> _usedStyles = new Dictionary<Style, bool>();

        /// <summary>
        /// Gets or sets the list of styles to rotate.
        /// </summary>
        public IList Styles
        {
            get
            {
                return _styles;
            }
            set
            {
                if (value != _styles)
                {
                    _styles = value;
                    _usedStyles.Clear();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the StyleDispenser class.
        /// </summary>
        public StyleDispenser()
        {
        }

        /// <summary>
        /// Removes a style matching a given target type from the pool of 
        /// available styles and returns it.  Once all styles are exhausted the 
        /// available pool of styles are reset.
        /// </summary>
        /// <param name="targetType">The target type of the requested style.
        /// </param>
        /// <param name="inherit">Whether to return ancestors of the 
        /// target type.</param>
        /// <returns>The next applicable style in the Styles collection.
        /// </returns>
        public Style NextStyle(Type targetType, bool inherit)
        {
            if (_styles == null)
            {
                return null;
            }

            IEnumerable<Style> styles = 
                Styles.Cast<Style>();

            // If a style that has been used has been removed from the 
            // collection remove it from the used collection to avoid memory
            // leaks.
            IList<Style> orphanedUsedStyles = _usedStyles.Keys.Except(styles).ToList();
            foreach (Style orphanedStyle in orphanedUsedStyles)
            {
                _usedStyles.Remove(orphanedStyle);
            }

            // If all styles are used clear used styles list and start over
            if (_usedStyles.Count == _styles.Count)
            {
                _usedStyles.Clear();
            }

            // Look up inheritance tree if takeAncestors is true
            Func<Style, bool> predicate;
            if (inherit)
            {
                predicate = style => style.TargetType.IsAssignableFrom(targetType);
            }
            else
            {
                predicate = style => style.TargetType == targetType;
            }
            
            IEnumerable<Style> unusedStyles = styles.Where(style => !_usedStyles.ContainsKey(style));
            Style matchingStyle = unusedStyles.Where(predicate).FirstOrDefault();

            // If a match is found add it to the used styles and return it
            if (matchingStyle != null)
            {
                _usedStyles[matchingStyle] = true;
            }

            return matchingStyle;
        }

        /// <summary>
        /// Resets the state of the StyleDispenser.
        /// </summary>
        public void Reset()
        {
            _usedStyles.Clear();
        }
    }
}