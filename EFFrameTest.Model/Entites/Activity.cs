using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class Trip {
        [Key]
        public int Identified { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Activity> Activitys { get; set; }
    }
    public class Activity
    {
        public int ActivityId { get; set; }
        //[Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }    //和Trip类是多对多关系
    }
}
