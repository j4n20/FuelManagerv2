using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels.NewButtonViewModels;
using FuelClient.Views.NewButtonViews;

namespace FuelClient.Controller.NewButtonController
{
    class FEmployeeConnectController
    {
        public FEmployeeConnectButtonView mView;
        private FEmployeeConnectViewmodel mViewModel;
        private App mApplication;
        private AuthentificationServiceClient client = new AuthentificationServiceClient();
        public bool isCancelled = false;

        public FEmployeeConnectController(FEmployeeConnectButtonView view, FEmployeeConnectViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            mView.DataContext = mViewModel;

            foreach(var unconnectedCar in client.GetUnconnectedCars())
            {
                mViewModel.CarModel.Add(unconnectedCar);
            }
            
            mViewModel.ConnectCommand = new RelayCommand(ExecuteConnectCommand);
            mViewModel.CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        public void ExecuteCancelCommand(object o)
        {
            mView.DialogResult = true;
            mViewModel.CarModel = null;
            mView.Close();
            isCancelled = true;
        }

        public void ExecuteConnectCommand(object o)
        {
            mView.DialogResult = true;
            mView.Close();
        }

        public Car ConnectCar()
        {
            mView.ShowDialog();
            if (isCancelled == false)
            {
                return mViewModel.SelectedModel;
            }
            else
            {
                MessageBox.Show("Error: Missing input");
                return null;
            }
            
        }
    }
}
