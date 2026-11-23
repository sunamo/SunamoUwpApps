namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;

    /// <summary>
    /// Represents the i sunamo async command base type.
    /// </summary>
    public interface ISunamoAsyncCommandBase
    {
        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canExecute">The can execute.</param>
        void RaiseCanExecuteChanged(bool canExecute);

    }

    /// <summary>
    /// Represents the i sunamo async command type.
    /// </summary>
    public interface ISunamoAsyncCommand : ISunamoAsyncCommandBase //: ICommand
    {
        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute result.</returns>
        Task< bool> CanExecute(object parameter);

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        void Execute(object parameter);
    }

    /// <summary>
    /// Represents the i sunamo async command routed type.
    /// </summary>
    public interface ISunamoAsyncCommandRouted : ISunamoAsyncCommandBase //: ICommand
    {


        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="eventArgs">The event args.</param>
        void Execute(object parameter, RoutedEventArgs eventArgs);
    }

    /// <summary>
    /// Represents the i sunamo command type.
    /// </summary>
    public interface ISunamoCommand : ICommand
    {
        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        /// <param name="canExecute">The can execute.</param>
        void RaiseCanExecuteChanged(bool canExecute);
        /// <summary>
        /// Update associated controls.
        /// </summary>
        void UpdateAssociatedControls();
    }
