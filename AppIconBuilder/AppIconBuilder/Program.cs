using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AppIconBuilder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string mainPath = "iOS";
            var fooContents = await File.ReadAllTextAsync("Contents.json");
            iOSImageDefinition imageDefinition = JsonConvert.DeserializeObject<iOSImageDefinition>(fooContents);
            imageDefinition.CalculateSize();
            imageDefinition.GenerateIcons(mainPath);

            mainPath = "Android_Launcher";
            AndroidImageDefinition androidImageDefinition = new AndroidImageDefinition();
            androidImageDefinition.Initialization();
            androidImageDefinition.GenerateIcons(mainPath);

            mainPath = "Android_Resource";
            androidImageDefinition.ChangeRole();
            androidImageDefinition.GenerateIcons(mainPath);

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
