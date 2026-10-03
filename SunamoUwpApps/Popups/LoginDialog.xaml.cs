using apps.Essential;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
namespace apps.Popups;
    public sealed partial class LoginDialog : UserControl, IPopupResponsive, IPopupDialogResult, IAsync
    {
static Type type = typeof(LoginDialog);
        public event VoidBoolNullable ChangeDialogResult;
        static string loadedPassword = string.Empty;
        public static string LoadedPassword
        {
            get
            {
                return loadedPassword;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                loadedPassword = value;
            }
        }
        public static string LoadedLogin = null;
        StorageApplicationData storageApplicationData = StorageApplicationData.NoWhere;
        private LoginDialog()
        {
            this.InitializeComponent();
            
        }
        static LoginDialog()
        {
        }
        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            if (ChangeDialogResult != null)
            {
                ChangeDialogResult(true);
            }
        }
        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
            if (ChangeDialogResult != null)
            {
                ChangeDialogResult(false);
            }
        }
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }
        public Brush BackgroundBrush
        {
            set { border.Background = value; }
        }
        public Size MaxContentSize
        {
            get
            {
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }
        public static string li
        {
            get
            {
                return LoadedLogin;
                
            }
        }
        public static string pw
        {
            get
            {
                return LoadedPassword;
            }
        }
        public  string Login
        {
            get
            {
                string text = string.Empty;
                text = txtLogin.Text;
                //WpfApp.cd.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => text = txtLogin.Text);
                //AsyncHelper.ci.GetResult();
                return text ;
            }
        }
        public  string Password
        {
            get
            {
                string text = string.Empty;
                text = txtHeslo.Password;
                //AsyncHelper.ci.GetResult(WpfApp.cd.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => text = txtHeslo.Password));
                return text;
            }
        }
        /// <summary>
        /// Instead this use OnClickOk and OnClickCancel methods
        /// </summary>
        public bool? DialogResult
        {
            set
            {
                ThrowEx.NotImplementedMethod();
                
            }
        }
        string salt = null;
        public LoginDialog(CryptDelegates cd, string salt) : this()
        {
            this.cryptDelegates = cd;
            this.salt = salt;
            chbAutoLogin.Checked += chbAutoLogin_Checked;
            chbRememberLogin.Unchecked += chbRememberLogin_Unchecked;
        }
        public LoginDialog(CryptDelegates cd, string salt, StorageApplicationData storageApplicationData, Brush borderBrush)
            : this(cd, salt)
        {
            this.storageApplicationData = storageApplicationData;
            this.PopupBorderBrush = borderBrush;
            Initialize();
        }
        void chbRememberLogin_Unchecked(object sender, RoutedEventArgs e)
        {
            chbAutoLogin.IsChecked = false;
        }
        void chbAutoLogin_Checked(object sender, RoutedEventArgs e)
        {
            chbRememberLogin.IsChecked = true;
        }
        static StorageFile _passwordSf;
        static StorageFile passwordSf
        {
            get
            {
                if (_passwordSf == null)
                {
                    LoadStorageFiles();
                }
                return _passwordSf;
            }
        }
        static StorageFile _loginSf;
        static StorageFile loginSf
        {
            get
            {
                //DebugLogger.Instance.WriteLine("get loginSf start");
                if (_loginSf == null)
                {
                    LoadStorageFiles();
                }
                //DebugLogger.Instance.WriteLine("get loginSf end");
                return _loginSf;
            }
        }
        static StorageFile _saltSf;
        static StorageFile saltSf
        {
            get
            {
                if (_saltSf == null)
                {
                    LoadStorageFiles();
                }
                return _saltSf;
            }
        }
        static void LoadStorageFiles()
        {
            //DebugLogger.Instance.WriteLine("LoadStorageFiles start"); 
            var v = GetStorageFiles();
            
            StorageFile[] sfa = v;
            _loginSf = sfa[0];
            _saltSf = sfa[1];
            _passwordSf = sfa[2];
            //DebugLogger.Instance.WriteLine("LoadStorageFiles end");
        }
        /// <summary>
        /// Must be instance, not static, due to IAsync
        /// Load login and password from file
        /// </summary>
        /// <param name="salt"></param>
        public async Task GetLoginAndPassword(string salt)
        {
            // Invalid pointer
            // Load password
            LoadStorageFiles();



            #region Old way to loading
            //IBuffer encryptedH = await FileIO.ReadBufferAsync(passwordSf).AsTask();
            ////DebugLogger.Instance.WriteLine("GetLoginAndPassword");

            //if (encryptedH != null)
            //{
            //    LoadedPassword = ProtectedDataHelper.ToInsecureString(encryptedH);
            //} 
            #endregion

            #region New way to loading
            var c = await FileIO.ReadTextAsync(passwordSf, Windows.Storage.Streams.UnicodeEncoding.Utf16BE);
            LoadedPassword = cryptDelegates.decryptString(null, c);
            #endregion

            // Načtu už. jméno
            LoadedLogin = TFApps.ReadFile(loginSf);
        }
        /// <summary>
        /// Initiate controls
        /// </summary>
        public void Initialize()
        {
            if (storageApplicationData == StorageApplicationData.TextFile)
            {
                GetLoginAndPassword(salt);
                this.txtLogin.Text = Login;
                this.txtHeslo.Password = LoadedPassword;
            }
            else if (storageApplicationData == StorageApplicationData.NoWhere)
            {
                // Do nothing, user don't want save credentials
            }
            else
            {
                ThrowExceptionSavingConfigInOtherWayIsntSupportedInWindowsStoreAppsNotSupported();
            }
            if (txtLogin.Text != "")
            {
                this.chbRememberLogin.IsChecked = txtLogin.Text != "";
                this.chbAutoLogin.IsChecked = txtHeslo.Password != "";
            }
            else
            {
                this.chbRememberLogin.IsChecked = false;
                this.chbAutoLogin.IsChecked = false;
            }
        }

        CryptDelegates cryptDelegates = null;

        /// <summary>
        /// Get files to read
        /// </summary>
        private static StorageFile[] GetStorageFiles()
        {
            StorageFile[] vr = new StorageFile[3];
            vr[0] = AppDataApps.ci.GetFile(AppFolders.Settings, "l.txt");
            vr[1] = AppDataApps.ci.GetFile(AppFolders.Settings, "s.txt");
            vr[2] = AppDataApps.ci.GetFile(AppFolders.Settings, "h.txt");
            return vr;
        }
        private static void ThrowExceptionSavingConfigInOtherWayIsntSupportedInWindowsStoreAppsNotSupported()
        {//Ukládání nastavení jinde než do textového souboru zatím není podporováno ve Windows Store Apps
            ThrowEx.Custom("Saving into other way than text file isn't supported in Windows Store apps yet");
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (storageApplicationData == StorageApplicationData.TextFile)
            {
                StorageFile loginSf, saltSf, passwordSf;
                StorageFile[] sfa = GetStorageFiles();
                loginSf = sfa[0];
                saltSf = sfa[1];
                passwordSf = sfa[2];
                if ((bool)chbRememberLogin.IsChecked)
                {
                    TFApps.SaveFile(this.txtLogin.Text, AppDataApps.ci.GetFile(AppFolders.Settings, "l.txt"));
                    if ((bool)this.chbAutoLogin.IsChecked)
                    {
                        var encoded = cryptDelegates.encryptString(null, txtHeslo.Password);
                        await FileIO.WriteTextAsync(passwordSf,encoded, Windows.Storage.Streams.UnicodeEncoding.Utf16BE);
                        //await ProtectedDataHelper.SaveSecureToDisc(TFApps.ReadFile(saltSf), this.txtHeslo.Password, passwordSf);
                    }
                    else
                    {
                        TFApps.SaveFile("",passwordSf);
                    }
                }
                else
                {
                    TFApps.SaveFile("", loginSf);
                    TFApps.SaveFile("", passwordSf);
                }
            }
            else
            {
                ThrowExceptionSavingConfigInOtherWayIsntSupportedInWindowsStoreAppsNotSupported();
            }
            if (storageApplicationData != StorageApplicationData.NoWhere)
            {
                if (txtLogin.Text.Trim() != "" && txtHeslo.Password.Trim() != "")
                {
                    ChangeDialogResult(true);
                }
                else
                {
                    ChangeDialogResult(false);
                }
            }
            else
            {
                ChangeDialogResult(true);
            }
        }
        private void btnForgetLoginAndPassword_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            txtHeslo.Password = "";
            if (storageApplicationData == StorageApplicationData.NoWhere)
            {
                // Nedělej nic, data nebyly nikde uloženy
            }
            else if (storageApplicationData == StorageApplicationData.TextFile)
            {
                StorageFile loginSf, saltSf, passwordSf;
                StorageFile[] sfa = GetStorageFiles();
                loginSf = sfa[0];
                saltSf = sfa[1];
                passwordSf = sfa[2];
                TFApps.SaveFile("", loginSf);
                TFApps.SaveFile("", passwordSf);
            }
            else
            {
                ThrowExceptionSavingConfigInOtherWayIsntSupportedInWindowsStoreAppsNotSupported();
            }
        }
        private void btnForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            txtHeslo.Password = "";
            if (storageApplicationData == StorageApplicationData.TextFile)
            {
                StorageFile loginSf, saltSf, passwordSf;
                StorageFile[] sfa = GetStorageFiles();
                loginSf = sfa[0];
                saltSf = sfa[1];
                passwordSf = sfa[2];
                TFApps.SaveFile("", passwordSf);
            }
            else if (storageApplicationData == StorageApplicationData.NoWhere)
            {
                // Nedělej nic, data nebyly nikde uloženy
            }
            else
            {
                ThrowExceptionSavingConfigInOtherWayIsntSupportedInWindowsStoreAppsNotSupported();
            }
        }
        public void ApplyColorTheme(ColorTheme ct)
        {
            ColorThemeHelper.ApplyColorTheme(border, ct);
        }
        private void btnCloseDialog_Click(object sender, RoutedEventArgs e)
        {
            ChangeDialogResult(null);
        }
        public  T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
