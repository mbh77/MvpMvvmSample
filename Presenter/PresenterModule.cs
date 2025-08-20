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
            services.AddSingleton<MainWindow>(); // IoC에 등록되었지만 실제 사용은 되지 않는다.
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
                //viewLocator.AddViewTypes("MainWindow", typeof(MainWindow)); //MainWindow는 App.xaml StartUpUri에서 생성된다.
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
                // Dialog용 View와 ViewModel은 별도 등록해서 사용한다.
                // 사용처에 따라 추가 작업이 필요하다.
                dialogService.RegisterDialog<DialogViewModel, DialogView>();
            }

            if (regionManager != null)
            {
                // MainWindowViewModel 에 있는 MainRegion 이라는 Region 오브젝트를 바인딩한 ContentControl에 FooView를 표시한다.
                regionManager.RequestNavigate<MainWindowViewModel>("MainRegion", "FooView", new NavigationParameters());
            }
        }
    }

}
