using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Prism.Events;
using ForceOrientation.Events;

namespace ForceOrientation.Droid
{
    [Activity(Label = "ForceOrientation", Icon = "@mipmap/ic_launcher",
        Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
            SubscribePrismEvent();
        }

        public void SubscribePrismEvent()
        {
            IContainerProvider containerProvider = App.Current.Container;
            IEventAggregator eventAggregator = containerProvider.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<CustomScreenOrientationEvent>().Subscribe(x =>
            {
                if (x.CustomScreenOrientation == CustomScreenOrientation.Unspecified)
                {
                    RequestedOrientation = ScreenOrientation.Unspecified;
                }
                else if (x.CustomScreenOrientation == CustomScreenOrientation.UserPortrait)
                {
                    RequestedOrientation = ScreenOrientation.Portrait;
                }
                else
                {
                    RequestedOrientation = ScreenOrientation.Landscape;
                }
            });
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

