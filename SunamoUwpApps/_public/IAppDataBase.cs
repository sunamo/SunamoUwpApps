namespace apps._public;

public interface IAppDataBase<StorageFolder, StorageFile>
{
    string GetFileCommonSettings(string key);
    string RootFolderCommon(bool isInFolderCommon);
}
