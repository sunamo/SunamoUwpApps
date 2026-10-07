namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    public static class TempHelper 
    {
        static StorageFolder folder = null;

        public static StorageFile GetTempStorageFile()
        {
            if (folder == null)
            {
                folder = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(Path.GetTempPath()).AsTask());
            }
            return GetResult<StorageFile>( folder.GetFileAsync(Path.GetTempFileName()).AsTask());
        }

        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
