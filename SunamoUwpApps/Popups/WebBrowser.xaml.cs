namespace apps.Popups;

using ImageHelper = apps.Helpers.Controls.ImageHelper;
using apps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

    /// <summary>
    /// Represents the web browser type.
    /// </summary>
    public sealed partial class WebBrowser : UserControl, IPopupWholeScreen
    {
        Uri uri = null;
        bool canGoBack = false;
        bool canGoNext = false;
        List<Uri> lastUri = new List<Uri>();
        int actualIndex = 0;
        /// <summary>
        /// The custom button click.
        /// </summary>
        public event UriEventHandler CustomButtonClick;
        /// <summary>
        /// The close button click.
        /// </summary>
        public event VoidVoid CloseButtonClick;
        string homeAdressWithoutHttp = null;
        /// <summary>
        /// The load completed.
        /// </summary>
        public event LoadCompletedEventHandler LoadCompleted;
        bool reload = false;
        List<bool> backnext = new List<bool>();

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        /// <summary>
        /// Initializes a new instance of the web browser class.
        /// </summary>
        /// <param name="TextCustomButton">The text custom button.</param>
        /// <param name="homeAdressWithoutHttp">The home adress without http.</param>
        public WebBrowser(string TextCustomButton, string homeAdressWithoutHttp)
        {
            this.InitializeComponent();
            this.homeAdressWithoutHttp = homeAdressWithoutHttp;
            btnBack.Content = ImageHelper.MsAppx(true, AppPics.Previous);
            btnNext.Content = ImageHelper.MsAppx(true, AppPics.Next);
            btnReload.Content = ImageHelper.MsAppx(false, AppPics.Reload);
            btnHome.Content = ImageHelper.MsAppx(false, AppPics.Home);
            btnClose.Content = ImageHelper.MsAppx(false, AppPics.Logout);
            

            if (AppLangHelper.currentUICulture.TwoLetterISOLanguageName == "cs")
            {
                ttBtnBack.Content = "Zpět";
                ttBtnNext.Content = "Vpřed";
                ttBtnReload.Content = "Znovu načíst";
                ttBtnHome.Content = "Domů na " + homeAdressWithoutHttp;
                ttBtnClose.Content = "Zavřít prohlížeč";
            }
            else
            {
                ttBtnBack.Content = "Back";
                ttBtnNext.Content = "Next";
                ttBtnReload.Content = "Reload";
                ttBtnHome.Content = "Home to " + homeAdressWithoutHttp;
                ttBtnHome.Content = "Close webbrowser";
            }

            if (TextCustomButton != "")
            {
                btnCustom.Content = ImageHelper.MsAppx(true, AppPics.BoardPin); 
                btnCustom.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                ttBtnCustom.Content = TextCustomButton;
            }
            else
            {
                btnCustom.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }

            //Navigate(new Uri("http://www.google.com"));
            webView.NavigationCompleted += webView_LoadCompleted;
            NavigateHome();
        }

        /// <summary>
        /// The max content size.
        /// </summary>
        public Size MaxContentSize
        {
            get
            {
                //return maxContentSize;
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                //maxContentSize = value;
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }

        /// <summary>
        /// Hide web view.
        /// </summary>
        public void HideWebView()
        {
            webView.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
        }

        /// <summary>
        /// Show web view.
        /// </summary>
        public void ShowWebView()
        {
            webView.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
        }

        void webView_LoadCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs navigationCompletedEventArgs)
        {
            if (!reload)
            {
                uri = sender.Source;
                txtAddress.Text = uri.ToString();

                lastUri.Add(uri);

                if (actualIndex != 0)
                {
                    btnBack.Content = ImageHelper.MsAppx(false, AppPics.Previous);
                    canGoBack = true;
                }
                else
                {
                    btnBack.Content = ImageHelper.MsAppx(true, AppPics.Previous);
                    canGoBack = false;
                }
                if (actualIndex == lastUri.Count - 1 || (backnext[backnext.Count - 1] == true && backnext[backnext.Count - 2] == false))
                {
                    btnNext.Content = ImageHelper.MsAppx(true, AppPics.Next);
                    canGoNext = false;
                }
                else
                {
                    btnNext.Content = ImageHelper.MsAppx(false, AppPics.Next);
                    canGoNext = true;
                }
                if (LoadCompleted != null)
                {
                    LoadCompleted(sender, navigationCompletedEventArgs);   
                }
                
            }
        }

        /// <summary>
        /// Enable custom button.
        /// </summary>
        /// <param name="enable">The enable.</param>
        public void EnableCustomButton(bool enable)
        {
            btnCustom.IsEnabled = enable;
            btnCustom.Content = ImageHelper.MsAppx(!enable, AppPics.BoardPin);
        }



        private void btnBack_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            if (canGoBack)
            {
                reload = false;
                backnext.Add(false);
                actualIndex--;
                Navigate(lastUri[actualIndex]);
            }
        }

        private void btnNext_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            if (canGoNext)
            {
                reload = false;
                backnext.Add(true);
                actualIndex++;
                Navigate(lastUri[actualIndex]);
            }
        }

        private void btnReload_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            reload = true;
            backnext.Add(false);
            Navigate(uri);
        }

        private void btnHome_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            reload = true;
            backnext.Clear();
            lastUri.Clear();
            backnext.Add(false);
            NavigateHome();
        }

        private void NavigateHome()
        {
            reload = false;
            backnext.Add(false);

            Navigate(new Uri("http://" + homeAdressWithoutHttp));
        }

        /// <summary>
        /// Navigate.
        /// </summary>
        /// <param name="uri">The uri.</param>
        public async Task Navigate(Uri uri)
        {
             webView.Source = uri;
        }


        private void btnCustom_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            
            CustomButtonClick(webView, new UriEventArgs(uri));
        }

        private void TextBox_KeyUp_1(object sender, KeyRoutedEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Windows.System.VirtualKey.Enter)
            {
                Uri uriOut = null;
                if (Uri.TryCreate(txtAddress.Text, UriKind.Absolute, out uriOut))
                {
                    reload = false;
                    actualIndex++;
                
                    Navigate(uriOut);
                }
            }
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            CloseButtonClick();
        }



        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }

        /// <summary>
        /// The x name.
        /// </summary>
        public string xName
        {
            set { border.Name = value; }
        }
    }
