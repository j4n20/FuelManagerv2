using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using FuelClient.Controller.NewButtonController;
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

            var carList = client.GetEmployeeToCarById(fEmployee);
            foreach (var entry in carList)
            {
                
                
                mViewModel.CarModels.Add(entry.Car);
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
        public void ExecuteNewCommand()
        {
            FEmployeeNewButtonController mController = mApplication.Container.Resolve<FEmployeeNewButtonController>();
            var result = mController.AddFEmployee();

            if (result != null)
            {
                mViewModel.Models.Clear();
                foreach (var driver in client.GetUsers())
                {
                    mViewModel.Models.Add(driver);
                    mViewModel.SelectedModel = driver;
                }
            }

        }

        public void ExecuteSaveCommand()
        {
            FEmployee fEmployee = new FEmployee
            {
                Firstname = mView.SelectedFirstname.Text,
                Lastname = mView.SelectedLastname.Text,
                Username = mView.SelectedUsername.Text,
                EmployeeNo = mView.SelectedEmployeeNumber.Text,
                Password = mView.PasswordBox.Password,
                Id = mViewModel.SelectedModel.Id
            };
            //var relationList = new List<EmployeeToCarRelation>();
            /*foreach (var selectedarea in mViewModel.CarModels)
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
            }*/
            client.AddUser(fEmployee);
            //client.AddEmployeeToCar(relationList.ToArray(), fEmployee);
        }
    }
}
