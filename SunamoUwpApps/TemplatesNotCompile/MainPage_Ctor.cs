using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps;
using apps.AwesomeFont;
using apps.Essential;
using apps.Helpers;
using apps.Popups;
using apps.UserControls;
using CommunityToolkit.WinUI.UI.Controls;
using Windows.Storage;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

public class MainPage_Ctor : Page, IEssentialMainPage
{
    #region To be copied
    #region Variables of _Ctor
    static Type type = typeof(MainPage_Ctor);
    CryptDelegates cryptDelegates = StringSecurityHelper.CreateCryptDelegates();
    public CryptDelegates CryptDelegates
    {
        get
        {
            return cryptDelegates;
        }
        set
        {
            cryptDelegates = value;
        }
    }
    Mode mode = Mode.Empty; public string ModeString { get => mode.ToString(); }
    EmptyUC emptyUC = null;
    LogUC logUC = null;
    UserControl _actual = new UserControl(); public UserControl actual { get => _actual; set => _actual = value; }
    IUserControl userControl = null;
    IUserControlWithSuMenuItemsList userControlWithSuMenuItems;
    IUserControlClosing userControlClosing;
    IKeysHandler keysHandler;
    List<SuMenuItem> previouslyRegisteredSuMenuItems = new List<SuMenuItem>();

    public Popup popup { get; set; }

    #region Defined in xaml
    SuMenuItem miGenerateScreenshot = null;
    SuMenuItem miAlwaysOnTop = null;
    /// <summary>
    /// Grid in SplitView.Content
    /// </summary>
    Grid grid;
    SuMenuItem miUC = new SuMenuItem();
    #endregion

    #region Implicitly in Window
    dynamic Dispatcher = null;
    TextBlock tbLastErrorOrWarning;
    TextBlock tbLastOtherMessage;
    string Title = null;
    #endregion

    public static SolidColorBrush borderBrush = new SolidColorBrush(Colors.Green);
#if DEBUG
    public const string adresaWebu = Consts.HttpLocalhostSlash;
    //public const string adresaWebu = "http://www.sunamo.cz/";
#else
        public const string adresaWebu = "http://www.sunamo.cz/";
#endif
    /// <summary>
    /// Hold login session
    /// </summary>
    SunamoCzLoginManager sunamoCzCredentials = new SunamoCzLoginManager(borderBrush, adresaWebu);


    public ApplicationDataContainer data { get; set; }
    //public ConfigurableWindowWrapper configurableWindowWrapper { get; set; }
    //public bool CancelClosing { get; set; }
    //public WindowWithUserControl windowWithUserControl { get; set; }

    AbstractCatalog<StorageFolder, StorageFile> ac = new AbstractCatalog<StorageFolder, StorageFile>();
    static MainPage_Ctor instance = null;
    #endregion

    #region Variables of this app

    #endregion

    protected async override void OnNavigatedTo(NavigationEventArgs navigationEventArgs)
    {
        base.OnNavigatedTo(navigationEventArgs);

        await AppDataApps.ci.CreateAppFoldersIfDontExists();

        Initialize();
    }

    /// <summary>
    /// In standalone method to ability restore default settings of all controls
    /// </summary>
    private async Task Initialize()
    {
        #region 1) ThisApp.Name, Check for already running, required conditions, Clipboard, AppData and Xlf
        XlfResourcesHSunamo.SaveResouresToRLSunamo(new ExistsDirectory(FSApps.ExistsDirectorySync), AppDataApps.ci);

        instance = this;

        ac.appData = AppDataApps.ci;

        ac.fs = new FSAbstract<StorageFolder, StorageFile>();
        ac.fs.existsDirectory = FSApps.ExistsDirectorySync;
        ac.fs.getStorageFile = FSApps.GetStorageFileSync;
        ac.fs.getFiles = FSApps.GetFilesSync;
        ac.fs.existsFile = FSApps.ExistsFileSync;
        ac.fs.pathFromStorageFile = FSApps.PathFromStorageFile;

        ac.tf = new TFAbstract<StorageFile>();
        ac.tf.writeAllText = TFApps.WriteAllTextSync;
        ac.tf.readAllText = TFApps.ReadAllTextSync;

        RL.loader = new ResourceLoaderApps();

        // Cant use IClipboardHelperApps because some methods of class have returning Task, but in IClipboardHelper is all non async
        ClipboardHelper.InstanceApps = ClipboardHelperApps.Instance;

        WpfApp.cd = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
        WpfApp.mp = this;WpfApp.htt = this; // delete htt when is not derived, its was mass replaced due to shutdown app after hide to tray

        // Dont set up anything to AppData, in UWP is use only AppDataApps
        //AppData.ci.RootFolder = AppDataApps.ci.RootFolder.Path;
        var appName = "";
        ThisApp.Name = appName;
        ThisApp.Namespace = appName;
        #endregion

        // All initialization must be after #region Initialize base properties of every app 

        #region 2) Initialize logging
        WpfApp.tbLastErrorOrWarning = tbLastErrorOrWarning;
        WpfApp.tbLastOtherMessage = tbLastOtherMessage;

        SetMode(Mode.LogUC);
        #endregion

        #region 3) Initialize base properties of app

        #endregion

        #region 4) Initialize helpers, SQL of app

        #endregion

        #region 5) Set modes


        // 2nd Edit only in #if
        SetMode(Mode.Empty);

#if DEBUG
        //3rd in debug show uc
        SetMode(Mode.Empty);
#endif
        #endregion

        #region 6) Attach handlers
        this.SizeChanged += MainPage_SizeChanged;
        sunamoCzCredentials.LoginFailed += SunamoCzCredentials_LoginFailed;
        sunamoCzCredentials.LoginSuccessful += SunamoCzCredentials_LoginSuccessful;
        #endregion

        #region 7) Notify icon

        #endregion

        #region 8) App-specific testing

        #endregion

        #region 9) Set up UI of app
        await SetAwesomeIcons();
        #endregion

        #region 10) Login, Load data

        #endregion


    }

    async Task SetAwesomeIcons()
    {
    }

        private void SunamoCzCredentials_LoginSuccessful()
    {
        EnableAppInterface(true);
    }

    private void SunamoCzCredentials_LoginFailed()
    {
        EnableAppInterface(false);
    }

    public void SetMode(object mode2)
    {
        var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);
        if (userControlClosing != null)
        {
            userControlClosing.OnClosing();
        }

        // In UWP is not Topmost, only https://stackoverflow.com/a/49801718/9327173
        //this.Topmost = false;
        #region After arrange I have to newly unregister
        //if (result != null)
        //{
        //    result.Finished -= Result_Finished;
        //}

        //if (userControlInWindow != null)
        //{
        //    userControlInWindow.ChangeDialogResult -= UserControlInWindow_ChangeDialogResult;
        //}
        #endregion

        this.mode = mode;
        grid.Children.Remove(actual);

        switch (mode)
        {
            #region Shared UC
            case Mode.Empty:
                
                actual = emptyUC;
                break;
            case Mode.LogUC:
                actual = logUC;
                break;
            #endregion
            default:
                ThrowEx.NotImplementedCase(mode);
                break;
        }

        // Here I can use (IUserControl) because every have to be IUserControl
        userControl = (IUserControl)actual;
        userControl.Init();

        userControlWithSuMenuItems = actual as IUserControlWithSuMenuItemsList;
        userControlClosing = actual as IUserControlClosing;
        keysHandler = actual as IKeysHandler;
        ThrowEx.WasNotKeysHandler(userControl.Title, keysHandler);

        #region On start I have to unregister
        previouslyRegisteredSuMenuItems.ForEach(menuItem => miUC.Items.Remove(menuItem));

        var pMode = "userControlWithSuMenuItems " + mode;

        if (userControlWithSuMenuItems != null)
        {
            // keep long name due to copy to new selling apps
            miUC.Visibility = Visibility.Visible;
            miUC.Header = userControl.Title;
            previouslyRegisteredSuMenuItems = userControlWithSuMenuItems.SuMenuItems();
            foreach (var item in previouslyRegisteredSuMenuItems)
            {
                if (item.Parent != null)
                {
                    ((Menu)item.Parent).Items.Remove(item);
                }
                miUC.Items.Add(item);
            }
            miUC.UpdateLayout();
        }
        else
        {
            miUC.Visibility = Visibility.Collapsed;
        }
        #endregion

        grid.Children.Add(actual);
        Grid.SetRow(actual, 1);

        MainPage_SizeChanged(null, null);
    }

    private void MainPage_SizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
    {

    }

    public void EnableAppInterface(bool enabled)
    {
        
    }
    #endregion

    #region To not be copied
    public MainPage_Ctor()
    {
        emptyUC = new EmptyUC();
        logUC = new LogUC();
    } 
    #endregion
}

class SunamoCzLoginManager
{
    public event VoidVoid LoginSuccessful;
    public event VoidVoid LoginFailed;

    public SunamoCzLoginManager(SolidColorBrush borderBrush, string adresaWebu)
    {
    }
}

public enum Mode
{
    // Empty First mode in every app
    Empty,

    // Then Modes of app

    // then shared UC for every app
    LogUC,
    CheckBoxListMode
}