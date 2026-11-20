namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.UI.Xaml;

    /// <summary>
    /// Represents the size extensions type.
    /// </summary>
    public static class SizeExtensions
    {
        /// <summary>
        /// Recalculate size with scale factor.
        /// </summary>
        /// <param name="originalSize">The original size.</param>
        /// <returns>The recalculate size with scale factor result.</returns>
        public static Size RecalculateSizeWithScaleFactor(this Size originalSize)
        {
            var scaleFactor = DisplayHelper.GetScaleFactor();
            var size = new Size(originalSize.Width / scaleFactor, originalSize.Height / scaleFactor);
            return size;
        }

        
    }
