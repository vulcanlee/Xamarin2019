using ChangeiOSBackButtonText.AttachedProperties;
using ChangeiOSBackButtonText.Interfaces;
using ChangeiOSBackButtonText.ViewModels;
using Xamarin.Forms;

namespace ChangeiOSBackButtonText.Views
{
    public partial class CanChangePage : ContentPage, IDynamicChangeBackText
    {
        public CanChangePage()
        {
            InitializeComponent();
        }
    }
}
