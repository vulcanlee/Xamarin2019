using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAAlarmManager.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XAAlarmManager.Interfaces;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand SetAlertCommand { get; set; }
        public int AfterMS { get; set; } = 10;
        public string Title { get; set; } = "提醒";
        public string Message { get; set; } = "您的預約通知已經到時了";
        private readonly INavigationService navigationService;
        private readonly IAlert alert;

        public MainPageViewModel(INavigationService navigationService, IAlert alert)
        {
            this.navigationService = navigationService;
            this.alert = alert;
            SetAlertCommand = new DelegateCommand(() =>
            {
                alert.Set(Title, Message, AfterMS * 1000);
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
