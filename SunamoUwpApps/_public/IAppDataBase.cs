namespace SunamoUwpApps._sunamo;

public interface IAppDataBase<StorageFolder, StorageFile>
{
    string GetFileCommonSettings(string key);
    string RootFolderCommon(bool isInFolderCommon);
}
