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
    class RefuelController
    {
        private RefuelsView mView;
        public RefuelsViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public RefuelController(RefuelsView view, RefuelsViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var entry in client.GetEmployeeToCarById(mApplication.Employee))
            {
                mViewModel.CarModels.Add(entry.Car);
            }
            foreach (var car in mViewModel.CarModels)
            {
                foreach (var refuel in client.GetRefuelById(car))
                {
                    mViewModel.RefuelsModels.Add(refuel);
                    mViewModel.SelectedModel = refuel;
                }
            }
            mView.DataContext = mViewModel;
            
        }

        public void ExecuteEditCommand()
        {
            mViewModel.Setread = false;
            //mViewModel.CarBox = mViewModel.SelectedModel.Car.LicensePlate;
        }

        public void ExecuteNewCommand()
        {
            RefuelNewButtonController mController = mApplication.Container.Resolve<RefuelNewButtonController>();
            var result = mController.AddRefuel(mViewModel.CarModels);

            if (result != null)
            {
                mViewModel.RefuelsModels.Clear();
                foreach (var car in mViewModel.CarModels)
                {
                    foreach (var refuel in client.GetRefuelById(car))
                    {
                        mViewModel.RefuelsModels.Add(refuel);
                        mViewModel.SelectedModel = refuel;
                    }
                }
            }

        }

        public void ExecuteDeleteCommand()
        {
            if (mViewModel.SelectedModel != null)
            {

                var check = client.DeleteRefuel(mViewModel.SelectedModel.Id);
                if (check == false)
                {
                    //mView.DeletionCheck.Content = "Error";
                    MessageBox.Show("Error: There is data connected to this employee");
                }
                else
                {
                    mViewModel.RefuelsModels.Remove(mViewModel.SelectedModel);

                }
            }
        }

        public void ExecuteSaveCommand()
        {
            Refuel refuel = new Refuel
            {
                Car = (Car)mView.CarComboBox.SelectedItem,
                Date = (DateTime)mView.DatePicker.SelectedDate,
                Mileage = mView.MileageTextBox.Text,
                Amount = (float)Decimal.Parse(mView.AmountTextBox.Text),
                Price = (float)Decimal.Parse(mView.PriceTextBox.Text),
                Id = mViewModel.SelectedModel.Id
            };
            
        }

        
    }
}
