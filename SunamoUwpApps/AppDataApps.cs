namespace apps;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

    public class AppDataApps : AppDataAppsAbstractBase<StorageFolder, StorageFile>, IAsync
    {
static Type type = typeof(AppDataApps);
        public static AppDataApps ci = new AppDataApps();
        private AppDataApps()
        {
            rootFolder = GetRootFolder();
        }
        public async Task< bool> CreateAppFoldersIfDontExists()
        {
            if (!string.IsNullOrEmpty(ThisApp.Name))
            {
                foreach (AppFolders item in Enum.GetValues(typeof(AppFolders)))
                {
                    StorageFolder storageFolder =  GetFolder(item);
                }
            }
            else
            {
                    ThrowEx.Custom("The application name is not specified!");
            }
            return true;
        }
        /// <summary>
        /// If file A1 dont exists or have empty content, then create him with empty content and G false
        /// </summary>
        /// <param name="path"></param>
        public bool ReadFileOfSettingsBool(string path, bool _def)
        {
            StorageFile storageFile = null;
            storageFile =  AppDataApps.ci.GetFile(AppFolders.Settings, path);
            string content =  TFApps.ReadFile(storageFile);
            bool result = false;
            if (bool.TryParse(content.Trim(), out result))
            {
                return result;
            }
            return _def;
        }
        public int ReadFileOfSettingsInt(string name, int def)
        {
            return BTS.TryParseInt( ReadFile(AppFolders.Settings, name), def);
        }
        public int ReadFileOfSettingsIntValues(string name, int def, List<int> items, bool lowerOrEqual, bool larger)
        {
            int number = BTS.TryParseInt( ReadFile(AppFolders.Settings, name), def);
            if (!items.Contains(number))
            {
                number = def;
            }
            else
            {
                if (items.Contains(number))
                {
                    return number;
                }
                if (items.Count > 1)
                {
                    // Nejdřív musím zjistit mezi kterými 2mi čísly to je valstně
                    for (int index = 0; index < items.Count - 1; index++)
                    {
                        if (number >= items[index] && number <= items[index + 1])
                        {
                            if (larger)
                            {
                                number = items[index + 1];
                                break;
                            }
                            else
                            {
                                number = items[index];
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (larger)
                    {
                        number = items[1];
                    }
                    else
                    {
                        number = items[0];
                    }
                }
            }
            if (lowerOrEqual)
            {
                if (number > def)
                {
                    number = def;
                }
            }
            return number;
        }
        public int ReadFileOfControlsInt(string name, int def)
        {
            return BTS.TryParseInt( ReadFile(AppFolders.Controls, name), def);
        }
        public bool ReadFileOfControlsBool(string name, bool def)
        {
            return BTS.TryParseBool( ReadFile(AppFolders.Controls, name), def);
        }
        public  string ReadFileOfControls(string name)
        {
            return  AppDataApps.ci.ReadFile(AppFolders.Controls, name);
        }
        /// <summary>
        /// If file A1 dont exists or have empty content, then create him with empty content and G SE
        /// </summary>
        /// <param name="path"></param>
        public string ReadFileOfSettingsOther(string filename)
        {
            StorageFile storageFile = null;
                storageFile =  AppDataApps.ci.GetFile(AppFolders.Settings, filename);
            string result = TFApps.ReadFile(storageFile);
            return result;
        }
        public  string ReadFile(AppFolders appFolder, string filename)
        {
            StorageFile storageFile = null;
                storageFile =  AppDataApps.ci.GetFile(appFolder, filename);
            
            //TFApps.CreateEmptyFileWhenDoesntExists(path);
            return  TFApps.ReadFile(storageFile);
        }
        /// <summary>
        /// Save file A1 to folder AF Settings with value A2.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public  void SaveFileOfSettings(string file, string value)
        {
            StorageFile fileToSave =  GetFile(AppFolders.Settings, file);
             TFApps.SaveFile(value, fileToSave);
        }
        /// <summary>
        /// Save file A2 to AF A1 with contents A3
        /// </summary>
        /// <param name="appFolder"></param>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void SaveFile(AppFolders appFolder, string file, string value)
        {
            StorageFile fileToSave =  GetFile(appFolder, file);
             TFApps.SaveFile(value, fileToSave);
        }
        public T ReadFileOfSettingsEnum<T>(string fnAudioType, T def) where T : struct, IConvertible
        {
            T item = default(T);
            string text =  ReadFileOfSettingsOther(fnAudioType);
            if( Enum.TryParse<T>(fnAudioType, out item))
            {
                return item;
            }
            return def;
        }
        /// <summary>
        /// Just call TFApps.SaveFile
        /// </summary>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void SaveFile(StorageFile file, string value)
        {
             TFApps.SaveFile(value, file, false);
        }
        /// <summary>
        /// Append to file A2 in AF A1 with contents A3
        /// </summary>
        /// <param name="appFolder"></param>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public override void AppendToFile(AppFolders appFolder, string file, string value)
        {
            StorageFile fileToSave =  GetFile(appFolder, file);
             TFApps.AppendToFile(value, fileToSave);
        }
        public StorageFile Combine(AppFolders appFolders, string first, string second)
        {
            StorageFolder storageFolder =  GetFolder(appFolders);
            StorageFolder storageFolder2 =  FSApps.ExistsFolderCreateIfNot(storageFolder, first);
            StorageFile storageFile =  FSApps.ExistsFileCreateIfNot(storageFolder2, second);
            return storageFile;
        }
        public List<StorageFile> GetFiles(AppFolders cache, string mask, string ext)
        {
            List<StorageFile> result = new List<StorageFile>();
            mask = mask + ext;
            StorageFolder sfCache =  GetFolder(cache);
            QueryOptions queryOptions = new QueryOptions(CommonFileQuery.DefaultQuery, CA.ToListString(ext));
            StorageFileQueryResult sfqr = sfCache.CreateFileQueryWithOptions(queryOptions);
            IReadOnlyList<StorageFile> files = GetResult<IReadOnlyList<StorageFile>>( sfqr.GetFilesAsync().AsTask());
            foreach (var item in files)
            {
                //if (Wildcard.IsMatch(item.Name, mask))
                if(SH.MatchWildcard(item.Name, mask))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public bool ReadFileOfControlsBool(object name, bool value)
        {
            ThrowEx.NotImplementedMethod();
            return false;
        }
        /// <summary>
        /// Ending with name of app
        /// </summary>
        public override  StorageFolder GetRootFolder()
        {
            StorageFolder sunamo =  FSApps.ExistsFolderCreateIfNot(Windows.Storage.ApplicationData.Current.LocalFolder, "sunamo");
            StorageFolder storageFolder =  FSApps.ExistsFolderCreateIfNot(sunamo, ThisApp.Name);
            return storageFolder;
        }
        public override  StorageFolder GetFolder(AppFolders appFolder2)
        {
            // Toto je protože to zpomaluje, proto následující řádek je hovadina
            //return AsyncHelper.ci.RunAsyncWithoutAwait<StorageFolder, string>(
            var rootFolder =  GetRootFolder();
            StorageFolder appFolder = FSApps.ExistsFolderCreateIfNot(rootFolder, appFolder2.ToString());
            return appFolder;
        }
        public override  bool IsRootFolderOk()
        {
            if (IsRootFolderNull())
            {
                return false;
            }
            return  FSApps.ExistsDirectory(rootFolder);
        }
        /// <summary>
        /// G path file A2 in AF A1.
        /// Automatically create upfolder if there dont exists.
        /// </summary>
        /// <param name="appFolder2"></param>
        /// <param name="file"></param>
        public override StorageFile GetFile(AppFolders appFolder2, string file)
        {
            StorageFolder sunamo =  GetSunamoFolder();
            StorageFolder storageFolder =  FSApps.ExistsFolderCreateIfNot(sunamo, ThisApp.Name);
            StorageFolder appFolder =  FSApps.ExistsFolderCreateIfNot(storageFolder, appFolder2.ToString());
            StorageFile storageFile = GetResult<StorageFile>( appFolder.CreateFileAsync(file, CreationCollisionOption.OpenIfExists).AsTask());
            return storageFile;
        }
        protected override void SaveFile(string content, StorageFile storageFile)
        {
            TFApps.SaveFile(content, storageFile);
        }
        public override void AppendToFile(string content, StorageFile storageFile)
        {
             TFApps.AppendToFile(content, storageFile);
        }
        public override bool IsRootFolderNull()
        {
            StorageFolder def = default(StorageFolder);
            return EqualityComparer<StorageFolder>.Default.Equals(rootFolder, def);
        }
        public override  StorageFolder GetSunamoFolder()
        {
            var result =  FSApps.ExistsFolderCreateIfNot(Windows.Storage.ApplicationData.Current.LocalFolder, "sunamo");
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public override string GetFileCommonSettings(string key)
        {
            // base.RootFolderCommon return C:\Users\w\AppData\Roaming\sunamo 
            // which is useless in UWP, therefore must use ApplicationData.Current.LocalFolder
            var folder = ApplicationData.Current.LocalFolder;
            var file = FSApps.ExistsFileCreateIfNot(folder, key);
            
            return file.Path;
        }
        
        /// <summary>
        /// Return always in User's AppData
        /// </summary>
        /// <param name="inFolderCommon"></param>
        public override string RootFolderCommon(bool inFolderCommon)
        {
            //string appDataFolder = SpecialFO
            string sunamo2 = ApplicationData.Current.LocalFolder.Path;
            if (inFolderCommon)
            {
                return FS.Combine(sunamo2, "Common");
            }
            return sunamo2;
        }
        public override StorageFile GetFileInSubfolder(AppFolders output, string subfolder, string file, string ext)
        {
            return AppDataApps.ci.GetFile(AppFolders.Output, subfolder + "\\" + file + ext);
        }
        public T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
