using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProduktVerwaltungTrippleLayer
{
    public class Customer
    {
        public int ID { get; set;}
        public string sFirstName { get; private set; }
        public string sSurName { get; private set; }
        public List<Product> lProducts;

        public Customer(string firstName, string surName)
        {
            this.sFirstName = firstName;
            this.sSurName = surName;
        }
    }
}
