namespace apps.Popups;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

    /// <summary>
    /// Represents the i popup responsive type.
    /// </summary>
    public interface IPopupResponsive : IPopup
    {
        /// <summary>
        /// insert (comment below)
        /// </summary>
        /// 
/*
 
 get
    {
        return FrameworkElementHelper.GetMaxContentSize(this);
    }
    set
    {
        FrameworkElementHelper.SetMaxContentSize(this, value);
    }
}
*/
Size MaxContentSize { get; set; }


}
