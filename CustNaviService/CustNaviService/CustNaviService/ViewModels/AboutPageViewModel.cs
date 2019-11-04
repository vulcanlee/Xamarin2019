using Vulcan.Courses.XamarinForms.NaviServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustNaviService.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        public AboutPageViewModel() : base((Application.Current as App).NavigationService)
        {
        }
    }
}
