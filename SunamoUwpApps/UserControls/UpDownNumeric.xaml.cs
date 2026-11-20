namespace apps.UserControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

    /// <summary>
    /// Represents the up down numeric type.
    /// </summary>
    public sealed partial class UpDownNumeric : UserControl
    {
        /// <summary>
        /// The value changed.
        /// </summary>
        public event ValueChangedRoutedHandler<uint> ValueChanged;

        /// <summary>
        /// Initializes a new instance of the up down numeric class.
        /// </summary>
        public UpDownNumeric()
        {
            this.InitializeComponent();
        }

        string latest = "";

        /// <summary>
        /// The value.
        /// </summary>
        public int Value
        {
            get
            {
                //return 0;
                return int.Parse(txtValue.Text);
            }
            set
            {
                txtValue.Text = value.ToString();
                latest = txtValue.Text;
                if (PropertyChanged != null)
                {
                    if (ValueChanged != null)
                    {
                        ValueChanged(this, new ValueChangedRoutedEventArgs<uint>((uint)value));
                    }
                    
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                    
                    
                }
            }
        }

        private void btnIncrement_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            if (Value != int.MaxValue)
            {
                Value++;
            }
            
        }

        private void btnDecrement_Click_1(object sender, RoutedEventArgs eventArgs)
        {
            if (Value != 0)
            {
                Value--;
            }
            
        }

        /// <summary>
        /// The value property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(double), typeof(UpDownNumeric), new PropertyMetadata(100));

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        private void txtValue_TextChanged_1(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            uint newValue = 0;
            if (uint.TryParse(txtValue.Text, out newValue))
            {
                if (newValue > 1000)
                {
                    txtValue.Text = latest;
                }
                else
                {
                    latest = txtValue.Text;
                    if (ValueChanged != null)
                    {
                        ValueChanged(sender, new ValueChangedRoutedEventArgs<uint>(newValue));
                    }
                }
            }
            else
            {
                txtValue.Text = latest;
            }
        }
    }
