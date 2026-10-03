using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace apps
{
    /// <summary>
    /// Základním znakem responzivních Popupů(případně jakýchkoliv responzivních aplikací) je že používají jen procentové hodnoty pro velikost čehokoliv, v žádném případě ne nic fixního!! Nejlepší je tedy používat jen Grid
    /// Všechno co může být Wrap(například TextBlock) nastav na Wrap
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
}