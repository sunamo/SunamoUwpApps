namespace apps.Popups;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    /// <summary>
    /// Represents the enter one value type.
    /// </summary>
    public sealed partial class EnterOneValue : UserControl, IPopupResponsive, IPopupEvents<EnterOneValueEventArgs>
    {
        Langs l = Langs.cs;
        /// <summary>
        /// The click OK.
        /// </summary>
        public event VoidT<EnterOneValueEventArgs> ClickOK;
        /// <summary>
        /// The click cancel.
        /// </summary>
        public event VoidT<EnterOneValueEventArgs> ClickCancel;
        /// <summary>
        /// Initializes a new instance of the enter one value class.
        /// </summary>
        /// <param name="coZadat">The co zadat.</param>
        /// <param name="language">The language.</param>
        public EnterOneValue(string coZadat, Langs language)
        {
            this.InitializeComponent();
            this.l = language;
            Reset(coZadat);
        }

        /// <summary>
        /// The entered text.
        /// </summary>
        public string EnteredText
        {
            get
            {
                return wtbZadani.Text;
            }
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {
            ClickCancel(null);
        }

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(new EnterOneValueEventArgs { EnteredText = EnteredText });
        }

        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
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
        /// Reset.
        /// </summary>
        /// <param name="coZadat">The co zadat.</param>
        public void Reset(string coZadat)
        {
            tbTitle.Text = SH.FirstCharUpper(coZadat);
            tbCoZadat.Text = sess.i18n("HereEnter") + coZadat;
            //wtbZadani.Text = tbCoZadat.Text;
            tbCoZadat.Text += AllStrings.colon;
        }

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }
    }
