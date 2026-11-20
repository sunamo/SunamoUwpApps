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

    /// <summary>
    /// Represents the yes no dialog type.
    /// </summary>
    public sealed partial class YesNoDialog : UserControl, IPopupResponsive, IPopupEvents<YesNoDialogEventArgs>
    {
        //Langs l = apps.Essential.WpfApp.l;
        object arg = null;

        /// <summary>
        /// Polož otázku A1 tak aby bylo na ní odpovědět Ano/Ne, např. Přejete si otevřít odkaz v novém okně?
        /// </summary>
        /// <param name="prompt"></param>
        public YesNoDialog(string prompt, object arg)
        {
            this.InitializeComponent();

            this.arg = arg;
           
                btnYes.Content = sess.i18n( "Yes");
                btnNo.Content = sess.i18n( "No");
            

            tbPromptMessage.Text = prompt;
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
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set
            {
                border.BorderBrush = value;
            }
        }

        /// <summary>
        /// The click cancel.
        /// </summary>
        public event VoidT<YesNoDialogEventArgs> ClickCancel;
        /// <summary>
        /// The click OK.
        /// </summary>
        public event VoidT<YesNoDialogEventArgs> ClickOK;

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        private void btnYes_Click(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(new YesNoDialogEventArgs { Arg = arg });
        }

        private void btnNo_Click(object sender, RoutedEventArgs eventArgs)
        {
            ClickCancel(new YesNoDialogEventArgs { Arg = arg });
        }
    }
