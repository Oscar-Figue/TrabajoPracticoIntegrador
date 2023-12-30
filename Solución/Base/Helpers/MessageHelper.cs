using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Base.Helpers
{


    public static class MessageHelper
    {
        private static async Task ShowMessageAsync(string message, string title, MessageBoxIcon icon, int delayInSeconds)
        {
            using (var form = new Form())
            {
                form.Size = new Size(300, 150);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = title;

                var label = new Label
                {
                    Text = message,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(20)
                };

                form.Controls.Add(label);

                var t = Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
                await t.ConfigureAwait(false);

                form.ShowDialog();
            }
        }

        public static async Task MostrarMensajeAsync(string mensaje, string titulo = "Mensaje", int duracionEnSegundos = 3)
        {
            await ShowMessageAsync(mensaje, titulo, MessageBoxIcon.Information, duracionEnSegundos);
        }

        public static async Task MostrarConfirmacionAsync(string mensaje, string titulo = "Confirmación")
        {
            var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            await Task.FromResult(result);
        }

        public static async Task MostrarErrorAsync(string mensaje, string titulo = "Error")
        {
            await ShowMessageAsync(mensaje, titulo, MessageBoxIcon.Error, 5);
        }

        public static async Task MostrarAdvertenciaAsync(string mensaje, string titulo = "Advertencia")
        {
            await ShowMessageAsync(mensaje, titulo, MessageBoxIcon.Warning, 4);
        }
    }


}
