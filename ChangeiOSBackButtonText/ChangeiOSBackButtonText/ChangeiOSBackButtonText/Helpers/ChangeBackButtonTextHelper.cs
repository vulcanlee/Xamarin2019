using ChangeiOSBackButtonText.Interfaces;
using ChangeiOSBackButtonText.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChangeiOSBackButtonText.Helpers
{
    public class ChangeBackButtonTextHelper
    {
        public static void ChangeBackButtonText(string newBackButtonText)
        {
            NaviCustomPage naviCustomPage = GetNaviCustomPage();
            if (naviCustomPage != null)
            {
                naviCustomPage.DynamicBackButtonText = newBackButtonText;
            };
        }
        public static string GetBackButtonText()
        {
            string result = "";
            NaviCustomPage naviCustomPage = GetNaviCustomPage();
            if (naviCustomPage != null)
            {
                result = naviCustomPage.DynamicBackButtonText;
            }
            return result;
        }
        public static NaviCustomPage GetNaviCustomPage()
        {
            NaviCustomPage naviCustomPage = null;
            if (App.Current.MainPage is MasterDetailPage)
            {
                MasterDetailPage masterDetailPage = App.Current.MainPage as MasterDetailPage;
                if (masterDetailPage.Detail is NaviCustomPage)
                {
                    naviCustomPage = masterDetailPage.Detail as NaviCustomPage;
                }
            }
            else if (App.Current.MainPage is NaviCustomPage)
            {
                naviCustomPage = App.Current.MainPage as NaviCustomPage;
            }
            return naviCustomPage;
        }
    }
}
