using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFCharCount
{
    public class CharCountAttachedProperty
    {
        #region EnableCharCount 附加屬性 Attached Property
        public static readonly BindableProperty EnableCharCountProperty =
               BindableProperty.CreateAttached(
                   propertyName: "EnableCharCount",   // 屬性名稱 
                   returnType: typeof(bool), // 回傳類型 
                   declaringType: typeof(View), // 宣告類型 
                   defaultValue: false, // 預設值 
                   propertyChanged: OnEnableCharCountChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetEnableCharCount(BindableObject bindable, bool entryType)
        {
            bindable.SetValue(EnableCharCountProperty, entryType);
        }
        public static bool GetEnableCharCount(BindableObject bindable)
        {
            return (bool)bindable.GetValue(EnableCharCountProperty);
        }

        private static void OnEnableCharCountChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Entry || bindable is Editor)
            {
                bool isEnable = (bool)newValue;
                if (isEnable)
                {
                    if (bindable is Entry)
                    {
                        (bindable as Entry).TextChanged += OnEntryTextChanged;
                    }
                    else if (bindable is Editor)
                    {
                        (bindable as Editor).TextChanged += OnEntryTextChanged;
                    }
                }
                else
                {
                    if (bindable is Entry)
                    {
                        (bindable as Entry).TextChanged -= OnEntryTextChanged;
                    }
                    else if (bindable is Editor)
                    {
                        (bindable as Editor).TextChanged -= OnEntryTextChanged;
                    }
                }
            }
            else
            {

            }
        }
        #endregion
        private static void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            int foo = CharCountAttachedProperty.GetCharNumber(sender as BindableObject);
            int length = e.NewTextValue.Length;
            CharCountAttachedProperty.SetCharNumber(sender as BindableObject, length);
            (sender as BindableObject).SetValue(CharNumberProperty, length);
            int foo2 = CharCountAttachedProperty.GetCharNumber(sender as BindableObject);
        }

        #region CharNumber 附加屬性 Attached Property
        public static readonly BindableProperty CharNumberProperty =
               BindableProperty.CreateAttached(
                   propertyName: "CharNumber",   // 屬性名稱 
                   returnType: typeof(int), // 回傳類型 
                   declaringType: typeof(View), // 宣告類型 
                   defaultValue: 0, // 預設值 
                   propertyChanged: OnCharNumberChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetCharNumber(BindableObject bindable, int entryType)
        {
            bindable.SetValue(CharNumberProperty, entryType);
        }
        public static int GetCharNumber(BindableObject bindable)
        {
            return (int)bindable.GetValue(CharNumberProperty);
        }

        private static void OnCharNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        #endregion

    }
}
