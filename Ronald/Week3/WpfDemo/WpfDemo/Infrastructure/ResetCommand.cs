using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo
{
    public class ResetCommand : ICommand
    {
        private WeightViewModel weightViewModel;

        public ResetCommand(WeightViewModel weightViewModel)
        {
            this.weightViewModel = weightViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => weightViewModel == null ? false : weightViewModel.Kilo >= 0;

        public void Execute(object parameter)
        {
            weightViewModel.Kilo = 0;
        }
    }
}
