using System;
using System.Xml.Serialization;
using PhillipsHueNet.DataModel;
using System.IO;
using System.Xml;

namespace PhillipsHueNet
{
    static class Serializers
    {
        static XmlSerializer _ser = new XmlSerializer(typeof(HueApp));

        static string configFile = "AppConfig.xml";

        static public HueApp DeserializeFromFile()
        {
            HueApp app;
            using (FileStream fs = File.OpenRead(configFile))
            {
                var reader = XmlReader.Create(fs);
                app = (HueApp)_ser.Deserialize(reader);
            }

            return app;
        }

        static public void SerializeToFile(HueApp app)
        {
            using (FileStream fs = File.Create(configFile))
            {
                _ser.Serialize(fs, app);
            }
        }
    }
}
