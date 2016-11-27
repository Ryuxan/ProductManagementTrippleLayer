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
        public abstract Customer GetCustomer(int customerId);
        public abstract int AddCostomer(Customer c);
        public abstract void DeleteCustomer(int customerID);
        public abstract void EditCustomer(Customer c);

        public abstract List<Product> ListProducts();
        public abstract Product GetProduct(int productId);
        public abstract int AddProduct(Product product);
        public abstract void DeleteProduct(int productId);
        public abstract void EditProduct(Product product);

        public abstract List<Order> ListOrders();
        public abstract int AddOrder(Order ord);
    }
}
