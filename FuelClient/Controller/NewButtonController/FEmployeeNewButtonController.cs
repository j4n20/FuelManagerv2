using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels.NewButtonViewModels;
using FuelClient.Views.NewButtonViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
                FEmployee fEmployee = new FEmployee
                {
                    Firstname = mView.SelectedFirstname.Text,
                    Lastname = mView.SelectedLastname.Text,
                    EmployeeNumber = mView.SelectedEmployeeNumber.Text,
                    Id = mViewModel.SelectedModel.Id
                };
                var relationList = new List<EmployeeToAreaRelation>();
                foreach (var selectedarea in mViewModel.AreaModels)
                {
                    if (selectedarea.isSelected == true)
                    {
                        EmployeeToAreaRelation relation = new EmployeeToAreaRelation()
                        {
                            Area = selectedarea.Gebiet,
                            Employee = driver
                        };
                        relationList.Add(relation);
                    }
                }
                client.AddDriver(driver);
                client.AddEmployeToArea(relationList.ToArray(), driver);
            

        }
    }
}
