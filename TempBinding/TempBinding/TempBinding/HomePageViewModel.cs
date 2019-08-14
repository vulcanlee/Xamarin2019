using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TempBinding
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyTime { get; set; }
        public string Message { get; set; }
        public Command TimeTapCommand { get; set; }
        public HomePageViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                MyTime = "HomePageViewModel 的 MyTime " + DateTime.Now.ToString();
                return true;
            });
            TimeTapCommand = new Command(() =>
            {
                Message = "頁尾時間文字已經被點選 " + DateTime.Now.ToString();
            });
        }
    }
}
