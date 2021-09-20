using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels.NewButtonViewModels;
using FuelClient.Views.NewButtonViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace FuelClient.Controller.NewButtonController
{
    class RefuelNewButtonController
    {
        public RefuelNewButtonView mView;
        private RefuelNewButtonViewmodel mViewModel;
        private App mApplication;
        private AuthentificationServiceClient client = new AuthentificationServiceClient();
        public bool isCancelled = false;

        public RefuelNewButtonController(RefuelNewButtonView view, RefuelNewButtonViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            mView.DataContext = mViewModel;

            mViewModel.AddTankenCommand = new RelayCommand(ExecuteAddTankenCommand);
            mViewModel.CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        public void ExecuteCancelCommand(object o)
        {
            mView.DialogResult = true;
            mViewModel.refuel = null;
            mView.Close();
            isCancelled = true;
        }

        public void ExecuteAddTankenCommand(object o)
        {
            mView.DialogResult = true;
            mView.Close();
        }

        public Refuel AddRefuel(ObservableCollection<Car> cars)
        {
            mViewModel.CarModels = cars;
            mView.ShowDialog();
            if (isCancelled == false)
            {
                try
                {
                    mViewModel.refuel = new Refuel
                    {
                        Price = (float)Decimal.Parse(mView.Preis.Text),
                        Mileage = mView.Kilometerstand.Text,
                        Amount = (float)Decimal.Parse(mView.Liter.Text),
                        Date = (DateTime)mView.DatePicker1.SelectedDate,
                        Car = (Car)mView.CarComboBox.SelectedItem
                    };
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Something went wrong please try again.");
                    return null;
                }
                var check = client.AddRefuel(mViewModel.refuel);
                if (check != true)
                {
                    MessageBox.Show("Error: Missing input");
                    return null;
                }
                return mViewModel.refuel;
            }

            return mViewModel.refuel;

        }
    }
}
