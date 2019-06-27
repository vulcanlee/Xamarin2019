using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                string file = "";
                using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load("icon.png"))
                {
                    image.Mutate(x => x
                         .Resize((int)item.Width, (int)item.Height));
                    if (item.Filename.Contains("ItunesArtwork@2x"))
                    {
                        file = item.Filename.Replace("ItunesArtwork@2x", "tmp");
                    }
                    else
                    {
                        file = item.Filename;
                    }
                    string filename = Path.Combine(mainPath, file);
                    image.Save(filename); // Automatic encoder selected based on extension.
                    image.Dispose();
                }
                if (item.Filename.Contains("ItunesArtwork@2x"))
                {
                    RemTransp(Path.Combine(mainPath, file));
                    string fileSource = Path.Combine(mainPath, file);
                    string fileTarget = Path.Combine(mainPath, item.Filename);
                    File.Delete(fileSource);
                }
            }

        }
        void RemTransp(string file)
        {
            Bitmap src = new Bitmap(file);
            Bitmap target = new Bitmap(src.Size.Width, src.Size.Height, PixelFormat.Format32bppRgb);
            target.SetResolution(72.0f, 72.0f);
            Graphics g = Graphics.FromImage(target);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.White)), 0, 0, target.Width, target.Height);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, target.Width, target.Height);
            g.DrawImage(src, 0, 0);
            target.Save(file.Replace("tmp", "ItunesArtwork@2x"));
            src.Dispose();
            target.Dispose();
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
