using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace TerminalCOM_IWSK.Resources
{
    internal static class OptionsCollections
    {
        public static IReadOnlyCollection<int> Speeds = new List<int> { 2400, 4800, 9600, 14400, 19200, 28800 };
        public static IReadOnlyCollection<string> Ports = SerialPort.GetPortNames();
        public static IReadOnlyCollection<int> DataBites = new List<int> { 5, 6, 7, 8 };
        public static IReadOnlyCollection<string> Parities = Enum.GetNames(typeof(Parity));
        public static IReadOnlyCollection<string> StopBits
        {
            get
            {
                var bits = new List<string>();
                foreach (var value in Enum.GetNames(typeof(StopBits)))
                {
                    if (value != System.IO.Ports.StopBits.None.ToString())
                    {
                        bits.Add(value);
                    }
                }
                return bits;
            }
        }
    }
}
