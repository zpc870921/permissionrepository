using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    /// <summary>
    /// 地址类（复杂类型）
    /// </summary>
    //[ComplexType]
    public class Address
    {
        //public int AddressId { get; set; }    //复杂类型不能有主键id（Key Property） 切记！
        [StringLength(100)]
        [Required]
        [MaxLength(200)]
        public string StreetAddress { get; set; }  //街道地址
        [StringLength(20)]
        [Required]
        [MaxLength(30)]
        public string City { get; set; }  //城市
        [StringLength(20)]
        public string State { get; set; }  //州
        
        [StringLength(6)]
        public string ZipCode { get; set; }  //邮编
    }
}
