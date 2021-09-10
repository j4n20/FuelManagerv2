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
    class CarController
    {
        private CarView mView;
        public CarViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public CarController(CarView view, CarViewmodel videoMode, App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;
            foreach (var area in client.GetCars())
            {
                mViewModel.Models.Add(area);
                mViewModel.SelectedModel = area;
            }

            mView.DataContext = mViewModel;

        }

        /*public void ExecuteDeleteCommand()
        {
            if (mViewModel.SelectedModel != null)
            {
                var postalCode = Int32.Parse(mView.PostCodeTextBox.Text);
                var check = client.DeleteArea(postalCode);
                if (check == false)
                {
                    //mView.DeletionCheck.Content = "Error";
                    MessageBox.Show("Error: There is data connected to this area");
                }
                else
                {
                    mViewModel.Models.Remove(mViewModel.SelectedModel);

                }
            }
        }*/

        /*public void ExecuteNewCommand()
        {
            AreaNewButtonController mController = mApplication.Container.Resolve<AreaNewButtonController>();
            var result = mController.AddArea();

            if (result != null)
            {
                client.AddArea(result);
                mViewModel.Models.Clear();
                foreach (var area in client.GetAreas())
                {
                    mViewModel.Models.Add(area);
                    mViewModel.SelectedModel = area;
                }
            }
        }*/
        public void ExecuteEditCommand()
        {
            mViewModel.Setread = false;
        }
        /*public void ExecuteSaveCommand()
        {
            Area area = new Area
            {

                Description = mView.CityTextBox.Text,
                Id = mViewModel.SelectedModel.Id
            };
            try
            {
                area.PostCode = Int32.Parse(mView.PostCodeTextBox.Text);
                client.AddArea(area);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.", "Error");
                return;
            }
        }*/
    }
}
