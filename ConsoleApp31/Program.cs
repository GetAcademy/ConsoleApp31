using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;

namespace ConsoleApp31
{
    internal class Program
    {
        private static T[] Add<T>(T newValue, T[] oldList = null)
        {
            if(oldList==null)oldList = new T[0];
            var list = new List<T>(oldList);
            list.Add(newValue);
            return list.ToArray();
        }

        private static void Main(string[] args)
        {
            var thing = new value();
            thing.type = "subscribe";
            thing.product_ids = Add("ETH-USD", thing.product_ids);
            thing.product_ids = Add("ETH-EUR", thing.product_ids);
            thing.channels = Add(new valueChannels() { name = "level2" }, thing.channels);
            thing.channels = Add(new valueChannels() { name = "heartbeat" }, thing.channels);
            thing.channels = Add(new valueChannels()
            {
                name = "ticker",
                product_ids = new string[] { "ETH-BTC", "ETH-USD" }
            }, thing.channels);
            var json = JsonConvert.SerializeObject(thing);
        }

        /*
                        {
                            ""name"": ""ticker"",
                            ""product_ids"": [
                                ""ETH-BTC"",
                                ""ETH-USD""
                            ]
                        }
            var wrapperJson = "{ \"value\": " + json + "}";
            var obj = (XmlDocument)JsonConvert.DeserializeXmlNode(wrapperJson);
            var xml = obj.OuterXml;         
         */
    }
}
