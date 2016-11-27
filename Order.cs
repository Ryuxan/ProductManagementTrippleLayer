using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProduktVerwaltungTrippleLayer
{
    public class Order
    {
        public int ID { get; set; }
        public Product Product;
        public Customer Customer;
        public int iAmount;
        public DateTime OrderDate;
    }
}
