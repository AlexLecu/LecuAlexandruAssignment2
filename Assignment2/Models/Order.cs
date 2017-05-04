using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ShippingAddress { get; set; }
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
