using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace MobileApp.Helpers
{
    public static class Toast
    {
        public static void Show(string message, MessageType type)
        {
            Color messageColor;

            switch (type)
            {
                case MessageType.Danger:
                    messageColor = Color.Red;
                    break;
                case MessageType.Primary:
                    messageColor = Color.Blue;
                    break;
                case MessageType.Success:
                    messageColor = Color.Green;
                    break;
                case MessageType.Warning:
                    messageColor = Color.Yellow;
                    break;
                default:
                    messageColor = Color.Black;
                    break;
            }

            SnackBarOptions options = new SnackBarOptions
            {
                MessageOptions = new MessageOptions
                {
                    Foreground = Color.White,
                    Message = message,
                    Padding = 15,
                },
                BackgroundColor = messageColor,
                Duration = TimeSpan.FromSeconds(8),
                CornerRadius = 0,
            };

            Application.Current.MainPage.DisplaySnackBarAsync(options);
        }
    }

    public enum MessageType
    {
        Primary,
        Success,
        Warning,
        Danger
    }
}
