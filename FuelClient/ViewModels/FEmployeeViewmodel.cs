using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SupremeLollipopClient.Framework;
using FuelClient.Service;

namespace SupremeLollipopClient.ViewModels
{
    class FEMmployeeViewmodel : ViewModelBase
    {
        public ICommand EmployeeSelectedCommand { get; set; }
        private FuelClient.Service.FEmployee mSelectedModel = new FuelClient.Service.FEmployee();


        public ObservableCollection<FuelClient.Service.FEmployee> Models { get; set; } = new ObservableCollection<FuelClient.Service.FEmployee>();
        public ObservableCollection<SelectedCar> CarModels { get; set; } = new ObservableCollection<SelectedCar>();

        public FuelClient.Service.FEmployee SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;
                OnPropertyChanged();
            }
        }

        private SelectedCar mCar;
        public SelectedCar SelectedCarModel
        {
            get { return mCar; }
            set
            {
                mCar = value;
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

        private bool _setvisible = false;
        public bool Setvisible
        {
            get { return _setvisible; }
            set
            {
                _setvisible = value;
                OnPropertyChanged();
            }
        }

        private bool _setchecked = false;
        public bool Setchecked
        {
            get { return _setchecked; }
            set
            {
                _setchecked = value;
                OnPropertyChanged();
            }
        }
    }
}
