using Microsoft.Extensions.DependencyInjection;
using MvpMvvm.Dialogs;
using MvpMvvm.Locators;
using MvpMvvm.Modularity;
using Presenter.ViewModels;
using Presenter.Views;
using System.Reflection.Metadata;

namespace Presenter
{
    public class PresenterModule : IModule
    {
        public void RegisterTypes(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>(); // IoC�� ��ϵǾ����� ���� ����� ���� �ʴ´�.
            services.AddSingleton<FooView>();
            services.AddSingleton<BarView>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<FooViewModel>();
            services.AddSingleton<BarViewModel>();
        }

        public void OnInitialized(IServiceProvider serviceProvider)
        {
            var viewLocator = serviceProvider.GetRequiredService<ViewLocator>();
            var viewModelLocator = serviceProvider.GetRequiredService<ViewModelLocator>();
            var regionManager = serviceProvider.GetService<IRegionManager>();
            var dialogService = serviceProvider.GetService<IDialogService>();

            if (viewLocator != null)
            {
                //viewLocator.AddViewTypes("MainWindow", typeof(MainWindow)); //MainWindow�� App.xaml StartUpUri���� �����ȴ�.
                viewLocator.AddViewTypes("FooView", typeof(FooView));
                viewLocator.AddViewTypes("BarView", typeof(BarView));
            }

            if (viewModelLocator != null)
            {
                viewModelLocator.AddViewModelTypes("MainWindowViewModel", typeof(MainWindowViewModel));
                viewModelLocator.AddViewModelTypes("FooViewModel", typeof(FooViewModel));
                viewModelLocator.AddViewModelTypes("BarViewModel", typeof(BarViewModel));
            }

            if (dialogService != null)
            {
                // Dialog�� View�� ViewModel�� ���� ����ؼ� ����Ѵ�.
                // ���ó�� ���� �߰� �۾��� �ʿ��ϴ�.
                dialogService.RegisterDialog<DialogViewModel, DialogView>();
            }

            if (regionManager != null)
            {
                // MainWindowViewModel �� �ִ� MainRegion �̶�� Region ������Ʈ�� ���ε��� ContentControl�� FooView�� ǥ���Ѵ�.
                regionManager.RequestNavigate<MainWindowViewModel>("MainRegion", "FooView", new NavigationParameters());
            }
        }
    }

}
