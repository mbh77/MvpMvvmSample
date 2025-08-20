using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvpMvvm.Dialogs;
using MvpMvvm.Locators;

namespace Presenter.ViewModels
{
    public partial class DialogViewModel : DialogViewModelBase
    {
        public DialogViewModel()
        {
            Title = "Info";
        }

        public override void OnDialogOpend(IDialogParameters? parameters)
        {
        }

        [RelayCommand]
        private void ClickButton(object? parameters)
        {
            if (_parent != null)
            {
                var dialogParam = new DialogParameters();

                DialogResult = parameters switch
                {
                    "Yes" => new DialogResult() { Parameters = dialogParam, Result = DialogButtonResult.Yes },
                    "No" => new DialogResult() { Parameters = dialogParam, Result = DialogButtonResult.No },
                    _ => new DialogResult() { Parameters = dialogParam, Result = DialogButtonResult.None }
                };

                _parent.Close();
            }
        }
    }
}
