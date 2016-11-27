using System;
using System.Collections.Generic;


namespace ProduktVerwaltungTrippleLayer
{
    public class Fachkonzept2 : IFachkonzept
    {
        public Fachkonzept2(IDatenhaltung datenhaltung)
            : base(datenhaltung)
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

        public override int AddCostomer(Customer c)
        {
            return this.Datenhaltung.AddCostomer(c);
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

        public override int AddProduct(Product product)
        {
            return this.Datenhaltung.AddProduct(product);
        }

        public override void DeleteProduct(int productId)
        {
            this.Datenhaltung.DeleteProduct(productId);
        }

        public override void EditProduct(Product product)
        {
            this.Datenhaltung.EditProduct(product);
        }

        public override int AddOrder(Order ord)
        {
            return this.Datenhaltung.AddOrder(ord);
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
