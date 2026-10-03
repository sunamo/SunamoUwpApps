namespace SunamoUwpApps._sunamo;

/// <summary>
/// Maybe will be desirable IWindowOpener
/// </summary>
public interface IUserControl  //: IPanel
{
    string Title { get; }
    void Init();

    //uc_Loaded is not required, anyway I have to make screenshot handly
    //void uc_Loaded(object sender, RoutedEventArgs e);

    // Stupid, better is doing that on ctor
    //void OnClosing();
}