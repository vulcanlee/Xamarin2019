using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFlexLayout.Helpers
{
    public class ScreenInfo
    {
        public static double ScreenPixelWidth { get; set; }
        public static double ScreenPixelHeight { get; set; }
        public static double DesignScreenWidth { get; set; } 
        public static double DesignScreenHeight { get; set; }
        public static double DesignTimeScreenWidth { get; set; } = 360;
        public static double DesignScalar { get; set; }
        public static double Density { get; set; }
        public static double GetNewDesingSize(double value)
        {
            return DesignScalar * value;
        }
    }
}
