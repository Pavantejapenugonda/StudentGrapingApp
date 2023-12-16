using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CPSC440_F2023_Project.ViewModel
{
    internal class RelayCommand: ICommand
    {
        private Action<object> exit;

        public RelayCommand(Action<object> exit)
        {
            this.exit = exit;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };
        public void Execute(object parameter)
        {
            exit(parameter);
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }
    }
}
