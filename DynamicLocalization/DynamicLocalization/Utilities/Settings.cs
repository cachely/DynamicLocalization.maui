using DynamicLocalization.Messaging;

namespace DynamicLocalization.Utilities
{
    internal static class Settings
    {
        internal static string Culture { get; set; } = "en";

        internal static void FlipCulture()
        {
            Culture = Culture.Equals("en") ? "es-MX" : "en-US";
            MessagingCenter.Send<object>(Application.Current, CultureChangedMessage.Message);
        }
    }
}
