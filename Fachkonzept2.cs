using System;
using System.Collections.Generic;


namespace ProduktVerwaltungTrippleLayer
{
    class Fachkonzept2 : IFachkonzept
    {
        public Fachkonzept2(IDatenhaltung datenhaltung) : base(datenhaltung)
        {
            if (this.Datenhaltung == null)
            {
                //initsialize and test new
            }
        }

        public override Customer GetCustomer(int customerId)
        {
            return this.Datenhaltung.GetCustomer(customerId);
        }

        public override void AddCostomer(Customer c)
        {
            this.Datenhaltung.AddCostomer(c);
        }

        public override void DeleteCustomer(int customerID)
        {
            this.Datenhaltung.DeleteCustomer(customerID);
        }

        public override void EditCustomer(Customer c)
        {            
            this.Datenhaltung.EditCustomer(c);
        }

        public override Product GetProduct(int productId)
        {
            return this.Datenhaltung.GetProduct(productId);
        }

        public override void AddProduct(Product product)
        {
            this.Datenhaltung.AddProduct(product);
        }

        public override void DeleteProduct(int productId)
        {
            this.DeleteProduct(productId);
        }

        public override void EditProduct(Product product)
        {
            this.EditProduct(product);
        }

        public override void AddOrder(Customer c, Product p, int amount, DateTime Date)
        {
            this.AddOrder(c, p, amount, Date);
        }

        public override List<Customer> ListCustomers()
        {
            return this.Datenhaltung.ListCustomers();
        }

        public override List<Product> ListProducts()
        {
            return this.Datenhaltung.ListProducts();
        }

        public override List<Order> ListOrders()
        {
            return this.Datenhaltung.ListOrders();
        }
    }
}
