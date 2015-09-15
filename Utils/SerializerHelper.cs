using Newtonsoft.Json;

namespace SLWeek.Utils
{
   public  class SerializerHelper
    {

       public static string ToJson<T>(T obj)
       {
           return JsonConvert.SerializeObject(obj);
       }


       public static T FromJson<T>(string toString)
       {
           return JsonConvert.DeserializeObject<T>(toString);
       }
    }
}
