using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SupremeLollipopClient.Framework;

namespace SupremeLollipopClient.ViewModels
{
    public class LoginWindowViewModel: ViewModelBase
    {
        private SupremeLollipopService.FEmployee mSelectedModel = new SupremeLollipopService.FEmployee();

        public ObservableCollection<SupremeLollipopService.FEmployee> Models { get; set; } = new ObservableCollection<SupremeLollipopService.FEmployee>();
        public SupremeLollipopService.FEmployee SelectedModel
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
