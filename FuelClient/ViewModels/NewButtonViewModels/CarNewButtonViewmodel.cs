using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.ViewModels.NewButtonViewModels
{
    class CarNewButtonViewmodel
    {
        public ICommand AddCarCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Car Model { get; set; }

    }
}
