using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites.OrderEntity
{
    public class ShippingAddress
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
