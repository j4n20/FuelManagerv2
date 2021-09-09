using FuelClient.Framework;
using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.ViewModels
{
    class ExportViewmodel : ViewModelBase
    {
        public ICommand ExportCommand { get; set; }
        public ObservableCollection<Car> CarModels { get; set; } = new ObservableCollection<Car>();
        public ObservableCollection<Refuel> RefuelsModel { get; set; } = new ObservableCollection<Refuel>();

        
    }
}
