using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SLWeek.Utils
{
 public  static class ThemeResourceManager
    {
     public static void LoadBrushDictionary(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return;
            try
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary();
                Application.LoadComponent(resourceDictionary, new Uri(relativePath, UriKind.RelativeOrAbsolute));
                foreach (KeyValuePair<object, object> keyValuePair in (IEnumerable<KeyValuePair<object, object>>)resourceDictionary.ToList())
                {
                    var sourcekey = Application.Current.Resources[keyValuePair.Key];
                   
                    if (sourcekey!=null)
                    {
                        Application.Current.Resources[keyValuePair.Key] = keyValuePair.Value;
                        Debug.WriteLine("Key:{0},Value:{1}", keyValuePair.Key, keyValuePair.Value);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public static void LoadBrushByColorDictionary(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return;
            try
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary();
                Application.LoadComponent(resourceDictionary, new Uri(relativePath, UriKind.RelativeOrAbsolute));
                foreach (KeyValuePair<object, object> keyValuePair in resourceDictionary)
                {
                    if (keyValuePair.Value is Color)
                        Application.Current.Resources[keyValuePair.Key] = new SolidColorBrush((Color)keyValuePair.Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }


        private static bool ChangeResourceColor(IEnumerable<KeyValuePair<object, object>> map)
        {
            if (map == null)
                return false;
            foreach (KeyValuePair<object, object> keyValuePair in map)
            {
                if (keyValuePair.Value is Color)
                {
                    object obj;
                    Application.Current.Resources.TryGetValue(keyValuePair.Key, out obj);
                    SolidColorBrush solidColorBrush = obj as SolidColorBrush;
                    if (solidColorBrush != null)
                        solidColorBrush.Color=((Color)keyValuePair.Value);
                }
            }
            return true;
        }

    }
}
