namespace apps.Popups;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the select file type.
    /// </summary>
    public partial class SelectFile : UserControl, IPopupResponsive
    {
        Border border = new Border();

        /// <summary>
        /// Initializes a new instance of the select file class.
        /// </summary>
        public SelectFile()
        {
            InitializeComponent();
            SelectedFile = null;

            
            MinWidth = 300;
        }

        private void SetSelectedFile(StorageFile storageFile)
        {
            selectedFile = storageFile;
            tbSelectedFile.Text = "Selected file: " + GetPathStorageFile(storageFile);
        }

        private string GetPathStorageFile(StorageFile storageFile)
        {
            if (storageFile == null)
            {
                return "None";
            }
            return storageFile.Path;
        }

        /// <summary>
        /// The file selected.
        /// </summary>
        public event VoidStorageFile FileSelected;

        /// <summary>
        /// The file type.
        /// </summary>
        public PickerLocationId FileType = PickerLocationId.PicturesLibrary;
        /// <summary>
        /// The ext.
        /// </summary>
        public CollectionWithoutDuplicates<string> ext = new CollectionWithoutDuplicates<string>();

        private async void btnSelectFile_Click(object sender, RoutedEventArgs eventArgs)
        {
            
            StorageFile file = null;

            if (FileType == PickerLocationId.PicturesLibrary)
            {
                ext.AddRange(CA.ToListString(".jpg", ".png", ".gif", ".bmp"));
                file = await Pickers.GetFile(PickerViewMode.Thumbnail, FileType, ext.Collection.ToArray());
                
            }
            else 
            {
                file = await Pickers.GetFile(PickerViewMode.List, FileType, ext.Collection.ToArray());
            }

            if (file != null)
            {
                if (FSApps.ExistsFile(file))
                {
                    SelectedFile = file;
                    FileSelected(file);
                }
            }


        }

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
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

        /// <summary>
        /// The max content size.
        /// </summary>
        public Size MaxContentSize
        {
            get
            {
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }


        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }
    }
