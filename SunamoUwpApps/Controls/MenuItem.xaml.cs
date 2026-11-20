namespace apps.Controls;

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

    /// <summary>
    /// Represents the su menu item type.
    /// </summary>
    public sealed partial class SuMenuItem : UserControl
    {
        /// <summary>
        /// The items.
        /// </summary>
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

        private void SuMenuItem_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            double buttonHeight = btn.ActualHeight;
            double contentHeight = gridButtonContent.ActualHeight;
        }

        /// <summary>
        /// Initializes a new instance of the su menu item class.
        /// </summary>
        /// <param name="fgIcon">The fg icon.</param>
        /// <param name="otfIcon">The otf icon.</param>
        /// <param name="fgText">The fg text.</param>
        /// <param name="text">The text.</param>
        public SuMenuItem(Brush fgIcon, string otfIcon, Brush fgText, string text) : this()
        {
            Initialize(fgIcon, otfIcon, fgText, text);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fgIcon">The fg icon.</param>
        /// <param name="otfIcon">The otf icon.</param>
        /// <param name="fgText">The fg text.</param>
        /// <param name="text">The text.</param>
        public void Initialize(Brush fgIcon, string otfIcon, Brush fgText, string text)
        {
            txtIconBorder.Width = widthOfIconControl;
            txtIconBorder.Height = heightOfIconControl;
            
            gridButtonContent.Height = heightOfIconControl;

            AwesomeFontControls.SetAwesomeFontSymbol(txtIcon, otfIcon, fgIcon, AwesomeFontControls.CalculateFontSize(widthOfIconControl, heightOfIconControl), text);

            txtText.Foreground = fgText;
            txtText.Text = AllStrings.space + text;

            
        }

        /// <summary>
        /// Set action.
        /// </summary>
        /// <param name="reh">The reh.</param>
        /// <param name="tag">The tag.</param>
        public void SetAction(RoutedEventHandler reh, object tag)
        {
            btn.Click += reh;
            btn.Tag = tag;
        }

        /// <summary>
        /// Set action.
        /// </summary>
        /// <param name="reh">The reh.</param>
        public void SetAction(RoutedEventHandler reh)
        {
            btn.Click += reh;
        }
    }
