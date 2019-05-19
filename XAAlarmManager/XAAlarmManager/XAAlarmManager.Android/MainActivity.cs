using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Toasts;
using Prism;
using Prism.Ioc;

[assembly: UsesPermission(Name = Android.Manifest.Permission.WakeLock)]
[assembly: UsesPermission(Name = Android.Manifest.Permission.SetAlarm)]
namespace XAAlarmManager.Droid
{
    [Activity(Label = "XAAlarmManager", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            ToastNotification.Init(this);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<IToastNotificator, ToastNotification>();
            containerRegistry.Register<Interfaces.IAlert, MyAlert>();
        }
    }
}

