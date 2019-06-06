using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeiOSBackButtonText.ViewModels
{
    using System.ComponentModel;
    using ChangeiOSBackButtonText.Helpers;
    using ChangeiOSBackButtonText.Views;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class CanChangePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action ChangeBackButtonTextDel;
        public string Message { get; set; } = "客製文字";
        public string ThisBackText { get; set; } = "I-Will";
        public DelegateCommand SetBackButtonTextCommand { get; set; }
        private readonly INavigationService navigationService;

        public CanChangePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SetBackButtonTextCommand = new DelegateCommand(() =>
            {
                ChangeBackButtonTextHelper.ChangeBackButtonText(Message);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
