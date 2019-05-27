using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendPushNotification
{
    public class Constants
    {
        public static string APNS_P12FILENAME { get; set; } = "com.vulcan.azurehub.p12";
        public static string PUSH_CERT_PWD { get; set; } = "";
        public static string GCM_SENDER_ID { get; set; } = "";
        public static string AUTH_TOKEN { get; set; } = "";
    }
}
