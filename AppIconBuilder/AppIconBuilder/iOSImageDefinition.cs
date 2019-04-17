using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppIconBuilder
{
    public class iOSImageDefinition
    {
        public List<iOSImageItem> Images { get; set; }
        public Info info { get; set; }
        public void CalculateSize()
        {
            foreach (var item in Images)
            {
                item.CalculateSize();
            }
        }
        public void GenerateIcons(string mainPath)
        {
            if (Directory.Exists(mainPath) == false)
            {
                Directory.CreateDirectory(mainPath);
            }
            foreach (var item in Images)
            {
                using (Image<Rgba32> image = Image.Load("icon.png"))
                {
                    image.Mutate(x => x
                         .Resize((int)item.Width, (int)item.Height));
                    string filename = Path.Combine(mainPath, item.Filename);
                    image.Save(filename); // Automatic encoder selected based on extension.
                }
            }

        }
    }
    public class iOSImageItem
    {
        public string Idiom { get; set; }
        public string Size { get; set; }
        public string Scale { get; set; }
        public string Filename { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public void CalculateSize()
        {
            var fooSize = Convert.ToDouble(Size.Split('x')[0]);
            var fooScale = Convert.ToInt32(Scale.Replace("x", ""));
            Width = fooSize * fooScale;
            Height = fooSize * fooScale;
        }
    }

    public class Info
    {
        public int Version { get; set; }
        public string Author { get; set; }
    }
}
