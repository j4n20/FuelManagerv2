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
    class PreisentwicklungController
    {
        private PreisentwicklungView mView;
        public PreisentwicklungViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public PreisentwicklungController(PreisentwicklungView view, PreisentwicklungViewmodel videoMode, App app)
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
