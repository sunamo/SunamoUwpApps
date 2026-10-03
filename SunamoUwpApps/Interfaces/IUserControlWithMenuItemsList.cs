namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps;
using CommunityToolkit.WinUI.UI.Controls;

public interface IUserControlWithSuMenuItemsList : IUserControl
{
    List<SuMenuItem> SuMenuItems();
}
