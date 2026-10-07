namespace apps.Popups;

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

    public sealed partial class ShowFSException : UserControl, IPopupResponsive, IPopupEvents<object>
    {
        Langs l = Langs.cs;
        string fileOrFolder = null;

        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }
        public ShowFSException(string fileOrFolder, FileExceptions fsExc, Langs language)
        {
            this.InitializeComponent();
            this.fileOrFolder = fileOrFolder;
            this.l = language;
            tbTitle.Text = ThisApp.Name + AllStrings.swda;
            
            tbTitle.Text += sess.i18n("Warning");
            switch (fsExc)
            {
                case FileExceptions.None:
                    ExcNone();
                    break;
                case FileExceptions.FileNotFound:
                    ExcFileNotFound();
                    break;
                case FileExceptions.UnauthorizedAccess:
                    ExcUnauthorizedAccess();
                    break;
                case FileExceptions.General:
                default:
                    ExcGeneral();
                    break;
            }
        }

        private void ExcGeneral()
        {
            
            ShowMessage(sess.i18n("UnknownErrorWhenWorkWithFileOrFolder") + AllStrings.space + fileOrFolder);
        }

        private void ShowMessage(string path)
        {
            tbZprava.Text = path;
        }

        public Size MaxContentSize
        {
            get
            {
                //return maxContentSize;
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                //maxContentSize = value;
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }

        private void ExcUnauthorizedAccess()
        {
            ShowMessage(sess.i18n("InsufficientRightsToAccessFileOrFolder") + AllStrings.space + fileOrFolder);
        }

        private void ExcFileNotFound()
        {
            ShowMessage(sess.i18n("FileOrFolder") + AllStrings.space + fileOrFolder + AllStrings.space + sess.i18n("doesNotExists"));
        }

        private void ExcNone()
        {
            
                ShowMessage(sess.i18n("ExceptionNotExists"));
            
        }

        

        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }

        public event VoidT<object> ClickCancel;

        public event VoidT<object> ClickOK;

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(null);
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {

        }
    }
