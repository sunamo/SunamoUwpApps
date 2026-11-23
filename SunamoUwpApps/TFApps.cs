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

    /// <summary>
    /// Represents the TF apps type.
    /// </summary>
    public static class TFApps 
    {
    #region GetLines
    /// <summary>
    /// Get lines.
    /// </summary>
    /// <param name="storageFile">The storage file.</param>
    /// <returns>The get lines result.</returns>
    public static List<string> GetLines(StorageFile storageFile)
    {
        var lines = GetResult<IList<string>>( FileIO.ReadLinesAsync(storageFile).AsTask());
        return lines.ToList();
    }
    #endregion

    #region Sync
    #region ReadAllText
    /// <summary>
    /// Read all text sync.
    /// </summary>
    /// <param name="storageFile">The storage file.</param>
    /// <returns>The read all text sync result.</returns>
    public static string ReadAllTextSync(StorageFile storageFile)
    {
        return ReadFile(storageFile);
    }
    #endregion

    #region ReadAllText
    /// <summary>
    /// Write all text sync.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="content">The content.</param>
    public static void WriteAllTextSync(StorageFile file, string content)
    {

        SaveFile(content, file, false);
    }
    #endregion 
    #endregion

    #region SaveFile
    /// <summary>
    /// Save file.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="VybranySouborLogu">The vybrany soubor logu.</param>
    public static void SaveFile(string path, string VybranySouborLogu)
    {
        SaveFile(path, GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(VybranySouborLogu).AsTask()), false);
    }

    /// <summary>
    /// Save file.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="storageFile">The storage file.</param>
    public static void SaveFile(string path, StorageFile storageFile)
    {
        SaveFile(path, storageFile, false);
    }

    /// <summary>
    /// Save file.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="storageFile">The storage file.</param>
    /// <param name="append">The append.</param>
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
    /// <summary>
    /// Read lines.
    /// </summary>
    /// <param name="storageFile">The storage file.</param>
    /// <returns>The read lines result.</returns>
    public static IEnumerable<string> ReadLines(StorageFile storageFile)
    {
        return SH.GetLinesList(ReadFile(storageFile));
    }
    #endregion

    #region AppendToFile
    /// <summary>
    /// Append to file.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="fileToSave">The file to save.</param>
    public static void AppendToFile(string value, StorageFile fileToSave)
    {
         SaveFile(value, fileToSave, true);
    }
    #endregion

    #region WriteBuffer
    /// <summary>
    /// Write buffer storage file.
    /// </summary>
    /// <typeparam name="StorageFile">The type StorageFile.</typeparam>
    /// <param name="storageFile">The storage file.</param>
    /// <param name="buffProtectedData">The buff protected data.</param>
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

    /// <summary>
    /// Read file.
    /// </summary>
    /// <param name="storageFile">The storage file.</param>
    /// <returns>The read file result.</returns>
    public static string ReadFile(StorageFile storageFile)
    {
        return GetResult<string>( FileIO.ReadTextAsync(storageFile).AsTask());
    }



    /// <summary>
    /// Read file.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The read file result.</returns>
    public static string ReadFile(string text)
    {
        return  ReadFile(GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(text).AsTask()));
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
    #endregion


}
