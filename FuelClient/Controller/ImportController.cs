using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;
using Microsoft.Win32;

namespace FuelClient.Controller
{
    class ImportController
    {
        private ImportView mView;
        public ImportViewmodel mViewModel;
        private App mApplication;

        private AuthentificationServiceClient client = new AuthentificationServiceClient();

        public ImportController(ImportView view, ImportViewmodel videoMode, App app)
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

            mViewModel.ImportCommand = new RelayCommand(ImportCommand);
        }

        public void ImportCommand(object o)
        {
            List<Refuel> mRefuel;
            var serializer = new XmlSerializer(typeof(List<Refuel>), new XmlRootAttribute("Boxenstopps"));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var path = openFileDialog.FileName;
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    mRefuel = serializer.Deserialize(stream) as List<Refuel>;
                }

            }
        }
    }
}
