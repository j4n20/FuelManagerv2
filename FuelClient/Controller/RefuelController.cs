using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void ExecuteNewCommand()
        {
            RefuelNewButtonController mController = mApplication.Container.Resolve<RefuelNewButtonController>();
            var result = mController.AddRefuel(mViewModel.CarModels);

            if (result != null)
            {
                mViewModel.RefuelsModels.Clear();
                foreach(var car in mViewModel.CarModels)
                {
                    foreach (var refuel in client.GetRefuelById(car))
                    {
                        mViewModel.RefuelsModels.Add(refuel);
                        mViewModel.SelectedModel = refuel;
                    }
                }
                
            }

        }
    }
}
