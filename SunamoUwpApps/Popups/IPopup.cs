namespace apps.Popups;

using apps.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the i popup events t type.
    /// </summary>
    public interface IPopupEvents<T>
    {
        /// <summary>
        /// The click cancel.
        /// </summary>
        event VoidT<T> ClickCancel;
        /// <summary>
        /// The click OK.
        /// </summary>
        event VoidT<T> ClickOK;
    }

    /// <summary>
    /// Have only border brush
    /// Another name for that is IFlyout
    /// </summary>
    public interface IPopup : IColorTheme
    {
        /// <summary>
        /// insert border.BorderBrush = value;
        /// </summary>
        Brush PopupBorderBrush { set; }
        
    }

    /// <summary>
    /// have ChangeDialogResult / DialogResult
    /// Right, as IControlWithResult in wpf is use also ChangeDialogResult / DialogResult
    /// </summary>
    public interface IPopupDialogResult 
    {
        /// <summary>
        /// Null není pro zavření okna, null je pro 3. tlačítko
        /// </summary>
        event VoidBoolNullable ChangeDialogResult;
        /// <summary>
        /// Do Set zapiš jen ChangeDialogResult(value); 
        /// It is construction from WF apps and protect if handler will be null.
        /// </summary>
        bool? DialogResult { set; }
    }
