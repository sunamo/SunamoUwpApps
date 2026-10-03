using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace apps
{
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

        public static T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
}