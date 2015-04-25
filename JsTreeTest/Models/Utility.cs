using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Reflection;
using System.ComponentModel;
using EFFrameTest2.Model;

namespace JsTreeTest.Models
{
    public static class Utility
    {

        public static IPermission PermissionSvc
        {
            get
            {
                var factory = new ChannelFactory<IPermission>("basicHttpBinding_IPermission");
                return factory.CreateChannel();
            }
        }

        /// <summary>
        /// 获取对象的自定义说明...
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(this object obj)
        {

            Type type = obj.GetType();
            string key = String.Concat(type.Namespace, type.FullName, obj.ToString());

                FieldInfo field = type.GetField(obj.ToString());
                if (field == null)
                {
                    return null;
                }
                var desc = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                if (desc == null)
                {
                    return null;
                }
                return ((DescriptionAttribute)desc).Description;
           
        }

        public static IDictionary<int, string> EnumToDict(this Type type)
        {
            if (type == null)
            {
                return null;
            }
            
                var enums =System.Enum.GetValues(type);
                IDictionary<int, string> dict = new Dictionary<int, string>();
                foreach (var item in enums)
                {
                    string desc = item.GetDescription();
                    if (String.IsNullOrEmpty(desc))
                    {
                        continue;
                    }
                    dict.Add((int)item, desc);
                }
                return dict;
        }
        //public static Dictionary<int, string> EnumToDict(Type type)
        //{
        //    if (type == null)
        //    {
        //        return null;
        //    }
        //    var enums = System.Enum.GetValues(type);
        //    Dictionary<int, string> dict = new Dictionary<int, string>();
        //    foreach (var item in enums)
        //    {
        //        dict.Add((int)item, item.GetDescription());
        //    }
        //    return dict;
        //}

        public static T ConvertTo<T>(this string str)
        {
            if (String.IsNullOrWhiteSpace(str)) {
                return default(T);
            }
            str = str.Trim();
            try
            {
               return (T)Convert.ChangeType(str, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static T ConvertTo<T>(this string str,T defaultValue)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return defaultValue;
            }
            try
            {
                str = str.Trim();
                return (T)Convert.ChangeType(str, typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}