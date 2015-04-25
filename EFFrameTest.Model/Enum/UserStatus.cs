using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Enum
{
    [Flags]
    [DataContract]
    public enum UserStatus
    {
        [EnumMember]
        [Description("")]
        Null=0,
        [EnumMember]
        [Description("正常")]
        Normal=1,
        [EnumMember]
        [Description("离职")]
        Out=2,
        [EnumMember]
        [Description("冻结")]
        Freeze=4
    }
}
