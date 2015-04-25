using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EFFrameTest2.Model.Enum
{
    
    [Flags]
    public enum PrdoductStatus
    {
        [Description("无")]
        Null=0x00,
        [Description("正常")]
        Normal=0x01,
        [Description("隐藏")]
        Hided=Normal<<1,
        [Description("删除")]
        Deleted=Hided<<1
    }
}
