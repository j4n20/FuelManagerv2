using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<RefuelXml> mRefuel;
            var serializer = new XmlSerializer(typeof(List<RefuelXml>), new XmlRootAttribute("Boxenstopps"));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();
            double amount = 0;
            double price = 0;
            if (result == true)
            {
                string path = (openFileDialog.FileName);
                
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    mRefuel = serializer.Deserialize(stream) as List<RefuelXml>;
                    foreach(var entry in mRefuel)
                    {
                        if (entry.Amount.Contains(','))
                        {
                            amount = Math.Round(Double.Parse(entry.Amount.Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat), 2);
                        } else
                        {
                            amount = Math.Round(Double.Parse(entry.Amount, CultureInfo.InvariantCulture.NumberFormat), 2);
                        }

                        if (entry.Price.Contains(','))
                        {
                            price = Math.Round(Double.Parse(entry.Price.Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat), 2);
                        }
                        else
                        {
                            price = Math.Round(Double.Parse(entry.Price, CultureInfo.InvariantCulture.NumberFormat), 2);
                        }
                    
                        Car car = client.GetCarIdByLicensePlate(entry.Kennzeichen);

                        if (car == null)
                        {
                            Car newCar = new Car
                            {
                                LicensePlate = entry.Kennzeichen,
                                Vendor = "-",
                                Model = "-"
                            };
                            client.AddCar(newCar);

                            Car refuelCar = client.GetCarIdByLicensePlate(newCar.LicensePlate);
                            Refuel refuel = new Refuel
                            {
                                Date = entry.Date,
                                Mileage = entry.Mileage,
                                Amount = (float)amount,
                                Price = (float)price,
                                Car = refuelCar
                            };
                            client.AddRefuel(refuel);
                        }
                        else
                        {
                            Refuel refuel = new Refuel
                            {
                                Date = entry.Date,
                                Mileage = entry.Mileage,
                                Amount = (float)amount,
                                Price = (float)price,
                                Car = car
                            };
                            client.AddRefuel(refuel);
                        }
                        
                    }
                    MessageBox.Show("Der Importvorgang war erfolgreich");
                }

            }
        }
    }
}
