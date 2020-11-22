using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace FileSync
{
    class JsonHelper
    {

        private static object GetTypeValue(string value, Type colType)
        {

            if (colType == typeof(Int32))
            {
                int result = 0;
                if (string.IsNullOrEmpty(value))
                {
                    result = 0;
                }
                else
                {
                    int.TryParse(value, out result);
                }
                return result;
            }
            if (colType == typeof(Int64))
            {
                int result = 0;
                if (string.IsNullOrEmpty(value))
                {
                    result = 0;
                }
                else
                {
                    int.TryParse(value, out result);
                }
                return result;
            }
            if (colType == typeof(String))
                return string.IsNullOrEmpty(value) ? string.Empty : value;
            if (colType == typeof(DateTime))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return DateTime.Now;
                }
                else
                {
                    DateTime time = DateTime.Now;
                    DateTime.TryParse(value, out time);
                    return time;
                }
            }
            if (colType == typeof(Boolean))
                return string.IsNullOrEmpty(value) ? false : Convert.ToBoolean(value);
            if (colType == typeof(Guid))
                return string.IsNullOrEmpty(value) ? Guid.Empty : Guid.Parse(value);
            if (colType == typeof(Int16))
            {
                int result = 0;
                if (string.IsNullOrEmpty(value))
                {
                    result = 0;
                }
                else
                {
                    int.TryParse(value, out result);
                }
                return result;
            }
            if (colType == typeof(float))
            {
                float result = 0;
                if (string.IsNullOrEmpty(value))
                {
                    result = 0;
                }
                else
                {
                    float.TryParse(value, out result);
                }
                return result;
            }
            return string.IsNullOrEmpty(value) ? null : value;
        }
        public static T JokenToEntity<T>(JToken joten)
        {
            Type t = typeof(T);
            T entity = (T)Activator.CreateInstance(t);
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {
                if (joten[p.Name] != null)
                {
                    string value = joten[p.Name].ToString();
                    object obj = GetTypeValue(value, p.PropertyType);
                    p.SetValue(entity, obj, null);
                }
            }
            return entity;
        }
        public static List<T> JsonConverToList<T>(string json)
        {
            List<T> list = new List<T>();
            JArray groupjarray = (JArray)JsonConvert.DeserializeObject(json);
            foreach (JToken joten in groupjarray)
            {
                T t = JokenToEntity<T>(joten);
                list.Add(t);
            }
            return list;
        }
    }
    class Base64Helper
    {

        public static string Base64Dncode(string source)
        {
            return Base64Dncode(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式</param>
        /// <param name="source">待解密的密文</param>
        /// <returns></returns>
        public static string Base64Dncode(Encoding encodeType, string source)
        {
            string dncode = string.Empty;
            byte[] bytes = Convert.FromBase64String(source);
            try
            {
                dncode = encodeType.GetString(bytes);
            }
            catch
            {
                dncode = source;
            }
            return dncode;

        }
        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;

        }


    }
}
