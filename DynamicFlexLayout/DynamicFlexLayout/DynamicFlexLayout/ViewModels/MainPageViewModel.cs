using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicFlexLayout.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using DynamicFlexLayout.Helpers;
    using DynamicFlexLayout.Models;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ItemBlock> myItemList { get; set; } = new ObservableCollection<ItemBlock>();
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Random rnd = new Random();
            ItemBlock fooItem;
            for (int i = 0; i < 3; i++)
            {
                fooItem = new ItemBlock()
                {
                    Width = ScreenInfo.GetNewDesingSize(100),
                    Height = ScreenInfo.GetNewDesingSize(100),
                    Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                    ShowLabel = false,
                };
                myItemList.Add(fooItem);
            }
            fooItem = new ItemBlock()
            {
                Width = ScreenInfo.GetNewDesingSize(300),
                Height = ScreenInfo.GetNewDesingSize(50),
                Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                ShowLabel = true,
                ShowBoxView = false
            };
            myItemList.Add(fooItem);
            fooItem = new ItemBlock()
            {
                Width = ScreenInfo.GetNewDesingSize(301),
                Height = ScreenInfo.GetNewDesingSize(200),
                Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                ShowLabel = false,
            };
            myItemList.Add(fooItem);
            for (int i = 0; i < 31; i++)
            {
                fooItem = new ItemBlock()
                {
                    Width = ScreenInfo.GetNewDesingSize(100),
                    Height = ScreenInfo.GetNewDesingSize(100),
                    Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                    ShowLabel = false,
                };
                myItemList.Add(fooItem);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
