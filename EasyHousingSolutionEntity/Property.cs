using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutionEntity
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal PriceRange { get; set; }
        public decimal InitialDeposit { get; set; }
        public string Landmark { get; set; }
        public string IsActive { get; set; }
        public int SellerId { get; set; }
    }

}
