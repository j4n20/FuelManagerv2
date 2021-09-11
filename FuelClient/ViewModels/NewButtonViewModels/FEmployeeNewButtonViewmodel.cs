using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.ViewModels.NewButtonViewModels
{
    class FEmployeeNewButtonViewmodel
    {
        public ICommand AddFEmployeeCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
