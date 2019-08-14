using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TempBinding
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(MainPage), "Control Template Demo App");
        public static readonly BindableProperty FooterTextProperty = BindableProperty.Create("FooterText", typeof(string), typeof(MainPage), "(c) Xamarin 2016");
        public static readonly BindableProperty TapGestureCommandProperty = 
            BindableProperty.Create("TapGestureCommand", typeof(Command), typeof(MainPage), null);
        public static readonly BindableProperty ButtonTapGestureCommandProperty =
            BindableProperty.Create("ButtonTapGestureCommand", typeof(Command), typeof(MainPage), null);

        public Command ButtonTapGestureCommand
        {
            set
            {
                SetValue(ButtonTapGestureCommandProperty, value);
            }
            get
            {
                return (Command)GetValue(ButtonTapGestureCommandProperty);

            }
        }
        public Command TapGestureCommand
        {
            set
            {
                SetValue(TapGestureCommandProperty, value);
            }
            get
            {
                return (Command)GetValue(TapGestureCommandProperty);

            }
        }
        public string HeaderText
        {
            set { SetValue(HeaderTextProperty, value); }
            get { return (string)GetValue(HeaderTextProperty); }
        }

        public string FooterText
        {
            set { SetValue(FooterTextProperty, value); }
            get { return (string)GetValue(FooterTextProperty); }
        }
        public MainPage()
        {
            InitializeComponent();

            TapGestureCommand = new Command(OnTapGestureCommand);
            ButtonTapGestureCommand = new Command(OnButtonTapGestureCommand);
            //Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            //{
            //    FooterText = $"現在時間 {DateTime.Now.ToString()}";
            //    return true;
            //});
        }

        public virtual async void OnTapGestureCommand(object obj)
        {
            await DisplayAlert("通知", $"你已經按下了頁頭區域", "OK");
        }
        public virtual async void OnButtonTapGestureCommand(object obj)
        {
            await DisplayAlert("通知", $"你已經按下了頁尾的按鈕 {FooterText}", "知道了");
        }
    }
}
