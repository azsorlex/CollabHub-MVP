using Xamarin.Forms;
using Acr.UserDialogs;

namespace CollabHub.Models
{
    public class ToastNotification
    {
        public Command TapCommand { get; private set; }
        private string message;
        private int timeout;

        public ToastNotification(string message, int timeout)
        {
            TapCommand = new Command(OnTapped);
            this.message = message;
            this.timeout = timeout;
        }

        void OnTapped(object s)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(timeout);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(33, 30, 28));
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}