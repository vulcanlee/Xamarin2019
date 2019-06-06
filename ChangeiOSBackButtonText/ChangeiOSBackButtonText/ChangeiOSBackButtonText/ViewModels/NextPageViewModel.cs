using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeiOSBackButtonText.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand SwithChangePageCommand { get; set; }
        private readonly INavigationService navigationService;

        public NextPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SwithChangePageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("CanChangePage");
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
