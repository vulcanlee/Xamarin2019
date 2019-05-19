using System;
using System.Collections.Generic;
using System.Text;

namespace XAAlarmManager.Interfaces
{
    public interface IAlert
    {
        void Set(string title, string message,int ms);
    }
}
