using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model
{
    [ServiceContract]
    public interface IProduct
    {
        [OperationContract]
        int Addproduct(Product model);

        [OperationContract]
        IList<Product> GetProductByCate(int cate);
    }
}
