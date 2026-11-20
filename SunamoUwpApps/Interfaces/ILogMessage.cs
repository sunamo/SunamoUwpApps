namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the i log message type.
    /// </summary>
    public interface ILogMessage
    {
        /// <summary>
        /// Gets or sets the bg.
        /// </summary>
        Brush Bg { get; set; }
        /// <summary>
        /// Gets or sets the ts.
        /// </summary>
        string Ts { get; set; }
    }
