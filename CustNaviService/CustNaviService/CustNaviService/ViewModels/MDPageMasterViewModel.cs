using CourseNaviService.NaviServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustNaviService.ViewModels
{
    public class MDPageMasterViewModel : ViewModelBase
    {
        public Action<string> MenuDelegate;
        public MDPageMasterViewModel() : base((Application.Current as App).NavigationService)
        {
            MenuDelegate = x =>
            {

            };
        }
    }
}
