using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Util.JsonExtension
{
    public static class Json
    {
        public static T Deserialize<T>(byte[] value)
        {
            try
            {
                if (value == null)
                {
                    return default(T);
                }
                var jsonString = Encoding.UTF8.GetString(value);
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static byte[] Serialize(this object value)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                var jsonString = JsonConvert.SerializeObject(value);
                return Encoding.UTF8.GetBytes(jsonString);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string SerializeToJsonString(this object value)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                return JsonConvert.SerializeObject(value);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }

}
