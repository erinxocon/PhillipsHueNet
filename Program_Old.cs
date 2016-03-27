//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Q42.HueApi;
//using Q42.HueApi.Interfaces;
//using Q42.HueApi.NET;
//using System.Xml.Serialization;
//using System.Threading.Tasks;
//using System.IO;
//using PhillipsHueNet.DataModels;
//using System.Xml;

//namespace PhillipsHueNet
//{
//    class Program_Old
//    {
//        //static void Main(string[] args)
//        //{
//        //    RunCommands();
//        //}

//        static string IpAddress { get; set; }
//        static string AppKey { get; set; }
//        static string AppName { get; set; } = "IF 5 App";
//        static string DeviceName { get; set; } = "Test Device";
//        static string ConfigFile { get; } = "AppConfig.xml";

//        static bool AppConfigXmlExists()
//        {
//            var file = ConfigFile; 
//            return File.Exists(file);
//        }

//        static async Task<ILocalHueClient> InitializeApp()
//        {
//            var serializer = new XmlSerializer(typeof(BridgeInformation));

//            BridgeInformation bridgeInfo;


//            ILocalHueClient client;

//            if (AppConfigXmlExists())
//            {
//                //client = await new GetClient();
//                using (FileStream fs = File.OpenRead(ConfigFile))
//                {
//                    var reader = XmlReader.Create(fs);
//                    bridgeInfo = (BridgeInformation)serializer.Deserialize(reader);
//                }

//                var key = bridgeInfo.Key;

//                //client.Initialize(key);

//            }

//            else
//            {
//                Console.WriteLine("Press the button on the base station within the next 5 seconds...");
//                //client = await new GetClient();
//                //AppKey = await client.RegisterAsync(AppName, DeviceName);
//                bridgeInfo = new BridgeInformation
//                {
//                    AppName = AppName,
//                    DeviceName = DeviceName,
//                    Key = AppKey,
//                    IpAddress = IpAddress
//                };
//                using (FileStream fs = File.Create(ConfigFile))
//                {
//                    serializer.Serialize(fs, bridgeInfo);
//                }
//            }

//            return client;
//        }

//        async Task<ILocalHueClient> GetClient()
//        {
//            IBridgeLocator locator = new SSDPBridgeLocator();
//            IEnumerable<string> bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
//            var ip = bridgeIPs.FirstOrDefault();
//            Console.WriteLine(ip);
//            ILocalHueClient client = new LocalHueClient(ip);
//            return client;
//        }

//        static async void RunCommands()
//        {
//            var client = await InitializeApp();
//            var command = new LightCommand();
//            command.Alert = Alert.Once;
//            await client.SendCommandAsync(command);
//        }

//    }
//}

//namespace PhillipsHueNet.DataModels
//{
//    [Serializable]
//    public class BridgeInformation
//    {
//        [XmlElement]
//        public string AppName { get; set; }

//        [XmlElement]
//        public string DeviceName { get; set; }

//        [XmlElement]
//        public string Key { get; set; }

//        [XmlElement]
//        public string IpAddress { get; set; }
//    }
//}
