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

    /// <summary>
    /// Represents the message box metro type.
    /// </summary>
    public sealed partial class MessageBoxMetro : UserControl, IPopupSmall
    {
        /// <summary>
        /// The click OK.
        /// </summary>
        public event RoutedEventHandler ClickOK;
        /// <summary>
        /// The click cancel.
        /// </summary>
        public event RoutedEventHandler ClickCancel;

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        /// <summary>
        /// Initializes a new instance of the message box metro class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        public MessageBoxMetro(string title, string message)
        {
            this.InitializeComponent();

            tbTitle.Text = title;
            tbZprava.Text = message;
        }

       

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(sender, eventArgs);
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {
            ClickCancel(sender, eventArgs);
        }

        /// <summary>
        /// Show cancel button.
        /// </summary>
        /// <param name="flag">The flag.</param>
        public void ShowCancelButton(bool flag)
        {
            if (flag)
            {
                btnCancel.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
            else
            {
                btnCancel.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }
        }



        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }
    }
