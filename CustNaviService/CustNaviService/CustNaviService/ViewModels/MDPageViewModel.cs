using CourseNaviService.NaviServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustNaviService.ViewModels
{
    public class MDPageViewModel : ViewModelBase
    {
        public Action<string> MenuSelectedDelegate;
        public MDPageViewModel() : base((Application.Current as App).NavigationService)
        {
            MenuSelectedDelegate = x =>
            {
                if(x== "Page 1")
                {
                    NavigationService.NavigateToAsync<HomePageViewModel>(NavigateMode.Master);
                }
                if (x == "Page 2")
                {
                    NavigationService.NavigateToAsync<AboutPageViewModel>(NavigateMode.Master);
                }
                if (x == "Page 3")
                {
                    NavigationService.NavigateToAsync<LoginPageViewModel>(NavigateMode.Absolute);
                }
            };
        }
    }
}
