namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

    /// <summary>
    /// Represents the selector helper list view commands type.
    /// </summary>
    public class SelectorHelperListViewCommands
    {
        /// <summary>
        /// The remove one cmd.
        /// </summary>
        public RemoveOneCommand RemoveOneCmd
        {
            get
            {
                return new RemoveOneCommand();
            }
        }

        /// <summary>
        /// The save to clipboard cmd.
        /// </summary>
        public SaveToClipboardCommand SaveToClipboardCmd
        {
            get
            {
                return new SaveToClipboardCommand();
            }
        }

        /// <summary>
        /// The run one cmd.
        /// </summary>
        public RunOneCommand RunOneCmd
        {
            get
            {
                return new RunOneCommand();
            }
        }

        /// <summary>
        /// Represents the remove one command type.
        /// </summary>
        public class RemoveOneCommand : ICommand
        {
            /// <summary>
            /// The can execute changed.
            /// </summary>
            public event EventHandler CanExecuteChanged;

            /// <summary>
            /// Can execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            /// <returns>The can execute result.</returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }

            /// <summary>
            /// Execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.RemoveOne(selectorHelperItem.Id);
            }
        }

        /// <summary>
        /// Represents the save to clipboard command type.
        /// </summary>
        public class SaveToClipboardCommand : ICommand
        {
            /// <summary>
            /// The can execute changed.
            /// </summary>
            public event EventHandler CanExecuteChanged;

            /// <summary>
            /// Can execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            /// <returns>The can execute result.</returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }

            /// <summary>
            /// Execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.SaveToClipboard(selectorHelperItem.Id);
            }
        }

        /// <summary>
        /// Represents the run one command type.
        /// </summary>
        public class RunOneCommand : ICommand
        {
            /// <summary>
            /// The can execute changed.
            /// </summary>
            public event EventHandler CanExecuteChanged;

            /// <summary>
            /// Can execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            /// <returns>The can execute result.</returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }

            /// <summary>
            /// Execute.
            /// </summary>
            /// <param name="parameter">The parameter.</param>
            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.RunOne(selectorHelperItem.Id);
            }
        }
    }
