namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

    public class SelectorHelperListViewCommands
    {
        public RemoveOneCommand RemoveOneCmd
        {
            get
            {
                return new RemoveOneCommand();
            }
        }

        public SaveToClipboardCommand SaveToClipboardCmd
        {
            get
            {
                return new SaveToClipboardCommand();
            }
        }

        public RunOneCommand RunOneCmd
        {
            get
            {
                return new RunOneCommand();
            }
        }

        public class RemoveOneCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.RemoveOne(selectorHelperItem.Id);
            }
        }

        public class SaveToClipboardCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.SaveToClipboard(selectorHelperItem.Id);
            }
        }

        public class RunOneCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                SelectorHelperItem selectorHelperItem = (SelectorHelperItem)parameter;

                 selectorHelperItem.sh.RunOne(selectorHelperItem.Id);
            }
        }
    }
