using apps.PopupsNoResponsive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace apps;
    class DW
    {
        private static bool ShowMessageDialog(string text, string typZpravy)
        {
            MessageDialog md = new MessageDialog(text, ThisApp.Name + AllStrings.swda + typZpravy);
            md.Options = MessageDialogOptions.None;
            var d = md.ShowAsync();
            return true;
        }

        public static bool ErrorAwait(string text)
        {
            return  ShowMessageDialog(text, sess.i18n( "Error"));
        }

        public static bool WarningAwait(string text)
        {
            return  ShowMessageDialog(text, sess.i18n( "Warning"));
        }

        public static bool InfoAwait(string text)
        {
            return  ShowMessageDialog(text, sess.i18n( "Information"));
        }

        public static bool SuccessAwait(string text)
        {
            return  ShowMessageDialog(text, sess.i18n( "Success"));
        }



    }
