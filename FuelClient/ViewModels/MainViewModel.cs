using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelClient.Framework;

namespace FuelClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand AufträgeViewCommand { get; set; }
        public ICommand UmsatzranglisteViewCommand { get; set; }
        public ICommand BestsellerViewCommand { get; set; }
        public ICommand UserViewCommand { get; set; }
        public ICommand ArticleViewCommand { get; set; }
        public ICommand DriverViewCommand { get; set; }
        public ICommand AreaViewCommand { get; set; }
        public ICommand EditCommand{ get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand HomeViewCommand{ get; set; }
        public ICommand KundenViewCommand { get; set; }
        
        private object _selectedController;
        public object SelectedController
        {
            get { return _selectedController; }
            set
            {
                _selectedController = value;
                OnPropertyChanged();
            }
        }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            
        }
    }
}
