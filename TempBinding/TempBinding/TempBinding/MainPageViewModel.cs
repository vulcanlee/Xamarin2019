using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TempBinding
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyTime { get; set; }
        public MainPageViewModel()
        {
            //Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            //{
            //    MyTime = DateTime.Now.ToString();
            //    return true;
            //});
        }
    }
}
