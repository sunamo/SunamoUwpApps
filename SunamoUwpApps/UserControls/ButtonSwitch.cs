namespace apps.UserControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the button switch type.
    /// </summary>
    public class ButtonSwitch : Button
    {
        SolidColorBrush panel1 = new SolidColorBrush(Colors.LightBlue);
        SolidColorBrush panel2 = new SolidColorBrush(Colors.White);
        SolidColorBrush panel3 = new SolidColorBrush(Colors.White);
        SolidColorBrush colorD = new SolidColorBrush(Colors.White);
        SolidColorBrush colorE = new SolidColorBrush(Colors.LightBlue);


        /// <summary>
        /// To left.
        /// </summary>
        public void ToLeft()
        {
            if (panel3 == colorE)
            {
                panel3 = colorD;
                panel2 = colorE;
            }
            else if (panel2 == colorE)
            {
                panel2 = colorD;
                panel1 = colorE;
            }
            else
            {
                panel1 = colorD;
                panel3 = colorE;
            }
        }

        /// <summary>
        /// To right.
        /// </summary>
        public void ToRight()
        {
            if (panel3 == colorE)
            {
                panel3 = colorD;
                panel1 = colorE;
            }
            else if (panel2 == colorE)
            {
                panel2 = colorD;
                panel3 = colorE;
            }
            else
            {
                panel1 = colorD;
                panel2 = colorE;
            }
        }

        /// <summary>
        /// The panel 1.
        /// </summary>
        public SolidColorBrush Panel1
        {
            get
            {
                return panel1;
            }
        }

        /// <summary>
        /// The panel 2.
        /// </summary>
        public SolidColorBrush Panel2
        {
            get
            {
                return panel2;
            }
        }

        /// <summary>
        /// The panel 3.
        /// </summary>
        public SolidColorBrush Panel3
        {
            get
            {
                return panel3;
            }
        }
    }
