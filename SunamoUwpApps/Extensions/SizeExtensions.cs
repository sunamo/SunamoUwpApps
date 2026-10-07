namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.UI.Xaml;

    public static class SizeExtensions
    {
        public static Size RecalculateSizeWithScaleFactor(this Size size2)
        {
            var scaleFactor = DisplayHelper.GetScaleFactor();
            var size = new Size(size2.Width / scaleFactor, size2.Height / scaleFactor);
            return size;
        }

        
    }
