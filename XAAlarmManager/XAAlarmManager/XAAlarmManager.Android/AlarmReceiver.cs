using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Toasts;
using Prism.Ioc;

namespace XAAlarmManager.Droid
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();


            // Run your code here
            IContainerProvider container = App.Current.Container;
            IToastNotificator toastNotificator = container.Resolve<IToastNotificator>();
            NotificationOptions options;
            if (intent.Extras != null)
            {
                string title = intent.GetStringExtra("title");
                string message = intent.GetStringExtra("message");
                options = new NotificationOptions()
                {
                    Title = title,
                    Description = message
                };
            }
            else
            {
                options = new NotificationOptions()
                {
                    Title = "提示",
                    Description = "鬧鈴已經到時"
                };
            }

            var result = await toastNotificator.Notify(options);


            wakeLock.Release();
        }
    }
}