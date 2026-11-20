namespace apps.Popups;

using apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the check box list UC type.
    /// </summary>
    public partial class CheckBoxListUC : UserControl, IPopupResponsive, IPopupEvents<object> //, IUserControlInPopup
    {
        /// <summary>
        /// The checked length.
        /// </summary>
        public int checkedLength = 0;

        /// <summary>
        /// The click OK.
        /// </summary>
        public event VoidT<object> ClickOK;
        /// <summary>
        /// The click cancel.
        /// </summary>
        public event VoidT<object> ClickCancel;

        /// <summary>
        /// Apply color theme.
        /// </summary>
        /// <param name="colorTheme">The color theme.</param>
        public void ApplyColorTheme(ColorTheme colorTheme)
        {
            ColorThemeHelper.ApplyColorTheme(border, colorTheme);
        }

        private void OnClickOK(object sender, RoutedEventArgs eventArgs)
        {
            if (ClickOK != null)
            {
                ClickOK(null);
            }
        }

        private void OnClickCancel(object sender, RoutedEventArgs eventArgs)
        {
            if (ClickCancel != null)
            {
                ClickCancel(null);
            }
        }


        /// <summary>
        /// The max content size.
        /// </summary>
        public Size MaxContentSize
        {
            get
            {
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }


        /// <summary>
        /// The popup border brush.
        /// </summary>
        public Brush PopupBorderBrush
        {
            set { border.BorderBrush = value; }
        }


        /// <summary>
        /// The background brush.
        /// </summary>
        public Brush BackgroundBrush
        {
            set { border.Background = value; }
        }


        /// <summary>
        /// The title foreground brush.
        /// </summary>
        public Brush TitleForegroundBrush
        {
            set
            {
                //tbTitle.Foreground = value;
            }
        }

        /// <summary>
        /// Checked.
        /// </summary>
        /// <returns>The checked result.</returns>
        public List<CheckBox> Checked()
        {
            List<CheckBox> chb = new List<CheckBox>(checkedLength);
            foreach (CheckBox item in spCheckBoxes.Children)
            {
                if (item.IsChecked.Value)
                {
                    chb.Add(item);
                }
            }
            return chb;
        }

        /// <summary>
        /// Get check box from tag.
        /// </summary>
        /// <param name="tag2">The tag 2.</param>
        /// <returns>The get check box from tag result.</returns>
        public bool GetCheckBoxFromTag(object tag2)
        {
            foreach (var item in spCheckBoxes.Children)
            {
                if (item is CheckBox)
                {
                    var checkBox = ((CheckBox)item);
                    var tag = checkBox.Tag;
                    
                        
                        if(BTS.CompareAsObjectAndString(tag2, tag))
                    { 
                        return BTS.GetValueOfNullable(((CheckBox)checkBox).IsChecked);
                    }
                }
            }
            return false;
        }

   

        /// <summary>
        /// Při volání této metody je zároveň vytvořit slovník SunamoDictionaryWithKeysDependencyObject a do toho vkládat checkboxy a hodnoty k nim
        /// Nastaví chb.IsThreeState = false;
        /// </summary>
        /// <param name="chb"></param>
        public void AddCheckBox(CheckBox chb)
        {
            
            if (BTS.GetValueOfNullable( chb.IsChecked))
            {
                checkedLength++;
            }
            chb.IsThreeState = false;
            chb.Checked += Chb_Checked;
            chb.Unchecked += Chb_Unchecked;

            spCheckBoxes.Children.Add(chb);
            TurnOnOffButtonOk();
        }

        private void Chb_Unchecked(object sender, RoutedEventArgs eventArgs)
        {
            checkedLength--;
            TurnOnOffButtonOk();
        }

        private void Chb_Checked(object sender, RoutedEventArgs eventArgs)
        {
            checkedLength++;
            TurnOnOffButtonOk();
        }

        private void TurnOnOffButtonOk()
        {
            if (checkedLength == 0)
            {
                btnOk.IsEnabled = false;
            }
            else
            {
                btnOk.IsEnabled = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the check box list UC class.
        /// </summary>
        public CheckBoxListUC()
        {
            InitializeComponent();
            SetContentToChbTickAll();
        }

        /// <summary>
        /// Initializes a new instance of the check box list UC class.
        /// </summary>
        /// <param name="uie">The uie.</param>
        public CheckBoxListUC(params UIElement[] uie) : this()
        {
            foreach (var item in uie)
            {
                if (item != null)
                {
                    spCustomControls.Children.Add(item);
                }
            }
        }

        private void SetContentToChbTickAll()
        {
            if (chbTickAll.IsChecked.Value)
            {
                chbTickAll.Content = sess.i18n("UntickAll");
            }
            else
            {
                chbTickAll.Content = sess.i18n("TickAll");
            }
        }

        private void chbTickAll_Checked(object sender, RoutedEventArgs eventArgs)
        {
            foreach (CheckBox item in spCheckBoxes.Children)
            {
                item.IsChecked = true;
            }
        }

        private void chbTickAll_Unchecked(object sender, RoutedEventArgs eventArgs)
        {
            foreach (CheckBox item in spCheckBoxes.Children)
            {
                item.IsChecked = false;
            }
        }

        
    }
