using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace JsTreeTest.Models.Enum
{
    [DataContract]
    public enum PageOperation
    {
        [DataMember]
        [Description("开放")]
        Open=0,
        [DataMember]
        [Description("浏览")]
        View=1,
        [DataMember]
        [Description("添加")]
        Add=2,
        [DataMember]
        [Description("修改")]
        Update=3,
        [DataMember]
        [Description("删除")]
        Delete=4,
        [DataMember]
        [Description("查询")]
        Query=5,
        [DataMember]
        [Description("创建供应商")]
        CreateSupplier=6
    }
}