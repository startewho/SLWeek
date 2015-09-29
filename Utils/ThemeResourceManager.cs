using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SLWeek.Utils
{
 public  static class ThemeResourceManager
    {
     private static void LoadBrushDictionary(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return;
            try
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary();
                Application.LoadComponent((object)resourceDictionary, new Uri(relativePath, UriKind.RelativeOrAbsolute));
                foreach (KeyValuePair<object, object> keyValuePair in (IEnumerable<KeyValuePair<object, object>>)resourceDictionary)
                {
                   
                        ((IDictionary<object, object>)Application.Current.Resources)[keyValuePair.Key] = (object)new SolidColorBrush((Color)keyValuePair.Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private static void LoadBrushByColorDictionary(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return;
            try
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary();
                Application.LoadComponent((object)resourceDictionary, new Uri(relativePath, UriKind.RelativeOrAbsolute));
                foreach (KeyValuePair<object, object> keyValuePair in (IEnumerable<KeyValuePair<object, object>>)resourceDictionary)
                {
                    if (keyValuePair.Value is Color)
                        ((IDictionary<object, object>)Application.Current.Resources)[keyValuePair.Key] = (object)new SolidColorBrush((Color)keyValuePair.Value);
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
                    ((IDictionary<object, object>)Application.Current.Resources).TryGetValue(keyValuePair.Key, out obj);
                    SolidColorBrush solidColorBrush = obj as SolidColorBrush;
                    if (solidColorBrush != null)
                        solidColorBrush.Color=((Color)keyValuePair.Value);
                }
            }
            return true;
        }

    }
}
