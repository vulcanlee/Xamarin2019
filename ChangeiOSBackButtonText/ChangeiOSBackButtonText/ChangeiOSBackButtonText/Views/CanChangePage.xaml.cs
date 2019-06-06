using ChangeiOSBackButtonText.Interfaces;
using ChangeiOSBackButtonText.ViewModels;
using Xamarin.Forms;

namespace ChangeiOSBackButtonText.Views
{
    public partial class CanChangePage : ContentPage, IDynamicChangeBackText
    {
        CanChangePageViewModel canChangePageViewModel;
        public CanChangePage()
        {
            InitializeComponent();

            //BackButtonText = "Want";

            canChangePageViewModel = BindingContext as CanChangePageViewModel;
            canChangePageViewModel.ChangeBackButtonTextDel = ()=>
            {
                //NaviCustomPage.SetDynamicBackButtonText(this, canChangePageViewModel.Message);
                //NaviCustomPage.SetBackButtonTitle(this, canChangePageViewModel.Message);
                if(App.Current.MainPage is MasterDetailPage)
                {
                    MasterDetailPage masterDetailPage = App.Current.MainPage as MasterDetailPage;
                    if(masterDetailPage.Detail is NaviCustomPage)
                    {
                        NaviCustomPage naviCustomPage = masterDetailPage.Detail as NaviCustomPage;
                        naviCustomPage.DynamicBackButtonText = canChangePageViewModel.Message;
                    }
                } else if(App.Current.MainPage is NaviCustomPage)
                {
                    NaviCustomPage naviCustomPage = App.Current.MainPage as NaviCustomPage;
                    naviCustomPage.DynamicBackButtonText = canChangePageViewModel.Message;
                }
            };
        }

        public string BackButtonText { get; set; }
    }
}
