namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    public abstract class ComboBoxEnumHelperBase<T> : ComboBoxHelperBase<T>
    {
        public ComboBoxEnumHelperBase(ComboBox comboBox) : base(comboBox)
        {

        }

        protected abstract void AddItems();
        public abstract void SetValue(T sablonyProjektu);
        public abstract void SetValue(string cbi);
        public abstract void RemoveItem(T item);
        public abstract T GetSelected();
    }

    public abstract class ComboBoxHelperBase<T>
    {
        protected ComboBox cb = null;

        public ComboBoxHelperBase(ComboBox comboBox)
        {
            this.cb = comboBox;
        }
    }
