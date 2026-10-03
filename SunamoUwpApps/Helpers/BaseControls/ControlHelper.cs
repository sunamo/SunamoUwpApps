namespace apps.Helpers.BaseControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class ControlHelper
    {
static Type type = typeof(ControlHelper);
        public static Point GetOnCenter(Size parent, Size child)
        {
            Point vr = new Point();
            if (parent.Width > child.Width)
            {
                vr.X = ((parent.Width - child.Width) / 2d);
            }
            else if(parent.Width == child.Width)
            {
                vr.X = 0;
            }
            else
            {
                vr.X = 0;
            }
            if (parent.Height > child.Height)
            {
                vr.Y = (parent.Height - child.Height) / 2d;
            }
            else if (parent.Height == child.Height)
            {
                vr.Y = 0;
            }
            else
            {
                vr.Y = 0;
            }
            return vr;
        }
        public static readonly Size SizePositiveInfinity = new Size(double.PositiveInfinity, double.PositiveInfinity);
        /// <summary>
        /// ControlHelper.GetMinimumSize - call only measure
        /// FrameworkElementHelper.SizeToContent - call measure and arrange
        /// </summary>
        /// <param name="uie"></param>
        /// <param name="maxSize"></param>
        public static Size GetMinimumSize(UIElement uie, Size maxSize)
        {
            uie.Measure(maxSize);
            return uie.DesiredSize; //SizeHelper.RecalculateSizeWithScaleFactor( uie.DesiredSize.Width, uie.DesiredSize.Height);
        }
        /// <summary>
        /// ControlHelper.GetMinimumSize - call only measure
        /// FrameworkElementHelper.SizeToContent - call measure and arrange
        /// </summary>
        /// <param name="uie"></param>
        public static Size GetMinimumSize(UIElement uie)
        {
            uie.Measure(SizePositiveInfinity);
            return uie.DesiredSize; //SizeHelper.RecalculateSizeWithScaleFactor( uie.DesiredSize.Width, uie.DesiredSize.Height);
        }
        public static Size GetMinimumHeightMaximumWidth(UIElement uie, Size windowSize)
        {
            uie.Measure(SizePositiveInfinity);
            var vr = uie.DesiredSize; //SizeHelper.RecalculateSizeWithScaleFactor( uie.DesiredSize.Width, uie.DesiredSize.Height);
            //Frame rootFrame = Window.Current.Content as Frame;
            vr.Width = windowSize.Width;
            return vr;
        }
        public static Size GetMinimumHeightMinimumWidth(UIElement uie)
        {
            return GetMinimumHeightMinimumWidth(uie, SizePositiveInfinity);
        }
        public static Size GetMinimumHeightMinimumWidth(UIElement uie, Size windowSize)
        {
            uie.Measure(windowSize);
            var vr = uie.DesiredSize;
            
            return vr;
        }
        /// <summary>
        /// A1 musí být (FrameworkElement)
        /// A2 nemůže být null ani SE, jinak Ex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="prefixToRemove"></param>
        public static string GetName(object sender, string prefixToRemove)
        {
            if (string.IsNullOrEmpty(prefixToRemove))
            {
                ThrowEx.Custom("Parameter prefixToRemove in ControlHelper.GetName was SE or null");
            }
            string vr = null;
            vr = GetName(sender);
            
            if (vr.StartsWith(prefixToRemove))
            {
                return vr.Substring(prefixToRemove.Length);
            }
            else
            {
                ThrowEx.Custom("If you want only get Control name, use method ControlHelper.GetName(object sender), or specify prefixToRemove in actual.");
                return null;
            }
        }
        /// <summary>
        /// A1 musí být (FrameworkElement)
        /// </summary>
        /// <param name="sender"></param>
        private static string GetName(object sender)
        {
            string vr;
            FrameworkElement fe = (FrameworkElement)sender;
            if (fe == null)
            {
                ThrowEx.Custom("Parameter sender in ControlHelper.GetName wasnt FrameworkElement");
            }
            vr = fe.Name;
            return vr;
        }
        public static string GetNameChb(object sender)
        {
            return GetName(sender, "chb");
        }
    }
