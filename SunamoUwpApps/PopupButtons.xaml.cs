namespace apps;

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
    /// Represents the popup buttons type.
    /// </summary>
    public sealed partial class PopupButtons : UserControl
    {
static Type type = typeof(PopupButtons);
        /// <summary>
        /// Initializes a new instance of the popup buttons class.
        /// </summary>
        public PopupButtons()
        {
            this.InitializeComponent();
            
            MinWidth = 300;
        }
        /// <summary>
        /// The custom control.
        /// </summary>
        public UIElement CustomControl
        {
            set
            {
                sp.Children.Insert(0, value);
            }
            get
            {
                return sp.Children[0];
            }
        }
        /// <summary>
        /// The dialog result.
        /// </summary>
        public bool? DialogResult
        {
            set
            {
                ChangeDialogResult(value);
            }
        }
        /// <summary>
        /// The change dialog result.
        /// </summary>
        public event VoidBoolNullable ChangeDialogResult;
        /// <summary>
        /// The is enabled btn ok.
        /// </summary>
        public bool IsEnabledBtnOk
        {
            set
            {
                btnOk.IsEnabled = value;
            }
        }
        /// <summary>
        /// The is enabled btn apply.
        /// </summary>
        public bool IsEnabledBtnApply
        {
            set
            {
                btnApply.IsEnabled = value;
            }
        }
        /// <summary>
        /// The visibility btn apply.
        /// </summary>
        public Visibility VisibilityBtnApply
        {
            set
            {
                btnApply.Visibility = value;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs eventArgs)
        {
            DialogResult = false;
        }
        private void btnOk_Click(object sender, RoutedEventArgs eventArgs)
        {
            DialogResult = true;
        }
        private void btnApply_Click(object sender, RoutedEventArgs eventArgs)
        {
            DialogResult = null;
        }
        /// <summary>
        /// Accept.
        /// </summary>
        /// <param name="input">The input.</param>
        public void Accept(object input)
        {
            ThrowEx.Custom("Only buttons cant be accepted, because hasnt data for accept.");
        }
    }
