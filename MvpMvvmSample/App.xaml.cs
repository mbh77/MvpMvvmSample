using Microsoft.Extensions.DependencyInjection;
using MvpMvvm;
using MvpMvvm.Locators;
using MvpMvvm.Modularity;
using Presenter;
using Presenter.Views;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;

namespace MvpMvvmSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MvvmApp
    {
        public App() : base(new ServiceCollection())
        {

        }

        protected override void ConfigureModuleCatalog(List<IModule> moduleCatalog)
        {
            moduleCatalog.Add(new PresenterModule());

            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override void RegisterTypes(IServiceCollection services)
        {
            base.RegisterTypes(services);
        }

        protected override void OnInitialized(IServiceProvider serviceProvider)
        {
            base.OnInitialized(serviceProvider);
        }
    }
}
