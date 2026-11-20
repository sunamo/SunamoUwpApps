namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps;
using CommunityToolkit.WinUI.UI.Controls;

/// <summary>
/// Represents the i user control with su menu items list type.
/// </summary>
public interface IUserControlWithSuMenuItemsList : IUserControl
{
    /// <summary>
    /// Su menu items.
    /// </summary>
    /// <returns>The su menu items result.</returns>
    List<SuMenuItem> SuMenuItems();
}
