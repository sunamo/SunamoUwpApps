namespace apps._public;

/// <summary>
/// Represents the i user control type.
/// </summary>
public interface IUserControl  //: IPanel
{
    /// <summary>
    /// Gets the title.
    /// </summary>
    string Title { get; }
    /// <summary>
    /// Init.
    /// </summary>
    void Init();

    //uc_Loaded is not required, anyway I have to make screenshot handly
    //void uc_Loaded(object sender, RoutedEventArgs e);

    // Stupid, better is doing that on ctor
    //void OnClosing();
}
