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
        internal static System.Timers.Timer TwoSecondTimer = new System.Timers.Timer(10000);
        public static void init()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            TwoSecondTimer.Elapsed += TwoSecondTimer_Elapsed;
            TwoSecondTimer.Start();

        }

        private static void TwoSecondTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            read_data();
        }

        private  static void read_data()
        {

            bool sucess = false;
            string json = _serialPort.ReadExisting();
            while (!sucess)
            {
                if (json == "")
                {
                    Thread.Sleep(5000);
                    continue;
                }
                try
                {
                    data = JObject.Parse(json);
                    sucess = true;
                }
                catch
                {
                    continue;
                }

                

            }
        }  
    }
}
