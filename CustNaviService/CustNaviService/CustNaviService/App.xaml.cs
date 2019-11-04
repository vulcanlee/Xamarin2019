using Vulcan.Courses.XamarinForms.NaviServices;
using CustNaviService.ViewModels;
using CustNaviService.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustNaviService
{
    public partial class App : Application
    {
        public INaviService NavigationService { get; set; }
        public App()
        {
            InitializeComponent();

            NavigationService = new NaviService(
                () => { return Application.Current.MainPage as NaviPage; },
                page => { return new NaviPage(page); },
                () => { return (Application.Current.MainPage as MDPage)?.Detail as NaviPage; },
                () => { return Application.Current.MainPage as MDPage; },
                () => { return new MDPage(); });

            //MainPage = new MainPage();

            NavigationService.NavigateToAsync<LoginPageViewModel>(NavigateMode.Absolute);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
