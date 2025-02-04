﻿using Xamarin.Forms;
using Acr.UserDialogs;

namespace CollabHub.Models.GlobalUtilities
{
    public class ToastNotification
    {
        private readonly string message;
        private readonly int timeout;

        public ToastNotification(string message, int timeout)
        {
            this.message = message;
            this.timeout = timeout;
        }

        public void Show()
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(timeout);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(33, 30, 28));
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}