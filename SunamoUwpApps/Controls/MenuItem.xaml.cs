using apps.AwesomeFont;
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

namespace apps
{
    /// <summary>
    /// Is used in UWP apps SocialNetworksManager or CreateW10AppGraphics
    /// as replacement of SuMenuItem of WPF and easy porting WPF xaml
    /// Now is not compile, better is use Microsoft.Toolkit.UWP.UI which contains Menu / SuMenuItems
    /// </summary>
    public sealed partial class SuMenuItem : UserControl
    {
        public List<SuMenuItem> Items = new List<SuMenuItem>();

        double widthOfIconControl = 50;
        double heightOfIconControl = 50;

        /// <summary>
        /// Pokud používáš tento ctor, musíš pak zavolat metodu Initialize
        /// 
        /// </summary>
        public SuMenuItem()
        {
            this.InitializeComponent();

            Loaded += SuMenuItem_Loaded;
        }

        private void SuMenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            double w1 = btn.ActualHeight;
            double w2 = gridButtonContent.ActualHeight;
        }

        public SuMenuItem(Brush fgIcon, string otfIcon, Brush fgText, string text) : this()
        {
            Initialize(fgIcon, otfIcon, fgText, text);
        }

        public void Initialize(Brush fgIcon, string otfIcon, Brush fgText, string text)
        {
            txtIconBorder.Width = widthOfIconControl;
            txtIconBorder.Height = heightOfIconControl;
            
            gridButtonContent.Height = heightOfIconControl;

            AwesomeFontControls.SetAwesomeFontSymbol(txtIcon, otfIcon, fgIcon, AwesomeFontControls.CalculateFontSize(widthOfIconControl, heightOfIconControl), text);

            txtText.Foreground = fgText;
            txtText.Text = AllStrings.space + text;

            
        }

        public void SetAction(RoutedEventHandler reh, object tag)
        {
            btn.Click += reh;
            btn.Tag = tag;
        }

        public void SetAction(RoutedEventHandler reh)
        {
            btn.Click += reh;
        }
    }
}