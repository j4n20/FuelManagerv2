using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels.NewButtonViewModels;
using FuelClient.Views.NewButtonViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FuelClient.Controller.NewButtonController
{
    class FEmployeeNewButtonController
    {
        public FEmployeeNewButtonView mView;
        private FEmployeeNewButtonViewmodel mViewModel;
        private App mApplication;
        private AuthentificationServiceClient client = new AuthentificationServiceClient();
        public bool isCancelled = false;

        public FEmployeeNewButtonController(FEmployeeNewButtonView view, FEmployeeNewButtonViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            mView.DataContext = mViewModel;

            mViewModel.AddFEmployeeCommand = new RelayCommand(ExecuteNewCommand);
            mViewModel.CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        public void ExecuteCancelCommand(object o)
        {
            mView.DialogResult = true;
            mViewModel.Model = null;
            mView.Close();
            isCancelled = true;
        }
        public void ExecuteNewCommand(object o)
        {
            mView.DialogResult = true;
            mView.Close();
        }

        public FEmployee AddFEmployee()
        {
            mView.ShowDialog();
            if(isCancelled == false)
            {
                try
                {
                    mViewModel.Model = new FEmployee
                    {
                        Firstname = mView.SelectedFirstname.Text,
                        Lastname = mView.SelectedLastname.Text,
                        EmployeeNo = Guid.NewGuid().ToString(),
                        Password = mView.PasswordBox.Password,
                        Username = mView.SelectedUsername.Text.ToLower()
                    };
                    if (mView.AdminCheckBox.IsChecked == true)
                    {
                        mViewModel.Model.isAdmin = true;
                    }
                    else
                    {
                        mViewModel.Model.isAdmin = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Something went wrong please try again.");
                    return null;
                }
                var check = client.AddUser(mViewModel.Model);
                if(check!= true)
                {
                    MessageBox.Show("Error: Missing input");
                    return null;
                }
                return mViewModel.Model;
            }

            return mViewModel.Model;
        }
    }
}
