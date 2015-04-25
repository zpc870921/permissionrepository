using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public User User { get; set; }

        [DataMember]
        public IList<UserReRole> RoleList { get; set; }
    }
}
