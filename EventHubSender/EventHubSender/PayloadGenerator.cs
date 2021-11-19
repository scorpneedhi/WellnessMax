using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    internal class PayloadGenerator
    {
        private static readonly Random Getrandom = new Random();
        List<string> _devicename = new List<String>() { "pump1", "pump2", "pump3", "pump4" };
        List<string> _ledColor = new List<String>() { "red", "yellow", "orange", "green" };

        public PayloadGenerator()
        {

        }

        public static int GetRandomNumber()
        {
            lock(Getrandom) //synchonrize
            {
                return Getrandom.Next(1,4);
            }
        }

        public string Payload()
        {
            dynamic data = new ExpandoObject();
            data.device = _devicename[GetRandomNumber()];
            data.ledColor = _ledColor[GetRandomNumber()];

            return JsonConvert.SerializeObject(data);
        }
    }
}
