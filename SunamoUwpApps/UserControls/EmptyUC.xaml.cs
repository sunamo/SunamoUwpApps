namespace apps.UserControls;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

    /// <summary>
    /// Represents the empty UC type.
    /// </summary>
    public sealed partial class EmptyUC : UserControl, IUserControl, IKeysHandler
    {
        /// <summary>
        /// Initializes a new instance of the empty UC class.
        /// </summary>
        public EmptyUC()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title => "";

        /// <summary>
        /// Handle key.
        /// </summary>
        /// <param name="keyEventArgs">The key event args.</param>
        /// <returns>The handle key result.</returns>
        public bool HandleKey(KeyEventArgs keyEventArgs)
        {
            return false;
        }

        /// <summary>
        /// Init.
        /// </summary>
        public void Init()
        {
            
        }
    }
