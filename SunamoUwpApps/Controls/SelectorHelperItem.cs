using apps.AwesomeFont;
using apps.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace apps
{
    /// <summary>
    /// Helper class to add operations to any control/object. In GeoCachingTool is passed here FileNameWithDateTime<StorageFolder, StorageFile>.
    /// It's data class for SelectorHelperListViewUC
    /// </summary>
    public class SelectorHelperItem : IIdentificator
    {
        #region Is inicialized in ctor
        public Visibility btnSaveToClipboardVisibility { get; set; }
        public Visibility btnRunOneVisibility { get; set; }
        public Visibility btnRemoveOneVisibility { get; set; }

        public string Row1 { get; set; }
        public string Row2 { get; set; }
        public object Id
        {
            get;
            set;
        }

        public string RemoveOneFa { get; set; }
        public string RunOneFa { get; set; }
        public string SaveToClipboardFa { get; set; } 
        #endregion

        public FontFamily AwesomeFontFamily { get; set; }

        /// <summary>
        /// Has inner commands classes
        /// </summary>
        public SelectorHelperListViewCommands SelectorHelperListViewCmds { get; set; }
        public object AppCmds { get; set; }
        public SelectorHelper sh = null;


        public SelectorHelperItem(SelectorHelper sh, Visibility btnSaveToClipboardVisibility, Visibility btnRunOneVisibility, Visibility btnRemoveOneVisibility, string Row1, string Row2, object Id, string RemoveOneFa, string RunOneFa, string SaveToClipboardFa)
        {
            this.sh = sh;
            this.btnSaveToClipboardVisibility = btnSaveToClipboardVisibility;
            this.btnRunOneVisibility = btnRunOneVisibility;
            this.btnRemoveOneVisibility = btnRemoveOneVisibility;
            this.Row1 = Row1;
            this.Row2 = Row2;
            this.Id = Id;

            this.RemoveOneFa = RemoveOneFa;
            this.RunOneFa = RunOneFa;
            this.SaveToClipboardFa = SaveToClipboardFa;

            this.AwesomeFontFamily = new FontFamily(AwesomeFontControls.awesomeFontPath);

            SelectorHelperListViewCmds = new SelectorHelperListViewCommands();

        }
    }
}