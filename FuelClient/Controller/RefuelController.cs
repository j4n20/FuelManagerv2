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
            /*foreach (var refuel in client.GetRefuels())
            {
                mViewModel.RefuelsModels.Add(refuel);
                mViewModel.SelectedModel = refuel;
            }*/

            mView.DataContext = mViewModel;

        }
    }
}
