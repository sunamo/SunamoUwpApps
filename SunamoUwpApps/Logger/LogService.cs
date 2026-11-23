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

    /// <summary>
    /// Represents the log service type.
    /// </summary>
    public class LogService : LogServiceAbstract<Color, StorageFile>, IAsync
    {
static Type type = typeof(LogService);
        /// <summary>
        /// The instance.
        /// </summary>
        public static  LogService Instance = new LogService();

        /// <summary>
        /// Get background brush of type of message.
        /// </summary>
        /// <param name="messageType">The message type.</param>
        /// <returns>The get background brush of type of message result.</returns>
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
        /// <summary>
        /// Get foreground brush of type of message.
        /// </summary>
        /// <param name="messageType">The message type.</param>
        /// <returns>The get foreground brush of type of message result.</returns>
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
        /// <summary>
        /// Initializes a new instance of the log service class.
        /// </summary>
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

        /// <summary>
        /// Read messages from file.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <returns>The read messages from file result.</returns>
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
     
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="soubor">The soubor.</param>
        /// <param name="invariant">The invariant.</param>
        /// <param name="tssl">The tssl.</param>
        /// <param name="language">The language.</param>
        public  void Initialize(string soubor, bool invariant, TextBlock tssl, Langs language)
        {
            InitializeAbstract(invariant, language);
            this.tssl = tssl;
        }
        private void InitializeAbstract(bool invariant, Langs language)
        {
            ThrowEx.NotImplementedMethod();
        }
        /// <summary>
        /// Create message.
        /// </summary>
        /// <returns>The create message result.</returns>
        protected override LogMessageAbstract<Color, StorageFile> CreateMessage()
        {
            return new LogMessage();
        }
        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="messageType">The message type.</param>
        /// <param name="status">The status.</param>
        /// <returns>The add result.</returns>
        public override LogMessageAbstract<Color, StorageFile> Add(TypeOfMessage messageType, string status)
        {
            ThrowEx.NotImplementedMethod();
            return null;
        }
        /// <summary>
        /// Save to file.
        /// </summary>
        public override void SaveToFile()
        {
            ThrowEx.NotImplementedMethod();
        }
        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
