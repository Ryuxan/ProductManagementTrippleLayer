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

        public override List<int> ListCustomers()
        {
            List<Customer> Customers = this.iD.ListCustomers();
            Customers = Customers.OrderBy(x => x.sFirstName).OrderBy(x => x.sSurName).ToList();
            List<int> CustIDs = new List<int>();
            foreach(Customer c in Customers)
            {
                CustIDs.Add(c.ID);
            }
            return CustIDs;
        }

        public override Customer GetCustomer(int customerId)
        {
            return this.iD.GetCustomer(customerId);
        }
        public override int AddCustomer(string sFirstName, string sName)
        {
            Customer c = new Customer();
            c.sFirstName = sFirstName;
            c.sSurName = sName;
            return this.iD.AddCustomer(c);
        }

        public override void DeleteCustomer(int customerId)
        {
            this.iD.DeleteCustomer(customerId);
        }

        public override void EditCustomer(int customerId, string sFirstName, string sName)
        {
            Customer c = new Customer();
            c.ID = customerId;
            c.sFirstName = sFirstName;
            c.sSurName = sName;
            this.iD.EditCustomer(c);
        }

        public override List<int> ListProducts()
        {
            List<Product> Products = this.iD.ListProducts();
            Products = Products.OrderBy(x => x.dPrice).ToList();
            List<int> ProdIDs = new List<int>();
            foreach (Product p in Products)
            {
                ProdIDs.Add(p.ID);
            }
            return ProdIDs;
        }

        public override Product GetProduct(int productId)
        {
            return this.iD.GetProduct(productId);
        }

        public override void AddProduct(string sLabel, double dPrice)
        {
            Product p = new Product();
            p.sLabel = sLabel;
            p.dPrice = dPrice;
            p.sTyp = "";
            this.iD.AddProduct(p);
        }

        public override void DeleteProduct(int productId)
        {
            this.iD.DeleteProduct(productId);
        }

        public override void EditProduct(int productId, string sLabel, double dPrice)
        {
            Product p = new Product();
            p.ID = productId;
            p.sLabel = sLabel;
            p.dPrice = dPrice;
            p.sTyp = "";
            this.iD.EditProduct(p);
        }

        //public List<Order> ListOrders()
        //{
        //    List<Order> Orders = this.iD.ListOrders();
        //    return Orders.OrderBy(x => x.Customer.ID).ToList();
        //}

        public override int AddOrder(Order o)
        {
            return this.iD.AddOrder(o);
        }

        public override Order GetOrder(int orderId)
        {
            return this.iD.GetOrder(orderId);
        }

        public override string GetCustomerName(int ID)
        {
            return GetCustomer(ID).sSurName;
        }

        public override string GetCustomerFirstName(int ID)
        {
            return GetCustomer(ID).sFirstName;
        }

        public override string GetProductLabel(int productId)
        {
            return GetProduct(productId).sLabel;
        }

        public override double GetProductPrice(int productId)
        {
            return GetProduct(productId).dPrice;
        }

        public override string GetProductTyp(int productId)
        {
            return GetProduct(productId).sTyp;
        }

        public override int GetOrderCustomerId(int orderId)
        {
            throw new NotImplementedException();
        }
        public override int GetOrderProductId(int orderId)
        {
            throw new NotImplementedException();
        }
        public override int GetOrderAmount(int orderId)
        {
            throw new NotImplementedException();
        }
        public override DateTime GetOrderDate(int orderId)
        {
            throw new NotImplementedException();
        }

        public override int AddCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public override void EditCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public override int AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override int AddProduct(string label, string type, double price)
        {
            throw new NotImplementedException();
        }

        public override void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override void EditProduct(int productID, string label, string type, double price)
        {
            throw new NotImplementedException();
        }

        public override int AddOrder(int customerID, int ProductID, int menge, DateTime date)
        {
            throw new NotImplementedException();
        }

        public override List<Order> ListOrders()
        {
            throw new NotImplementedException();
        }
    }
}
