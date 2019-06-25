using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForceOrientation.Events
{
    public enum CustomScreenOrientation
    {
        UserPortrait,
        UserLandscape,
        Unspecified
    }
    public class CustomScreenOrientationEvent : PubSubEvent<CustomScreenOrientationPayload>
    {

    }

    public class CustomScreenOrientationPayload
    {
        public CustomScreenOrientation CustomScreenOrientation { get; set; }
    }
}
