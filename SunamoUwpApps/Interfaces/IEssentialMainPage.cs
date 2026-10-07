namespace apps.Interfaces;

using apps;
using apps.Popups;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

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

    void EnableAppInterface(bool enabled);
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
