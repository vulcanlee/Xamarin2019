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

namespace XAAlarmManager.Droid
{
    public class MyAlert : Interfaces.IAlert
    {
        public void Set(string title, string message, int ms)
        {
            var alarmIntent = new Intent(Application.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("title", title);
            alarmIntent.PutExtra("message", message);

            var pending = PendingIntent.GetBroadcast(Application.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

            var alarmManager = Application.Context.GetSystemService(Context.AlarmService).JavaCast<AlarmManager>();
            alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + ms, pending);
        }
    }
}