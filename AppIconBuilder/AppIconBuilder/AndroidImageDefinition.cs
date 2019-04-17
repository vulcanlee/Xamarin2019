using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppIconBuilder
{
    public class AndroidImageDefinition
    {
        public List<AndroidImageItem> Images { get; set; }
        public void Initialization()
        {
            Images = new List<AndroidImageItem>();
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-hdpi",
                Filename = "ic_launcher.png",
                Width = 72,
                Height = 72,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-ldpi",
                Filename = "ic_launcher.png",
                Width = 36,
                Height = 36,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-mdpi",
                Filename = "ic_launcher.png",
                Width = 48,
                Height = 48,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-xhdpi",
                Filename = "ic_launcher.png",
                Width = 96,
                Height = 96,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-xxhdpi",
                Filename = "ic_launcher.png",
                Width = 144,
                Height = 144,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "mipmap-xxxhdpi",
                Filename = "ic_launcher.png",
                Width = 192,
                Height = 192,
            });
        }
        public void ChangeRole()
        {
            foreach (var item in Images)
            {
                item.Path = item.Path.Replace("mipmap", "drawable");
                item.Filename = item.Filename.Replace("ic_launcher", "icon");
            }
        }
        public void GenerateIcons(string mainPath)
        {
            foreach (var item in Images)
            {
                string path = Path.Combine(mainPath, item.Path);
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                using (Image<Rgba32> image = Image.Load("icon.png"))
                {
                    image.Mutate(x => x
                         .Resize((int)item.Width, (int)item.Height));
                    string filename = Path.Combine(path, item.Filename);
                    image.Save(filename); // Automatic encoder selected based on extension.
                }
            }

        }
    }
    public class AndroidImageItem
    {
        public string Filename { get; set; }
        public string Path { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
