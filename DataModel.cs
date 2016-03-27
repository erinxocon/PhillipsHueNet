using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhillipsHueNet.DataModel
{
    public class HueApp
    {
        public string IpAddress { get; set; }
        public string AppKey { get; set; }
        public string AppName { get; set; } = "IF5App";
        public string DeviceName { get; set; } = "IFServer";
        public string ConfigFile { get; } = "AppConfig.xml";


        private async Task<ILocalHueClient> GetBridgeClient()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            IEnumerable<string> bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
            IpAddress = bridgeIPs.FirstOrDefault();
            ILocalHueClient client = new LocalHueClient(IpAddress);
            return client;
        }

        public async Task<ILocalHueClient> InitializeNewApp()
        {
            ILocalHueClient client = await GetBridgeClient();
            Console.WriteLine("Press the button on the base station...");
            //Console.ReadKey();
            AppKey = await client.RegisterAsync(AppName, DeviceName);
            return client;
        }

        public async Task<ILocalHueClient> GetExistingClient()
        {
            ILocalHueClient client = await GetBridgeClient();
            client.Initialize(AppKey);
            return client;
        }
    }
}
