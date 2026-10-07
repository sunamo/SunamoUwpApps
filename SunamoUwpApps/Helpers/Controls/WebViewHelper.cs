namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System.Threading;
using Microsoft.UI.Xaml.Controls;

    public class WebViewHelper
    {
         WebView2 wv = new WebView2();
         bool loaded = false;
         string loadedSource = "";

        public WebViewHelper()
        {
            wv.NavigationCompleted += wv_LoadCompleted;
        }

         void wv_LoadCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs navigationCompletedEventArgs)
        {
            loaded = true;
            loadedSource = sender.Source?.ToString();
        }

        public  string GetStringAsync(string uri)
        {
            loadedSource = "";
            loaded = false;
            wv.Source = new Uri(uri);
            
            while (!loaded)
            {
                WorkItemHandler wih = new WorkItemHandler(WaitOneSecond);
                AsyncHelperApps.ci.GetResult( Windows.System.Threading.ThreadPool.RunAsync(wih));
                
            }
            return loadedSource;
        }

        void WaitOneSecond(IAsyncAction asyncAction)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));   
        }
    }
