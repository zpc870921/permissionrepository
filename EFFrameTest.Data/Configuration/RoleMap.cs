using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            //this.ToTable("Role");
            //this.HasKey(r => r.RoleID);
            //this.Property(r => r.RoleName).IsRequired().HasMaxLength(50);

           // this.HasMany(r => r.Users).WithMany(u => u.Roles).Map(t => t.MapLeftKey("UserID").MapRightKey("RoleID"));
        }
    }
}
