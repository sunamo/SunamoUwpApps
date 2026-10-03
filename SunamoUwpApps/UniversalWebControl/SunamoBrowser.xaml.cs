namespace apps.UniversalWebControl;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using HtmlAgilityPack;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Threading.Tasks;

    public sealed partial class SunamoBrowser : UserControl, ISunamoAppsBrowser<Control>, IAsync
    {
        public static Dictionary<WebView2, SunamoBrowser> webViewToSunamoBrowser = new Dictionary<WebView2, SunamoBrowser>();
        bool isNavigating = false;
        public ISunamoBrowserHost sbHost { get; set; }

        public bool IsNavigating
        {
            get
            {
                return isNavigating;
            }
            set
            {
                
                isNavigating = value;
            }
        }

        public SunamoBrowser()
        {
            
            
            this.InitializeComponent();

            instance = this;

            
            var wvt = new WebViewTag();
            webView.Tag = wvt;
            
            

            //webView.Navigate(new Uri("about:blank"));
            webViewToSunamoBrowser.Add(webView, this);

            GoBackCommand.Set(this);
            GoForwardCommand.Set(this);
            ReloadCommand.Set(this);
            StopLoadingCommand.Set(this);
        }

        ~SunamoBrowser()
        {
            if (webView != null)
            {
                webViewToSunamoBrowser.Remove(webView);
            }
            
        }

        public Uri Source
        {
            get
            {
                return webView.Source;
            }
            set
            {
                webView.Source = value;
            }
        }

        static SunamoBrowser instance = null;

        public static SunamoBrowser Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public WebView2 WebView
        {
            get
            {
                return webView;
            }

            set
            {
                if (webView.Tag == null)
                {

                }
                webView = value;
            }
        }
        
        HtmlDocument hd = null;

        public HtmlDocument HtmlDocument
        {
            
            set
            {
                hd = value;
            }
        }

        string ISunamoBrowser.HTML => html;

        public async Task <HtmlDocument> GetHtmlDocument()
        {
            if (IsNavigating)
            {
                return null;
            }
            hd = HtmlAgilityHelper.CreateHtmlDocument();
            var html = HTML();
            hd.LoadHtml(html);
            return hd;
        }

        public void Click(string buttonId)
        {
             Eval("document.getElementById('" + buttonId + "').click();");
        }

        string html = null;

        /// <summary>
        /// Sometimes is getting outer html quite slow so put await Task.Delay(500); before calling GetContent()
        /// </summary>
        public async Task< string> GetContent()
        {
            WebViewTag tag = webView.Tag as WebViewTag;
            // Zde je to v pořádku, sunamo.cz vrátí dobrý výsledek ale gc.com si to chrání
            tag.content = await Eval("document.documentElement.outerHTML;");

            while (!tag.content.Contains("<title"))
            {
                await Task.Delay(500);
                tag.content = await Eval("document.documentElement.outerHTML;");
            }

            html = tag.content;

            return tag.content;
        }

        public async Task<string> Eval(string javascript)
        {
            WebViewTag tag = webView.Tag as WebViewTag;

                try
                {
                    //await Task.Delay(1000);
                    string result = null;

                //WebView.InvokeScript method has been unavailable for releases after Windows 8.1. Instead, use InvokeScriptAsync
                result = await webView.ExecuteScriptAsync(javascript).AsTask().Conf() ;

                #region MyRegion
                //var await2 = wv.InvokeScriptAsync("eval", new List<string> { javascript });
                ////var await2 = wv.InvokeScriptAsync(javascript, CA.ToListString());
                //var task = await2.AsTask();
                //var awaiter = task.GetAwaiter();
                //// zde se zastaví
                //result = awaiter.GetResult(); 
                #endregion

                //result = AsyncHelperApps.ci.GetResult<string>( webView.InvokeScriptAsync("eval", new List<string> { javascript }));
                return 
                    result;

                    /*
                     * Without GetAwaiter - Method was calling in unexcepted time
                     * await wv.InvokeScriptAsync("eval", new List<string> { javascript }); - never end
                     * add await Task.Delay(1000); - the same
                     * 
                     * https://stackoverflow.com/a/6642936/9327173 InvokeScript by mělo být voláno až po LoadComplete ale u mě to nefunguje
                     * 
                     * WebView.InvokeScript method has been unavailable for releases after Windows 8.1. Instead, use InvokeScriptAsync
                     */

                    return result;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Exception from HRESULT: 0x80020101")
                    {
                        return string.Empty;
                    }
                }
            
            return string.Empty;
        }

        public override string ToString()
        {
            return (webView.Tag as WebViewTag).toString;

        }

        public string HTML()
        {
            return (webView.Tag as WebViewTag).content;
            //try
            //{
            //    var c = string.Empty;
            //    //c =GetResult<string>(  GetContent(wv));
            //    string val = c;
            //    return val;
            //}
            //catch (Exception ex)
            //{
            //    return "";
            //}
        }


        public event VoidUri SourceUpdated;

        private void webView_NavigationStarting(WebView2 sender, CoreWebView2NavigationStartingEventArgs args)
        {
                if (sbHost.lastOpenedSunamoBrowserAlsoInBackground.webView != sender && sbHost.SelectedWebView() == sender)
                {
                IsNavigating = true;
            }
            if (SourceUpdated != null)
            {
                SourceUpdated(new Uri(args.Uri));
            }
        }

        private void webView_NavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            IsNavigating = false;
            //bool b = cmdStopLoadingCommand.CanExecute(null);
        }

        public async Task Navigate(Uri uri)
        {
            webView.Source = uri;
            //webView.Source = uri;

        }

        public bool ScrollToEnd()
        {
            return false;
        }

        public void Init()
        {
            
        }

        public T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }

        public void Navigate(string uri)
        {
             Navigate(new Uri(uri));
        }
    }
