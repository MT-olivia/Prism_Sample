using System.Windows;

namespace Prism_Sample.Services
{
    public interface IMessageService
    {
        void ShowDialog(string message);
        MessageBoxResult Question(string message);
    }
}
