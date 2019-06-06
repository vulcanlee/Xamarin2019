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

        public NaviCustomPage()
        {
            InitializeComponent();
        }
    }
}
