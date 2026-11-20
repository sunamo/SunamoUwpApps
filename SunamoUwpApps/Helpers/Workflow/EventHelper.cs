namespace apps.Helpers.Workflow;

using Microsoft.UI.Xaml;

/// <summary>
/// Represents the event helper type.
/// </summary>
public static class EventHelper
{

    /// <summary>
    /// Get get right source t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    /// <returns>The get get right source t result.</returns>
    public static T GetGetRightSource<T>(object sender, RoutedEventArgs eventArgs)
    {
        if (sender.GetType() == typeof(T))
        {
            return (T)sender;
        }
        if (eventArgs.OriginalSource.GetType() == typeof(T))
        {
            return (T)eventArgs.OriginalSource;
        }
        //if (ea.Source.GetType() == typeof(T))
        //{
        //    return (T)ea.Source;
        //}
        return default(T);
    }
}
