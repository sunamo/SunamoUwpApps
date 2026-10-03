using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace apps.Popups;
    public sealed partial class PopupWithResult : UserControl, IPopupDialogResult, IPopupResponsive
    {
        public PopupWithResult(FrameworkElement customControl)
        {
            this.InitializeComponent();
            //this.MinWidth = 1000;

            CustomControl = customControl;

            popupButtons.ChangeDialogResult += PopupButtons_ChangeDialogResult1;
            Loaded += PopupWithResult_Loaded;
        }

        /// <summary>
        /// Here is working badly
        /// Try make other layout, use other panel also have no effect
        /// There is two way of make it working:
        /// 1) manual set Max Width/Height
        /// 2) Implement my own method which will measure recursively all elements 
        /// </summary>
        /// <param name="availableSize"></param>
        protected override Size MeasureOverride(Size availableSize)
        {
            customControl.Measure(ControlHelper.SizePositiveInfinity);
            popupButtons.Measure(ControlHelper.SizePositiveInfinity);

            Size size = new Size();
            size.Height = customControl.DesiredSize.Height + popupButtons.DesiredSize.Height;
            size.Width = customControl.DesiredSize.Width > popupButtons.DesiredSize.Width ? customControl.DesiredSize.Width : popupButtons.DesiredSize.Width;
            return size;
        }

        private void PopupWithResult_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Measure(ControlHelper.SizePositiveInfinity);
            //DebugLogger.Instance.WriteLine("Popup: " + this.DesiredSize);

            //DebugLogger.Instance.WriteLine("Buttons: " + popupButtons.DesiredSize);
            FrameworkElementHelper.SizeToContent(popupButtons);

            // Buttony se zvětšily ale Popup zůstavá stejný
            //DebugLogger.Instance.WriteLine("Buttons: " + popupButtons.DesiredSize);

            this.Measure(popupButtons.DesiredSize);
            this.Arrange(new Rect(new Point(0,0), popupButtons.DesiredSize));

            /*
             * Popup: 175.2,90.4
Buttons: 220.8,52.8
Buttons: 225.6,52.8
Popup: 175.2,52.8
225.600006103516
             */

            //FrameworkElementHelper.SizeToContent(this);
            // Not working, still have small desired size
            //this.UpdateLayout();
            //DebugLogger.Instance.WriteLine("Popup: " + this.DesiredSize);

            //DebugLogger.Instance.WriteLine(this.ActualWidth);
        }

        public bool? DialogResult { set  { if (ChangeDialogResult != null) { ChangeDialogResult(true); } } }

        public event VoidBoolNullable ChangeDialogResult;

        private void PopupButtons_ChangeDialogResult1(bool? b)
        {
            DialogResult = b;
        }

        public void ApplyColorTheme(ColorTheme ct)
        {
            ColorThemeHelper.ApplyColorTheme(border, ct);
        }

        FrameworkElement customControl = null;

        public FrameworkElement CustomControl
        {
            set
            {
                if (customControl != null)
                {
                    grid.Children.Remove(customControl);
                }
                customControl = value;
                Grid.SetRow(customControl, 0);
                grid.Children.Add(customControl);

                // V InvalidateMeasure není volání na žádné Invalidate
                InvalidateMeasure();
                // Díval jsem se do ReferenceSource, InvalidateVisual volá jen InvalidateArrange
                InvalidateArrange();
            }
        }

        public Size MaxContentSize
        {
            get
            {
                return FrameworkElementHelper.GetMaxContentSize(this);
            }
            set
            {
                FrameworkElementHelper.SetMaxContentSize(this, value);
            }
        }
    
        public Brush PopupBorderBrush { set => border.BorderBrush = value; }
    }
