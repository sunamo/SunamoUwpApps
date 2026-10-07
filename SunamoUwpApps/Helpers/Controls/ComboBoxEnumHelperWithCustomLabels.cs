namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    public class ComboBoxEnumHelperWithCustomLabels<T> : ComboBoxEnumHelperBase<T>
    {
        Dictionary<string, string> d = null;

        public ComboBoxEnumHelperWithCustomLabels(ComboBox comboBox, Dictionary<string, string> labels) : base(comboBox)
        {
            this.d = labels;
            AddItems();
        }

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

        public override void SetValue(T sablonyProjektu)
        {
            string cbi = d[sablonyProjektu.ToString()];
            SetValue(cbi);
        }

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
