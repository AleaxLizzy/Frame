using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Util
{
    public static class ObjectExtension
    {
        public static T GetAttributeOfEnum<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var menInfo = type.GetMember(enumVal.ToString());
            var attribute = menInfo[0].GetCustomAttributes(typeof(T), false);
            return (attribute.Length > 0) ? (T)attribute[0] : null;
        }

        #region 基础对象扩展

        #region string

        /// <summary>
        ///     对象转换为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>当对象为null或DBNull时返回空字符串</returns>
        public static string ToStr(this object obj)
        {
            return (obj == null || obj == DBNull.Value) ? "" : obj.ToString();
        }

        /// <summary>
        ///     对象转换为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">当对象为null或DBNull时的默认值</param>
        /// <returns></returns>
        public static string ToStr(this object obj, string defaultValue)
        {
            return (obj == null || obj == DBNull.Value) ? defaultValue : obj.ToString();
        }

        #endregion

        #region int

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>对象为空null或DBNull返回0</returns>
        public static byte ToByte(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0;
            byte val = 0;
            byte.TryParse(obj.ToString(), out val);
            return val;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>对象为空null或DBNull返回0</returns>
        public static int ToInt(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0;
            var val = 0;
            int.TryParse(obj.ToString(), out val);
            return val;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns>对象为空null或DBNull返回默认值</returns>
        public static int ToInt(this object obj, int defaultValue)
        {
            var val = 0;
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            int.TryParse(obj.ToString(), out val);
            return val;
        }

        //public static string GetEnumDisplay<TEnum>(this Int32 value)
        //{
        //    string showName = "";
        //    var type = typeof(TEnum);
        //    FieldInfo[] fields = type.GetFields();
        //    var item = "";
        //    foreach (var field in fields)
        //    {
        //        int val = Convert.ToInt32(field);
        //        if (val == value)
        //        {
        //            item = field.ToString();
        //            break;
        //        }
        //    }
        //    var menInfo = type.GetMember(item);

        //    var attributes = menInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
        //    DisplayAttribute attribute = (attributes.Length > 0) ? (DisplayAttribute)attributes[0] : null;
        //    showName = attribute.Name;
        //    return showName;
        //}

        #endregion

        #region int64

        public static long ToInt64(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0;
            long val = 0;
            long.TryParse(obj.ToString(), out val);
            return val;
        }

        public static long ToInt64(this object obj, long defaultValue)
        {
            long val = 0;
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            long.TryParse(obj.ToString(), out val);
            return val;
        }

        #endregion

        #region decimal

        public static decimal ToDecimal(this object obj)
        {
            decimal val = 0;
            if (obj != null && obj != DBNull.Value)
                decimal.TryParse(obj.ToString(), out val);
            return val;
        }

        public static decimal ToDecimal(this object obj, decimal defaultValue)
        {
            decimal val = 0;
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            decimal.TryParse(obj.ToString(), out val);
            return val;
        }

        #endregion

        #region Float

        public static float ToFloat(this object obj)
        {
            float val = 0;
            if (obj != null && obj != DBNull.Value)
                float.TryParse(obj.ToString(), out val);
            return val;
        }

        public static float ToFloat(this object obj, float defaultValue)
        {
            float val = 0;
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            float.TryParse(obj.ToString(), out val);
            return val;
        }

        #endregion

        #region Double

        public static double ToDouble(this object obj)
        {
            double val = 0;
            if (obj != null && obj != DBNull.Value)
                double.TryParse(obj.ToString(), out val);
            return val;
        }

        public static double ToDouble(this object obj, double defaultValue)
        {
            double val = 0;
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            double.TryParse(obj.ToString(), out val);
            return val;
        }

        #endregion

        #region Datetime

        public static bool ToBool(this object obj)
        {
            var val = false;
            if (obj != null && obj != DBNull.Value)
                bool.TryParse(obj.ToString(), out val);
            return val;
        }

        public static DateTime ToDate(this object obj)
        {
            var val = DateTime.Parse("1900-01-01 00:00:00");
            if (obj != null && obj != DBNull.Value)
                DateTime.TryParse(obj.ToString(), out val);
            return val;
        }

        public static DateTime ToDate(this object obj, DateTime defaultValue)
        {
            var val = DateTime.Parse("1900-01-01 00:00:00");
            if (obj == null || obj == DBNull.Value)
                return defaultValue;
            DateTime.TryParse(obj.ToString(), out val);
            return val;
        }

        public static string ToDateFormat(this object obj, string format)
        {
            var val = DateTime.Parse("1900-01-01 00:00:00");
            if (obj != null && obj != DBNull.Value)
                DateTime.TryParse(obj.ToString(), out val);
            return val.ToString(format);
        }

        /// <summary>
        ///     扩展日期类 孟高原 2014-12-17 (扩展，当obj为空时，则返回空字符串)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateFormatString(this object obj, string format)
        {
            var val = DateTime.Parse("1900-01-01 00:00:00");
            if (obj != null && obj != DBNull.Value)
                DateTime.TryParse(obj.ToString(), out val);
            var result = obj == null ? "" : val.ToString(format);
            return result;
        }

        public static string ToDateFormat(this object obj, DateTime defaultValue, string format)
        {
            var val = DateTime.Parse("1900-01-01 00:00:00");
            if (obj != null && obj != DBNull.Value)
                return defaultValue.ToString(format);
            DateTime.TryParse(obj.ToString(), out val);
            return val.ToString(format);
        }

        public static string ToChineseWeek(this DayOfWeek week)
        {
            var val = "";
            switch (week.ToString())
            {
                case "Monday":
                    val = "星期一";
                    break;
                case "Tuesday":
                    val = "星期二";
                    break;
                case "Wednesday":
                    val = "星期三";
                    break;
                case "Thursday":
                    val = "星期四";
                    break;
                case "Friday":
                    val = "星期五";
                    break;
                case "Saturday":
                    val = "星期六";
                    break;
                case "Sun":
                    val = "星期天";
                    break;
            }
            return val;
        }

        /// <summary>
        ///     日期转为13位数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToTicksInt64(this DateTime obj)
        {
            long val = 0;
            if (obj != null && obj != DateTime.MinValue)
                val = (obj.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000;
            return val;
        }

        public static long ToTicksInt64(this DateTime? obj)
        {
            long val = 0;
            if (obj != null && obj != DateTime.MinValue)
                val = (((DateTime)obj).Ticks - new DateTime(1970, 1, 1).Ticks) / 10000;
            return val;
        }

        #endregion

        #region Enum

        /// <summary>
        ///     将string转换为Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">多值使用英文逗号分隔</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        #endregion

        #endregion

        #region 将对象数组链接为字符串

        /// <summary>
        ///     将对象数组拼接成字符串
        /// </summary>
        /// <param name="array"></param>
        /// <param name="separator">分隔符,</param>
        /// <returns>1,2,3</returns>
        public static string ToJoin(this IEnumerable<object> array, string separator)
        {
            return array.ToJoin(separator, "");
        }

        /// <summary>
        ///     将对象数组拼接成字符串
        /// </summary>
        /// <param name="array"></param>
        /// <param name="separator">分隔符,或','</param>
        /// <param name="wrapper">单包裹字符如'</param>
        /// <returns>'1','2','3'</returns>
        public static string ToJoin(this IEnumerable<object> array, string separator, string wrapper)
        {
            return array.ToJoin(separator, wrapper, wrapper);
        }

        /// <summary>
        ///     将对象数组拼接成字符串
        /// </summary>
        /// <param name="array"></param>
        /// <param name="separator"></param>
        /// <param name="leftWrapper">左包裹字符{</param>
        /// <param name="rightWrapper">右包裹字符}</param>
        /// <returns>(1,2,3)</returns>
        public static string ToJoin(this IEnumerable<object> array, string separator, string leftWrapper,
            string rightWrapper)
        {
            var join = string.Join(separator, array);
            join = string.Format("{0}{1}{2}", leftWrapper, join, rightWrapper);
            return join;
        }

        #endregion

        #region JSON

        /// <summary>
        ///     对象转换为JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new IsoDateTimeConverter
                    {
                        Culture = CultureInfo.CurrentCulture
                    }
                }
            });
        }

        /// <summary>
        ///     JSON转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        #endregion JSON
    }

}
