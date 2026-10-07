namespace apps.PopupsNoResponsive;

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

    public sealed partial class EnterOneValue : UserControl, IPopupSmall
    {
        Langs l = Langs.cs;
        public event RoutedEventHandler ClickOK;
        public event RoutedEventHandler ClickCancel;
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        public EnterOneValue(string coZadat, Langs language)
        {
            this.InitializeComponent();
            this.l = language;
            Reset(coZadat);
            
        }

        public string EnteredText
        {
            get
            {
                return wtbZadani.Text;
            }
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {
            ClickCancel(this, null);
        }

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(this, null);
        }

        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }




        public void Reset(string coZadat)
        {
            tbTitle.Text = SH.FirstCharUpper(coZadat);
            if (l == Langs.cs)
            {
                tbCoZadat.Text = "Zde zadejte " + coZadat;
            }
            else
            {
                tbCoZadat.Text = "Here enter " + coZadat;
            }
            //wtbZadani.Text = tbCoZadat.Text;
            tbCoZadat.Text += AllStrings.colon;
        }
    }
