namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.UI.Xaml.Media.Imaging;

    public class BitmapImageWithStorageFile
    {
        public StorageFile path = null;
        public BitmapImage image = null;

        public BitmapImageWithStorageFile(StorageFile path, BitmapImage image)
        {
            this.path = path;
            this.image = image;
        }

        public override string ToString()
        {
            return path.Path;
        }
    }
