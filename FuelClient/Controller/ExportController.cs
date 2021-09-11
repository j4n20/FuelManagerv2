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
    class ExportController
    {
        private ExportView mView;
        public ExportViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public ExportController(ExportView view, ExportViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            /*foreach (var area in client.GetCars())
            {
                mViewModel.Models.Add(area);
                mViewModel.SelectedModel = area;
            }*/

            mView.DataContext = mViewModel;

        }
    }
}
