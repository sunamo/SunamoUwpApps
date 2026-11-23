namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the combo box enum helper base t type.
    /// </summary>
    public abstract class ComboBoxEnumHelperBase<T> : ComboBoxHelperBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the combo box enum helper base class.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        public ComboBoxEnumHelperBase(ComboBox comboBox) : base(comboBox)
        {

        }

        /// <summary>
        /// Add items.
        /// </summary>
        protected abstract void AddItems();
        /// <summary>
        /// Set value.
        /// </summary>
        /// <param name="sablonyProjektu">The sablony projektu.</param>
        public abstract void SetValue(T sablonyProjektu);
        /// <summary>
        /// Set value.
        /// </summary>
        /// <param name="cbi">The cbi.</param>
        public abstract void SetValue(string cbi);
        /// <summary>
        /// Remove item.
        /// </summary>
        /// <param name="item">The item.</param>
        public abstract void RemoveItem(T item);
        /// <summary>
        /// Get selected.
        /// </summary>
        /// <returns>The get selected result.</returns>
        public abstract T GetSelected();
    }

    /// <summary>
    /// Represents the combo box helper base t type.
    /// </summary>
    public abstract class ComboBoxHelperBase<T>
    {
        /// <summary>
        /// The cb.
        /// </summary>
        protected ComboBox cb = null;

        /// <summary>
        /// Initializes a new instance of the combo box helper base class.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        public ComboBoxHelperBase(ComboBox comboBox)
        {
            this.cb = comboBox;
        }
    }
