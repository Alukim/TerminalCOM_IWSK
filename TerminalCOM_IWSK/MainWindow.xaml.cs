using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Media;
using TerminalCOM_IWSK.Extensions;

namespace TerminalCOM_IWSK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly SerialPort serialPort;

        private void InitializeOptions()
        {
            this.FillOptionsComboBoxes();
            this.SetDefaultComboBoxesValues();
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeOptions();

            serialPort = PortExtensions.InitializeSerialPortWithDefaultValues(WriteResponseData);
        }

        public void WriteResponseData(object sender, SerialDataReceivedEventArgs eventArgs)
        {
            
        }

        public void SetDefaultButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SetDefaultComboBoxesValues();
            this.SaveSerialPortOptions();
            MainWindowExtensions.ShowInformation("Przywrócono ustawienia domyślne.");
        }

        public void SaveOptionsButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SaveSerialPortOptions();
            MainWindowExtensions.ShowInformation("Zapisano nowe ustawienia");
        }

        public void ReturnButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.ReturnComboBoxesValues(serialPort);
            MainWindowExtensions.ShowInformation("Przywrócono nie zapisane zmiany");
        }

        public void ConnectButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.ConnectToDevice();
        }
    }
}
