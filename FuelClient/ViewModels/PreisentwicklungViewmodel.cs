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
    class PreisentwicklungViewmodel : ViewModelBase
    {
        public ICommand RefreshCommand { get; set; }
        public ObservableCollection<FuelClient.Service.Car> CarModels { get; set; } = new ObservableCollection<FuelClient.Service.Car>();
        public ObservableCollection<Verbrauch> PreisentwicklungModel { get; set; } = new ObservableCollection<Verbrauch>();

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
        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged();
            }
        }
    }
}
