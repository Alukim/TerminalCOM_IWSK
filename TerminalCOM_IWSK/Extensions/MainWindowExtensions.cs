using System.Windows;

namespace TerminalCOM_IWSK.Extensions
{
    public static class MainWindowExtensions
    {
        public static void DisableAllFields(this MainWindow mainWindow)
        {
            mainWindow.portComboBox.IsEnabled = false;
            mainWindow.speedComboBox.IsEnabled = false;
            mainWindow.dataComboBox.IsEnabled = false;
            mainWindow.parityComboBox.IsEnabled = false;
            mainWindow.stopComboBox.IsEnabled = false;
            mainWindow.defaultOptionsButton.IsEnabled = false;
            mainWindow.saveOptionsButton.IsEnabled = false;
            mainWindow.returnOptionsButton.IsEnabled = false;
        }

        public static void EnableAllFields(this MainWindow mainWindow)
        {
            mainWindow.portComboBox.IsEnabled = true;
            mainWindow.speedComboBox.IsEnabled = true;
            mainWindow.dataComboBox.IsEnabled = true;
            mainWindow.parityComboBox.IsEnabled = true;
            mainWindow.stopComboBox.IsEnabled = true;
            mainWindow.defaultOptionsButton.IsEnabled = true;
            mainWindow.saveOptionsButton.IsEnabled = true;
            mainWindow.returnOptionsButton.IsEnabled = true;
        }

        public static void ShowInformation(string text)
            => MessageBox.Show(text, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        public static void ShowError(string text)
            => MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
