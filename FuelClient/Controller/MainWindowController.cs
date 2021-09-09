using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;
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

            /*HomeViewController mHomeViewController = mApplication.Container.Resolve<HomeViewController>();
            mViewModel.CurrentView = mHomeViewController.mViewModel;*/

            mViewModel.HomeViewCommand = new RelayCommand(ExecuteHomeViewCommand);
            mViewModel.KundenViewCommand = new RelayCommand(ExecuteKundenViewCommand);
            mViewModel.AreaViewCommand = new RelayCommand(ExecuteAreaViewCommand);
            mViewModel.ArticleViewCommand = new RelayCommand(ExecuteArticleViewCommand);
            mViewModel.DriverViewCommand = new RelayCommand(ExecuteDriverViewCommand);
            mViewModel.BestsellerViewCommand = new RelayCommand(ExecuteBestsellerViewCommand);
            mViewModel.UmsatzranglisteViewCommand = new RelayCommand(ExecuteUmsatzranglisteViewCommand);
            mViewModel.UserViewCommand = new RelayCommand(ExecuteUserViewCommand);
            mViewModel.AufträgeViewCommand = new RelayCommand(ExecuteAufträgeViewCommand);


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

            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                controller.ExecuteNewCommand();

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
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

            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                controller.ExecuteEditCommand();
            }
            else if (mViewModel.SelectedController is DriverController)
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

            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                controller.ExecuteSaveCommand();
            }
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

            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                controller.ExecuteDeleteCommand();
            }
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
            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }

            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
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
            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                return true;

            }
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
            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
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

        public bool CanExecuteSaveCommand(object o)
        {
            /*if (mViewModel.SelectedController is UserController)
            {
                UserController controller = (UserController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;

            }
            else if (mViewModel.SelectedController is LiefergebieteController)
            {
                LiefergebieteController controller = (LiefergebieteController)mViewModel.SelectedController;
                return controller.mViewModel.SelectedModel != null ? true : false;
            }
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

        public void ExecuteAufträgeViewCommand(object o)
        {
            /*AufträgeController mAufträgeViewController = mApplication.Container.Resolve<AufträgeController>();
            mViewModel.CurrentView = mAufträgeViewController;
            mViewModel.CurrentView = mAufträgeViewController.mViewModel;
            mViewModel.SelectedController = mAufträgeViewController;*/
        }
        public void ExecuteBestsellerViewCommand(object o)
        {
            /*BestsellerController mBestsellerViewController = mApplication.Container.Resolve<BestsellerController>();
            mViewModel.CurrentView = mBestsellerViewController;
            mViewModel.CurrentView = mBestsellerViewController.mViewModel;
            mViewModel.SelectedController = mBestsellerViewController;*/
        }

        public void ExecuteUmsatzranglisteViewCommand(object o)
        {
            /*UmsatzranglisteController mUmsatzranglisteViewController = mApplication.Container.Resolve<UmsatzranglisteController>();
            mViewModel.CurrentView = mUmsatzranglisteViewController;
            mViewModel.CurrentView = mUmsatzranglisteViewController.mViewModel;
            mViewModel.SelectedController = mUmsatzranglisteViewController;*/
        }

        public void ExecuteHomeViewCommand(object o)
        {
            /*HomeViewController mHomeViewController = mApplication.Container.Resolve<HomeViewController>();
            mViewModel.CurrentView = mHomeViewController;
            mViewModel.CurrentView = mHomeViewController.mViewModel;
            mViewModel.SelectedController = mHomeViewController;*/
        }
        public void ExecuteAreaViewCommand(object o)
        {
            /*LiefergebieteController mAreaViewController = mApplication.Container.Resolve<LiefergebieteController>();
            mViewModel.CurrentView = mAreaViewController;
            mViewModel.CurrentView = mAreaViewController.mViewModel;
            mViewModel.SelectedController = mAreaViewController;*/
        }

        public void ExecuteArticleViewCommand(object o)
        {
            /*ArticleController mArticleViewController = mApplication.Container.Resolve<ArticleController>();
            mViewModel.CurrentView = mArticleViewController;
            mViewModel.CurrentView = mArticleViewController.mViewModel;
            mViewModel.SelectedController = mArticleViewController;*/
        }

        public void ExecuteDriverViewCommand(object o)
        {
            /*DriverController mDriverViewController = mApplication.Container.Resolve<DriverController>();
            mViewModel.CurrentView = mDriverViewController;
            mViewModel.CurrentView = mDriverViewController.mViewModel;
            mViewModel.SelectedController = mDriverViewController;*/
        }

        public void ExecuteKundenViewCommand(object o)
        {
            /*KundenController mKundenController = mApplication.Container.Resolve<KundenController>();
            mViewModel.CurrentView = mKundenController;
            mViewModel.CurrentView = mKundenController.mViewModel;
            mViewModel.SelectedController = mKundenController;*/
        }

        public void ExecuteUserViewCommand(object o)
        {
            /*UserController mUserController = mApplication.Container.Resolve<UserController>();
            mViewModel.CurrentView = mUserController;
            mViewModel.CurrentView = mUserController.mViewModel;
            mViewModel.SelectedController = mUserController;*/
        }
    }
}

