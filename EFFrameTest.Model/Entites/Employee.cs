using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        //[ConcurrencyCheck]
        public int SocialSecurityNumber { get; set; }   //社保号
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public Address address { get; set; }   //复杂类型

        public PersonPhoto Photo { get; set; }  //一对一关系
    }
}
