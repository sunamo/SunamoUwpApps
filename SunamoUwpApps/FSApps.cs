namespace apps;

using apps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

public static class FSApps //: IAsync
{
    public static FileExceptions folderExc = FileExceptions.None;
    public static FileExceptions fileExc = FileExceptions.None;
    public static StorageFile file = null;
    public static StorageFolder folder = null;

    public static void DeleteFiles(StorageFolder storageFolder)
    {
        var files = GetResult<IReadOnlyList<StorageFile>>(storageFolder.GetFilesAsync().AsTask());
        foreach (var item in files)
        {
            DeleteFile(item);
        }
    }

    public static void DeleteFiles(List<StorageFile> items)
    {
        foreach (var item in items)
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
        catch (Exception exception)
        {
        }
    }

    public static void DeleteFilesWithSize(StorageFolder task, ulong value)
    {
        var files = GetResult<IReadOnlyList<StorageFile>>( task.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        foreach (var item in files)
        {
            if (FSApps.GetFileSize(item) == value)
            {
                try
                {
                    DeleteFile(item);
                }
                catch (Exception exception)
                {
                }
            }
        }
    }

    public static IReadOnlyList<StorageFile> GetFilesOfExtensionCaseInsensitive(StorageFolder storageFolder, string ext)
    {
        ext = ext.ToLower();
        List<StorageFile> result = new List<StorageFile>();
        var files = GetResult<IReadOnlyList<StorageFile>>( storageFolder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        foreach (var item in files)
        {
            if (item.Name.ToLower().EndsWith(ext))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public static List<StorageFile> GetFilesOfExtensionCaseInsensitiveRecursively(StorageFolder storageFolder, string ext)
    {
        List<StorageFile> files = new List<StorageFile>();
        files = FSApps.GetFilesRek(storageFolder, AllStrings.asterisk, files);
        for (int index = files.Count - 1; index >= 0; index--)
        {
            if (!files[index].Name.ToLower().EndsWith(ext))
            {
                files.RemoveAt(index);
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

    public static StorageFile ExistsFileCreateIfNot(StorageFolder storageFolder, string fileName)
    {
        file = AsyncHelperApps.ci.GetResult<StorageFile>( storageFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists));
        return file;
    }

    public static StorageFile RandomFileFromFolder(string value)
    {
        StorageFolder storageFolder = GetResult<StorageFolder>( StorageFolder.GetFolderFromPathAsync(value).AsTask());
        IReadOnlyList<StorageFile> files = GetResult< IReadOnlyList < StorageFile >>( storageFolder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery).AsTask());
        return RandomHelper.RandomElementOfCollectionT<StorageFile>(files);
    }

    public static StorageFolder ExistsFolderCreateIfNot(StorageFolder storageFolder, string folderName)
    {
        folder = AsyncHelperApps.ci.GetResult<StorageFolder>( storageFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists));
        return folder;
    }

    public static bool ExistsFileSync(StorageFile storageFile)
    {
        if (storageFile == null)
        {
            return false;
        }

        StorageFolder folder = GetResult<StorageFolder>( storageFile.GetParentAsync().AsTask());
        return ExistsFile(folder, storageFile.Name); 
    }

    /// <summary>
    /// ZMĚNA
    /// Vytvořím nebo získám soubor a vrátím zda jeho velikost není 0
    /// </summary>
    /// <param name="fileName"></param>
    public static bool ExistsFile(StorageFolder storageFolder, string fileName)
    {
        StorageFile file = TryGetStorageFile(storageFolder, fileName);
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

    public static bool ExistsFile(StorageFile storageFile)
    {
        var basicProperties = storageFile.GetBasicPropertiesAsync();
        return GetResult<BasicProperties>( basicProperties.AsTask()).Size != 0;
    }

    public static StorageFile TryGetStorageFile(StorageFolder storageFolder, string fileName)
    {
        return GetResult<IStorageItem>( storageFolder.TryGetItemAsync(fileName).AsTask()) as StorageFile;
    }

    public static string GetPathIfNotExists(StorageFolder storageFolder, string fileName)
    {
        bool exists = FSApps.ExistsFile(storageFolder, fileName);
        StorageFile file = GetResult<StorageFile>( storageFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists).AsTask()) as StorageFile;
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

    public static ulong GetFileSize(StorageFile storageFile)
    {
        var basicProperties = storageFile.GetBasicPropertiesAsync();
        return GetResult<BasicProperties>( basicProperties.AsTask()).Size;
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
        List<StorageFolder> result = new List<StorageFolder>();
        RecursivelyReturnAllFolders(nameOfFolder, storageFolder, result);
        return result;
    }

    private static void RecursivelyReturnAllFolders(string nameOfFolder, StorageFolder storageFolder, List<StorageFolder> result)
    {
        IReadOnlyList<StorageFolder> sfs = GetResult< IReadOnlyList < StorageFolder >>( storageFolder.GetFoldersAsync().AsTask());
        foreach (StorageFolder item in sfs)
        {
            if (item.Name == nameOfFolder)
            {
                result.Add(item);
            }
            RecursivelyReturnAllFolders(nameOfFolder, item, result);
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
    /// <param name="storageFolder"></param>
    /// <param name="slozka2"></param>
    /// <param name="odstranitPrazdneSlozky"></param>
    /// <param name="forceReturn"></param>
    public static StorageFolder GetStorageFolder(StorageFolder storageFolder, string slozka2, bool odstranitPrazdneSlozky, bool forceReturn)
    {
        // Vytvořím složku A2 v A1, když se podaří, vrátím nově vytvořenou složku
        slozka2 = SH.RemoveLastCharIfIs(slozka2, AllChars.bs);
        StorageFolder storageFolder2 = GetResult<StorageFolder>( storageFolder.CreateFolderAsync(slozka2, CreationCollisionOption.OpenIfExists).AsTask());
        if (ExistsFolder(storageFolder2))
        {
            return storageFolder2;
        }
        // Odstraním všechny soubory z A2
        int pocetSlozek = SH.SplitNone(slozka2, AllStrings.bs).Length();
        FSApps.DeleteFiles(storageFolder2);

        // Pokud A3, odstraním prázdné složky z A1
        if (odstranitPrazdneSlozky)
        {
            string slozka = FS.GetDirectoryName(storageFolder2.Path);

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
            return storageFolder2;
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
        catch (Exception exception)
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

    public static StorageFile GetStorageFile(StorageFolder storageFolder, string soubor)
    {
        return GetStorageFile(storageFolder, soubor, false);
    }

    public static StorageFile GetStorageFile(StorageFolder storageFolder, string soubor, bool odstranitPrazdneSlozky)
    {
        StorageFile storageFile = GetResult<StorageFile>( storageFolder.CreateFileAsync(soubor, CreationCollisionOption.OpenIfExists).AsTask());
        if (ExistsFile(storageFolder, soubor))
        {
            return storageFile;
        }

        int pocetSlozek = SH.SplitNone(soubor, AllStrings.bs).Length();
        FSApps.DeleteFile(storageFile);
        if (odstranitPrazdneSlozky)
        {
            string slozka = FS.GetDirectoryName(storageFile.Path);

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

    public static T GetResult<T>(Task<T> task)
    {
        return AsyncHelper.ci.GetResult<T>(task);
    }

    //public static StorageFile> GetStorageFile(StorageFile file)
    //{
    //    var folder = StorageFolder.GetFolderFromPathAsync(file.folder);
    //    return GetStorageFile(folder, file.file);
    //}
}
//}
