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

        public static JObject data = new JObject();

        public static void init()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }

        private static JObject read_data()
        {
           

           
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
                    Thread.Sleep(5000);
                }
                catch
                {
                    continue;
                }

                

            }
        }  
    }
}
