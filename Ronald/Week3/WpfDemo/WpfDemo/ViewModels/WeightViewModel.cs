using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo
{
    public class WeightViewModel : INotifyPropertyChanged
    {
        private double _kilo;

        public WeightViewModel()
        {
            ResetCommand = new ResetCommand(this);
        }

        public double Kilo
        {
            get => _kilo;
            set
            {
                _kilo = value;
                RaisePropertyChanged("Kilo");
            }
        }

        public ICommand ResetCommand { get; set; }


        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
