using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class Destination
    {
        public Destination()
        {
            this.Lodgings = new List<Lodging>();
        }
        public int DestinationId { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Country { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }
        //[Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public virtual ICollection<Lodging> Lodgings { get; set; }
    }
}
