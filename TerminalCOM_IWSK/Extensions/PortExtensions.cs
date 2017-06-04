using System;
using System.IO.Ports;

namespace TerminalCOM_IWSK.Extensions
{
    internal static class PortExtensions
    {
        public static SerialPort InitializeSerialPortWithDefaultValues()
        {
            var serialPort = new SerialPort()
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };
            //serialPort.DataReceived += new SerialDataReceivedEventHandler()

            return serialPort;
        }

        public static void SaveSerialPortOptions(this SerialPort serialPort, MainWindow mainWindow)
        {
            serialPort.PortName = mainWindow.portComboBox.Text;
            serialPort.BaudRate = int.Parse(mainWindow.speedComboBox.Text);
            serialPort.DataBits = int.Parse(mainWindow.dataComboBox.Text);
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), mainWindow.parityComboBox.Text);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), mainWindow.stopComboBox.Text);
        }
    }
}
