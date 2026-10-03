namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

    public interface ILogMessage
    {
        Brush Bg { get; set; }
        string Ts { get; set; }
    }
