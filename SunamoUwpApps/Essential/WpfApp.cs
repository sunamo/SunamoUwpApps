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

    public  class WpfApp : ThisApp
    {
        public WpfApp()
        {
            StatusSetted += WpfApp_StatusSetted;
        }

        private void WpfApp_StatusSetted(TypeOfMessage messageType, string message)
        {
            SetStatus(TypeOfMessage.Information, message);
        }

        public static IEssentialMainPage mp = null;
        public static bool withTime = true;
        
        public static CoreDispatcher cd = null;
        public static CoreDispatcherPriority cdp = CoreDispatcherPriority.Normal;


#if DEBUG
        public static void WriteDebug(string v)
        {
            Debug.WriteLine(v);
        }
#endif

        public static void SetStatusTimeMeter( TimeMeter timeMeter, string operation)
        {
            operation = timeMeter.Stop(operation);
            if (operation != null)
            {
                 SetStatus( TypeOfMessage.Information, operation, true);
            }
        }

        public static TextBlock tbLastOtherMessage;
        public static TextBlock tbLastErrorOrWarning;

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
