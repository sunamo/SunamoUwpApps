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

    public sealed partial class MessageBoxMetro : UserControl, IPopupSmall
    {
        public event RoutedEventHandler ClickOK;
        public event RoutedEventHandler ClickCancel;

        public void ApplyColorTheme(ColorTheme ct)
        {
            ColorThemeHelper.ApplyColorTheme(border, ct);
        }

        public MessageBoxMetro(string title, string message)
        {
            this.InitializeComponent();

            tbTitle.Text = title;
            tbZprava.Text = message;
        }

       

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            ClickOK(sender, e);
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
            ClickCancel(sender, e);
        }

        public void ShowCancelButton(bool p)
        {
            if (p)
            {
                btnCancel.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
            else
            {
                btnCancel.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }
        }



        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }
    }
