namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

    public class FileNameWithDateTime
    {
static Type type = typeof(FileNameWithDateTime);
        public DateTime dt = DateTime.MinValue;
        public string name = "";
        /// <summary>
        /// Pokud bude vyplněná, nebude se používat čas, který i tak bude uložen v proměnné dt
        /// </summary>
        public int? serie = null;
        public string fnwoe = "";
        public int SerieValue
        {
            get
            {
                return serie.Value;
            }
        }
        string displayText = null;
        string row1 = null;
        string row2 = null;
        public FileNameWithDateTime(string row1, string row2)
        {
            this.displayText = row1 + AllStrings.space + row2;
            this.row1 = row1;
            this.row2 = row2;
        }
        public string Row1 { get { return row1; } }
        public string Row2 { get { return row2; } }
        public override string ToString()
        {
            return displayText;
        }
    }
    public class DateTimeFileIndex
    {
        public event VoidString RaisedException;
        public event VoidT<List<FileNameWithDateTime>> InitComplete;
        StorageFolder folder = null;
        string ext = null;
        //SunamoDictionary<string, DateTime> dict = new SunamoDictionary<string, DateTime>();
        public List<FileNameWithDateTime> files = new List<FileNameWithDateTime>();
        FileEntriesDuplicitiesStrategy ds = FileEntriesDuplicitiesStrategy.Time;
        Langs l = Langs.cs;
        public DateTimeFileIndex(AppFolders appFolder, string ext, FileEntriesDuplicitiesStrategy duplicitiesStrategy, bool addPostfix)
        {
            Initialize(appFolder, ext, duplicitiesStrategy, addPostfix);
        }
        async Task Initialize(AppFolders appFolder, string ext, FileEntriesDuplicitiesStrategy duplicitiesStrategy, bool addPostfix)
        {
            this.ds = duplicitiesStrategy;
            this.folder = AppDataApps.ci.GetFolder(appFolder);
            this.ext = ext;
            string mask = "????_??_??_";
            if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Serie)
            {
                mask += "S_?*_";
            }
            else if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Time)
            {
                mask += "??_??_";
            }
            else
            {
                ThrowEx.Custom("Not supported strategy of saving files.");
            }
            mask += AllStrings.asterisk;
            if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Serie)
            {
                files.Sort(new CompareFileNameWithDateTimeBySerie().Desc);
            }
            files.Sort(new CompareFileNameWithDateTimeByDateTime().Desc);
            InitComplete(files);
        }
        private static string GetDisplayText(DateTime date, int? serie, Langs language)
        {
            string displayText;
            if (serie == null)
            {
                displayText = DTHelper.DateTimeToString(date, language, SqlServerHelper.DateTimeMinVal);
            }
            else
            {
                int ser = serie.Value;
                string addSer = "";
                if (ser != 0)
                {
                    addSer = " (" + ser + AllStrings.rb;
                }
                displayText = DTHelper.DateToString(date, language) + addSer;
            }
            return displayText;
        }
        private FileNameWithDateTime CreateObjectFileNameWithDateTime(string row1, string row2, DateTime date, int? serie, string postfix, string fnwoe)
        {
            FileNameWithDateTime add = new FileNameWithDateTime(row1, row2);
            add.dt = date;
            add.serie = serie;
            add.name = postfix;
            add.fnwoe = DeleteWrongCharsInFileName(fnwoe);
            return add;
        }
        string DeleteWrongCharsInFileName(string fnwoe)
        {
            return SH.ReplaceAll(FS.DeleteWrongCharsInFileName(fnwoe, false), AllStrings.lowbar, AllStrings.space);
        }
        public async Task DeleteFile(FileNameWithDateTime fileName)
        {
            try
            {
                StorageFile storageFile = await GetStorageFile(fileName);
                //File.Delete(t);
                FSApps.DeleteFile( storageFile);
                files.Remove(fileName);
            }
            catch (Exception exception)
            {
                RaisedException(sess.i18n("FileCannotBeDeleted"));
            } 
        }
        public async Task<StorageFile> GetStorageFile(FileNameWithDateTime fileName)
        {
            return FSApps.GetStorageFile(folder, fileName.fnwoe + ext);
            //return FS.Combine(folder, o.fnwoe + ext);
        }
        /// <summary>
        /// Zapíše soubor FileEntriesDuplicitiesStrategy se strategií specifikovanou v konstruktoru
        /// Nepřidává do kolekce files, vrací objekt 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        public async Task< FileNameWithDateTime> SaveFileWithDate(string name, string content)
        {
            DateTime dateTime = DateTime.Now;
            DateTime today = DateTime.Today;
            string fnwoe = "";
            int? max = null;
            if (ds == FileEntriesDuplicitiesStrategy.Time)
            {
                fnwoe = name + AllStrings.lowbar + DTHelper.DateTimeToFileName(dateTime, true);
            }
            else if (ds == FileEntriesDuplicitiesStrategy.Serie)
            {
                IEnumerable<int?> values = files.Where(file => file.dt == today).Select(file2 => file2.serie);
                
                if (values.Count() != 0)
                {
                    max = values.Max() + 1;
                }
                if (!max.HasValue)
                {
                    max = 1;
                }
                fnwoe = DTHelper.DateTimeToFileName(dateTime, false) + "_S_" + max.Value + AllStrings.lowbar + name;
            }
            else
            {
                // Zbytečné, kontroluje se již v konstruktoru
            }
            StorageFile storageFile = FSApps.GetStorageFile(folder, DeleteWrongCharsInFileName( fnwoe) + ext);
            TFApps.SaveFile(content, storageFile);
            return CreateObjectFileNameWithDateTime(GetDisplayText(dateTime, max, l), name, dateTime, max, name, fnwoe);
        }
    }
    public class CompareFileNameWithDateTimeBySerie : ISunamoComparer<FileNameWithDateTime>
    {
        public int Desc(FileNameWithDateTime fileName, FileNameWithDateTime fileName2)
        {
            return fileName.SerieValue.CompareTo(fileName2.SerieValue) * -1;
        }
        public int Asc(FileNameWithDateTime fileName, FileNameWithDateTime fileName2)
        {
            return fileName.SerieValue.CompareTo(fileName2.SerieValue);
        }
    }
    public class CompareFileNameWithDateTimeByDateTime : ISunamoComparer<FileNameWithDateTime>
    {
        public int Desc(FileNameWithDateTime fileName, FileNameWithDateTime fileName2)
        {
            return fileName.dt.CompareTo(fileName2.dt) * -1;
        }
        public int Asc(FileNameWithDateTime fileName, FileNameWithDateTime fileName2)
        {
            return fileName.dt.CompareTo(fileName2.dt);
        }
    }
