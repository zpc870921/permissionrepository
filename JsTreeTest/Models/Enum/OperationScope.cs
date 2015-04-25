using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JsTreeTest.Models.Enum
{
    [DataContract]
    public enum OperationScope
    {
        [EnumMember]
        [Description("无")]
        Null=0,
        [EnumMember]
        [Description("全部")]
        All=1,
        [EnumMember]
        [Description("部门")]
        Company=2,
        [EnumMember]
        [Description("自己")]
        Self=4
    }
}