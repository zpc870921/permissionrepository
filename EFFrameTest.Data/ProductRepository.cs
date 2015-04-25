using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data
{
    public partial class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
    public partial interface IProductRepository:IRepository<Product> { 
        
    }
}
