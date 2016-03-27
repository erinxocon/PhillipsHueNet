using Q42.HueApi.Interfaces;
using PhillipsHueNet.DataModel;
using System.IO;
using Q42.HueApi;
using System.Threading.Tasks;
using System;

namespace PhillipsHueNet
{
    class Program
    {
        static bool configFileExists = File.Exists("AppConfig.xml");

        static void Main(string[] args)
        {
            RunCommands();
            Console.ReadKey();
        }

        static async void RunCommands()
        {
            ILocalHueClient client = await GetClient();
            var command = new LightCommand();
            command.Brightness = 255;
            await client.SendCommandAsync(command);
        }

        static async Task<ILocalHueClient> GetClient()
        {
            HueApp app;
            if (configFileExists)
            {
                app = Serializers.DeserializeFromFile();
                ILocalHueClient client = await app.GetExistingClient();
                return client;
            }
            else
            {
                app = new HueApp();
                ILocalHueClient client = await app.InitializeNewApp();
                Serializers.SerializeToFile(app);
                return client;
            }
        }
    }
}
