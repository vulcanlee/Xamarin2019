using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DynamicFlexLayout.Models
{
    public class ItemBlock
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Color Color { get; set; }
        public bool ShowLabel { get; set; }
        public bool ShowBoxView { get; set; } = true;
    }
}
