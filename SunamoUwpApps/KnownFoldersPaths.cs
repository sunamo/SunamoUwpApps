namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    public class KnownFoldersPaths
    {
        private StorageFolder GetStorageFileOfKnownFolder(StorageFolder storageFolder)
        {
            StorageFolder childFolder = FSApps.GetStorageFolder(storageFolder, "a", true, true);
            // Již s koncovým lomítkem na konci vrací
            return childFolder;// +AllStrings.bs;

        }

        public StorageFolder MediaServerDevices()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.MediaServerDevices);
        }

        public StorageFolder MusicLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.MusicLibrary);
        }

        public StorageFolder PicturesLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.PicturesLibrary);
        }

        public StorageFolder RemovableDevices()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.RemovableDevices);
        }

        public StorageFolder VideosLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.VideosLibrary);
        }
    }
