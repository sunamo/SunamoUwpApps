using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps.Essential;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Microsoft.UI.Xaml;

namespace apps
{
    public static class PageHelper
    {
        /// <summary>
        /// Pokud má být aplikace použitelná na mobilech, A1 musí být vždy True
        /// Pokud bude false, vrátí se výška i šířka 2x delší než jaká ve skutečnosti je(resp. vrátí se správná - 720x1136 ale na obrazovku se zvládne vykreslit jen 360x568)
        /// </summary>
        /// <param name="noScaleFactor"></param>
        public static Size WindowSize(bool noScaleFactor)
        {
            
                var sf = DisplayHelper.GetScaleFactor();
                var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
                double width = bounds.Width;
                double height = bounds.Height;

            if (noScaleFactor)
            {
                sf = 1;
            }
                return new Size(width *sf, height *sf);
            
        }

        public async static Task SetStatus(LogMessageAbstract<Color, StorageFile> lmn, bool alsoLb)
        {
            if (alsoLb)
            {
                 RefreshLogs(lmn);
            }
            var st = lmn.st;
            var status = lmn.Message;
            WpfApp.SetStatusToTextBlock(st, status);
        }

        /// <summary>
        /// Add log 
        /// </summary>
        /// <param name="lm"></param>
        private static void RefreshLogs(LogMessageAbstract<Color, StorageFile> lm)
        {
            // WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            //{
            //    WpfApp.mp.ListBoxLogs.Children.Insert(0, WpfControlGenerator.LogMessage(lm));
            //}).AsTask().Conf();
        }
    }
}