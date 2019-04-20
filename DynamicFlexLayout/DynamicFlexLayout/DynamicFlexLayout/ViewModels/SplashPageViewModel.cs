using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicFlexLayout.ViewModels
{
    using System.ComponentModel;
    using DynamicFlexLayout.Helpers;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class SplashPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public SplashPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            ScreenInfo.Density = mainDisplayInfo.Density;
            ScreenInfo.ScreenPixelWidth = mainDisplayInfo.Width;
            ScreenInfo.ScreenPixelHeight = mainDisplayInfo.Height;
            ScreenInfo.DesignScreenWidth = ScreenInfo.ScreenPixelWidth/ScreenInfo.Density;
            ScreenInfo.DesignScreenHeight = ScreenInfo.ScreenPixelHeight / ScreenInfo.Density;
            ScreenInfo.DesignScalar = ScreenInfo.DesignScreenWidth / ScreenInfo.DesignTimeScreenWidth;
            navigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
