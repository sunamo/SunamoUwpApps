namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    /// <summary>
    /// Represents the known folders paths type.
    /// </summary>
    public class KnownFoldersPaths
    {
        private StorageFolder GetStorageFileOfKnownFolder(StorageFolder storageFolder)
        {
            StorageFolder childFolder = FSApps.GetStorageFolder(storageFolder, "a", true, true);
            // Již s koncovým lomítkem na konci vrací
            return childFolder;// +AllStrings.bs;

        }

        /// <summary>
        /// Media server devices.
        /// </summary>
        /// <returns>The media server devices result.</returns>
        public StorageFolder MediaServerDevices()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.MediaServerDevices);
        }

        /// <summary>
        /// Music library.
        /// </summary>
        /// <returns>The music library result.</returns>
        public StorageFolder MusicLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.MusicLibrary);
        }

        /// <summary>
        /// Pictures library.
        /// </summary>
        /// <returns>The pictures library result.</returns>
        public StorageFolder PicturesLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.PicturesLibrary);
        }

        /// <summary>
        /// Removable devices.
        /// </summary>
        /// <returns>The removable devices result.</returns>
        public StorageFolder RemovableDevices()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.RemovableDevices);
        }

        /// <summary>
        /// Videos library.
        /// </summary>
        /// <returns>The videos library result.</returns>
        public StorageFolder VideosLibrary()
        {
            return GetStorageFileOfKnownFolder(KnownFolders.VideosLibrary);
        }
    }
