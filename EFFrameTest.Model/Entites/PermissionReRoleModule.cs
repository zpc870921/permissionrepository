using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    [DataContract]
    public class PermissionReRoleModule
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public int FuncCode { get; set; }

        [DataMember]
        public int OptScope { get; set; }
    }
}
