using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppIconBuilder
{
    public class iTunesImageDefinition
    {
        public List<AndroidImageItem> Images { get; set; }
        public void Initialization()
        {
            Images = new List<AndroidImageItem>();
            Images.Add(new AndroidImageItem()
            {
                Path = "AppStore",
                Filename = "iTunesArtwork@1x.png",
                Width = 512,
                Height = 512,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "AppStore",
                Filename = "iTunesArtwork@2x.png",
                Width = 1024,
                Height = 1024,
            });
            Images.Add(new AndroidImageItem()
            {
                Path = "AppStore",
                Filename = "iTunesArtwork@3x.png",
                Width = 1536,
                Height = 1536,
            });
        }
        public void GenerateIcons(string mainPath)
        {
            foreach (var item in Images)
            {
                string path = Path.Combine(mainPath, "");
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
}
