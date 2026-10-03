using apps;
// cant be, then would be StorageFile 2x
//using sunamo.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

//namespace apps
//{
/// <summary>
/// Must be FSApps because is used many methods from FSApps
/// </summary>
public static class FSApps //: IAsync
{
    public static FileExceptions folderExc = FileExceptions.None;
    public static FileExceptions fileExc = FileExceptions.None;
    public static StorageFile file = null;
    public static StorageFolder folder = null;

    public static void DeleteFiles(StorageFolder tt)
    {
        var files = GetResult<IReadOnlyList<StorageFile>>(tt.GetFilesAsync().AsTask());
        foreach (var item in files)
        {
            DeleteFile(item);
        }
    }

    public static void DeleteFiles(List<StorageFile> tt)
    {
        foreach (var item in tt)
        {
            DeleteFile(item);
        }
    }

    public static string GetFileNameWithoutExtension(StorageFile storageFile)
    {
        return storageFile.Name.Substring(0, storageFile.Name.Length - storageFile.FileType.Length);
    }

    /// <summary>
    /// Pokud se nepodaří smazat, nevyhodí žádnou výjimku
    /// </summary>
    /// <param name="item"></param>
    public static void DeleteFile(StorageFile item)
    {
        try
        {
            AsyncHelperApps.ci.GetResult( item.DeleteAsync(StorageDeleteOption.PermanentDelete));
        }
        catch (Exception ex)
        {
        }
    }

    public static void DeleteFilesWithSize(StorageFolder task, ulong v)
    {
        var q = GetResult<IReadOnlyList<StorageFile>>( task.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        foreach (var item in q)
        {
            if (FSApps.GetFileSize(item) == v)
            {
                try
                {
                    DeleteFile(item);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    public static IReadOnlyList<StorageFile> GetFilesOfExtensionCaseInsensitive(StorageFolder sf, string ext)
    {
        ext = ext.ToLower();
        List<StorageFile> vr = new List<StorageFile>();
        var dd = GetResult<IReadOnlyList<StorageFile>>( sf.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        foreach (var item in dd)
        {
            if (item.Name.ToLower().EndsWith(ext))
            {
                vr.Add(item);
            }
        }
        return vr;
    }

    public static List<StorageFile> GetFilesOfExtensionCaseInsensitiveRecursively(StorageFolder sf, string ext)
    {
        List<StorageFile> files = new List<StorageFile>();
        files = FSApps.GetFilesRek(sf, AllStrings.asterisk, files);
        for (int i = files.Count - 1; i >= 0; i--)
        {
            if (!files[i].Name.ToLower().EndsWith(ext))
            {
                files.RemoveAt(i);
            }
        }
        return files;
    }

    public static List<StorageFile> GetFilesSync(StorageFolder folder, string mask, bool recursively )
    {
        List<StorageFile> files = new List<StorageFile>();
        if (recursively)
        {
            
             files = GetFilesRek(folder, mask, files);
        }
        else
        {
            var files2 = AsyncHelperApps.ci.GetResult<IReadOnlyList<StorageFile>>( folder.GetFilesAsync());
            foreach (var item in files2)
            {
                if (SH.MatchWildcard(item.Name, mask))
                {
                    files.Add(item);
                }
            }
        }

        return files;
    }

    private static List<StorageFile> GetFilesRek(StorageFolder folder, string mask, List<StorageFile> files)
    {
        StorageFolder fold = folder;

        IReadOnlyList<IStorageItem> items = GetResult<IReadOnlyList <IStorageItem>>( fold.GetItemsAsync().AsTask());

        foreach (var item in items)
        {
            if (item.GetType() == typeof(StorageFile))
            {
                var file = item as StorageFile;
                if (SH.MatchWildcard(file.Name, mask))
                {
                    files.Add(file);
                }
            }
            else if (item is StorageFolder)
            {
                files = GetFilesRek(item as StorageFolder, mask, files);
            }
        }

        return files;
    }

    public static StorageFile ExistsFileCreateIfNot(StorageFolder sf, string fileName)
    {
        file = AsyncHelperApps.ci.GetResult<StorageFile>( sf.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists));
        return file;
    }

    public static StorageFile RandomFileFromFolder(string v)
    {
        StorageFolder sf = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(v).AsTask());
        IReadOnlyList<StorageFile> v2 = GetResult< IReadOnlyList < StorageFile >>( sf.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        return RandomHelper.RandomElementOfCollectionT<StorageFile>(v2);
    }

    public static StorageFolder ExistsFolderCreateIfNot(StorageFolder sf, string folderName)
    {
        folder = AsyncHelperApps.ci.GetResult<StorageFolder>( sf.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists));
        return folder;
    }

    public static bool ExistsFileSync(StorageFile sf)
    {
        if (sf == null)
        {
            return false;
        }

        StorageFolder folder = GetResult<StorageFolder>( sf.GetParentAsync().AsTask());
        return ExistsFile(folder, sf.Name); 
    }

    /// <summary>
    /// ZMĚNA
    /// Vytvořím nebo získám soubor a vrátím zda jeho velikost není 0
    /// </summary>
    /// <param name="fileName"></param>
    public static bool ExistsFile(StorageFolder sf, string fileName)
    {
        StorageFile file = TryGetStorageFile(sf, fileName);
#if DEBUG
        Debug.WriteLine("Existuje soubor " + fileName + ": " + (file != null).ToString());
#endif
        if (file != null)
        {
            // The file exists, "file" variable contains a reference to it.
            return true;
        }
        else
        {
            // The file doesn't exist.
            return false;
        }


    }

    public static bool ExistsFile(StorageFile sf)
    {
        var bp = sf.GetBasicPropertiesAsync();
        return GetResult<BasicProperties>( bp.AsTask()).Size != 0;
    }

    public static StorageFile TryGetStorageFile(StorageFolder sf, string fileName)
    {
        return GetResult<IStorageItem>( sf.TryGetItemAsync(fileName).AsTask()) as StorageFile;
    }

    public static string GetPathIfNotExists(StorageFolder sf, string fileName)
    {
        bool exists = FSApps.ExistsFile(sf, fileName);
        StorageFile file = GetResult<StorageFile>( sf.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists).AsTask()) as StorageFile;
        if (GetFileSize(file) != 0)
        {
            return null;
        }
        else
        {
            FSApps.DeleteFile(file);
            if (!exists)
            {
                return file.Path;
            }

        }
        return null;
    }

    public static ulong GetFileSize(StorageFile sf)
    {
        var bp = sf.GetBasicPropertiesAsync();
        return GetResult<BasicProperties>( bp.AsTask()).Size;
    }

    public static IRandomAccessStreamWithContentType OpenReadAsync(StorageFile item)
    {
        //bool found = false;
        IRandomAccessStreamWithContentType tem = null;
        try
        {
            tem = GetResult< IRandomAccessStreamWithContentType>( item.OpenReadAsync().AsTask());
            fileExc = FileExceptions.None;
            //found = true;
        }
        catch (System.IO.FileNotFoundException)
        {
            fileExc = FileExceptions.FileNotFound;

        }
        catch (UnauthorizedAccessException)
        {
            fileExc = FileExceptions.UnauthorizedAccess;

        }
        catch
        {
            fileExc = FileExceptions.General;

        }

        return tem;
    }

    public static List<StorageFolder> RecursivelyReturnAllFolders(string nameOfFolder, StorageFolder storageFolder)
    {
        List<StorageFolder> vr = new List<StorageFolder>();
        RecursivelyReturnAllFolders(nameOfFolder, storageFolder, vr);
        return vr;
    }

    private static void RecursivelyReturnAllFolders(string nameOfFolder, StorageFolder storageFolder, List<StorageFolder> vr)
    {
        IReadOnlyList<StorageFolder> sfs = GetResult< IReadOnlyList < StorageFolder >>( storageFolder.GetFoldersAsync().AsTask());
        foreach (StorageFolder item in sfs)
        {
            if (item.Name == nameOfFolder)
            {
                vr.Add(item);
            }
            RecursivelyReturnAllFolders(nameOfFolder, item, vr);
        }
    }

    public static string PathFromStorageFile(StorageFile arg)
    {
        return arg.Path;
    }

    /// <summary>
    /// Pokud chceš jen vytvořit složku, použij sf.CreateFolderAsync kde můžeš specifikovat co se má stát když složka již bude existovat
    /// Vytvoří složku A2 v A1. Pokud se nepodaří vytvořit, smaže všechny soubory ze složky A2(nekontroluje ale zda existuje a nesmaže samotnou složku)
    /// Pokud A3, odstraním prázdné složky z A1
    /// Pokud A4, vrátím objekt StorageFolder z A2 bez ohledu na jeho hodnotu nebo zda složka existuje
    /// </summary>
    /// <param name="sf"></param>
    /// <param name="slozka2"></param>
    /// <param name="odstranitPrazdneSlozky"></param>
    /// <param name="forceReturn"></param>
    public static StorageFolder GetStorageFolder(StorageFolder sf, string slozka2, bool odstranitPrazdneSlozky, bool forceReturn)
    {
        // Vytvořím složku A2 v A1, když se podaří, vrátím nově vytvořenou složku
        slozka2 = SH.RemoveLastCharIfIs(slozka2, AllChars.bs);
        StorageFolder vr = GetResult<StorageFolder>( sf.CreateFolderAsync(slozka2, CreationCollisionOption.OpenIfExists).AsTask());
        if (ExistsFolder(vr))
        {
            return vr;
        }
        // Odstraním všechny soubory z A2
        int pocetSlozek = SH.SplitNone(slozka2, AllStrings.bs).Length();
        FSApps.DeleteFiles(vr);

        // Pokud A3, odstraním prázdné složky z A1
        if (odstranitPrazdneSlozky)
        {
            string slozka = FS.GetDirectoryName(vr.Path);

            while (pocetSlozek > 1)
            {
                pocetSlozek--;
                StorageFolder mayDelete = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(slozka).AsTask());
                if ((GetResult<IReadOnlyList<StorageFolder>>( mayDelete.GetFoldersAsync().AsTask())).Count == 0)
                {
                    if ((GetResult<IReadOnlyList<StorageFile>>( mayDelete.GetFilesAsync().AsTask())).Count == 0)
                    {
                        slozka = FS.GetDirectoryName(mayDelete.Path);
                        FSApps.DeleteFiles(mayDelete);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        // Pokud A4, vrátím objekt StorageFolder bez ohledu na jeho hodnotu nebo zda složka existuje
        if (forceReturn)
        {
            return vr;
        }
        return null;
    }

    public  static bool? ExistsDirectorySync(string path)
    {
        //: 'Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED))'
        //var rootFolder = StorageFolder.GetFolderFromPathAsync(path).AsTask().GetAwaiter().GetResult();

        //UnauthorizedAccessException: Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED))
        StorageFolder rootFolder = null;

        try
        {
            rootFolder = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(path).AsTask());
        }
        catch (Exception ex)
        {
            // For example I try to access xlf in sunamo project. This is impossible in UWP and when return null, it's signal for use in other way
            return null;
        }

        return ExistsFolder(rootFolder) ;
    }

    public static bool ExistsDirectory(StorageFolder rootFolder)
    {
        return  ExistsFolder(rootFolder);
    }

    /// <summary>
    /// Vrátí mi zda v této složce je alespoň jeden soubor a/nebo adresář.
    /// </summary>
    /// <param name="mayDelete"></param>
    private static bool ExistsFolder(StorageFolder mayDelete)
    {
        if ((GetResult<IReadOnlyList< StorageFolder>>( mayDelete.GetFoldersAsync().AsTask())).Count == 0)
        {
            if ((GetResult<IReadOnlyList<StorageFile>>( mayDelete.GetFilesAsync().AsTask())).Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return true;
    }

    public static StorageFile GetStorageFileSync(StorageFolder folder, string file)
    {
        return GetStorageFile(folder, file);
    }

    public static StorageFile GetStorageFile(StorageFolder sf, string soubor)
    {
        return GetStorageFile(sf, soubor, false);
    }

    public static StorageFile GetStorageFile(StorageFolder sf, string soubor, bool odstranitPrazdneSlozky)
    {
        StorageFile vr = GetResult<StorageFile>( sf.CreateFileAsync(soubor, CreationCollisionOption.OpenIfExists).AsTask());
        if (ExistsFile(sf, soubor))
        {
            return vr;
        }

        int pocetSlozek = SH.SplitNone(soubor, AllStrings.bs).Length();
        FSApps.DeleteFile(vr);
        if (odstranitPrazdneSlozky)
        {
            string slozka = FS.GetDirectoryName(vr.Path);

            while (pocetSlozek > 1)
            {
                pocetSlozek--;
                StorageFolder mayDelete = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(slozka).AsTask());
                if ((GetResult<IReadOnlyList<StorageFolder>>( mayDelete.GetFoldersAsync().AsTask())).Count == 0)
                {
                    if ((GetResult< IReadOnlyList<StorageFile>>( mayDelete.GetFilesAsync().AsTask())).Count == 0)
                    {
                        slozka = FS.GetDirectoryName(mayDelete.Path);
                        FSApps.DeleteFiles(mayDelete);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        return null;
    }

    public static T GetResult<T>(Task<T> t)
    {
        return AsyncHelper.ci.GetResult<T>(t);
    }

    //public static StorageFile> GetStorageFile(StorageFile file)
    //{
    //    var folder = StorageFolder.GetFolderFromPathAsync(file.folder);
    //    return GetStorageFile(folder, file.file);
    //}
}
//}