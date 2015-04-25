using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFFrameTest2.Data.Configuration
{
    public class ResortMap : EntityTypeConfiguration<Resort>
    {
        public ResortMap()
        {
            this.Property(p => p.LodgingIdentify).HasColumnName("LodgingIdentify");
            this.Property(p => p.MilesFromNearestAirport).HasColumnName("MilesFromNearestAirport");
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.Owner).HasColumnName("Owner");
            this.Property(p => p.DestinationIdentify).HasColumnName("DestinationIdentify");
            this.Property(p => p.Entertainment).HasColumnName("Entertainment");
            this.Property(p => p.Activities).HasColumnName("Activities");
            //this.ToTable("Resort");
        }
    }
    public class LodgingMap:EntityTypeConfiguration<Lodging>
    {
        public LodgingMap()
        {
            #region ef默认继承映射tph  父类、子类在一张表里

            //this.ToTable("Lodging");
            this.Property(l => l.Name).IsRequired().HasMaxLength(200);
            this.Property(l => l.MilesFromNearestAirport).HasPrecision(18, 2);
            this.HasRequired(l => l.Destination).WithMany(d => d.Lodgings).HasForeignKey(d=>d.DestinationIdentify);

            //this.Map<Lodging>(l => { l.Requires("From").HasValue("Standard"); });
            //this.Map<Resort>(l => { l.Requires("From").HasValue("Resort"); });
            #endregion

            #region tpt 模式  父类、子类在不同表里 ,子类表中包含父类的id做主键，同时也是外键，子类通过该字段找到父类
            //this.Map(m =>
            //{
            //    m.ToTable("Lodging");
            //}).Map<Resort>(m => {
            //    m.ToTable("Resort");
            //});
            #endregion

            #region tpc  每个子类表中包含从父类继承的属性、同时包含自己独有的属性
            //this.Map(m =>
            //{
            //    m.ToTable("Lodging");
            //}).Map<Resort>(m => {
            //    m.ToTable("Resort");
            //    m.MapInheritedProperties();
            //});
            #endregion
        }
    }
}
