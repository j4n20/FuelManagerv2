using Autofac;
using FuelClient.Views;
using FuelClient.Framework;
using FuelClient.Service;
using FuelClient.ViewModels;



namespace FuelClient.Controller
{
    class LoginWindowController
    {
        private LoginWindow mView;
        private LoginWindowViewModel mViewModel;
        private FuelClient.App mApplication;
        private AuthentificationServiceClient client = new AuthentificationServiceClient();
        public LoginWindowController(LoginWindow view, LoginWindowViewModel videoMode, FuelClient.App app)
        {
            mView = view;
            mViewModel = videoMode;
            mApplication = app;

            mView.DataContext = mViewModel;
            mApplication.MainWindow = mView;

            mViewModel.LoginCommand = new RelayCommand(ExecuteLoginCommand);
        }

        public void ExecuteLoginCommand(object obj)
        {
            FEmployee user = new FEmployee { Password = mView.PasswordBox.Password, Username = mView.NameTextBox.Text };
            var returnedUser = client.CheckCredentials(user);
            mApplication.Employee = returnedUser;
            if (returnedUser != null)
            {

                MainWindowController mMainWindowController = mApplication.Container.Resolve<MainWindowController>();
                mView.Hide();
                mMainWindowController.mView.ShowDialog();

            }
            else
            {
                mView.CredentialCheck.Content = "Wrong Username or Password";
            }


        }

        public void Initialize()
        {
            mView.ShowDialog();
        }
    }
}
