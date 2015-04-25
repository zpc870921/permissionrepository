using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public bool Sex { get; set; }
    }
}
