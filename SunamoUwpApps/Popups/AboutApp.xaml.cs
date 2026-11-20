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

    /// <summary>
    /// Represents the about app type.
    /// </summary>
    public sealed partial class AboutApp : UserControl, IPopupResponsive, IPopupEvents<object>
    {
        

        /// <summary>
        /// The click OK.
        /// </summary>
        public event VoidT<object> ClickOK;

        /// <summary>
        /// Initializes a new instance of the about app class.
        /// </summary>
        public AboutApp()
        {
            this.InitializeComponent();

            FrameworkElementHelper.SetMinMaxWidth(this, 466);
            FrameworkElementHelper.SetMinMaxHeight(this, 932 / 2);

                tbTitle.Text = sess.i18n("AboutApp") + AllStrings.space  + ThisApp.Name;
            string text = sess.i18n("AboutDeveloper");
            tbAboutApp.Text = text;

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

        /// <summary>
        /// The max content size.
        /// </summary>
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

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
           
            ClickOK(null);
        }

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }


        /// <summary>
        /// The click cancel.
        /// </summary>
        public event VoidT<object> ClickCancel;
    }
