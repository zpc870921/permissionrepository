using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    /// <summary>
    /// 用户头像类
    /// </summary>
    public class PersonPhoto
    {
        [Key]
        //[ForeignKey("PhotoOf")]
        public int PersonId { get; set; }
        public byte[] Photo { get; set; }
        public string Caption { get; set; }  //标题
        public Person PhotoOf { get; set; }
    }
}
