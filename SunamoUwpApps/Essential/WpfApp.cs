namespace apps.Essential;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the wpf app type.
    /// </summary>
    public  class WpfApp : ThisApp
    {
        /// <summary>
        /// Initializes a new instance of the wpf app class.
        /// </summary>
        public WpfApp()
        {
            StatusSetted += WpfApp_StatusSetted;
        }

        private void WpfApp_StatusSetted(TypeOfMessage messageType, string message)
        {
            SetStatus(TypeOfMessage.Information, message);
        }

        /// <summary>
        /// The mp.
        /// </summary>
        public static IEssentialMainPage mp = null;
        /// <summary>
        /// The with time.
        /// </summary>
        public static bool withTime = true;
        
        /// <summary>
        /// The cd.
        /// </summary>
        public static CoreDispatcher cd = null;
        /// <summary>
        /// The cdp.
        /// </summary>
        public static CoreDispatcherPriority cdp = CoreDispatcherPriority.Normal;


#if DEBUG
        /// <summary>
        /// Write debug.
        /// </summary>
        /// <param name="v">The v.</param>
        public static void WriteDebug(string v)
        {
            Debug.WriteLine(v);
        }
#endif

        /// <summary>
        /// Set status time meter.
        /// </summary>
        /// <param name="timeMeter">The time meter.</param>
        /// <param name="operation">The operation.</param>
        public static void SetStatusTimeMeter( TimeMeter timeMeter, string operation)
        {
            operation = timeMeter.Stop(operation);
            if (operation != null)
            {
                 SetStatus( TypeOfMessage.Information, operation, true);
            }
        }

        /// <summary>
        /// The tb last other message.
        /// </summary>
        public static TextBlock tbLastOtherMessage;
        /// <summary>
        /// The tb last error or warning.
        /// </summary>
        public static TextBlock tbLastErrorOrWarning;

        /// <summary>
        /// Set status to text block.
        /// </summary>
        /// <param name="messageType">The message type.</param>
        /// <param name="status">The status.</param>
        public static void SetStatusToTextBlock(TypeOfMessage messageType, string status)
        {
            Color color = LogService.Instance .GetForegroundBrushOfTypeOfMessage(messageType);
            if (messageType == TypeOfMessage.Error || messageType == TypeOfMessage.Warning)
            {
                 SetForeground(tbLastErrorOrWarning,  color);
                 SetText(tbLastErrorOrWarning, status);
            }
            else
            {
                 SetForeground(tbLastOtherMessage, color);
                 SetText(tbLastOtherMessage, status);
            }
        }


        /// <summary>
        /// Use all Uap apps
        /// Another way is use ThisApp.StatusSetted redirected to this
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="status"></param>
        /// <param name="alsoLb"></param>
        public async static Task SetStatus(TypeOfMessage messageType, string status, bool alsoLb = true)
        {
#if DEBUG
            WriteDebug(status);
#endif
            
            status = DTHelper.TimeToStringAngularTime(DateTime.Now) + AllStrings.space + status;
            LogMessageAbstract<Color, StorageFile> lmn = null;
            //if (alsoLb)
            //{
            //    lmn = mp.lsg.Add(st, status);
            //    //lbLogs.RefreshLb(ls.messagesActualSession2);
            //}
            //else
            //{
                lmn =  new LogMessage().Initialize(DateTime.Now, messageType, status, LogService.Instance.GetBackgroundBrushOfTypeOfMessage(messageType));
            //}
            await PageHelper.SetStatus(lmn, alsoLb);

        }

        /// <summary>
        /// Set foreground.
        /// </summary>
        /// <param name="tbLastOtherMessage">The tb last other message.</param>
        /// <param name="color">The color.</param>
        public static void SetForeground(TextBlock tbLastOtherMessage, Color color)
        {
            if (tbLastOtherMessage != null)
            {
                cd.RunAsync(cdp, () =>
                {
                    tbLastOtherMessage.Foreground = new SolidColorBrush(color);
                }).AsTask().Conf();
            }
        }

        /// <summary>
        /// Set text.
        /// </summary>
        /// <param name="lblStatusDownload">The lbl status download.</param>
        /// <param name="status">The status.</param>
        public static void SetText(TextBlock lblStatusDownload, string status)
        {
            if (lblStatusDownload != null)
            {
                cd.RunAsync(cdp, () =>
               {
                   lblStatusDownload.Text = status;
               }).AsTask().Conf();
            }
        }

        /// <summary>
        /// Set is enabled.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <param name="value">The value.</param>
        public static void SetIsEnabled(Control uie, bool? value)
        {
            if (value.HasValue)
            {
                 cd.RunAsync(cdp, () =>
                {
                    uie.IsEnabled = value.Value;
                }).AsTask().Conf();
            }
        }

        /// <summary>
        /// Set visibility.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <param name="visibility">The visibility.</param>
        public static void SetVisibility(UIElement uie, Visibility? visibility)
        {
            if (visibility.HasValue)
            {
                cd.RunAsync(cdp, () =>
                {
                    uie.Visibility = visibility.Value;
                }).AsTask().Conf();
            }
        }

        /// <summary>
        /// Set border brush.
        /// </summary>
        /// <param name="borderDoManagePhotogallery">The border do manage photogallery.</param>
        /// <param name="Value">The value.</param>
        public static void SetBorderBrush(Border borderDoManagePhotogallery, SolidColorBrush Value)
        {
            if(Value != null)
            {
                AsyncHelperApps.ci.GetResult( cd.RunAsync(cdp, () =>
                {
                    borderDoManagePhotogallery.BorderBrush = Value;
                }));
            }
        }

        /// <summary>
        /// POkud se nepodaří získat vrátí null
        /// </summary>
        /// <param name="borderDoManagePhotogallery"></param>
        public static SolidColorBrush GetBorderBrush(Border borderDoManagePhotogallery)
        {
            SolidColorBrush solidColorBrush = null;
            AsyncHelperApps.ci.GetResult( cd.RunAsync(cdp, () =>
            {
                solidColorBrush = (SolidColorBrush)borderDoManagePhotogallery.BorderBrush;
            }));
            return solidColorBrush;
        }
    }
