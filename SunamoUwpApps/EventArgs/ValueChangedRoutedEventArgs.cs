
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml;

namespace apps
{
    public delegate void ValueChangedRoutedHandler<T>(object sender, ValueChangedRoutedEventArgs<T> ea);

    public class ValueChangedRoutedEventArgs<T> : RoutedEventArgs
    {
        T newValue = default(T);

        public T NewValue
        {
            get
            {
                return newValue;
            }
        }

        public ValueChangedRoutedEventArgs(T newValue) : base()
        {
            this.newValue = newValue;
        }
    }
}