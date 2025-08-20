using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvpMvvm.Dialogs;
using MvpMvvm.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private IServiceProvider _serviceProvider;
        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        [ObservableProperty]
        Region mainRegion;
        [ObservableProperty]
        string mainWindowText;

        public MainWindowViewModel(IServiceProvider serviceProvider, IRegionManager regionManager,
            IDialogService dialogService)
        {
            _serviceProvider = serviceProvider;
            _regionManager = regionManager;
            _dialogService = dialogService;

            MainRegion = new Region();
            MainWindowText = "Text Biniding OK";
        }

        [RelayCommand]
        void ChangeView()
        {
            if (_regionManager.GetRegion<MainWindowViewModel>("MainRegion") is IRegion region)
            {
                if (region.ViewName == "BarView")
                {
                    // MainWindowViewModel 에 있는 MainRegion 이라는 Region 오브젝트를 바인딩한 ContentControl에 FooView를 표시한다.
                    _regionManager.RequestNavigate<MainWindowViewModel>("MainRegion", "FooView", new NavigationParameters());
                }
                else if (region.ViewName == "FooView")
                {
                    // MainWindowViewModel 에 있는 MainRegion 이라는 Region 오브젝트를 바인딩한 ContentControl에 BarView를 표시한다.
                    _regionManager.RequestNavigate<MainWindowViewModel>("MainRegion", "BarView", new NavigationParameters());
                }
            }
        }

        [RelayCommand]
        void ShowDialog()
        {
            DialogParameters param = new DialogParameters()
            {
                { "ProductItem", "item" },
            };

            _dialogService.ShowDialog<DialogViewModel>(param, (IDialogResult result) =>
            {
                if (result.Result == DialogButtonResult.Yes) 
                { 
                    
                }
                else if(result.Result == DialogButtonResult.No)
                {

                }

                System.Diagnostics.Debug.WriteLine($"Dialog result = {result.Result}");
            });
        }
    }
}
