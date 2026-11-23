namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Represents the bitmap image with path type.
    /// </summary>
    public class BitmapImageWithPath
    {
        /// <summary>
        /// The path.
        /// </summary>
        public string path = "";
        /// <summary>
        /// The image.
        /// </summary>
        public BitmapImage image = null;

        /// <summary>
        /// Initializes a new instance of the bitmap image with path class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="image">The image.</param>
        public BitmapImageWithPath(string path, BitmapImage image)
        {
            this.path = path;
            this.image = image;
        }

        /// <summary>
        /// To string.
        /// </summary>
        /// <returns>The to string result.</returns>
        public override string ToString()
        {
            return path;
        }
    }
