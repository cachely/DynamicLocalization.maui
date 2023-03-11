using DynamicLocalization.Resources.Localization;
using System.Diagnostics;
using System.Globalization;

namespace DynamicLocalization.Utilities
{
    internal static class DynamicLocalizer
    {
        internal static string GetText(string text)
        {
            if (text == null)
                return string.Empty;

            try
            {
                var cultureInfo = new CultureInfo(Settings.Culture);
                var value = AppResources.ResourceManager.GetString(text, cultureInfo) ?? string.Empty;
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);   
            }

            return string.Empty;
            //consider a default or a handler for empty strings
        }
    }
}
