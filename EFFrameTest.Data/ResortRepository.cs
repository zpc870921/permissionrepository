using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data
{
    public partial class ResortRepository:RepositoryBase<Resort>,IResortRepository
    {
        public ResortRepository(IDatabaseFactory factory):base(factory){
            
        }


    }
    public partial interface IResortRepository : IRepository<Resort>
    { 
        
    }
}
