using FuelClient.Service;
using FuelClient.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.ViewModels
{
    class RefuelsViewmodel : ViewModelBase
    {
        public ICommand MinusCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand SelectionChanged { get; set; }
        

        private FuelClient.Service.Car mSelectedCar = new FuelClient.Service.Car();

        private FuelClient.Service.Refuel mSelectedModel = new FuelClient.Service.Refuel();

        public ObservableCollection<Car> CarModels { get; set; } = new ObservableCollection<FuelClient.Service.Car>();
        public ObservableCollection<FuelClient.Service.Refuel> RefuelsModels { get; set; } = new ObservableCollection<FuelClient.Service.Refuel>();

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
        public FuelClient.Service.Refuel SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;

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

        private DateTime mOrderDateBox = DateTime.Now;
        public DateTime DateTimeBox
        {
            get { return mOrderDateBox; }
            set
            {
                mOrderDateBox = value;
                OnPropertyChanged();
            }
        }

        private Car mCarBox = new Car();

        public Car CarBox
        {
            get { return mCarBox; }
            set
            {
                mCarBox = value;
                OnPropertyChanged();
                
            }
        }
        
    }
}
