namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the button with action type.
    /// </summary>
    public  class ButtonWithAction : UserControl, IIdentificator
    {
        VoidObject action = null;
        FrameworkElement fe = null;
        //sunamo.Action action = sunamo.Action.Nope;
        /// <summary>
        /// The id.
        /// </summary>
        public object Id
        {
            get; set;
        }
        /// <summary>
        /// Init button with action.
        /// </summary>
        /// <param name="visible">The visible.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="action">The action.</param>
        /// <param name="content">The content.</param>
        /// <param name="idObject">The id object.</param>
        /// <returns>The init button with action result.</returns>
        public ButtonWithAction InitButtonWithAction(bool visible, double width, double height, VoidObject action, object content, object idObject)
        {
            if (visible)
            {
                this.Id = idObject;
                string text = "";
                if (content != null)
                {
                    text = content.ToString();
                }
                this.action = action;
                if (action == null)
                {
                    fe = new TextBlock();
                    TextBlock textBlock = fe as TextBlock;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.Text = text;
                }
                else
                {
                    fe = new Button();
                    Button button = fe as Button;
                    button.Margin = new Thickness(5, 0, 5, 0);
                    button.Click += Button_Click;
                    button.HorizontalContentAlignment = HorizontalAlignment.Center;
                    button.VerticalContentAlignment = VerticalAlignment.Center;
                    
                    TextBlock textBlock = new TextBlock();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.Text = text;
                    
                    button.Width = width;
                    button.Height = height;

                    button.Content = textBlock;
                    //SetButtonContent();
                }
                
                Content = fe;
            }
            return this;
        }


        /// <summary>
        /// Set button content.
        /// </summary>
        /// <param name="content">The content.</param>
        protected void SetButtonContent(object content)
        {
            if (fe is Button)
            {
                //this.content = content;
                Button button = fe as Button;
                button.Content = content;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs eventArgs)
        {
            if (action != null)
            {
                 action.Invoke(Id);
            }
        }
    }
