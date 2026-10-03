namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

    public partial class SelectImageFile : UserControl, IAsync
    {
        public SelectImageFile()
        {
            InitializeComponent();
            SelectedFile = null;
        }

        private string GetPathFile(StorageFile v)
        {
            if (v == null)
            {
                bi = null;
                return "None";
            }
            return v.Path;
        }

        private void SetSelectedFile(StorageFile v)
        {
            selectedFile = v;
            tbSelectedFile.Text = "Selected file: " + GetPathFile( v);
        }

        public event VoidStorageFileBitmapImage FileSelected;

        private async void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = null;
            file = await  Pickers.GetFile(Windows.Storage.Pickers.PickerViewMode.Thumbnail, Windows.Storage.Pickers.PickerLocationId.PicturesLibrary, ".jpg", ".png");
            if (file != null)
            {
                 OnSelectedFile(file);
            }
        }

        public void OnSelectedFile(StorageFile file)
        {
            if ( FSApps.ExistsFile(file))
            {
                SelectedFile = file;
                        bi = new BitmapImage();
                IRandomAccessStreamWithContentType randomAccessStreamWithContentType = GetResult<IRandomAccessStreamWithContentType>(file.OpenReadAsync().AsTask());
                bi.SetSource( randomAccessStreamWithContentType);
                FileSelected(file, bi);
            }
        }

        public T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }

        BitmapImage bi = null;

        public BitmapImage SelectedBitmapImage
        {
            get
            {
                return bi;
            }
            set
            {
                bi = value;
            }
        }

        StorageFile selectedFile = null;

        public StorageFile SelectedFile
        {
            get
            {
                return selectedFile;
            }
            set
            {
                SetSelectedFile(value);
            }
        }
    }
