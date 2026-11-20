namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the combo box helper t type.
    /// </summary>
    public class ComboBoxHelper<T> : ComboBoxHelperBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the combo box helper class.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        public ComboBoxHelper(ComboBox comboBox) : base(comboBox)
        {

        }


    }
