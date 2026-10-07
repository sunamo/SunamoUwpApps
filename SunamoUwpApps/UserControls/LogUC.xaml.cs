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

    public sealed partial class LogUC : UserControl, IUserControl, IKeysHandler
    {
        public LogUC()
        {
            this.InitializeComponent();
        }

        public string Title => "Log";

        public bool HandleKey(KeyEventArgs keyEventArgs)
        {
            return false;
        }

        public void Init()
        {
            
        }
    }
