using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

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
                //depending on how you handle your may have to reset your resource manager with each call.
                var resMgr = new ResourceManager($"DynamicLocalization.Resources.{Settings.Culture}", typeof(DynamicLocalizer).GetTypeInfo().Assembly);
                var value = resMgr.GetString(text) ?? string.Empty;
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);   
            }

            return String.Empty;
            //consider a default or a handler for empty strings
        }
    }
}
