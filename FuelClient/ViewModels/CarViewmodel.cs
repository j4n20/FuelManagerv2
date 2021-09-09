using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelClient.Framework;

namespace FuelClient.ViewModels
{
    class CarViewmodel : ViewModelBase
    {
        private FuelClient.Service.Car mSelectedModel = new FuelClient.Service.Car();

        public ObservableCollection<FuelClient.Service.Car> Models { get; set; } = new ObservableCollection<FuelClient.Service.Car>();

        public FuelClient.Service.Car SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;
                OnPropertyChanged();
            }
        }

        private bool _setread = true;
        public bool Setread
        {
            get { return _setread; }
            set
            {
                _setread = value;
                OnPropertyChanged();
            }
        }
    }
}
