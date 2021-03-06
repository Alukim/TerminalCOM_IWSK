﻿using System;
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
                    mainWindow.EnableAfterConnection();
                    mainWindow.ChangeStatusOfConnection(Colors.Green, $"Połączono z portem: {serialPort.PortName}");
                }
                catch(Exception exception)
                {
                    mainWindow.ChangeStatusOfConnection(Colors.Red, $"Błąd połączenia z portem: {serialPort.PortName}");
                    mainWindow.EnableAllFields();
                    mainWindow.EnableAfterDisconnection();
                    MainWindowExtensions.ShowError($"Błąd połączenia: \n{exception.Message}");
                }
            }
        }

        public static void DisconnectDevice(this MainWindow mainWindow)
        {
            if(mainWindow.serialPort.IsOpen)
            {
                mainWindow.serialPort.Close();
            }

            mainWindow.EnableAllFields();
            mainWindow.EnableAfterDisconnection();
            mainWindow.ChangeStatusOfConnection(Colors.Red, "Brak połączenia");
        }

        public static void SendMessage(this MainWindow mainWindow)
        {
            if (mainWindow.serialPort.IsOpen)
            {
                var command = mainWindow.commandText.Text;
                mainWindow.textBox.AddColorText($"Master: {command}", Brushes.Blue);
                mainWindow.serialPort.WriteLine(command);
            }
            else
            {
                MainWindowExtensions.ShowInformation("Aby wysłać komendę musisz ustanowić połączenie");
            }
        }

        public static void ReceivedData(this MainWindow mainWindow)
        {
            var inputData = mainWindow.serialPort.ReadExisting();
            if (!string.IsNullOrEmpty(inputData))
            {
                mainWindow.textBox.AddColorText($"Slave: {inputData}", Brushes.Green);
            }
        }
    }
}
