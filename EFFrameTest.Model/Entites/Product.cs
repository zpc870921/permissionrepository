using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
 
        public class Product
        {
            /// <summary>
            /// 产品ID
            /// </summary>
            public int ProductID { get; set; }

            /// <summary>
            /// 产品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 单价
            /// </summary>
            public decimal UnitPrice { get; set; }

            /// <summary>
            /// 库存
            /// </summary>
            public int UnitsInStock { get; set; }

            /// <summary>
            /// 是否售完
            /// </summary>
            public bool Discontinued { get; set; }

            /// <summary>
            /// 分类外键
            /// </summary>
            public int CategoryId { get; set; }

            /// <summary>
            /// 产品分类
            /// </summary>
            public virtual Category Category { get; set; }
        }
    
}
