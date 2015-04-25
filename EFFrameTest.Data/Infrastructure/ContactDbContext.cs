using EFFrameTest2.Data.Configuration;
using EFFrameTest2.Data.Migrations;
using EFFrameTest2.Model.Entites;
//using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace EFFrameTest2.Data.Infrastructure
{
    public class ContactDbContext :DbContext 
    {
        
        public ContactDbContext()
            : base("ContactStore")
        {
            //修改模型，重设数据库，并初始化数据
            //关闭初始化
            Database.SetInitializer<ContactDbContext>(null);
           // Database.SetInitializer<ContactDbContext>(new DropCreateDatabaseIfModelChanges<ContactDbContext>());
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactDbContext,Configuration>());

            //base.Configuration.LazyLoadingEnabled = true;
            //如果不加这句会给实体自动生成一些其他属性（wcf传输过程中序列化会出错）
            base.Configuration.ProxyCreationEnabled = false;
            
        }

        public virtual void Commit()
        {
            this.SaveChanges();
        }

        //public DbSet<Contact> InquirySheet { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //里继承了DbContext,这个基类和下面的DbSet<>都是用于Code First模式的，当然DataBase First也可以用。同时我们要重写OnModelCreating()方法，在这个方法里移除表名复数的契约。比如我们在这里Model叫Movie，如果不加modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();这句话，在数据库表中表名会被设置为Movies。这种情况下，就需要移除这个契约。
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 禁用一对多级联删除
           // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // 禁用多对多级联删除
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           // modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            //modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Configurations.Add(new ProductNMMap());
            //modelBuilder.Configurations.Add(new ContactConfiguration());

            #region 权限
            modelBuilder.Configurations.Add(new PermissionRoleConfigurationMap());
            modelBuilder.Configurations.Add(new PermissionModuleConfigurationMap());
            modelBuilder.Configurations.Add(new PermissionReRoleModuleConfigurationMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserReRoleMap());
            #endregion
            //modelBuilder.Configurations.Add(new ResortMap());
            //modelBuilder.Entity<Contact>().MapToStoredProcedures();
            //modelBuilder.Configurations.Add(new CategoryMap());
            //modelBuilder.Configurations.Add(new ProductMap());
            //modelBuilder.ComplexType<Address>();
            //modelBuilder.Configurations.Add(new EmployeeMap());
            //modelBuilder.Configurations.Add(new LodgingMap());
            //modelBuilder.Configurations.Add(new DestinationMap());
            //modelBuilder.Configurations.Add(new ReferenceProductConfiguration());
            //modelBuilder.Configurations.Add(new BlogConfiguration());
            //modelBuilder.Configurations.Add(new PostConfiguration());
            //modelBuilder.Configurations.Add(new ActivityMap());
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Remove)
        }
    }
}
