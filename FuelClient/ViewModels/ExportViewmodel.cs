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
        private Refuel mSelectedRefuel = new Refuel();
        public List<Refuel> toExport = new List<Refuel>();
        public ICommand ExportCommand { get; set; }
        public ObservableCollection<Car> CarModels { get; set; } = new ObservableCollection<Car>();
        public ObservableCollection<Refuel> RefuelsModel { get; set; } = new ObservableCollection<Refuel>();
        public Refuel SelectedRefuel
        {
            get { return mSelectedRefuel; }
            set
            {
                mSelectedRefuel = value;
                OnPropertyChanged();
                if (toExport.Contains(mSelectedRefuel) == false)
                {
                    toExport.Add(mSelectedRefuel);
                }
                else
                {
                    toExport.Remove(mSelectedRefuel);
                }
                
            }
        }
    }
}
