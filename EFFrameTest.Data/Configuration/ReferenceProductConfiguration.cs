using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class ReferenceProductConfiguration:EntityTypeConfiguration<ReferenceProduct>
    {
        public ReferenceProductConfiguration()
        {
            this.HasKey(p => p.Id);
            this.HasRequired(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);
        }
    }   
}
