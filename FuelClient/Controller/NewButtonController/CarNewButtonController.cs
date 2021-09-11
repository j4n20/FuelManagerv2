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
    class CarNewButtonController
    {
        public CarNewButtonView mView;
        private CarNewButtonViewmodel mViewModel;
        private App mApplication;
        private AuthentificationServiceClient client = new AuthentificationServiceClient();
        public bool isCancelled = false;

        public CarNewButtonController(CarNewButtonView view, CarNewButtonViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            mView.DataContext = mViewModel;

            mViewModel.AddCarCommand = new RelayCommand(ExecuteAddCarCommand);
            mViewModel.CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        public void ExecuteCancelCommand(object o)
        {
            mView.DialogResult = true;
            mViewModel.Model = null;
            mView.Close();
            isCancelled = true;
        }

        public void ExecuteAddCarCommand(object o)
        {
            mView.DialogResult = true;
            mView.Close();
        }
        public Car AddCar()
        {
            mView.ShowDialog();
            if (isCancelled == false)
            {
                try
                {
                    mViewModel.Model = new Car { LicensePlate = mView.KennzeichenTextBox.Text, Vendor = mView.HerstellerTextBox.Text, Model = mView.ModellTextBox.Text };
                } catch (NullReferenceException)
                {
                    MessageBox.Show("Kennzeichen muss einen Wert enthalten");
                    return null;
                }

                var check = client.AddCar(mViewModel.Model);
                if (check != true)
                {
                    MessageBox.Show("Error: Missing input");
                }
                return mViewModel.Model;
            }
            return null;

        }
    }
}
