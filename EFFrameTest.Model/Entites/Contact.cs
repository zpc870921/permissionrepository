using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFFrameTest2.Model.Entites
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        [MaxLength(10)]
        [Required]
        [StringLength(10,ErrorMessage="")]
        //[Column("UserName")]
        public string Name { get; set; }
        [DataMember]
        [Range(1,150)]
        public int Age { get; set; }

        [DataMember]
        [MaxLength(100)]
        [StringLength(100)]
        public string Address { get; set; }
        [DataMember]
        [MaxLength(13)]
        [StringLength(13)]
        public string Mobile { get; set; }
        [DataMember]
        public bool Sex { get; set; }

        [DataMember]
        public string Rating { get; set; }

        [DataMember]
        public string remark { get; set; }

        [NotMapped]
        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        [DisplayName("Grade")]
        [StringLength(20)]
        [DataMember]
        public string Grade { get; set; }
    }
}
