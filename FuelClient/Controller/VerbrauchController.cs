using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;

namespace FuelClient.Controller
{
    class VerbrauchController
    {
        private VerbrauchView mView;
        public VerbrauchViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public VerbrauchController(VerbrauchView view, VerbrauchViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var entry in client.GetEmployeeToCarById(mApplication.Employee))
            {
                mViewModel.CarModels.Add(entry.Car);
            }

            mView.DataContext = mViewModel;
            mViewModel.RefreshCommand = new RelayCommand(GetVerbrauch);

        }

        public void GetVerbrauch(object o)
        {
            foreach (var verbrauch in client.GetVerbrauch(mViewModel.SelectedCar))
            {
                mViewModel.VerbrauchModel.Add(verbrauch);
            }
            
        }
    }
}
