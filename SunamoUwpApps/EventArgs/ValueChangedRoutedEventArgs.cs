namespace apps.EventArgs;

using Microsoft.UI.Xaml;

    /// <summary>
    /// Represents the value changed routed handler t type.
    /// </summary>
    public delegate void ValueChangedRoutedHandler<T>(object sender, ValueChangedRoutedEventArgs<T> eventArgs);

    /// <summary>
    /// Represents the value changed routed event args t type.
    /// </summary>
    public class ValueChangedRoutedEventArgs<T> : RoutedEventArgs
    {
        T newValue = default(T);

        /// <summary>
        /// The new value.
        /// </summary>
        public T NewValue
        {
            get
            {
                return newValue;
            }
        }

        /// <summary>
        /// Initializes a new instance of the value changed routed event args class.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public ValueChangedRoutedEventArgs(T newValue) : base()
        {
            this.newValue = newValue;
        }
    }
