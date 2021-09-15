using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelClient.Framework;

namespace FuelClient.ViewModels.NewButtonViewModels
{
    class FEmployeeConnectViewmodel : ViewModelBase
    {
        public ICommand ConnectCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public Car mSelectedModel;
        public ObservableCollection<Car> CarModel { get; set; } = new ObservableCollection<Car>();

        public Car SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;
                OnPropertyChanged();
            }
        }
    }
}
