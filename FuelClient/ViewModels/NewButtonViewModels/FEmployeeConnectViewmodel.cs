using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.ViewModels.NewButtonViewModels
{
    class FEmployeeConnectViewmodel
    {
        public ICommand ConnectCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ObservableCollection<Car> CarModel { get; set; } = new ObservableCollection<Car>();
    }
}
