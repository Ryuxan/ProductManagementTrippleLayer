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

        public abstract List<Customer> ListCustomers();
        //public abstract List<Object> ListCustomersasobject();
        public abstract Customer GetCustomer(int customerId);
        public abstract int AddCustomer(Customer c);
        public abstract int AddCustomer(string firstName, string surName);
        public abstract void DeleteCustomer(int customerID);
        public abstract void EditCustomer(Customer c);
        public abstract void EditCustomer(int customerID, string firstName, string surName);

        public abstract List<Product> ListProducts();
        public abstract Product GetProduct(int productId);
        public abstract int AddProduct(Product product);
        public abstract int AddProduct(string label, string type, double price);
        public abstract void DeleteProduct(int productId);
        public abstract void EditProduct(Product product);
        public abstract void EditProduct(int productID, string label, string type, double price);

        public abstract List<Order> ListOrders();
        public abstract int AddOrder(Order ord);
        public abstract int AddOrder(int customerID, int ProductID, int menge, DateTime date);
    }
}
