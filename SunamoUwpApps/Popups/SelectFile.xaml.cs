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

    public partial class SelectFile : UserControl, IPopupResponsive
    {
        Border border = new Border();

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

        public event VoidStorageFile FileSelected;

        public PickerLocationId FileType = PickerLocationId.PicturesLibrary;
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

        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
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


        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }
    }
