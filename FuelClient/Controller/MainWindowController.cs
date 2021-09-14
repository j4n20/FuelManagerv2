using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
using FuelClient.Views;
using Autofac;

namespace FuelClient.Controller
{
    class MainWindowController
    {
        public MainWindow mView;
        private MainViewModel mViewModel;
        private App mApplication;
        public static FEmployee currentEmployee;
        public AuthentificationServiceClient client = new AuthentificationServiceClient();


        public MainWindowController(MainWindow View, MainViewModel ViewModel, App App)
        {

            mView = View;
            mViewModel = ViewModel;
            mApplication = App;

            mView.DataContext = mViewModel;
            mApplication.MainWindow = mView;

            CarController mHomeViewController = mApplication.Container.Resolve<CarController>();
            mViewModel.CurrentView = mHomeViewController.mViewModel;

            mViewModel.FEmployeeViewCommand = new RelayCommand(ExecuteFEmployeeViewCommand);
            mViewModel.RefuelViewCommand = new RelayCommand(ExecuteRefuelViewCommand);
            mViewModel.VerbrauchViewCommand = new RelayCommand(ExecuteVerbrauchViewCommand);
            mViewModel.PreisentwicklungViewCommand = new RelayCommand(ExecutePreisentwicklungViewCommand);
            mViewModel.ImportViewCommand = new RelayCommand(ExecuteImportViewCommand);
            mViewModel.ExportViewCommand = new RelayCommand(ExecuteExportViewCommand);
            mViewModel.CarViewCommand = new RelayCommand(ExecuteCarViewCommand);


            mViewModel.EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
            mViewModel.NewCommand = new RelayCommand(ExecuteNewCommand, CanExecuteNewCommand);
            mViewModel.SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            mViewModel.DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);

            /*if (!mApplication.User.isAdmin)
            {
                mView.AdminButton.Visibility = Visibility.Hidden;
                mView.ArtikelButton.Visibility = Visibility.Hidden;
                mView.BenutzerButton.Visibility = Visibility.Hidden;
                mView.FahrerButton.Visibility = Visibility.Hidden;
                mView.LiefergebieteButton.Visibility = Visibility.Hidden;
            }*/
        }

        public void ExecuteNewCommand(object o)
        {
            if(mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }
            if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();

            }
            /*else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();
            }*/

        }

        public void ExecuteEditCommand(object o)
        {

            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();

            }
            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }
            /*else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }*/
        }

        public void ExecuteSaveCommand(object o)
        {

            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();

            }
            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }/*
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }*/
        }

        public void ExecuteDeleteCommand(object o)
        {

            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();

            }
            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();
            }/*
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand(); //TODO: implementieren Biteeee
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();
            }*/
        }

        public bool CanExecuteDeleteCommand(object o)
        {
            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }

            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }/*
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                return controller.mViewModel.Models != null ? true : false;
            }*/

            return false;
        }

        public bool CanExecuteNewCommand(object o)
        {
            if(mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                return true;
            }
            if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                return true;

            }/*
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                return true;
            }
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                return true;
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                return true;
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                return true;
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                return true;
            }*/
            return false;
        }

        public bool CanExecuteEditCommand(object o)
        {
            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }
            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            /*else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }*/
            return false;
        }

        public bool CanExecuteSaveCommand(object o)
        {
            if (mViewModel.SelectedController is CarController)
            {
                CarController controller = (CarController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }
            else if (mViewModel.SelectedController is FEmployeeController)
            {
                FEmployeeController controller = (FEmployeeController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }/*
            else if (mViewModel.SelectedController is DriverController)
            {
                DriverController controller = (DriverController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is ArticleController)
            {
                ArticleController controller = (ArticleController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is KundenController)
            {
                KundenController controller = (KundenController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
            else if (mViewModel.SelectedController is AufträgeController)
            {
                AufträgeController controller = (AufträgeController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }*/
            return false;
        }

        public void ExecuteCarViewCommand(object o)
        {
            CarController mCarViewController = mApplication.Container.Resolve<CarController>();
            mViewModel.CurrentView = mCarViewController;
            mViewModel.CurrentView = mCarViewController.mViewModel;
            mViewModel.SelectedController = mCarViewController;
        }
        public void ExecuteFEmployeeViewCommand(object o)
        {
            FEmployeeController mFEmployeeController = mApplication.Container.Resolve<FEmployeeController>();
            mViewModel.CurrentView = mFEmployeeController;
            mViewModel.CurrentView = mFEmployeeController.mViewModel;
            mViewModel.SelectedController = mFEmployeeController;
        }

        public void ExecuteRefuelViewCommand(object o)
        {
            RefuelController mRefuelViewController = mApplication.Container.Resolve<RefuelController>();
            mViewModel.CurrentView = mRefuelViewController;
            mViewModel.CurrentView = mRefuelViewController.mViewModel;
            mViewModel.SelectedController = mRefuelViewController;
        }

        public void ExecuteVerbrauchViewCommand(object o)
        {
            VerbrauchController mVerbrauchViewController = mApplication.Container.Resolve<VerbrauchController>();
            mViewModel.CurrentView = mVerbrauchViewController;
            mViewModel.CurrentView = mVerbrauchViewController.mViewModel;
            mViewModel.SelectedController = mVerbrauchViewController;
        }
        public void ExecutePreisentwicklungViewCommand(object o)
        {
            PreisentwicklungController mPreisentwicklungViewController = mApplication.Container.Resolve<PreisentwicklungController>();
            mViewModel.CurrentView = mPreisentwicklungViewController;
            mViewModel.CurrentView = mPreisentwicklungViewController.mViewModel;
            mViewModel.SelectedController = mPreisentwicklungViewController;
        }

        public void ExecuteImportViewCommand(object o)
        {
            ImportController mImportViewController = mApplication.Container.Resolve<ImportController>();
            mViewModel.CurrentView = mImportViewController;
            mViewModel.CurrentView = mImportViewController.mViewModel;
            mViewModel.SelectedController = mImportViewController;
        }

        public void ExecuteExportViewCommand(object o)
        {
            ExportController mExportViewController = mApplication.Container.Resolve<ExportController>();
            mViewModel.CurrentView = mExportViewController;
            mViewModel.CurrentView = mExportViewController.mViewModel;
            mViewModel.SelectedController = mExportViewController;
        }
    }
}

