using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TerminalCOM_IWSK.Extensions
{
    internal static class TerminalExtensions
    {
        public static void AddColorText(this RichTextBox richTextBox, string text, Brush brush)
        {
            richTextBox.Dispatcher.Invoke(() =>
            {
                TextRange textRange = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
                textRange.Text = $"{text}";
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
                richTextBox.AppendText("\r");
            });
        }

        public static void InitializeRichTextBox(this MainWindow mainWindow)
            => mainWindow.textBox.Document.Blocks.Clear();

        public static void ChangeStatusOfConnection(this MainWindow mainWindow, Color color, string labelText)
        {
            mainWindow.border.BorderBrush = new SolidColorBrush(color);
            mainWindow.border.Background = new SolidColorBrush(color);
            mainWindow.connectionLabel.Content = labelText;
        }

        public static void InitializeButtons(this MainWindow mainWindow)
        {
            mainWindow.sentButton.IsEnabled = false;
            mainWindow.disconnectButton.IsEnabled = false;
            mainWindow.connectButton.IsEnabled = true;
        }

        public static void EnableAfterConnection(this MainWindow mainWindow)
        {
            mainWindow.sentButton.IsEnabled = true;
            mainWindow.disconnectButton.IsEnabled = true;
            mainWindow.connectButton.IsEnabled = false;
        }

        public static void EnableAfterDisconnection(this MainWindow mainWindow)
        {
            mainWindow.sentButton.IsEnabled = false;
            mainWindow.disconnectButton.IsEnabled = false;
            mainWindow.connectButton.IsEnabled = true;
        }
    }
}
