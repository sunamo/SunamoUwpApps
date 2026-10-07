namespace apps.Helpers.Workflow;

using Microsoft.UI.Xaml;

public static class EventHelper
{

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
