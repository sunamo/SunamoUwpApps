namespace apps.EventArgs;

using Microsoft.UI.Xaml;

    public delegate void ValueChangedRoutedHandler<T>(object sender, ValueChangedRoutedEventArgs<T> eventArgs);

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
