using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FuelClient.Framework;
using FuelClient.Service;

namespace FuelClient.ViewModels
{
    class FEMmployeeViewmodel : ViewModelBase
    {
        public ICommand EmployeeSelectedCommand { get; set; }
        public ICommand MinusCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand ConnectCommand { get; set; }
        
        private FuelClient.Service.FEmployee mSelectedModel = new FuelClient.Service.FEmployee();


        public ObservableCollection<FuelClient.Service.FEmployee> Models { get; set; } = new ObservableCollection<FuelClient.Service.FEmployee>();
        public ObservableCollection<Car> CarModels { get; set; } = new ObservableCollection<Car>();

        public FuelClient.Service.FEmployee SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;
                CarModels.Clear();
                OnPropertyChanged();
            }
        }

        private Car mCar;
        public Car SelectedCarModel
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

        private bool _setenabled = false;
        public bool Setenabled
        {
            get { return _setenabled; }
            set
            {
                _setenabled = value;
                OnPropertyChanged();
            }
        }
        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnPropertyChanged();
            }
        }
    }
}
