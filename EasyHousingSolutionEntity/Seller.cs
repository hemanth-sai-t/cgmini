using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutionEntity
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string EmailId { get; set; }

    }
}
