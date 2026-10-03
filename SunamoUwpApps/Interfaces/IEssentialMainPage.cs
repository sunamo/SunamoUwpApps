using apps;
using apps.Popups;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;



    // MainPage is never based from IEssentialMainPage with generic arguments
    /// <summary>
    /// This is all about logging
    /// now its doing with ThisApp.SetStatus
    /// => Everything commented
    /// </summary>
public interface IEssentialMainPage 
{
    //StackPanel ListBoxLogs { get; }
    //LogServiceAbstract<Color, StorageFile> lsg { get; }
    ///// <summary>
    ///// In standalone method due to easy calling
    ///// </summary>
    ///// <param name="logMessage"></param>
    ///// <param name="alsoLb"></param>
    //Task SetStatus(LogMessageAbstract<Color, StorageFile> logMessage, bool alsoLb);

    Popup popup { get; set; }
    CryptDelegates CryptDelegates { get; set; }

    void EnableAppInterface(bool en);
}

//public interface IEssentialMainPage : IEssentialMainPage
//{
//    #region Login - better have everything in shared class
//    //Task< bool  > Dialog_ClickOK(object sender, RoutedEventArgs e);
//    //void Dialog_ClickCancel(object sender, RoutedEventArgs e);
//    //void Dialog_ClickClose(object sender, RoutedEventArgs e);
//    //LoginDialog loginDialog { get; set; } 
//    #endregion
    
//}