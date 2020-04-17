using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BillingManagement.UI.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<Object> _execute;
        readonly Predicate<Object> _canExecute;


        //----------------------------------------------------------------------------Constructeurs

        public RelayCommand(Action<Object> execute, Predicate<Object> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("execuste");

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<Object> execute) : this(execute, null)
        {

        }


        //----------------------------------------------------------------------------Methodes

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }



        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
