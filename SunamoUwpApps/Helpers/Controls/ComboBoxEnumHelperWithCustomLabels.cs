namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the combo box enum helper with custom labels t type.
    /// </summary>
    public class ComboBoxEnumHelperWithCustomLabels<T> : ComboBoxEnumHelperBase<T>
    {
        Dictionary<string, string> d = null;

        /// <summary>
        /// Initializes a new instance of the combo box enum helper with custom labels class.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="labels">The labels.</param>
        public ComboBoxEnumHelperWithCustomLabels(ComboBox comboBox, Dictionary<string, string> labels) : base(comboBox)
        {
            this.d = labels;
            AddItems();
        }

        /// <summary>
        /// Get selected.
        /// </summary>
        /// <returns>The get selected result.</returns>
        public override T GetSelected()
        {
            string cbi = cb.SelectedItem.ToString();
            foreach (var item in d)
            {
                if (item.Value == cbi)
                {
                    return (T)Enum.Parse(typeof(T), item.Key);
                }
            }
            return default(T);
        }

        /// <summary>
        /// Remove item.
        /// </summary>
        /// <param name="item">The item.</param>
        public override void RemoveItem(T item)
        {
            string cbi = d[item.ToString()];
            for (int index = 0; index < cb.Items.Count; index++)
            {
                string guid = cb.Items[index].ToString();
                if (guid == cbi)
                {
                    cb.Items.RemoveAt(index);
                    break;
                }
            }
        }

        /// <summary>
        /// Set value.
        /// </summary>
        /// <param name="cbi">The cbi.</param>
        public override void SetValue(string cbi)
        {

            for (int index = 0; index < cb.Items.Count; index++)
            {
                string guid = cb.Items[index].ToString();
                if (guid == cbi)
                {
                    cb.SelectedIndex = index;
                    break;
                }
            }
        }

        /// <summary>
        /// Set value.
        /// </summary>
        /// <param name="sablonyProjektu">The sablony projektu.</param>
        public override void SetValue(T sablonyProjektu)
        {
            string cbi = d[sablonyProjektu.ToString()];
            SetValue(cbi);
        }

        /// <summary>
        /// Add items.
        /// </summary>
        protected override void AddItems()
        {
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                cb.Items.Add(d[item.ToString()]);
                //}
            }
            cb.SelectedIndex = 0;
        }
    }
