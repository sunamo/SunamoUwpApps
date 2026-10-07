namespace apps.Helpers.Workflow;

using System;
using System.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;

    public delegate void updateBorderBrushOfBorder(Border border, Brush brush);
    public delegate Brush getBorderBrushOfBorder(Border border);
    public delegate void updateProgressBarWpf(ProgressBar progressBar, double value);
    public delegate void updateTextBlockText(TextBlock lbl, string text);
    public delegate void appendToTextBlock(TextBlock lbl, string text);

    public delegate void changeVisibilityUIElementWpf(UIElement uie, Visibility visibility);
    
    public delegate void appendToTextBox(TextBox lbl, string text);
    public delegate void insertToListBoxWpf(ListBox listBox, int index, object value);
    public delegate void setDataContext(FrameworkElement frameworkElement, object value);
    public delegate object getDataContext(FrameworkElement frameworkElement);
    
    public delegate object getSelectedItemSelector(Selector selector);
    public delegate void setItemsSourceOfItemsControl(ItemsControl itemsControl, IEnumerable items);
    public delegate void setCaretIndexOfTextBox(TextBox txt, int caretIndex);
    public delegate void focusTextBox(TextBox txt);
    public delegate string getTextOfTextBox(TextBox txt);
    
    public delegate object getItemAtIndexInSelector(Selector selector, int dex);
    public delegate void setSelectedItemSelector(Selector selector, object item);
    public delegate void updateLayoutOfUIElement(UIElement uie);
    //public delegate ListBoxItem getListBoxItemFromObject(ListBox lb, object )
    public static partial class IH
    {
        public static changeVisibilityUIElementWpf delegateChangeVisibilityUIElementWpf = null;
        public static insertToListBoxWpf delegateInsertToListBoxWpf = null;
        
        public static updateBorderBrushOfBorder delegateUpdateBorderBrushOfBorder = null;
        public static getBorderBrushOfBorder delegateGetBorderBrushOfBorder = null;
        
        public static updateTextBlockText delegateUpdateTextBlockText = null;
        public static appendToTextBlock delegateAppendToTextBlock = null;
        
        public static appendToTextBox delegateAppendToTextBox = null;
        public static setDataContext delegateSetDataContext = null;
        public static getDataContext delegateGetDataContext = null;
        
        public static getSelectedItemSelector delegateGetSelectedItemSelector = null;
        public static setItemsSourceOfItemsControl delegateSetItemsSourceOfItemsControl = null;
        
        public static focusTextBox delegateFocusTextBox = null;
        public static getTextOfTextBox delegateGetTextOfTextBox = null;
        
        public static getItemAtIndexInSelector delegateGetItemAtIndexInSelector = null;
        public static setSelectedItemSelector delegateSetSelectedItemSelector = null;
        public static updateLayoutOfUIElement delegateUpdateLayoutOfUIElement = null;
        public static ListBoxItem getListBoxItemFromObject = null;
        //
        static IH()
        {
            delegateChangeVisibilityUIElementWpf = new changeVisibilityUIElementWpf(updateVisibility);
            delegateInsertToListBoxWpf = new insertToListBoxWpf(insertToListBoxWpfValue);
            
            delegateUpdateBorderBrushOfBorder = new updateBorderBrushOfBorder(updateBorderBrushOfBorderValue);
            delegateGetBorderBrushOfBorder = new getBorderBrushOfBorder(getBorderBrushOfBorderValue);
            
            delegateUpdateTextBlockText = new updateTextBlockText(updateTextBlockText);
            delegateAppendToTextBlock = new appendToTextBlock(appendToTextBlockText);
            
            delegateAppendToTextBox = new appendToTextBox(appendToTextBoxText);
            delegateSetDataContext = new setDataContext(setDataContextObject);
            delegateGetDataContext = new getDataContext(getDataContextObject);
            
            delegateGetSelectedItemSelector = new getSelectedItemSelector(getSelectedItemSelector);
            delegateSetItemsSourceOfItemsControl = new setItemsSourceOfItemsControl(setItemsSourceOfItemsControlM);
            
            delegateFocusTextBox = new focusTextBox(focusTextBox);
            delegateGetTextOfTextBox = new getTextOfTextBox(getTextOfTextBox);
            
            delegateGetItemAtIndexInSelector = new getItemAtIndexInSelector(getItemAtIndexInSelector);
            delegateSetSelectedItemSelector = new setSelectedItemSelector(setSelectedItemSelector);
            delegateUpdateLayoutOfUIElement = new updateLayoutOfUIElement(updateLayoutOfUIElement);

        }

        public static void updateLayoutOfUIElement(UIElement uie)
        {
            uie.UpdateLayout();
        }

        public static void setSelectedItemSelector(Selector selector, object item)
        {
            selector.SelectedItem = item;
        }

        public static object getItemAtIndexInSelector(Selector selector, int dex)
        {
            return selector.Items[dex];
        }

        

        public static string getTextOfTextBox(TextBox txt)
        {
            return txt.Text;
        }

        public static void focusTextBox(TextBox txt)
        {
            txt.Focus(FocusState.Programmatic);
        }

        

        

        public static void updateBorderBrushOfBorderValue(Border border, Brush brush)
        {
            border.BorderBrush = brush;
        }

        public static Brush getBorderBrushOfBorderValue(Border border)
        {
            return border.BorderBrush;
        }

        

        static void setItemsSourceOfItemsControlM(ItemsControl itemsControl, IEnumerable items)
        {
            itemsControl.ItemsSource = items;
        }

        
        public static void updateTextBlockText(TextBlock lbl, string text)
        {
            lbl.Text = text;
            UpdateTooltip(lbl, text);
        }

        public static void appendToTextBlockText(TextBlock lbl, string text)
        {
             text = lbl.Text + AllStrings.space + text;
            lbl.Text = text;
            UpdateTooltip(lbl, text);
        }

        private static void UpdateTooltip(DependencyObject lbl, string text)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Content = text;
            if (text == "About this app")
            {

            }
            ToolTipService.SetToolTip(lbl, text);
        }

        public static void appendToTextBoxText(TextBox textBox, string text)
        {
            textBox.Text = textBox.Text + AllStrings.space + text;
            UpdateTooltip(textBox, textBox.Text);
        }

        //
        public static void updateVisibility(UIElement uiElement, Visibility vis)
        {
            uiElement.Visibility = vis;
        }



        public static void insertToListBoxWpfValue(ListBox listBox, int index, object value)
        {
            listBox.Items.Insert(index, value);
        }

        public static void setDataContextObject(FrameworkElement frameworkElement, object dataContext)
        {
            frameworkElement.DataContext = dataContext;
        }

        public static object getDataContextObject(FrameworkElement frameworkElement)
        {
            return frameworkElement.DataContext;
        }

        

        public static object getSelectedItemSelector(Selector selector)
        {
            return selector.SelectedItem;
        }
    }
