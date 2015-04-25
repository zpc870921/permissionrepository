using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace EFFrameTest2.Model.Utils
{
    public static class Extension
    {
        public static string GetDescription(this object obj)
        {
            //return null;
            Type type = obj.GetType();
            var filedinfo = type.GetField(obj.ToString());
            if (null == filedinfo) {
                return null;
            }
            var desc = filedinfo.GetCustomAttributes(typeof(DescriptionAttribute),false).FirstOrDefault();
            if (null == desc) {
                return null;
            }
            return ((DescriptionAttribute)desc).Description;
        }
        public static IDictionary<int,string> EnumToDict(this Type type)
        {
            var arr= System.Enum.GetValues(type);
            IDictionary<int, string> dict = new Dictionary<int, string>();
            foreach (var item in arr)
            {
                var desc = item.GetDescription();
                if (String.IsNullOrEmpty(desc)) {
                    continue;
                }
                dict.Add((int)item,desc);
            }
            return dict;
        }
    }
}
