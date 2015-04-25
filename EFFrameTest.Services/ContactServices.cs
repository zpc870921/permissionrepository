using EFFrameTest2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Data;
using System.ServiceModel;
using System.Transactions;
using System.Linq.Expressions;
using EFFrameTest2.Model.Criteria;
using EFFrameTest2.Model.Utils;



namespace EFFrameTest2.Services
{
   
    public partial class ContactServices:IContact
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IContactRepostory contactRepository;
        public ContactServices(IUnitOfWork unitofwork,IContactRepostory contactRepository)
        {
            this.unitOfWork = unitofwork;
            this.contactRepository = contactRepository;
        }

        public IList<Contact> GetCustomContactList()
        {
            return this.contactRepository.GetCustomContactList();
        }

        public IList<Contact> GetContactListByProc(int contactId)
        {
            return this.contactRepository.GetContactListByProc(contactId);
        }

        public IList<Contact> OrderByTest()
        {
            return this.contactRepository.OrderByTest();
        }

        public int QueryLocal()
        {
            return this.contactRepository.QueryLocal();
        }


      

        public Contact FindSingleObj(int id)
        {
            return this.contactRepository.FindSingleObj(id);
        }

       [OperationBehavior(TransactionScopeRequired = true)]
        public int InsertContact(Contact contact)
        {
            var currentTran = Transaction.Current;


            this.contactRepository.Add(contact);
            this.unitOfWork.Commit();
            
            return contact.ContactId;
        }

       public IList<Contact> ContactPaging(Pagination pageInfo, ContactCriteria criteria)
       {
           return this.contactRepository.ContactPaging(pageInfo, criteria);
       }


        public IEnumerable<Contact> GetList()
        {
            return this.contactRepository.GetAll();
        }
    }
}
