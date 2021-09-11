using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;

namespace FuelClient.Controller
{
    class FEmployeeController
    {
        private FEmployeeView mView;
        public FEMmployeeViewmodel mViewModel;
        private App mApplication;
        public FEmployee fEmployee;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public FEmployeeController(FEmployeeView view, FEMmployeeViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var area in client.GetUsers())
            {
                mViewModel.Models.Add(area);
                mViewModel.SelectedModel = area;
            }

            mView.DataContext = mViewModel;
            mViewModel.EmployeeSelectedCommand = new RelayCommand(ExecuteFEmployeeSelectedCommand);
        }

        public void ExecuteFEmployeeSelectedCommand(object obj)
        {
            mViewModel.CarModels.Clear();
        }

        public void ExecuteEditCommand()
        {
            mViewModel.Setread = false;
            mViewModel.Setvisible = true;

            mViewModel.CarModels.Clear();
            fEmployee = mViewModel.SelectedModel;

            var carList = client.GetCars();
            foreach (var car in carList)
            {
                var newCheckCar = new SelectedCar();
                newCheckCar.Vehicle = car;
                if (fEmployee.ToCars.Count(_car => _car.Id == car.Id) > 0)
                {
                    newCheckCar.isSelected = true;
                }
                mViewModel.CarModels.Add(newCheckCar);
            }
        }

        public void ExecuteConnectCommand()
        {

        }

        public void ExecuteDeleteCommand()
        {
            if (mViewModel.SelectedModel != null)
            {

                var check = client.DeleteUser(mViewModel.SelectedModel.Id);
                if (check == false)
                {
                    //mView.DeletionCheck.Content = "Error";
                    MessageBox.Show("Error: There is data connected to this employee");
                }
                else
                {
                    mViewModel.Models.Remove(mViewModel.SelectedModel);

                }
            }
        }
        /*public void ExecuteNewCommand()
        {
            DriverNewButtonController mController = mApplication.Container.Resolve<DriverNewButtonController>();
            var result = mController.AddDriver();

            if (result != null)
            {
                var check = client.AddDriver(result);
                if (check != true)
                {
                    MessageBox.Show("Missing Input", "Error");
                    return;
                }

                mViewModel.Models.Clear();
                foreach (var driver in client.GetDrivers())
                {
                    mViewModel.Models.Add(driver);
                    mViewModel.SelectedModel = driver;
                }
            }

        }*/

        public void ExecuteSaveCommand()
        {
            FEmployee fEmployee = new FEmployee
            {
                Firstname = mView.SelectedFirstname.Text,
                Lastname = mView.SelectedLastname.Text,
                EmployeeNo = mView.SelectedEmployeeNumber.Text,
                Id = mViewModel.SelectedModel.Id
            };
            var relationList = new List<EmployeeToCarRelation>();
            foreach (var selectedarea in mViewModel.CarModels)
            {
                if (selectedarea.isSelected == true)
                {
                    EmployeeToCarRelation relation = new EmployeeToCarRelation()
                    {
                        Car = selectedarea.Vehicle,
                        FEmployee = fEmployee
                    };
                    relationList.Add(relation);
                }
            }
            client.AddUser(fEmployee);
            client.AddEmployeeToCar(relationList.ToArray(), fEmployee);
        }
    }
}
