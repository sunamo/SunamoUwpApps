namespace apps.Helpers.Workflow;

using System;
using System.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the update border brush of border type.
    /// </summary>
    public delegate void updateBorderBrushOfBorder(Border border, Brush brush);
    /// <summary>
    /// Represents the get border brush of border type.
    /// </summary>
    public delegate Brush getBorderBrushOfBorder(Border border);
    /// <summary>
    /// Represents the update progress bar wpf type.
    /// </summary>
    public delegate void updateProgressBarWpf(ProgressBar progressBar, double value);
    /// <summary>
    /// Represents the update text block text type.
    /// </summary>
    public delegate void updateTextBlockText(TextBlock lbl, string text);
    /// <summary>
    /// Represents the append to text block type.
    /// </summary>
    public delegate void appendToTextBlock(TextBlock lbl, string text);

    /// <summary>
    /// Represents the change visibility UI element wpf type.
    /// </summary>
    public delegate void changeVisibilityUIElementWpf(UIElement uie, Visibility visibility);
    
    /// <summary>
    /// Represents the append to text box type.
    /// </summary>
    public delegate void appendToTextBox(TextBox lbl, string text);
    /// <summary>
    /// Represents the insert to list box wpf type.
    /// </summary>
    public delegate void insertToListBoxWpf(ListBox listBox, int index, object value);
    /// <summary>
    /// Represents the set data context type.
    /// </summary>
    public delegate void setDataContext(FrameworkElement frameworkElement, object value);
    /// <summary>
    /// Represents the get data context type.
    /// </summary>
    public delegate object getDataContext(FrameworkElement frameworkElement);
    
    /// <summary>
    /// Represents the get selected item selector type.
    /// </summary>
    public delegate object getSelectedItemSelector(Selector selector);
    /// <summary>
    /// Represents the set items source of items control type.
    /// </summary>
    public delegate void setItemsSourceOfItemsControl(ItemsControl itemsControl, IEnumerable items);
    /// <summary>
    /// Represents the set caret index of text box type.
    /// </summary>
    public delegate void setCaretIndexOfTextBox(TextBox txt, int caretIndex);
    /// <summary>
    /// Represents the focus text box type.
    /// </summary>
    public delegate void focusTextBox(TextBox txt);
    /// <summary>
    /// Represents the get text of text box type.
    /// </summary>
    public delegate string getTextOfTextBox(TextBox txt);
    
    /// <summary>
    /// Represents the get item at index in selector type.
    /// </summary>
    public delegate object getItemAtIndexInSelector(Selector selector, int dex);
    /// <summary>
    /// Represents the set selected item selector type.
    /// </summary>
    public delegate void setSelectedItemSelector(Selector selector, object item);
    /// <summary>
    /// Represents the update layout of UI element type.
    /// </summary>
    public delegate void updateLayoutOfUIElement(UIElement uie);
    //public delegate ListBoxItem getListBoxItemFromObject(ListBox lb, object )
    /// <summary>
    /// Represents the IH type.
    /// </summary>
    public static partial class IH
    {
        /// <summary>
        /// The delegate change visibility UI element wpf.
        /// </summary>
        public static changeVisibilityUIElementWpf delegateChangeVisibilityUIElementWpf = null;
        /// <summary>
        /// The delegate insert to list box wpf.
        /// </summary>
        public static insertToListBoxWpf delegateInsertToListBoxWpf = null;
        
        /// <summary>
        /// The delegate update border brush of border.
        /// </summary>
        public static updateBorderBrushOfBorder delegateUpdateBorderBrushOfBorder = null;
        /// <summary>
        /// The delegate get border brush of border.
        /// </summary>
        public static getBorderBrushOfBorder delegateGetBorderBrushOfBorder = null;
        
        /// <summary>
        /// The delegate update text block text.
        /// </summary>
        public static updateTextBlockText delegateUpdateTextBlockText = null;
        /// <summary>
        /// The delegate append to text block.
        /// </summary>
        public static appendToTextBlock delegateAppendToTextBlock = null;
        
        /// <summary>
        /// The delegate append to text box.
        /// </summary>
        public static appendToTextBox delegateAppendToTextBox = null;
        /// <summary>
        /// The delegate set data context.
        /// </summary>
        public static setDataContext delegateSetDataContext = null;
        /// <summary>
        /// The delegate get data context.
        /// </summary>
        public static getDataContext delegateGetDataContext = null;
        
        /// <summary>
        /// The delegate get selected item selector.
        /// </summary>
        public static getSelectedItemSelector delegateGetSelectedItemSelector = null;
        /// <summary>
        /// The delegate set items source of items control.
        /// </summary>
        public static setItemsSourceOfItemsControl delegateSetItemsSourceOfItemsControl = null;
        
        /// <summary>
        /// The delegate focus text box.
        /// </summary>
        public static focusTextBox delegateFocusTextBox = null;
        /// <summary>
        /// The delegate get text of text box.
        /// </summary>
        public static getTextOfTextBox delegateGetTextOfTextBox = null;
        
        /// <summary>
        /// The delegate get item at index in selector.
        /// </summary>
        public static getItemAtIndexInSelector delegateGetItemAtIndexInSelector = null;
        /// <summary>
        /// The delegate set selected item selector.
        /// </summary>
        public static setSelectedItemSelector delegateSetSelectedItemSelector = null;
        /// <summary>
        /// The delegate update layout of UI element.
        /// </summary>
        public static updateLayoutOfUIElement delegateUpdateLayoutOfUIElement = null;
        /// <summary>
        /// The get list box item from object.
        /// </summary>
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

        /// <summary>
        /// Update layout of UI element.
        /// </summary>
        /// <param name="uie">The uie.</param>
        public static void updateLayoutOfUIElement(UIElement uie)
        {
            uie.UpdateLayout();
        }

        /// <summary>
        /// Set selected item selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <param name="item">The item.</param>
        public static void setSelectedItemSelector(Selector selector, object item)
        {
            selector.SelectedItem = item;
        }

        /// <summary>
        /// Get item at index in selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <param name="dex">The dex.</param>
        /// <returns>The get item at index in selector result.</returns>
        public static object getItemAtIndexInSelector(Selector selector, int dex)
        {
            return selector.Items[dex];
        }

        

        /// <summary>
        /// Get text of text box.
        /// </summary>
        /// <param name="txt">The txt.</param>
        /// <returns>The get text of text box result.</returns>
        public static string getTextOfTextBox(TextBox txt)
        {
            return txt.Text;
        }

        /// <summary>
        /// Focus text box.
        /// </summary>
        /// <param name="txt">The txt.</param>
        public static void focusTextBox(TextBox txt)
        {
            txt.Focus(FocusState.Programmatic);
        }

        

        

        /// <summary>
        /// Update border brush of border value.
        /// </summary>
        /// <param name="border">The border.</param>
        /// <param name="brush">The brush.</param>
        public static void updateBorderBrushOfBorderValue(Border border, Brush brush)
        {
            border.BorderBrush = brush;
        }

        /// <summary>
        /// Get border brush of border value.
        /// </summary>
        /// <param name="border">The border.</param>
        /// <returns>The get border brush of border value result.</returns>
        public static Brush getBorderBrushOfBorderValue(Border border)
        {
            return border.BorderBrush;
        }

        

        static void setItemsSourceOfItemsControlM(ItemsControl itemsControl, IEnumerable items)
        {
            itemsControl.ItemsSource = items;
        }

        
        /// <summary>
        /// Update text block text.
        /// </summary>
        /// <param name="lbl">The lbl.</param>
        /// <param name="text">The text.</param>
        public static void updateTextBlockText(TextBlock lbl, string text)
        {
            lbl.Text = text;
            UpdateTooltip(lbl, text);
        }

        /// <summary>
        /// Append to text block text.
        /// </summary>
        /// <param name="lbl">The lbl.</param>
        /// <param name="text">The text.</param>
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

        /// <summary>
        /// Append to text box text.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="text">The text.</param>
        public static void appendToTextBoxText(TextBox textBox, string text)
        {
            textBox.Text = textBox.Text + AllStrings.space + text;
            UpdateTooltip(textBox, textBox.Text);
        }

        //
        /// <summary>
        /// Update visibility.
        /// </summary>
        /// <param name="uiElement">The ui element.</param>
        /// <param name="vis">The vis.</param>
        public static void updateVisibility(UIElement uiElement, Visibility vis)
        {
            uiElement.Visibility = vis;
        }



        /// <summary>
        /// Insert to list box wpf value.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public static void insertToListBoxWpfValue(ListBox listBox, int index, object value)
        {
            listBox.Items.Insert(index, value);
        }

        /// <summary>
        /// Set data context object.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <param name="dataContext">The data context.</param>
        public static void setDataContextObject(FrameworkElement frameworkElement, object dataContext)
        {
            frameworkElement.DataContext = dataContext;
        }

        /// <summary>
        /// Get data context object.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <returns>The get data context object result.</returns>
        public static object getDataContextObject(FrameworkElement frameworkElement)
        {
            return frameworkElement.DataContext;
        }

        

        /// <summary>
        /// Get selected item selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>The get selected item selector result.</returns>
        public static object getSelectedItemSelector(Selector selector)
        {
            return selector.SelectedItem;
        }
    }
