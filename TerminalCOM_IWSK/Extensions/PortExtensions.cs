using System;
using System.IO.Ports;
using System.Windows.Media;

namespace TerminalCOM_IWSK.Extensions
{
    internal static class PortExtensions
    {
        public static SerialPort InitializeSerialPortWithDefaultValues(Action<object, SerialDataReceivedEventArgs> dataReceivedDelegate)
        {
            var serialPort = new SerialPort()
            {
                ReadTimeout = 500,
                WriteTimeout = 500,
            };
            serialPort.DataReceived += new SerialDataReceivedEventHandler((obj, dataReceived) => 
                {
                    dataReceivedDelegate.Invoke(obj, dataReceived);
                });

            return serialPort;
        }

        public static void SaveSerialPortOptions(this MainWindow mainWindow)
        {
            var serialPort = mainWindow.serialPort;
            serialPort.PortName = mainWindow.portComboBox.Text;
            serialPort.BaudRate = int.Parse(mainWindow.speedComboBox.Text);
            serialPort.DataBits = int.Parse(mainWindow.dataComboBox.Text);
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), mainWindow.parityComboBox.Text);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), mainWindow.stopComboBox.Text );
        }

        public static void ConnectToDevice(this MainWindow mainWindow)
        {
            var serialPort = mainWindow.serialPort;
            if(!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    mainWindow.DisableAllFields();
                    mainWindow.ChangeStatusOfConnection(Colors.Green, $"Połączono z portem: {serialPort.PortName}");
                }
                catch(Exception exception)
                {
                    mainWindow.ChangeStatusOfConnection(Colors.Red, $"Błąd połączenia z portem: {serialPort.PortName}");
                    mainWindow.EnableAllFields();
                    MainWindowExtensions.ShowError($"Błąd połączenia: \n{exception.Message}");
                }
            }
        }
    }
}
