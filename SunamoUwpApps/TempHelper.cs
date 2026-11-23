namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    /// <summary>
    /// Represents the temp helper type.
    /// </summary>
    public static class TempHelper 
    {
        static StorageFolder folder = null;

        /// <summary>
        /// Get temp storage file.
        /// </summary>
        /// <returns>The get temp storage file result.</returns>
        public static StorageFile GetTempStorageFile()
        {
            if (folder == null)
            {
                folder = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(Path.GetTempPath()).AsTask());
            }
            return GetResult<StorageFile>( folder.GetFileAsync(Path.GetTempFileName()).AsTask());
        }

        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
