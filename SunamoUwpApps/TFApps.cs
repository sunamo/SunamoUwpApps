namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

    public static class TFApps 
    {
    #region GetLines
    public static List<string> GetLines(StorageFile storageFile)
    {
        var lines = GetResult<IList<string>>( FileIO.ReadLinesAsync(storageFile).AsTask());
        return lines.ToList();
    }
    #endregion

    #region Sync
    #region ReadAllText
    public static string ReadAllTextSync(StorageFile storageFile)
    {
        return ReadFile(storageFile);
    }
    #endregion

    #region ReadAllText
    public static void WriteAllTextSync(StorageFile file, string content)
    {

        SaveFile(content, file, false);
    }
    #endregion 
    #endregion

    #region SaveFile
    public static void SaveFile(string path, string VybranySouborLogu)
    {
        SaveFile(path, GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(VybranySouborLogu).AsTask()), false);
    }

    public static void SaveFile(string path, StorageFile storageFile)
    {
        SaveFile(path, storageFile, false);
    }

    public static void SaveFile(string path, StorageFile storageFile, bool append)
    {
        if (append)
        {
            FileIO.AppendTextAsync((dynamic)storageFile, path);
        }
        else
        {
            FileIO.WriteTextAsync((dynamic)storageFile, path);
        }
    }
    #endregion


    #region ReadLines
    public static IEnumerable<string> ReadLines(StorageFile storageFile)
    {
        return SH.GetLinesList(ReadFile(storageFile));
    }
    #endregion

    #region AppendToFile
    public static void AppendToFile(string value, StorageFile fileToSave)
    {
         SaveFile(value, fileToSave, true);
    }
    #endregion

    #region WriteBuffer
    public static void WriteBuffer<StorageFile>(StorageFile storageFile, IBuffer buffProtectedData) where StorageFile : IStorageFile2
    {
        //FileIO.WriteBufferAsync
         System.Threading.Tasks.Task.FromResult<object>(null);
    }
    #endregion

    #region ReadFile
    //public static string> ReadFile(sunamo.Data.StorageFile sf)
    //{
    //    return ReadFile(FSApps.GetStorageFile(sf));
    //}

    public static string ReadFile(StorageFile storageFile)
    {
        return GetResult<string>( FileIO.ReadTextAsync(storageFile).AsTask());
    }



    public static string ReadFile(string text)
    {
        return  ReadFile(GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(text).AsTask()));
    }

    public static T GetResult<T>(Task<T> task)
    {
        return AsyncHelper.ci.GetResult<T>(task);
    }
    #endregion


}
