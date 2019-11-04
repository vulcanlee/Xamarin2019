using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Vulcan.Courses.XamarinForms.NaviServices
{
    public class NaviService : INaviService
    {
        // 這個方法需要在外部指派委派方法，回傳一個導航頁面物件
        public Func<NavigationPage> GetNavigationPageDelegate;
        public Func<MasterDetailPage> GetMasterDetailPageDelegate;
        public Func<NavigationPage> GetMasterDetailNavigationPageDelegate;
        //Application.Current.MainPage = new NaviPage(page);
        // 這個方法需要在外部指派委派方法，產生並且回傳一個導航頁面物件
        public Func<Page, NavigationPage> GenerateNavigationPageDelegate;
        public Func<MasterDetailPage> GenerateMasterDetailPageDelegate;
        public ViewModelBase PreviousPageViewModel
        {
            get
            {
                var mainPage = GetNavigationPageDelegate();
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }

        ViewModelBase INaviService.PreviousPageViewModel => throw new NotImplementedException();

        public NaviService(
            Func<NavigationPage> getNavigationPageDelegate,
            Func<Page, NavigationPage> generateNavigationPageDelegate,
            Func<NavigationPage> getMasterDetailNavigationPageDelegate,
            Func<MasterDetailPage> getMasterDetailPageDelegate,
            Func<MasterDetailPage> generateMasterDetailPageDelegate)
        {
            GetNavigationPageDelegate = getNavigationPageDelegate;
            GenerateNavigationPageDelegate = generateNavigationPageDelegate;
            GetMasterDetailNavigationPageDelegate = getMasterDetailNavigationPageDelegate;
            GetMasterDetailPageDelegate = getMasterDetailPageDelegate;
            GenerateMasterDetailPageDelegate = generateMasterDetailPageDelegate;
        }

        public Task InitializeAsync()
        {
            //NavigateToAsync<LoginViewModel>();
            return Task.FromResult(false);
        }


        public Task NavigateToAsync<TViewModel>(NavigateMode navigateMode = NavigateMode.Relative) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null, navigateMode);
        }

        public Task NavigateToAsync<TViewModel>(object parameter, NavigateMode navigateMode = NavigateMode.Relative) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter, navigateMode);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = GetNavigationPageDelegate();

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveNoneRootAsync()
        {
            var mainPage = GetNavigationPageDelegate();

            if (mainPage != null)
            {
                var needStackLength = mainPage.Navigation.NavigationStack.Count - 2;

                for (int i = 0; i < needStackLength; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[1];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = GetNavigationPageDelegate();

            if (mainPage != null)
            {
                var needStackLength = mainPage.Navigation.NavigationStack.Count - 2;

                for (int i = 0; i < needStackLength; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[0];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter,
            NavigateMode navigateMode = NavigateMode.Relative)
        {
            Page page = CreatePage(viewModelType, parameter);

            //if (page is LoginView)
            //{
            //    Application.Current.MainPage = new CustomNavigationView(page);
            //}
            //else
            //{
            var retriveNavigationPage = GetNavigationPageDelegate();
            var retriveMasterDetailPage = GetMasterDetailPageDelegate();
            var retriveMasterDetailNavigationPage = GetMasterDetailNavigationPageDelegate();
            if (navigateMode == NavigateMode.Relative)
            {
                NavigationPage navigationPage = null;
                if (retriveNavigationPage != null) navigationPage = retriveNavigationPage;
                if (retriveMasterDetailNavigationPage != null) navigationPage = retriveMasterDetailNavigationPage;
                //var navigationPage = GetNavigationPageDelegate();
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    //Application.Current.MainPage = new NaviPage(page);
                    Application.Current.MainPage = GenerateNavigationPageDelegate(page);
                }
            }
            else if (navigateMode == NavigateMode.RestartRelative)
            {
                Application.Current.MainPage = GenerateNavigationPageDelegate(page);
            }
            else if (navigateMode == NavigateMode.Master)
            {
                //if ((retriveMasterDetailPage == null) )
                //{
                MasterDetailPage masterDetailPage = GenerateMasterDetailPageDelegate();
                masterDetailPage.Detail = GenerateNavigationPageDelegate(page);
                Application.Current.MainPage = masterDetailPage;
                //}
                //else
                //{
                //    retriveMasterDetailPage.Detail = GenerateNavigationPageDelegate(page);
                //}
            }
            else
            {
                Application.Current.MainPage = page;
            }
            //}

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName
                .Replace(".ViewModels.", ".Views.")
                .Replace("ViewModel", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        public async Task GoBackAsync()
        {
            var navigationPage = GetNavigationPageDelegate();
            if (navigationPage != null)
            {
                await PreviousPageViewModel.ComeBackAsync();
                await navigationPage.PopAsync();
            }
        }

        public async Task GoBackAsync(object parameter)
        {
            var navigationPage = GetNavigationPageDelegate();
            if (navigationPage != null)
            {
                await PreviousPageViewModel.ComeBackAsync(parameter);
                await navigationPage.PopAsync();
            }
        }
    }
}
