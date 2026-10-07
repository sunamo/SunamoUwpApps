namespace apps.Logger;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Microsoft.UI.Xaml.Controls;

    public class LogService : LogServiceAbstract<Color, StorageFile>, IAsync
    {
static Type type = typeof(LogService);
        public static  LogService Instance = new LogService();

        public override Color GetBackgroundBrushOfTypeOfMessage(TypeOfMessage messageType)
        {
            switch (messageType)
            {
                case TypeOfMessage.Error:
                    return Colors.LightCoral;
                case TypeOfMessage.Warning:
                    return Colors.LightYellow;
                case TypeOfMessage.Information:
                    return Colors.White;
                case TypeOfMessage.Ordinal:
                    return Colors.White;
                case TypeOfMessage.Appeal:
                    return Colors.LightGray;
                case TypeOfMessage.Success:
                    return Colors.LightGreen;
                default:
                    return Colors.White;
            }
        }
        public override Color GetForegroundBrushOfTypeOfMessage(TypeOfMessage messageType)
        {
            switch (messageType)
            {
                case TypeOfMessage.Error:
                    return Colors.DarkRed;
                case TypeOfMessage.Warning:
                    return Colors.DarkOrange;
                case TypeOfMessage.Information:
                    return Colors.Black;
                case TypeOfMessage.Ordinal:
                    return Colors.Black;
                case TypeOfMessage.Appeal:
                    return Colors.Gray;
                case TypeOfMessage.Success:
                    return Colors.LightGreen;
                default:
                    return Colors.White;
            }
        }
        public LogService()
        {
        }

        TextBlock tssl = null;
        LogMessageAbstract<Color, StorageFile> prectenyRadek;
        bool HasRowContent(string text)
        {
            // Must set prectenyRadek here
            prectenyRadek = null;
            return true;
        }

         LogMessageAbstract<Color, StorageFile> Parse(LogMessageAbstract<Color, StorageFile> logMessageAbstract)
        {
            return null;
        }

        protected override List<LogMessageAbstract<Color, StorageFile>> ReadMessagesFromFile(StorageFile fileStream)
        {
            Stream stream = GetResult<Stream>( fileStream.OpenStreamForReadAsync());
            StreamReader streamReader = new StreamReader(stream);
            List<LogMessageAbstract<Color, StorageFile>> result = new List<LogMessageAbstract<Color, StorageFile>>();
            // Zde by se prazdne radky nemeli vyskytovat, ale v jinych programech ano!
            while (HasRowContent(streamReader.ReadLine()))
            {
                LogMessageAbstract<Color, StorageFile> zpravaLogu = CreateMessage();
                zpravaLogu = Parse(prectenyRadek);
                if (zpravaLogu != null)
                {
                    result.Add(zpravaLogu);
                }
                
            }
            streamReader.Dispose();
            return result;
        }
     
        public  void Initialize(string soubor, bool invariant, TextBlock tssl, Langs language)
        {
            InitializeAbstract(invariant, language);
            this.tssl = tssl;
        }
        private void InitializeAbstract(bool invariant, Langs language)
        {
            ThrowEx.NotImplementedMethod();
        }
        protected override LogMessageAbstract<Color, StorageFile> CreateMessage()
        {
            return new LogMessage();
        }
        public override LogMessageAbstract<Color, StorageFile> Add(TypeOfMessage messageType, string status)
        {
            ThrowEx.NotImplementedMethod();
            return null;
        }
        public override void SaveToFile()
        {
            ThrowEx.NotImplementedMethod();
        }
        public T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
