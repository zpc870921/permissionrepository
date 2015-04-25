using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("dbo.Category");
            this.HasKey(c => c.CategoryID);
            this.Property(c => c.CategoryName).IsRequired().HasMaxLength(15);
            this.Property(c => c.CategoryID).HasColumnName("CategoryID");
            this.Property(c => c.Picture).HasColumnType("image");

            //this.HasMany(c => c.Products).WithRequired(p => p.Category);
        }
    }
}
