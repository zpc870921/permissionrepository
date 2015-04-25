using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class PostConfiguration:EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
           // this.HasKey(p => p.PostId);
            this.HasMany(p => p.Tags).WithMany(t => t.Posts).MapToStoredProcedures();
        }
    }
}
