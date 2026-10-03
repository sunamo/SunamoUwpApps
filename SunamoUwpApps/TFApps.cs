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
    public static List<string> GetLines(StorageFile s)
    {
        var d = GetResult<IList<string>>( FileIO.ReadLinesAsync(s).AsTask());
        return d.ToList();
    }
    #endregion

    #region Sync
    #region ReadAllText
    public static string ReadAllTextSync(StorageFile sf)
    {
        return ReadFile(sf);
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
    public static void SaveFile(string p, string VybranySouborLogu)
    {
        SaveFile(p, GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(VybranySouborLogu).AsTask()), false);
    }

    public static void SaveFile(string p, StorageFile sf)
    {
        SaveFile(p, sf, false);
    }

    public static void SaveFile(string p, StorageFile sf, bool append)
    {
        if (append)
        {
            FileIO.AppendTextAsync((dynamic)sf, p);
        }
        else
        {
            FileIO.WriteTextAsync((dynamic)sf, p);
        }
    }
    #endregion


    #region ReadLines
    public static IEnumerable<string> ReadLines(StorageFile sf)
    {
        return SH.GetLinesList(ReadFile(sf));
    }
    #endregion

    #region AppendToFile
    public static void AppendToFile(string value, StorageFile fileToSave)
    {
         SaveFile(value, fileToSave, true);
    }
    #endregion

    #region WriteBuffer
    public static void WriteBuffer<StorageFile>(StorageFile sf, IBuffer buffProtectedData) where StorageFile : IStorageFile2
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

    public static string ReadFile(StorageFile s)
    {
        return GetResult<string>( FileIO.ReadTextAsync(s).AsTask());
    }



    public static string ReadFile(string s)
    {
        return  ReadFile(GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(s).AsTask()));
    }

    public static T GetResult<T>(Task<T> t)
    {
        return AsyncHelper.ci.GetResult<T>(t);
    }
    #endregion


}
