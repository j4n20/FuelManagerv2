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
    class PreisentwicklungViewModel : ViewModelBase
    {
        public ObservableCollection<Preisentwicklung> Preisentwicklung { get; set; } = new ObservableCollection<Preisentwicklung>();
    }
}
