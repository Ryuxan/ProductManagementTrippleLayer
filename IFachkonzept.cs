using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProduktVerwaltungTrippleLayer
{
    public abstract class IFachkonzept
    {
        protected IDatenhaltung Datenhaltung;
        public IFachkonzept(IDatenhaltung Datenhaltung)
        {
            this.Datenhaltung = Datenhaltung;
        }

        public abstract List<int> ListCustomers();
        public abstract List<Customer> ListCustomers();
        //public abstract List<Object> ListCustomersasobject();
        public abstract Customer GetCustomer(int customerId);
        public abstract string GetCustomerName(int customerId);
        public abstract string GetCustomerFirstName(int customerId);

        public abstract int AddCustomer(Customer c);
        public abstract int AddCustomer(string firstName, string surName);
        public abstract void DeleteCustomer(int customerID);
        public abstract void EditCustomer(Customer c);
        public abstract void EditCustomer(int customerID, string firstName, string surName);

        public abstract List<int> ListProducts();
        public abstract List<Product> ListProducts();
        public abstract Product GetProduct(int productId);
        public abstract string GetProductLabel(int productId);
        public abstract double GetProductPrice(int productId);
        public abstract string GetProductTyp(int productId);
        public abstract int AddProduct(Product product);
        public abstract void AddProduct(string sLabel, double dPrice);
        public abstract int AddProduct(string label, string type, double price);
        public abstract void DeleteProduct(int productId);
        public abstract void EditProduct(Product product);
        public void EditProduct(int productId, string sLabel, double dPrice);
        public abstract void EditProduct(int productID, string label, string type, double price);
        public abstract List<Order> ListOrders();
        public abstract int AddOrder(Order ord);
        public abstract int AddOrder(int customerID, int ProductID, int menge, DateTime date);
        public abstract Order GetOrder(int orderId);
        public abstract int GetOrderCustomerId(int orderId);
        public abstract int GetOrderProductId(int orderId);
        public abstract int GetOrderAmount(int orderId);
        public abstract DateTime GetOrderDate(int orderId);
    }
}

