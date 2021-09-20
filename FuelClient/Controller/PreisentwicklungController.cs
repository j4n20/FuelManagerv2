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
    class PreisentwicklungController
    {
        private PreisentwicklungView mView;
        public PreisentwicklungViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public PreisentwicklungController(PreisentwicklungView view, PreisentwicklungViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var entry in client.GetEmployeeToCarById(mApplication.Employee))
            {
                mViewModel.CarModels.Add(entry.Car);
            }

            mView.DataContext = mViewModel;
            mViewModel.RefreshCommand = new RelayCommand(GetPreisentwicklung);
        }

        public void GetPreisentwicklung(object o)
        {
            foreach (var preis in client.GetPreisentwicklung(mViewModel.SelectedCar))
            {
                mViewModel.PreisentwicklungModel.Add(preis);
            }

        }
    }
}
