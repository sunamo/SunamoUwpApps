namespace apps.Popups;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using apps;
using apps.Helpers;
using Windows.UI.Popups;
using Windows.ApplicationModel.Resources;

    public sealed partial class AboutApp : UserControl, IPopupResponsive, IPopupEvents<object>
    {
        

        public event VoidT<object> ClickOK;

        public AboutApp()
        {
            this.InitializeComponent();

            FrameworkElementHelper.SetMinMaxWidth(this, 466);
            FrameworkElementHelper.SetMinMaxHeight(this, 932 / 2);

                tbTitle.Text = sess.i18n("AboutApp") + AllStrings.space  + ThisApp.Name;
            string ad = sess.i18n("AboutDeveloper");
            tbAboutApp.Text = ad;

            WRTBH tbh2 = new WRTBH(475, 10, FontArgs.DefaultRun());
            tbh2.HyperLink(sess.i18n("CzechBlog"), "http://jepsano.net");
            tbh2.LineBreak();
            tbh2.HyperLink(sess.i18n("EnglishBlog"), "http://blog.sunamo.cz");
            tbh2.LineBreak();
            tbh2.HyperLink("Web", "http://www.sunamo.cz");
            tbh2.LineBreak();
            tbh2.HyperLink("Facebook", "https://www.facebook.com/alles.gute21");
            tbh2.LineBreak();
            tbh2.HyperLink("Instagram", "https://www.instagram.com/sunamo.cz");
            tbh2.LineBreak();

            tbh2.HyperLink("sunamocz@outlook.com", "mailto:sunamocz@outlook.com");
            tbh2.LineBreak();

            tbh2.Run("");
            tbh2.LineBreak();



            wg.DataContext = tbh2.uis;

        }

        public Size MaxContentSize
        {
            get
            {
                //return maxContentSize;
                return FrameworkElementHelper.GetMaxContentSize(grid);
            }
            set
            {
                //maxContentSize = value;
                FrameworkElementHelper.SetMaxContentSize(grid, value);
            }
        }

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
           
            ClickOK(null);
        }

        public void ApplyColorTheme(ColorTheme ct)
        {
            ColorThemeHelper.ApplyColorTheme(border, ct);
        }

        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }


        public event VoidT<object> ClickCancel;
    }
