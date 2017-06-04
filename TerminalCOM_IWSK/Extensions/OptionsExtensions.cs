using System.IO.Ports;
using System.Linq;
using System.Windows.Controls;
using Collections = TerminalCOM_IWSK.Resources.OptionsCollections;

namespace TerminalCOM_IWSK.Extensions
{
    public static class OptionsExtensions
    {
        public static void FillOptionsComboBoxes(this MainWindow mainWindow)
        {
            mainWindow.portComboBox.FillPortsComboBox();
            mainWindow.speedComboBox.FillSpeedComboBox();
            mainWindow.dataComboBox.FillDataBitesComboBox();
            mainWindow.parityComboBox.FillParityBiteComboBox();
            mainWindow.stopComboBox.FillStopBiteComboBox();
        }

        public static void SetDefaultComboBoxesValues(this MainWindow mainWindow)
        {
            mainWindow.portComboBox.Text = Collections.Ports.FirstOrDefault();
            mainWindow.speedComboBox.Text = Collections.Speeds.FirstOrDefault().ToString();
            mainWindow.dataComboBox.Text = Collections.DataBites.FirstOrDefault().ToString();
            mainWindow.parityComboBox.Text = Collections.Parities.FirstOrDefault();
            mainWindow.stopComboBox.Text = Collections.StopBits.FirstOrDefault();
        }

        public static void ReturnComboBoxesValues(this MainWindow mainWindow, SerialPort serialPort)
        {
            mainWindow.portComboBox.Text = serialPort.PortName.ToString();
            mainWindow.speedComboBox.Text = serialPort.BaudRate.ToString();
            mainWindow.dataComboBox.Text = serialPort.DataBits.ToString();
            mainWindow.parityComboBox.Text = serialPort.Parity.ToString();
            mainWindow.stopComboBox.Text = serialPort.StopBits.ToString();
        }

        private static void FillSpeedComboBox(this ComboBox comboBox)
           => comboBox.ItemsSource = Collections.Speeds;

        private static void FillPortsComboBox(this ComboBox comboBox)
            => comboBox.ItemsSource = Collections.Ports;

        private static void FillDataBitesComboBox(this ComboBox comboBox)
            => comboBox.ItemsSource = Collections.DataBites;

        private static void FillParityBiteComboBox(this ComboBox comboBox)
            => comboBox.ItemsSource = Collections.Parities;

        private static void FillStopBiteComboBox(this ComboBox comboBox)
            => comboBox.ItemsSource = Collections.StopBits;
    }
}
