namespace apps.UniversalWebControl;

using apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the go back command type.
    /// </summary>
    public class GoBackCommand : ISunamoAsyncCommand
    {
        static bool? previousCanExecute = null;
        /// <summary>
        /// Bude nastaven na null pokud nebude zobrazen žádný SunamoBrowser
        /// </summary>
        static WebView2 webView = null;
        /// <summary>
        /// 
        /// </summary>
        static SunamoBrowser sunamoBrowser = null;

        /// <summary>
        /// Set.
        /// </summary>
        /// <param name="sunamoBrowser2">The sunamo browser 2.</param>
        /// <returns>The set result.</returns>
        public async static Task< bool> Set(SunamoBrowser sunamoBrowser2)
        {
            ISunamoAsyncCommand currentCommand = SunamoBrowser.Instance.cmdGoBackCommand;
            bool canExecute = false;
            if (sunamoBrowser2 == null)
            {
                canExecute = false;
            }
            else
            {
                sunamoBrowser = sunamoBrowser2;
                webView = sunamoBrowser2.WebView;
                canExecute = await currentCommand.CanExecute(null);
            }
            if (previousCanExecute.HasValue)
            {
                if (previousCanExecute.Value != canExecute)
                {
                    currentCommand.RaiseCanExecuteChanged(canExecute);
                }
            }
            else
            {
                currentCommand.RaiseCanExecuteChanged(canExecute);
            }

            previousCanExecute = canExecute;
            return canExecute;
        }

        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canNow">The can now.</param>
        public void RaiseCanExecuteChanged(bool canNow)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(webView, canNow);
            }
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event VoidObjectBool CanExecuteChanged;

        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute result.</returns>
        public async Task< bool> CanExecute(object parameter)
        {
            if (webView != null)
            {
                if (!sunamoBrowser.IsNavigating)
                {
                    if (sunamoBrowser.WebView.CanGoBack)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        /// <summary>
        /// A1 je aktuální index(ne nový!!)
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            webView.GoBack();
        }
    }

    /// <summary>
    /// Represents the go forward command type.
    /// </summary>
    public class GoForwardCommand : ISunamoAsyncCommand
    {
        static bool? previousCanExecute = null;
        /// <summary>
        /// Bude nastaven na null pokud nebude zobrazen žádný SunamoBrowser
        /// </summary>
        static WebView2 webView = null;
        /// <summary>
        /// 
        /// </summary>
        static SunamoBrowser sunamoBrowser = null;

        /// <summary>
        /// Set.
        /// </summary>
        /// <param name="sunamoBrowser2">The sunamo browser 2.</param>
        /// <returns>The set result.</returns>
        public async static Task< bool> Set(SunamoBrowser sunamoBrowser2)
        {
            ISunamoAsyncCommand currentCommand = SunamoBrowser.Instance.cmdGoForwardCommand;
            bool canExecute = false;
            if (sunamoBrowser2 == null)
            {
                canExecute = false;
            }
            else
            {
                sunamoBrowser = sunamoBrowser2;
                webView = sunamoBrowser2.WebView;
                canExecute = await currentCommand.CanExecute(null);
            }
            if (previousCanExecute.HasValue)
            {
                if (previousCanExecute.Value != canExecute)
                {
                    currentCommand.RaiseCanExecuteChanged(canExecute);
                }
            }
            else
            {
                currentCommand.RaiseCanExecuteChanged(canExecute);
            }
            previousCanExecute = canExecute;
            return canExecute;
        }

        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canNow">The can now.</param>
        public void RaiseCanExecuteChanged(bool canNow)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(webView, canNow);
            }
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event VoidObjectBool CanExecuteChanged;

        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute result.</returns>
        public async Task<bool> CanExecute(object parameter)
        {
            if (webView != null)
            {
                if (!sunamoBrowser.IsNavigating)
                {
                    if (sunamoBrowser.WebView.CanGoForward)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        /// <summary>
        /// A1 je aktuální index(ne nový!!)
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            webView.Reload();
        }
    }

    /// <summary>
    /// Represents the reload command type.
    /// </summary>
    public class ReloadCommand : ISunamoAsyncCommand
    {
        static bool? previousCanExecute = null;
        /// <summary>
        /// Bude nastaven na null pokud nebude zobrazen žádný SunamoBrowser
        /// </summary>
        static WebView2 webView = null;
        /// <summary>
        /// 
        /// </summary>
        static SunamoBrowser sunamoBrowser = null;

        /// <summary>
        /// Set.
        /// </summary>
        /// <param name="sunamoBrowser2">The sunamo browser 2.</param>
        /// <returns>The set result.</returns>
        public async static Task< bool> Set(SunamoBrowser sunamoBrowser2)
        {
            ISunamoAsyncCommand currentCommand = SunamoBrowser.Instance.cmdReloadCommand;
            bool canExecute = false;
            if (sunamoBrowser2 == null)
            {
                canExecute = false;
            }
            else
            {
                sunamoBrowser = sunamoBrowser2;
                webView = sunamoBrowser2.WebView;
                canExecute = await currentCommand.CanExecute(null);
            }
            if (previousCanExecute.HasValue)
            {
                if (previousCanExecute.Value != canExecute)
                {
                    currentCommand.RaiseCanExecuteChanged(canExecute);
                }
            }
            else
            {
                currentCommand.RaiseCanExecuteChanged(canExecute);
            }
            previousCanExecute = canExecute;
            return canExecute;
        }

        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canNow">The can now.</param>
        public void RaiseCanExecuteChanged(bool canNow)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(webView, canNow);
            }
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event VoidObjectBool CanExecuteChanged;

        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute result.</returns>
        public async Task<bool> CanExecute(object parameter)
        {
            if (webView != null)
            {
                if (!sunamoBrowser.IsNavigating)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// A1 je aktuální index(ne nový!!)
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            webView.Reload();
        }
    }

    /// <summary>
    /// Represents the stop loading command type.
    /// </summary>
    public class StopLoadingCommand : ISunamoAsyncCommand
    {
        static bool? previousCanExecute = null;
        /// <summary>
        /// Bude nastaven na null pokud nebude zobrazen žádný SunamoBrowser
        /// </summary>
        static WebView2 webView = null;
        /// <summary>
        /// 
        /// </summary>
        static SunamoBrowser sunamoBrowser = null;

        /// <summary>
        /// Set.
        /// </summary>
        /// <param name="sunamoBrowser2">The sunamo browser 2.</param>
        /// <returns>The set result.</returns>
        public async static Task<bool> Set(SunamoBrowser sunamoBrowser2)
        {
            ISunamoAsyncCommand currentCommand = SunamoBrowser.Instance.cmdStopLoadingCommand;
            bool canExecute = false;
            if (sunamoBrowser2 == null)
            {
                canExecute = false;
            }
            else
            {
                sunamoBrowser = sunamoBrowser2;
                webView = sunamoBrowser2.WebView;
                canExecute = await currentCommand.CanExecute(null);
            }
            if (previousCanExecute.HasValue)
            {
                if (previousCanExecute.Value != canExecute)
                {
                    currentCommand.RaiseCanExecuteChanged(canExecute);
                }
            }
            else
            {
                currentCommand.RaiseCanExecuteChanged(canExecute);
            }
            previousCanExecute = canExecute;
            return canExecute;
        }

        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canNow">The can now.</param>
        public void RaiseCanExecuteChanged(bool canNow)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(webView, canNow);
            }
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event VoidObjectBool CanExecuteChanged;

        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute result.</returns>
        public async Task< bool> CanExecute(object parameter)
        {
            if (webView != null)
            {
                if (sunamoBrowser.IsNavigating)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// A1 je aktuální index(ne nový!!)
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            webView.CoreWebView2?.Stop();
        }
    }
