using DynamicLocalization.Messages;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace DynamicLocalization.Utilities
{
    internal static class Settings
    {
        internal static string Culture { get; set; } = "en";

        internal static void FlipCulture()
        {
            Culture = Culture.Equals("en") ? "es" : "en";
            MessagingCenter.Send<object>(Application.Current, CultureChangedMessage.Message);
        }
    }
}
