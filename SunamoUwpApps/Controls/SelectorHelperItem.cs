namespace apps.Controls;

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

    /// <summary>
    /// Represents the selector helper item type.
    /// </summary>
    public class SelectorHelperItem : IIdentificator
    {
        #region Is inicialized in ctor
        /// <summary>
        /// Gets or sets the btn save to clipboard visibility.
        /// </summary>
        public Visibility btnSaveToClipboardVisibility { get; set; }
        /// <summary>
        /// Gets or sets the btn run one visibility.
        /// </summary>
        public Visibility btnRunOneVisibility { get; set; }
        /// <summary>
        /// Gets or sets the btn remove one visibility.
        /// </summary>
        public Visibility btnRemoveOneVisibility { get; set; }

        /// <summary>
        /// Gets or sets the row 1.
        /// </summary>
        public string Row1 { get; set; }
        /// <summary>
        /// Gets or sets the row 2.
        /// </summary>
        public string Row2 { get; set; }
        /// <summary>
        /// The id.
        /// </summary>
        public object Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the remove one fa.
        /// </summary>
        public string RemoveOneFa { get; set; }
        /// <summary>
        /// Gets or sets the run one fa.
        /// </summary>
        public string RunOneFa { get; set; }
        /// <summary>
        /// Gets or sets the save to clipboard fa.
        /// </summary>
        public string SaveToClipboardFa { get; set; } 
        #endregion

        /// <summary>
        /// Gets or sets the awesome font family.
        /// </summary>
        public FontFamily AwesomeFontFamily { get; set; }

        /// <summary>
        /// Has inner commands classes
        /// </summary>
        public SelectorHelperListViewCommands SelectorHelperListViewCmds { get; set; }
        /// <summary>
        /// Gets or sets the app cmds.
        /// </summary>
        public object AppCmds { get; set; }
        /// <summary>
        /// The sh.
        /// </summary>
        public SelectorHelper sh = null;


        /// <summary>
        /// Initializes a new instance of the selector helper item class.
        /// </summary>
        /// <param name="selectorHelper">The selector helper.</param>
        /// <param name="btnSaveToClipboardVisibility">The btn save to clipboard visibility.</param>
        /// <param name="btnRunOneVisibility">The btn run one visibility.</param>
        /// <param name="btnRemoveOneVisibility">The btn remove one visibility.</param>
        /// <param name="Row1">The row 1.</param>
        /// <param name="Row2">The row 2.</param>
        /// <param name="value">The value.</param>
        /// <param name="RemoveOneFa">The remove one fa.</param>
        /// <param name="RunOneFa">The run one fa.</param>
        /// <param name="SaveToClipboardFa">The save to clipboard fa.</param>
        public SelectorHelperItem(SelectorHelper selectorHelper, Visibility btnSaveToClipboardVisibility, Visibility btnRunOneVisibility, Visibility btnRemoveOneVisibility, string Row1, string Row2, object value, string RemoveOneFa, string RunOneFa, string SaveToClipboardFa)
        {
            this.sh = selectorHelper;
            this.btnSaveToClipboardVisibility = btnSaveToClipboardVisibility;
            this.btnRunOneVisibility = btnRunOneVisibility;
            this.btnRemoveOneVisibility = btnRemoveOneVisibility;
            this.Row1 = Row1;
            this.Row2 = Row2;
            this.Id = value;

            this.RemoveOneFa = RemoveOneFa;
            this.RunOneFa = RunOneFa;
            this.SaveToClipboardFa = SaveToClipboardFa;

            this.AwesomeFontFamily = new FontFamily(AwesomeFontControls.awesomeFontPath);

            SelectorHelperListViewCmds = new SelectorHelperListViewCommands();

        }
    }
