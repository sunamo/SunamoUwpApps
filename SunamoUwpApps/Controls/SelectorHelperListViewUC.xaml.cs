namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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
    /// Represents the selector helper list view UC type.
    /// </summary>
    public sealed partial class SelectorHelperListViewUC : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the selector helper list view UC class.
        /// </summary>
        public SelectorHelperListViewUC()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public object SelectedItem { get; set; }
    }
