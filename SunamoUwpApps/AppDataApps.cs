using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;
namespace apps
{
    /// <summary>
    /// Dont use async, but only async. Then I can use same signature in apps and wpf
    /// Path in UWP apps is quite different:
    /// C:\Users\n\AppData\Local\Packages\ecffba09-1695-4048-b61e-3419da53e92a_2rg71m35gnwm0\LocalState\sunamo\App1\Data
    /// </summary>
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
                    StorageFolder sf =  GetFolder(item);
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
            StorageFile sf = null;
            sf =  AppDataApps.ci.GetFile(AppFolders.Settings, path);
            string content =  TFApps.ReadFile(sf);
            bool vr = false;
            if (bool.TryParse(content.Trim(), out vr))
            {
                return vr;
            }
            return _def;
        }
        public int ReadFileOfSettingsInt(string name, int def)
        {
            return BTS.TryParseInt( ReadFile(AppFolders.Settings, name), def);
        }
        public int ReadFileOfSettingsIntValues(string name, int def, List<int> c, bool lowerOrEqual, bool larger)
        {
            int nt = BTS.TryParseInt( ReadFile(AppFolders.Settings, name), def);
            if (!c.Contains(nt))
            {
                nt = def;
            }
            else
            {
                if (c.Contains(nt))
                {
                    return nt;
                }
                if (c.Count > 1)
                {
                    // Nejdřív musím zjistit mezi kterými 2mi čísly to je valstně
                    for (int i = 0; i < c.Count - 1; i++)
                    {
                        if (nt >= c[i] && nt <= c[i + 1])
                        {
                            if (larger)
                            {
                                nt = c[i + 1];
                                break;
                            }
                            else
                            {
                                nt = c[i];
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (larger)
                    {
                        nt = c[1];
                    }
                    else
                    {
                        nt = c[0];
                    }
                }
            }
            if (lowerOrEqual)
            {
                if (nt > def)
                {
                    nt = def;
                }
            }
            return nt;
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
            StorageFile sf = null;
                sf =  AppDataApps.ci.GetFile(AppFolders.Settings, filename);
            string vr = TFApps.ReadFile(sf);
            return vr;
        }
        public  string ReadFile(AppFolders af, string filename)
        {
            StorageFile sf = null;
                sf =  AppDataApps.ci.GetFile(af, filename);
            
            //TFApps.CreateEmptyFileWhenDoesntExists(path);
            return  TFApps.ReadFile(sf);
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
        /// <param name="af"></param>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void SaveFile(AppFolders af, string file, string value)
        {
            StorageFile fileToSave =  GetFile(af, file);
             TFApps.SaveFile(value, fileToSave);
        }
        public T ReadFileOfSettingsEnum<T>(string fnAudioType, T def) where T : struct, IConvertible
        {
            T t = default(T);
            string e =  ReadFileOfSettingsOther(fnAudioType);
            if( Enum.TryParse<T>(fnAudioType, out t))
            {
                return t;
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
        /// <param name="af"></param>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public override void AppendToFile(AppFolders af, string file, string value)
        {
            StorageFile fileToSave =  GetFile(af, file);
             TFApps.AppendToFile(value, fileToSave);
        }
        public StorageFile Combine(AppFolders appFolders, string p1, string p2)
        {
            StorageFolder af =  GetFolder(appFolders);
            StorageFolder q1 =  FSApps.ExistsFolderCreateIfNot(af, p1);
            StorageFile q2 =  FSApps.ExistsFileCreateIfNot(q1, p2);
            return q2;
        }
        public List<StorageFile> GetFiles(AppFolders cache, string mask, string ext)
        {
            List<StorageFile> vr = new List<StorageFile>();
            mask = mask + ext;
            StorageFolder sfCache =  GetFolder(cache);
            QueryOptions qo = new QueryOptions(CommonFileQuery.DefaultQuery, CA.ToListString(ext));
            StorageFileQueryResult sfqr = sfCache.CreateFileQueryWithOptions(qo);
            IReadOnlyList<StorageFile> files = GetResult<IReadOnlyList<StorageFile>>( sfqr.GetFilesAsync().AsTask());
            foreach (var item in files)
            {
                //if (Wildcard.IsMatch(item.Name, mask))
                if(SH.MatchWildcard(item.Name, mask))
                {
                    vr.Add(item);
                }
            }
            return vr;
        }
        public bool ReadFileOfControlsBool(object name, bool v)
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
            StorageFolder ja =  FSApps.ExistsFolderCreateIfNot(sunamo, ThisApp.Name);
            return ja;
        }
        public override  StorageFolder GetFolder(AppFolders af)
        {
            // Toto je protože to zpomaluje, proto následující řádek je hovadina
            //return AsyncHelper.ci.RunAsyncWithoutAwait<StorageFolder, string>(
            var ja =  GetRootFolder();
            StorageFolder appFolder = FSApps.ExistsFolderCreateIfNot(ja, af.ToString());
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
        /// <param name="af"></param>
        /// <param name="file"></param>
        public override StorageFile GetFile(AppFolders af, string file)
        {
            StorageFolder sunamo =  GetSunamoFolder();
            StorageFolder ja =  FSApps.ExistsFolderCreateIfNot(sunamo, ThisApp.Name);
            StorageFolder appFolder =  FSApps.ExistsFolderCreateIfNot(ja, af.ToString());
            StorageFile vr = GetResult<StorageFile>( appFolder.CreateFileAsync(file, CreationCollisionOption.OpenIfExists).AsTask());
            return vr;
        }
        protected override void SaveFile(string content, StorageFile sf)
        {
            TFApps.SaveFile(content, sf);
        }
        public override void AppendToFile(string content, StorageFile sf)
        {
             TFApps.AppendToFile(content, sf);
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
        public T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
}