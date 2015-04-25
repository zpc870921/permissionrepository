using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Configuration
{
    public class BlogConfiguration:EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            this.HasKey(b => b.BlogId);
            this.Property(b => b.BlogId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(b => b.Name).HasMaxLength(50).IsRequired();
            this.Property(b => b.Url).HasMaxLength(100).IsRequired();

            this.MapToStoredProcedures(s => {
                s.Insert(b => { 
                    b.HasName("Insert_Blog");
                   // b.Parameter(p => p.BlogId, "Blog_Id");
                    b.Parameter(p=>p.Name,"Blog_Name");
                    b.Parameter(p=>p.Url,"Blog_Url");
                    b.Result(p => p.BlogId, "generated_blog_identity");
                });
                s.Update(b =>{
                    b.HasName("Update_Blog");
                    b.Parameter(p=>p.BlogId,"Blog_Id");
                    b.Parameter(p => p.Name, "Blog_Name");
                    b.Parameter(p => p.Url, "Blog_Url");
                });
                s.Delete(b => {
                    b.HasName("Delete_Blog");
                    b.Parameter(p => p.BlogId, "Blog_Id");
                });
            });
        }
    }
}
