using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Vulcan.Courses.XamarinForms.NaviServices
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // 這裡需要提供 INaviService 的實作物件
        public INaviService NavigationService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(INaviService naviService)
        {
            //NavigationService = (Application.Current as App).NavigationService;
            NavigationService = naviService;
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public virtual Task ComeBackAsync()
        {
            return Task.FromResult(false);
        }

        public virtual Task ComeBackAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
