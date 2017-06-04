using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TerminalCOM_IWSK.Extensions
{
    internal static class TerminalExtensions
    {
        public static void AddColorText(this RichTextBox richTextBox, string text, Brush brush)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
            textRange.Text = text;
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
        }

        public static void ChangeStatusOfConnection(this MainWindow mainWindow, Color color, string labelText)
        {
            mainWindow.border.BorderBrush = new SolidColorBrush(color);
            mainWindow.border.Background = new SolidColorBrush(color);
            mainWindow.connectionLabel.Content = labelText;
        }
    }
}
