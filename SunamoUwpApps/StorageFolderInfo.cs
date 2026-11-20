namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    /// <summary>
    /// Represents the storage folder info type.
    /// </summary>
    public class StorageFolderInfo
    {
        string path = null;
        string name = null;
        List<string> fileNames = null;
        List<string> folderNames = null;

        /// <summary>
        /// Initializes a new instance of the storage folder info class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="folders">The folders.</param>
        /// <param name="files">The files.</param>
        public StorageFolderInfo(StorageFolder info, IReadOnlyList<StorageFolder> folders, IReadOnlyList<StorageFile> files)
        {
            path =  info.Path;
            name = info.Name;
            folderNames = new List<string>(folders.Count);
            foreach (var item in folders)
            {
                folderNames.Add(item.Path);
            }

            fileNames = new List<string>();
            foreach (var item in files)
            {
                fileNames.Add(item.Path);
            }
            
        }



        /// <summary>
        /// The name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// The path.
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// The file names.
        /// </summary>
        public List<string> FileNames
        {
            get
            {
                return fileNames;
            }
        }

        /// <summary>
        /// The folder names.
        /// </summary>
        public List<string> FolderNames
        {
            get
            {
                return folderNames;
            }
        }
    }
