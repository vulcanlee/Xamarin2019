using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Vulcan.Courses.XamarinForms.NaviServices
{
    public enum NavigateMode
    {
        Absolute,
        Relative,
        RestartRelative,
        Master
    }
    public interface INaviService
    {
        //Func<NavigationPage> GetNavigationPageDelegate;
        ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>(NavigateMode navigateMode = NavigateMode.Relative) where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter, NavigateMode navigateMode = NavigateMode.Relative) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();

        Task RemoveNoneRootAsync();

        Task GoBackAsync();

        Task GoBackAsync(object parameter);
    }
}
