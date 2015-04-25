using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model
{
    public interface ILodging
    {
        int InserLodging(Lodging model);
        Destination GetSingle(int id);
    }

    public interface IResort {
        int InsertResort(Resort model);
    }
}
