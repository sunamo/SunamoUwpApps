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

    /// <summary>
    /// Represents the show FS exception type.
    /// </summary>
    public sealed partial class ShowFSException : UserControl, IPopupResponsive, IPopupEvents<object>
    {
        Langs l = Langs.cs;
        string fileOrFolder = null;

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }
        /// <summary>
        /// Initializes a new instance of the show FS exception class.
        /// </summary>
        /// <param name="fileOrFolder">The file or folder.</param>
        /// <param name="fsExc">The fs exc.</param>
        /// <param name="language">The language.</param>
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

        /// <summary>
        /// The max content size.
        /// </summary>
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
        public event VoidT<object> ClickCancel;

        /// <summary>
        /// The click OK.
        /// </summary>
        public event VoidT<object> ClickOK;

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            ClickOK(null);
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {

        }
    }
