namespace XInput2Key
{
    using Autofac;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var container = new DIFactory().GetLifetimeScope();

            var locator = this.Resources["Locator"] as Locator;

            locator.Resolver = s => container.Resolve(Type.GetType($"XInput2Key.ViewModel.I{s}"));
        }
    }
}
