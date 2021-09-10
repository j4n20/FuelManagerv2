using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using Autofac;
using FuelClient.Controller;

namespace FuelClient
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public IContainer Container { get; set; }
        public Service.FEmployee Employee { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.IsClass && (t.Namespace.Contains("Controller") || t.Namespace.Contains("ViewModels") || t.Namespace.Contains("Views")));
            containerBuilder.RegisterInstance(this);

            Container = containerBuilder.Build();

            Container.Resolve<LoginWindowController>().Initialize();
        }
    }
}
