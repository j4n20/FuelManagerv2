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
        public ICommand CarViewCommand { get; set; }
        public ICommand RefuelViewCommand { get; set; }
        public ICommand VerbrauchViewCommand { get; set; }
        public ICommand PreisentwicklungViewCommand { get; set; }
        public ICommand ImportViewCommand { get; set; }
        public ICommand ExportViewCommand { get; set; }
        public ICommand FEmployeeViewCommand { get; set; }
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
