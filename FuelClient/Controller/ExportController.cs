using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;
using Microsoft.Win32;

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

            foreach (var entry in client.GetEmployeeToCarById(mApplication.Employee))
            {
                mViewModel.CarModels.Add(entry.Car);
            }
            foreach (var car in mViewModel.CarModels)
            {
                foreach (var refuel in client.GetRefuelById(car))
                {
                    mViewModel.RefuelsModel.Add(refuel);
                }
            }

            mView.DataContext = mViewModel;
            mViewModel.ExportCommand = new RelayCommand(ExportCommand);
            
           
        }

        public void ExportCommand(object o)
        {
            List<RefuelXml> exportList = new List<RefuelXml>();
            foreach(var item in mViewModel.toExport)
            {
                RefuelXml exportRefuel = new RefuelXml
                {
                    Mileage = item.Mileage,
                    Date = item.Date,
                    Amount = item.Amount.ToString(),
                    Price = item.Price.ToString(),
                    Kennzeichen = item.Car.LicensePlate
                };
                exportList.Add(exportRefuel);

                
            }
            try
            {
                var serializer = new XmlSerializer(typeof(List<RefuelXml>), new XmlRootAttribute("Boxenstopps"));
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                Nullable<bool> result = saveFileDialog.ShowDialog();
                string path = saveFileDialog.FileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(stream, exportList);
                }
                MessageBox.Show("Der Exportvorgang war erfolgreich.");
            }
            catch(Exception e)
            {
                MessageBox.Show("Etwas ist schiefgelaufen.", e.ToString());
            }
        }
    }
}
