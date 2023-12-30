using System.Windows.Forms;
namespace Base.Helpers
{
    public static class MessageHelper
    {
        public static void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string message, string title = "Question")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // Puedes agregar más métodos según tus necesidades

        // Ejemplo de método para mostrar un mensaje personalizado con botones personalizados
        public static DialogResult ShowCustomMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }
    }
}
