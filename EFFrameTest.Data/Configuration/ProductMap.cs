using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(p => p.ProductID);
            this.Property(p => p.ProductName).IsRequired().HasMaxLength(15);
            this.Property(p => p.UnitPrice).HasPrecision(18, 2);
            

            this.HasRequired(p => p.Category).WithMany(c => c.Products).HasForeignKey(c=>c.CategoryId).WillCascadeOnDelete(false);

            //this.HasRequired(p => p.Category).WithMany(c => c.Products).Map(t=>t.MapKey("CategoryID")).WillCascadeOnDelete(false);

        }
    }
}
