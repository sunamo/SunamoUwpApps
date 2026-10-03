namespace apps.UniversalWebControl;

using apps;
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

    public sealed partial class OpenInControl : UserControl
    {
static Type type = typeof(OpenInControl);
        public OpenInControl()
        {
            this.InitializeComponent();
           
                rbNever.Content = sess.i18n( "Never");
                rbAlways.Content = sess.i18n( "Always");
                rbPrompt.Content = sess.i18n( "Prompt");
            OpenIn = OpenInNewTab.Always;
        }
        public OpenInNewTab openIn = OpenInNewTab.Always;
        
        /// <summary>
        /// Check right radio button
        /// </summary>
        public OpenInNewTab OpenIn {
            get
            {
                return openIn;
            }
            set
            {
                switch (value)
                {
                    case OpenInNewTab.Never:
                        rbNever.IsChecked = true;
                        break;
                    case OpenInNewTab.Always:
                        rbAlways.IsChecked = true;
                        break;
                    case OpenInNewTab.Prompt:
                        rbPrompt.IsChecked = true;
                        break;
                    default:
                        ThrowEx.Custom("OpenInControl.OpenIn");
                        break;
                }
                openIn = value;
            }
        }
        private void rbNever_Click(object sender, RoutedEventArgs e)
        {
            openIn = OpenInNewTab.Never;
        }
        private void rbAlways_Click(object sender, RoutedEventArgs e)
        {
            openIn = OpenInNewTab.Always;
        }
        private void rbPrompt_Click(object sender, RoutedEventArgs e)
        {
            openIn = OpenInNewTab.Prompt;
        }
    }
