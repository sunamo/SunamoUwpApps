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
    /// Represents the error listing type.
    /// </summary>
    public sealed partial class ErrorListing : UserControl, IPopupSmall
    {
        /// <summary>
        /// The click OK.
        /// </summary>
        public event RoutedEventHandler ClickOK;

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        /// <summary>
        /// The title.
        /// </summary>
        public string Title
        {
            set
            {
                tbTitle.Text = value;
            }
        }

        /// <summary>
        /// Musíš nastavit i Visible
        /// </summary>
        public string Collapse
        {
            set
            {
                ttCollapse.Content = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tbCollapse.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    tbCollapse.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                }
            }
        }
        /// <summary>
        /// Musíš nastavit i Collapsee
        /// </summary>
        public string Visible
        {
            set
            {
                tbChybovaZprava.Text = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the error listing class.
        /// </summary>
        public ErrorListing()
        {
            this.InitializeComponent();
        }

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(sender, eventArgs);
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
        public event RoutedEventHandler ClickCancel;
    }
