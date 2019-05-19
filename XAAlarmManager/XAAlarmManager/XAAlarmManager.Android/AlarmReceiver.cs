using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
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
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "AlarmReceiver");
            wakeLock.Acquire();


            // Run your code here
            string title = "";
            string message = "";
            if (intent.Extras != null)
            {
                title = intent.GetStringExtra("title");
                message = intent.GetStringExtra("message");
            }
            var pendingIntent = PendingIntent.GetActivity(context, DateTime.Now.Millisecond, intent, PendingIntentFlags.OneShot);
            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(context)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            NotificationManager notificationManager;
            notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                notificationManager.Notify(DateTime.Now.Millisecond, notificationBuilder.Build());
            }
            else
            {
                notificationBuilder.SetChannelId("123");
                var name = "123";
                var description = message;
                var channel = new NotificationChannel("123", name, NotificationImportance.Default)
                {
                    Description = description,
                };

                notificationManager.CreateNotificationChannel(channel);
                notificationManager.Notify(DateTime.Now.Millisecond, notificationBuilder.Build());
            }

            wakeLock.Release();
        }
    }
}