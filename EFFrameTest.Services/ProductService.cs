using EFFrameTest2.Data;
using EFFrameTest2.Model;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Services
{
    public class ProductService:IProduct
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IProductRepository productRepository;
        public ProductService(IUnitOfWork unitofwork,IProductRepository productRepository)
        {
            this.unitOfWork = unitofwork;
            this.productRepository = productRepository;
        }

        public int Addproduct(Product model)
        {
            this.productRepository.Add(model);
            this.unitOfWork.Commit();
            return model.ProductID;
        }

        public IList<Product> GetProductByCate(int cate)
        {
            return this.productRepository.GetMany(p => p.CategoryId == cate).ToList();
        }
    }
}
