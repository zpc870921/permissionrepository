using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Criteria
{
    [DataContract]
    public class ContactCriteria
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
    }
}
