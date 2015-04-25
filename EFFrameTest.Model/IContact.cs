using EFFrameTest2.Model.Criteria;
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
    public interface IContact
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int InsertContact(Contact contact);

        [OperationContract]
        IEnumerable<Contact> GetList();

        [OperationContract]
        IList<Contact> ContactPaging(Pagination pageInfo, ContactCriteria criteria);

        [OperationContract]
        IList<Contact> GetCustomContactList();

        [OperationContract]
        IList<Contact> GetContactListByProc(int contactId);

        [OperationContract]
        IList<Contact> OrderByTest();

        [OperationContract]
        int QueryLocal();

        [OperationContract]
        Contact FindSingleObj(int id);
    }
}
