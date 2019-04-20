using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignTimeBinding.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Message { get; set; }
        private readonly INavigationService navigationService;
        public MainPageViewModel()
        {
            Message = "Come From Default Constuctor  !!";
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Message = "Come From Injection Constructor";
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
