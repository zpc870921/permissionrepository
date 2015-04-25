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
    public class LodgingService:ILodging
    {
        protected IUnitOfWork unitOfWork;
        public ILodgingRepository lodgingRepository;
        
        public LodgingService(IUnitOfWork unitOfWork,ILodgingRepository lodgingRepository)
        {
            this.unitOfWork = unitOfWork;
            this.lodgingRepository = lodgingRepository;
        }

        public int InserLodging(Model.Entites.Lodging model)
        {
            this.lodgingRepository.Add(model);
            this.unitOfWork.Commit();
            return model.LodgingIdentify;
        }

        public Destination GetSingle(int id)
        {
            return this.lodgingRepository.GetSingle(id);
        }
    }

    public class ResortService : IResort
    {
        protected IUnitOfWork unitOfWork;
        protected IResortRepository resortRepository;
        public ResortService(IUnitOfWork unitOfWork,IResortRepository resortRepository)
        {
            this.unitOfWork = unitOfWork;
            this.resortRepository = resortRepository;
        }

        public int InsertResort(Model.Entites.Resort model)
        {
            this.resortRepository.Add(model);
            return model.LodgingIdentify;
        }
    }
}
