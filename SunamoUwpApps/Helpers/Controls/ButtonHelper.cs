namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class ButtonHelper
    {
        public static Button Get(Orientation orientation, object content, RoutedEventHandler handler)
        {
            Button button = Get(Orientation.Horizontal, content);
            button.Click += handler;
            return button;
        }

        public static Button Get(Orientation orientation, object content, ICommand command)
        {
            Button button = Get(Orientation.Horizontal, content);
            button.Command = command;
            return button;
        }

        public static Button Get(Orientation orientation, object content, ISunamoAsyncCommand command)
        {
            Button button = Get(Orientation.Horizontal, content);
            button.Click += delegate (object sender, RoutedEventArgs eventArgs) {
                command.Execute(sender);
            };
            return button;
        }

        /// <summary>
        /// Pokud je A1 orientován do řádku(Horizontal), bude uprostřed řádku. Jinak sloupce.
        /// </summary>
        /// <param name="orientation"></param>
        /// <param name="content"></param>
        public static Button Get(Orientation orientation, object content)
        {
            Button button = new Button();
            button.Content = content;

            if (orientation == Orientation.Horizontal)
            {
                button.VerticalAlignment = VerticalAlignment.Center;
            }
            else
            {
                button.HorizontalAlignment = HorizontalAlignment.Center;
            }
            return button;
        }
    }
