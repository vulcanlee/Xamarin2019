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
    public partial class Page2 : MainPage
    {
        public Page2()
        {
            InitializeComponent();
            HeaderText = "Page2 的覆寫頁面標題";
            FooterText = "Page2 的覆寫頁面尾標題";
        }

        private void BtnGoHome_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
        }
    }
}