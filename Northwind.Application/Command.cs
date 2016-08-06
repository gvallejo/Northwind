using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Application
{
    public class Command : ICommand
    {
        //public event EventHandler CanExecuteChanged = delegate { };

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> execute):this(execute, null)
        {

        }

        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            //if is _canExecute is null then default to true, else evaluate _canExecute using passed parameter
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged

        {

            add

            {

                if (_canExecute != null)

                {

                    CommandManager.RequerySuggested += value;

                }

            }

            remove

            {

                if (_canExecute != null)

                {

                    CommandManager.RequerySuggested -= value;

                }

            }

        }



        public void RaiseCanExecuteChanged()

        {

            CommandManager.InvalidateRequerySuggested();

        }

    }
}
