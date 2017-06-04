using System;
using System.IO.Ports;
using System.Windows;
using TerminalCOM_IWSK.Extensions;

namespace TerminalCOM_IWSK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SerialPort serialPort;

        private void InitializeOptions()
        {
            this.FillOptionsComboBoxes();
            this.SetDefaultComboBoxesValues();
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeOptions();

            serialPort = PortExtensions.InitializeSerialPortWithDefaultValues();
        }

        public void SetDefaultButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.SetDefaultComboBoxesValues();
        }

    }
}
