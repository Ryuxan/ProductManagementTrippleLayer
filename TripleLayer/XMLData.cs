using ProduktVerwaltungTrippleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TripleLayer
{
    public class XMLData : IDatenhaltung
    {
        private const string path = @"\xml_data\customers.xml";
        private XDocument xml;


        public XMLData()
        {
            XDocument xml = XDocument.Load(@"\xml_data\customers.xml");
        }

        public List<Customer> ListCustomers()
        {
            //var elements = xml.Descendants("products");

            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void AddCostomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public void EditCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public List<Product> ListProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Order> ListOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Customer c, Product p, int amount, DateTime Date)
        {
            throw new NotImplementedException();
        }
    }
}
