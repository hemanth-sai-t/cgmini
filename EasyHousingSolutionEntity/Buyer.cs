using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutionEntity
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}
