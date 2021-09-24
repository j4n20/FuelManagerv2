using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using FuelClient.Controller.NewButtonController;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;

namespace FuelClient.Controller
{
    class CarController
    {
        private CarView mView;
        public CarViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public CarController(CarView view, CarViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var car in client.GetCars())
            {
                mViewModel.Models.Add(car);
                mViewModel.SelectedModel = car;
            }

            mView.DataContext = mViewModel;

        }

        public void ExecuteDeleteCommand()
        {
            if (mViewModel.SelectedModel != null)
            {
               
                var check = client.DeleteCar(mViewModel.SelectedModel.Id);
                if (check == false)
                {
                    //mView.DeletionCheck.Content = "Error";
                    MessageBox.Show("Error: There is data connected to this car");
                }
                else
                {
                    mViewModel.Models.Remove(mViewModel.SelectedModel);

                }
            }
        }

        public void ExecuteNewCommand()
        {
            CarNewButtonController mController = mApplication.Container.Resolve<CarNewButtonController>();
            var result = mController.AddCar();

            if (result != null)
            {
                client.AddCar(result);
                mViewModel.Models.Clear();
                foreach (var car in client.GetCars())
                {
                    mViewModel.Models.Add(car);
                    mViewModel.SelectedModel = car;
                }
            }
        }
        public void ExecuteEditCommand()
        {
            mViewModel.Setread = false;
        }
        public void ExecuteSaveCommand()
        {
            Car car = new Car
            {

                LicensePlate = mView.KennzeichenTextBox.Text,
                Vendor = mView.HerstellerTextBox.Text,
                Model = mView.ModellTextBox.Text,
                Id = mViewModel.SelectedModel.Id
            };

            client.AddCar(car);
        }
    }
}
