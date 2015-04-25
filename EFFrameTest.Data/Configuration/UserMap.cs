using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EFFrameTest2.Model.Entites;

namespace EFFrameTest2.Data.Configuration
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        //public UserMap()
        //{
        //    this.ToTable("User");
        //    this.HasKey(u => u.UserID);
        //    this.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        //    this.Property(u => u.Password).IsRequired().HasMaxLength(50);

        //    this.HasMany(u => u.Roles).WithMany(r => r.Users).Map(t => t.MapLeftKey("RoleID").MapRightKey("UserID"));

        //}
    }
}
