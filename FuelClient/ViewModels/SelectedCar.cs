using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelClient.Service;

namespace SupremeLollipopClient.ViewModels
{
    public class SelectedCar
    {
        public bool isSelected { get; set; } = false;
        public Car Vehicle { get; set; }
    }
}
