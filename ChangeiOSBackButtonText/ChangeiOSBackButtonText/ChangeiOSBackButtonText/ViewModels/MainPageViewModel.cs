using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeiOSBackButtonText.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand SwithChangePageCommand { get; set; }
        public DelegateCommand SwithNextPageCommand { get; set; }
        public DelegateCommand SwithTwoPageCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SwithChangePageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("CanChangePage");
            });
            SwithNextPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("NextPage");
            });
            SwithTwoPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("NextPage/CanChangePage");
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
