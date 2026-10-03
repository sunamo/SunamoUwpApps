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
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236
namespace apps;
    public sealed partial class PopupButtons : UserControl
    {
static Type type = typeof(PopupButtons);
        public PopupButtons()
        {
            this.InitializeComponent();
            
            MinWidth = 300;
        }
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
        public bool? DialogResult
        {
            set
            {
                ChangeDialogResult(value);
            }
        }
        public event VoidBoolNullable ChangeDialogResult;
        public bool IsEnabledBtnOk
        {
            set
            {
                btnOk.IsEnabled = value;
            }
        }
        public bool IsEnabledBtnApply
        {
            set
            {
                btnApply.IsEnabled = value;
            }
        }
        public Visibility VisibilityBtnApply
        {
            set
            {
                btnApply.Visibility = value;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = null;
        }
        public void Accept(object input)
        {
            ThrowEx.Custom("Only buttons cant be accepted, because hasnt data for accept.");
        }
    }
