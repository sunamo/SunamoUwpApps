namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

    /// <summary>
    /// Represents the pickers type.
    /// </summary>
    public static class Pickers //: IAsync
    {
        /// <summary>
        /// Vrátí null v případě že uživatel nevybere žádný soubor
        /// </summary>
        /// <param name="pvm"></param>
        /// <param name="plid"></param>
        /// <param name="exts"></param>
        public async static Task< StorageFile> GetFile(PickerViewMode pvm, PickerLocationId plid, params string[] exts)
        {
            var picker = new FileOpenPicker();

            picker.SuggestedStartLocation = plid;
            picker.ViewMode = pvm;
            foreach (var item in exts)
            {
                picker.FileTypeFilter.Add(item);
            }

            // Cant be AsyncHelper, will frozen whole UI (with await too)
            return await picker.PickSingleFileAsync().AsTask();
        }

        /// <summary>
        /// Get files.
        /// </summary>
        /// <param name="pvm">The pvm.</param>
        /// <param name="plid">The plid.</param>
        /// <param name="exts">The exts.</param>
        /// <returns>The get files result.</returns>
        public static IReadOnlyList<StorageFile> GetFiles(PickerViewMode pvm, PickerLocationId plid, params string[] exts)
        {
            var picker = new FileOpenPicker();

            picker.SuggestedStartLocation = plid;
            picker.ViewMode = pvm;
            foreach (var item in exts)
            {
                picker.FileTypeFilter.Add(item);
            }
            return GetResult<IReadOnlyList<StorageFile>>( picker.PickMultipleFilesAsync().AsTask());
        }

        /// <summary>
        /// Get folder.
        /// </summary>
        /// <param name="pvm">The pvm.</param>
        /// <param name="plid">The plid.</param>
        /// <param name="exts">The exts.</param>
        /// <returns>The get folder result.</returns>
        public static StorageFolder GetFolder( PickerViewMode pvm, PickerLocationId plid, params string[] exts)
        {
            var picker = new FolderPicker();

            picker.SuggestedStartLocation = plid;
            picker.ViewMode = pvm;
            foreach (var item in exts)
            {
                picker.FileTypeFilter.Add(item);
            }
            return GetResult<StorageFolder>(picker.PickSingleFolderAsync().AsTask());
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
