using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Util
{
    public class SignUtil
    {
        /// <summary>
        /// 给请求签名。
        /// </summary>
        /// <param name="parameters">所有字符型的请求参数</param>
        /// <param name="secret">签名密钥</param>
        /// <returns>签名</returns>
        public static string Sign(IDictionary<string, string> parameters, string secret)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();

            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.AppendFormat("{0}={1}&", key, value);
                }
            }
            if (query.Length > 0)
            {
                query.Remove(query.Length - 1, 1);
            }
            query.Append(secret);

            //MD5签名
            return MD5Sign(query.ToString());
        }

        /// <summary>
        /// 清除字典中值为空的项。
        /// </summary>
        /// <param name="dict">待清除的字典</param>
        /// <returns>清除后的字典</returns>
        public static IDictionary<string, T> CleanupDictionary<T>(IDictionary<string, T> dict)
        {
            IDictionary<string, T> newDict = new Dictionary<string, T>(dict.Count);
            IEnumerator<KeyValuePair<string, T>> dem = dict.GetEnumerator();

            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                T value = dem.Current.Value;
                if (value != null)
                {
                    newDict.Add(name, value);
                }
            }

            return newDict;
        }

        /// <summary>
        /// MD5签名
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Sign(string value)
        {
            // 使用MD5加密
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            // 把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }

        /// <summary>
        /// 双MD5盐值签名
        /// </summary>
        /// <param name="value"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string DoubleMD5Sign(string value, string salt)
        {
            string result = MD5Sign(value);
            result = MD5Sign(string.Concat(result, salt));
            return result;
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static string SAH256(IDictionary<string, string> parameters, string secretKey)
        {
            StringBuilder query = new StringBuilder();
            query.Append(secretKey);
            IEnumerator<KeyValuePair<string, string>> reqDataKV = parameters.GetEnumerator();
            while (reqDataKV.MoveNext())
            {
                string key = reqDataKV.Current.Key;
                string value = reqDataKV.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.AppendFormat("{0}={1}&", key, value);
                }
            }
            if (query.Length > 0)
            {
                query.Remove(query.Length - 1, 1);
            }

            //使用SHA256加密
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));

            //把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }
    }

}
