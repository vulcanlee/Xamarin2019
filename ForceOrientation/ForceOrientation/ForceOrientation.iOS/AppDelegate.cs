using CoreFoundation;
using ForceOrientation.Events;
using Foundation;
using ObjCRuntime;
using Prism;
using Prism.Events;
using Prism.Ioc;
using UIKit;


namespace ForceOrientation.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        CustomScreenOrientation ScreenOrientation = CustomScreenOrientation.Unspecified;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));
            SubscribePrismEvent();
            return base.FinishedLaunching(app, options);
        }
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
        {
            if (ScreenOrientation == CustomScreenOrientation.Unspecified)
            {
                return UIInterfaceOrientationMask.All;
            }
            else if (ScreenOrientation == CustomScreenOrientation.UserLandscape)
            {
                return UIInterfaceOrientationMask.Landscape;
            }
            else
            {
                return UIInterfaceOrientationMask.Portrait;
            }
        }
        public void SubscribePrismEvent()
        {
            IContainerProvider containerProvider = App.Current.Container;
            IEventAggregator eventAggregator = containerProvider.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<CustomScreenOrientationEvent>().Subscribe(x =>
            {
                ScreenOrientation = x.CustomScreenOrientation;
                NSNumber n ;
                NSString key = new NSString("orientation");
                if (x.CustomScreenOrientation == CustomScreenOrientation.Unspecified)
                {
                    n = new NSNumber((int)UIInterfaceOrientation.Unknown);
                }
                else if (x.CustomScreenOrientation == CustomScreenOrientation.UserPortrait)
                {
                    n = new NSNumber((int)UIInterfaceOrientation.Portrait);
                }
                else
                {
                    n = new NSNumber((int)UIInterfaceOrientation.LandscapeLeft);
                }
                UIDevice.CurrentDevice.SetValueForKey(
      new NSNumber((int)n),
      new NSString("orientation"));
                UIViewController.AttemptRotationToDeviceOrientation();

                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                });
            });
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
