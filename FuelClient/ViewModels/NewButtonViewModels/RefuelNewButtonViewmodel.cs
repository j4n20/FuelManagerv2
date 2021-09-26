using FuelClient.Framework;
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
    class RefuelNewButtonViewmodel : ViewModelBase
    {
        public ObservableCollection<FuelClient.Service.Car> CarModels { get; set; } = new ObservableCollection<FuelClient.Service.Car>();
        public Refuel refuel = new Refuel();

        public ICommand AddTankenCommand { get; set; }

        public ICommand CancelCommand { get; set; }
        private Car mSelectedCar { get; set; }
        public Car SelectedCar
        {
            get { return mSelectedCar; }
            set
            {
                mSelectedCar = value;
                OnPropertyChanged();
            }
        }
    }
}
