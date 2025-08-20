using CommunityToolkit.Mvvm.ComponentModel;
using MvpMvvm.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.ViewModels
{
    public partial class FooViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private string _viewName;

        public FooViewModel()
        {
            ViewName = "Foo View";
        }

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo(NavigationParameters? parameter)
        {
            
        }
    }
}
