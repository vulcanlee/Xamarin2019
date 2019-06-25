using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceOrientation.ViewModels
{
    using System.ComponentModel;
    using ForceOrientation.Events;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class ScreenOrientationPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<string> OrientationCommand { get; set; }
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public ScreenOrientationPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            OrientationCommand = new DelegateCommand<string>(x =>
            {
                CustomScreenOrientationPayload customScreenOrientationPayload = new CustomScreenOrientationPayload();
                if (x == "自由旋轉")
                {
                    customScreenOrientationPayload.CustomScreenOrientation = CustomScreenOrientation.Unspecified;
                }
                else if (x == "限制直式")
                {
                    customScreenOrientationPayload.CustomScreenOrientation = CustomScreenOrientation.UserPortrait;
                }
                else
                {
                    // 限制橫式
                    customScreenOrientationPayload.CustomScreenOrientation = CustomScreenOrientation.UserLandscape;
                }
                eventAggregator.GetEvent<CustomScreenOrientationEvent>().Publish(customScreenOrientationPayload);
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
