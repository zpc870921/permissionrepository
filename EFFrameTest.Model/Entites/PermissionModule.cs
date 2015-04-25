using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Mapping;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFFrameTest2.Model.Entites
{
    [DataContract]
    public class PermissionModule
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Target { get; set; }

        [DataMember]
        public int IsMenu { get; set; }

        [DataMember]
        public int OrderVal { get; set; }

        [DataMember]
        public int Type { get; set;}

        [DataMember]
        public int MaxLeavel { get; set; }

        [DataMember]
        public string Attributes { get; set; }

        [DataMember]
        public string OptCode { get; set; }

        [DataMember]
        public int ParentId { get; set; }

        [DataMember]
        public string ChildNodes { get; set; }

       
    }
}
