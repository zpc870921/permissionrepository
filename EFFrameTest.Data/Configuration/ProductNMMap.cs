using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFFrameTest2.Data.Configuration
{
    public class ProductNMMap:EntityTypeConfiguration<ProductNM>
    {
        public ProductNMMap()
        {
            //this.HasKey(p => p.Id);
            this.Property(p => p.AutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
