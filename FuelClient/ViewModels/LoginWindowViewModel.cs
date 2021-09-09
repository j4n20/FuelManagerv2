using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelClient.Framework;

namespace FuelClient.ViewModels
{
    public class LoginWindowViewModel: ViewModelBase
    {
        private FuelClient.Service.FEmployee mSelectedModel = new FuelClient.Service.FEmployee();

        public ObservableCollection<FuelClient.Service.FEmployee> Models { get; set; } = new ObservableCollection<FuelClient.Service.FEmployee>();
        public FuelClient.Service.FEmployee SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                mSelectedModel = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get
            {
                return mSelectedModel.Username;
            }
            set
            {
                mSelectedModel.Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return mSelectedModel.Password;
            }
            set
            {
                mSelectedModel.Password = value;
                OnPropertyChanged();
            }
        }
        public ICommand LoginCommand { get; set; }
    }
}
