using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EFFrameTest2.Model.Entites
{
   
  
        public class Category
        {
            /// <summary>
            /// 分类ID
            /// </summary>
            public int CategoryID { get; set; }

            /// <summary>
            /// 分类名称
            /// </summary>
            public string CategoryName { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 图片
            /// </summary>
            public byte[] Picture { get; set; }

            /// <summary>
            /// 产品
            /// </summary>
            public virtual ICollection<Product> Products { get; set; }
        }
    }

