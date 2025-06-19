using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Services
{
    internal class UserPreferencesService
    {
        public static void Save(string key, string value) =>
        Preferences.Set(key, value);
        public static void Save(string key, bool value) =>
            Preferences.Set(key, value);
        public static void Save(string key, int value) =>
            Preferences.Set(key, value);
        public static string Get(string key, string defaultValue = "") =>
            Preferences.Get(key, defaultValue);
        public static bool Get(string key, bool defaultValue = false) =>
            Preferences.Get(key, defaultValue);
        public static int Get(string key, int defaultValue = 0) =>
            Preferences.Get(key, defaultValue);
        public static void Remove(string key) =>
            Preferences.Remove(key);
        public static void ClearAllExcept(Dictionary<string, Type> keysToKeep)
        {
            var preserved = new Dictionary<string, object>();

            foreach (var kvp in keysToKeep)
            {
                var key = kvp.Key;
                var type = kvp.Value;

                if (!Preferences.ContainsKey(key)) continue;

                if (type == typeof(string))
                    preserved[key] = Preferences.Get(key, string.Empty);
                else if (type == typeof(int))
                    preserved[key] = Preferences.Get(key, 0);
                else if (type == typeof(bool))
                    preserved[key] = Preferences.Get(key, false);
            }

            Preferences.Clear();

            foreach (var kvp in preserved)
            {
                if (kvp.Value is string strVal)
                    Preferences.Set(kvp.Key, strVal);
                else if (kvp.Value is int intVal)
                    Preferences.Set(kvp.Key, intVal);
                else if (kvp.Value is bool boolVal)
                    Preferences.Set(kvp.Key, boolVal);
            }
        }
    }
}
