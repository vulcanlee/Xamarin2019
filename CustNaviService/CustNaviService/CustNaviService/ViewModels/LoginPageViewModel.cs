using System;
using System.Collections.Generic;
using System.Text;
using Vulcan.Courses.XamarinForms.NaviServices;
using Xamarin.Forms;

namespace CustNaviService.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public Command LoginCommand { get; set; }
        public LoginPageViewModel() : base((Application.Current as App).NavigationService)
        {
            LoginCommand = new Command(() =>
            {
                NavigationService.NavigateToAsync<HomePageViewModel>(NavigateMode.Master);
            });
        }
    }
}
