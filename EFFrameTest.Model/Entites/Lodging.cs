using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class Lodging
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LodgingIdentify { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public decimal MilesFromNearestAirport { get; set; }
        
        public int DestinationIdentify { get; set; }

        [ForeignKey("DestinationIdentify")]
        public virtual Destination Destination { get; set; }
    }

    //[Table("Resorts")]
    public class Resort : Lodging {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResortIdentity { get; set; }

        public string Entertainment { get; set; }
        public string Activities { get; set; }

    }
}
