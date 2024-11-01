using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.OrderService.Dto
{
    public class OrderItemDto
    {
        public int ProudctId { get; set; }
        public string ProudctName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }

    }
}
