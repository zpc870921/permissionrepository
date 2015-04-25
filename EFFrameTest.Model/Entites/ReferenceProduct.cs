using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class ReferenceProduct
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public ProductNM Product { get; set; }
    }
}
