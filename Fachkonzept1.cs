using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktVerwaltungTrippleLayer
{
    public class Fachkonzept1 : IFachkonzept
    {
        IDatenhaltung iD;
        public Fachkonzept1(IDatenhaltung iD)
        {
            this.iD = iD;
        }

        public override List<Customer> ListCustomers()
        {
            List<Customer> Customers = this.iD.ListCustomers();
            return Customers.OrderBy(x => x.sFirstName).OrderBy(x => x.sSurName).ToList();
        }

        public override Customer GetCustomer(int customerId)
        {
            return this.iD.GetCustomer(customerId);
        }
        public override void AddCustomer(Customer c)
        {
            this.iD.AddCostomer(c);
        }

        public override void DeleteCustomer(int customerId)
        {
            this.iD.DeleteCustomer(customerId);
        }

        public override void EditCustomer(Customer c)
        {
            this.iD.EditCustomer(c);
        }

        public List<Product> ListProducts()
        {
            List<Product> Products = this.iD.ListProducts();
            return Products.OrderBy(x=>x.dPrice).ToList();
        }

        public override Product GetProduct(int productId)
        {
            return this.iD.GetProduct(productId);
        }

        public override void AddProduct(Product product)
        {
            this.iD.AddProduct(product);
        }

        public override void DeleteProduct(int productId)
        {
            this.iD.DeleteProduct(productId);
        }

        public override void EditProduct(Product product)
        {
            this.iD.EditProduct(product);
        }

        public List<Order> ListOrders()
        {
            List<Order> Orders = this.iD.ListOrders();
            return Orders.OrderBy(x => x.Customer.ID).ToList();
        }

        public override void AddOrder(Order o)
        {
            this.iD.AddOrder(o);
        }
    }
}
