using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.IO.Ports;
using System.Threading;

namespace Aquaponics1
{
    static class SerialListener
    {
        static SerialPort _serialPort;

        public static void init()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }

        public static JObject read_data()
        {
            return new JObject();

            JObject data = new JObject();
            string json = _serialPort.ReadExisting();
            while (true)
            {
                if (json == "")
                {
                    Thread.Sleep(5000);
                    continue;
                }
                try
                {
                    data = JObject.Parse(json);
                }
                catch
                {
                    continue;
                }

                return data;

            }
        }  
    }
}
