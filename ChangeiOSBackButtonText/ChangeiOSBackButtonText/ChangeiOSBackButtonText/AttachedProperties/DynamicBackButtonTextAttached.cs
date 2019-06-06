using ChangeiOSBackButtonText.Helpers;
using ChangeiOSBackButtonText.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChangeiOSBackButtonText.AttachedProperties
{
    public class DynamicBackButtonTextAttached
    {
        #region SetBackButtonText 附加屬性 Attached Property
        public static readonly BindableProperty SetBackButtonTextProperty =
               BindableProperty.CreateAttached(
                   propertyName: "SetBackButtonText",   // 屬性名稱 
                   returnType: typeof(string), // 回傳類型 
                   declaringType: typeof(ContentPage), // 宣告類型 
                   defaultValue: null, // 預設值 
                   propertyChanged: OnSetBackButtonTextChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetSetBackButtonText(BindableObject bindable, string entryType)
        {
            bindable.SetValue(SetBackButtonTextProperty, entryType);
        }
        public static string GetSetBackButtonText(BindableObject bindable)
        {
            return (string)bindable.GetValue(SetBackButtonTextProperty);
        }

        private static void OnSetBackButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ContentPage page = bindable as ContentPage;
            if (page == null) return;
            string oldString = oldValue as string;
            string newString = newValue as string;

            if (newString == null) return;

            if(page is IDynamicChangeBackText)
            {
                ChangeBackButtonTextHelper.ChangeBackButtonText(newString);
            }
        }
        #endregion
    }
}
