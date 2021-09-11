using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
    }
}
