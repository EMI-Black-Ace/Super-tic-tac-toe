using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Super_tic_tac_toe.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action Command;
        private readonly Func<object, bool> ExecuteCondition;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action command, Func<object, bool> executeCondition)
        {
            Command = command;
            ExecuteCondition = executeCondition;
        }

        public bool CanExecute(object parameter)
        {
            return ExecuteCondition(parameter);
        }

        public void Execute(object parameter)
        {
            if(CanExecute(parameter)) Command();
        }
    }
}
