using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MainPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        public override async void OnButtonTapGestureCommand(object obj)
        {
            await DisplayAlert("通知~~", $"這裡是客製頁尾的按鈕事件訂閱方法 {FooterText}", "喔喔");
        }

        private void BtnShowNoTemp_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Page1();
        }

        private void BtnShowAnotherTempPage_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Page2();
        }
    }
}