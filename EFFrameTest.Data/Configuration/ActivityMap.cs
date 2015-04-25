using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class ActivityMap : EntityTypeConfiguration<Activity>
    {
        public ActivityMap()
        {
            this.HasMany(a => a.Trips).WithMany(t => t.Activitys).Map(t => t.ToTable("TripActivities").MapLeftKey("ActivityId").MapRightKey("TripIdenfied"));
        }
    }
}
