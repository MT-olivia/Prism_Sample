using Prism_Sample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Prism_Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Prism.Unity.PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Sample>();
            containerRegistry.RegisterForNavigation<Views.AddCalc>();
        }
    }
}
