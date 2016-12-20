using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProduktVerwaltungTrippleLayer
{
    public class Product
    {
        public int ID { get; set; }
        public string sLabel { get; set; }
        public double dPrice { get; set; }
        public string sTyp { get; set; }

        public Product(){ }
        public Product(string label, double price)
        {
            this.sLabel = label;
            this.dPrice = price;
        }
    }
}
