namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

    public class BitmapImageWithPath
    {
        public string path = "";
        public BitmapImage image = null;

        public BitmapImageWithPath(string path, BitmapImage image)
        {
            this.path = path;
            this.image = image;
        }

        public override string ToString()
        {
            return path;
        }
    }
