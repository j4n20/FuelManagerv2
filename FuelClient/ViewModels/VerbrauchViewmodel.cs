using SupremeLollipopClient.Framework;
using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SupremeLollipopClient.ViewModels
{
    class VerbrauchgViewModel : ViewModelBase
    {
        public ObservableCollection<Verbrauch> Verbrauch { get; set; } = new ObservableCollection<Verbrauch>();
    }
}
