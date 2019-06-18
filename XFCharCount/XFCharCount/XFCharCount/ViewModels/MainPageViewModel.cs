using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFCharCount.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string EditorInputText { get; set; }
        public int EditorInputTextLength { get; set; } 
        public string EntryInputInputText { get; set; }
        public int EntryInputTextLength { get; set; } 
        public string EntryChangedInputText { get; set; }
        public int EntryChangedInputTextLength { get; set; } 
        public string EntryBehaviorInputText { get; set; }
        public int EntryBehaviorInputTextLength { get; set; }
        public DelegateCommand EntryChangedCommand { get; set; }
        private readonly INavigationService navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            EntryChangedCommand = new DelegateCommand(() =>
            {
                EntryBehaviorInputTextLength = EntryBehaviorInputText is null ? 0 : EntryBehaviorInputText.Length;
            });
        }
        public void OnEntryChangedInputTextChanged()
        {
            if(string.IsNullOrEmpty(EntryChangedInputText))
            {
                EntryChangedInputTextLength = 0;
            }
            else
            {
                EntryChangedInputTextLength = EntryChangedInputText.Length;
            }
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
