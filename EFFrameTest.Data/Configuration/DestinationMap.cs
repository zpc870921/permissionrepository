using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class DestinationMap : EntityTypeConfiguration<Destination>
    {
        public DestinationMap()
        {
            this.ToTable("Destination");
            this.Property(d => d.Name).IsRequired().HasMaxLength(200);
            this.Property(d => d.Photo).HasColumnType("image");

            this.HasMany(d => d.Lodgings).WithRequired(l => l.Destination);
        }
    }
}
