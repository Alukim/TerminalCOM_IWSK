using System.IO.Ports;
using System.Windows;
using System.Windows.Media;
using TerminalCOM_IWSK.Extensions;
using static TerminalCOM_IWSK.Extensions.PortExtensions;
using static TerminalCOM_IWSK.Extensions.MainWindowExtensions;

namespace TerminalCOM_IWSK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SerialPort serialPort;

        private void InitializeOptions()
        {
            this.FillOptionsComboBoxes();
            this.SetDefaultComboBoxesValues();
        }

        private void InitializeTerminal()
        {
            this.ChangeStatusOfConnection(Colors.Red, "Brak połączenia");
            this.InitializeRichTextBox();
            this.InitializeButtons();
        }

        private void InitializePort()
            => serialPort = InitializeSerialPortWithDefaultValues(WriteResponseData);

        public MainWindow()
        {
            InitializeComponent();
            InitializeOptions();
            InitializeTerminal();
            InitializePort();
        }

        public void WriteResponseData(object sender, SerialDataReceivedEventArgs eventArgs)
        {
            this.ReceivedData();
        }

        public void SetDefaultButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SetDefaultComboBoxesValues();
            this.SaveSerialPortOptions();
            ShowInformation("Przywrócono ustawienia domyślne.");
        }

        public void SaveOptionsButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SaveSerialPortOptions();
            ShowInformation("Zapisano nowe ustawienia");
        }

        public void ReturnButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.ReturnComboBoxesValues(serialPort);
            ShowInformation("Przywrócono nie zapisane zmiany");
        }

        public void ConnectButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.ConnectToDevice();
        }

        public void DisconnectButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.DisconnectDevice();
        }

        public void SentButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SendMessage();
        }
    }
}
