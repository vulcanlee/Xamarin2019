using Xamarin.Forms;

namespace ChangeiOSBackButtonText.Views
{
    public partial class NaviCustomPage : NavigationPage
    {
        #region DynamicBackButtonText 可綁定屬性 BindableProperty
        public static readonly BindableProperty DynamicBackButtonTextProperty =
            BindableProperty.Create("DynamicBackButtonText", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(NaviCustomPage), // 宣告類型 
                "", // 預設值 
                propertyChanged: OnDynamicBackButtonTextChanged  // 屬性值異動時，要執行的事件委派方法
            );

        public string DynamicBackButtonText
        {
            set
            {
                SetValue(DynamicBackButtonTextProperty, value);
            }
            get
            {
                return (string)GetValue(DynamicBackButtonTextProperty);
            }
        }

        private static void OnDynamicBackButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        #endregion

        //#region DynamicBackButtonText 附加屬性 Attached Property
        //public static readonly BindableProperty DynamicBackButtonTextProperty =
        //       BindableProperty.CreateAttached(
        //           propertyName: "DynamicBackButtonText",   // 屬性名稱 
        //           returnType: typeof(string), // 回傳類型 
        //           declaringType: typeof(NaviCustomPage), // 宣告類型 
        //           defaultValue: "", // 預設值 
        //           propertyChanged: OnDynamicBackButtonTextChanged  // 屬性值異動時，要執行的事件委派方法
        //       );

        //public static void SetDynamicBackButtonText(BindableObject bindable, string entryType)
        //{
        //    bindable.SetValue(DynamicBackButtonTextProperty, entryType);
        //}
        //public static string GetDynamicBackButtonText(BindableObject bindable)
        //{
        //    return (string)bindable.GetValue(DynamicBackButtonTextProperty);
        //}

        //private static void OnDynamicBackButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //}
        //#endregion

        public NaviCustomPage()
        {
            InitializeComponent();
        }
    }
}
