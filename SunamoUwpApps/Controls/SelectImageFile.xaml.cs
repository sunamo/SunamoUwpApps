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

    /// <summary>
    /// Represents the select image file type.
    /// </summary>
    public partial class SelectImageFile : UserControl, IAsync
    {
        /// <summary>
        /// Initializes a new instance of the select image file class.
        /// </summary>
        public SelectImageFile()
        {
            InitializeComponent();
            SelectedFile = null;
        }

        private string GetPathFile(StorageFile storageFile)
        {
            if (storageFile == null)
            {
                bi = null;
                return "None";
            }
            return storageFile.Path;
        }

        private void SetSelectedFile(StorageFile storageFile)
        {
            selectedFile = storageFile;
            tbSelectedFile.Text = "Selected file: " + GetPathFile( storageFile);
        }

        /// <summary>
        /// The file selected.
        /// </summary>
        public event VoidStorageFileBitmapImage FileSelected;

        private async void btnSelectFile_Click(object sender, RoutedEventArgs eventArgs)
        {
            StorageFile file = null;
            file = await  Pickers.GetFile(Windows.Storage.Pickers.PickerViewMode.Thumbnail, Windows.Storage.Pickers.PickerLocationId.PicturesLibrary, ".jpg", ".png");
            if (file != null)
            {
                 OnSelectedFile(file);
            }
        }

        /// <summary>
        /// On selected file.
        /// </summary>
        /// <param name="file">The file.</param>
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

        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }

        BitmapImage bi = null;

        /// <summary>
        /// The selected bitmap image.
        /// </summary>
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

        /// <summary>
        /// The selected file.
        /// </summary>
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
