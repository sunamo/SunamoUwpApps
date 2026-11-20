namespace apps.PopupsNoResponsive;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the i popup calculated size type.
    /// </summary>
    public interface IPopupCalculatedSize //: IPopup
    {
        //List<Control> GetChildElements();
        /// <summary>
        /// Gets or sets the popup border brush.
        /// </summary>
        Brush PopupBorderBrush { set; }
        /// <summary>
        /// Gets the border.
        /// </summary>
        Border Border { get; }
        /// <summary>
        /// Gets the stack panel.
        /// </summary>
        StackPanel StackPanel { get; }
    }
