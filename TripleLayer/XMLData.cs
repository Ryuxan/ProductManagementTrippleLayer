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
        private const string customerPath = @".\xml_data\customers.xml";
        private const string ordersPath = @".\xml_data\orders.xml";
        private const string productsPath = @".\xml_data\products.xml";

        public List<Customer> ListCustomers()
        {
            XDocument xml = XDocument.Load(customerPath);
            var elements = xml.Root.Descendants("customer");

            var customers = elements.Select(c => new Customer
                (
                    firstName: c.Descendants("firstName").FirstOrDefault().Value,
                    surName: c.Descendants("surName").FirstOrDefault().Value
                )
                {
                    ID = Convert.ToInt16(c.Descendants("id").FirstOrDefault().Value)
                }
            );

            return customers.ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            XDocument xml = XDocument.Load(customerPath);
            var elements = xml.Root.Descendants("customer");

            var customer = elements
                .Where(c => c.Descendants("id").FirstOrDefault().Value == customerId.ToString())
                .Select(c => new Customer
                    (
                        firstName: c.Descendants("firstName").FirstOrDefault().Value,
                        surName: c.Descendants("surName").FirstOrDefault().Value
                    )
                    {
                        ID = Convert.ToInt16(c.Descendants("id").FirstOrDefault().Value)

                    }
                ).FirstOrDefault();
            return customer;
        }

        public int AddCostomer(Customer customer)
        {
            XDocument xml = XDocument.Load(customerPath);
            var lastCustomer = xml.Root.Descendants("customer").Last();
            int newId = Convert.ToInt16(lastCustomer.Descendants("id").FirstOrDefault()) + 1;

            XElement newCustomer = new XElement(
                "customer",
                new XElement("id", newId),
                new XElement("firstName", customer.sFirstName),
                new XElement("surname", customer.sSurName)
            );
            xml.Element("customers").Add(newCustomer);
            xml.Save(customerPath);

            return newId;
        }

        public void DeleteCustomer(int customerID)
        {
            XDocument xml = XDocument.Load(customerPath);

            var customer = xml.Descendants("customer")
                .Where(c => c.Descendants("id").FirstOrDefault().Value == customerID.ToString())
                .FirstOrDefault();
            customer.Remove();
            xml.Save(customerPath);
        }

        public void EditCustomer(Customer customer)
        {
            XDocument xml = XDocument.Load(customerPath);

            var xmlCustomer = xml.Descendants("customer")
                .Where(c => c.Descendants("id").FirstOrDefault().Value == customer.ID.ToString())
                .FirstOrDefault();

            xmlCustomer.Element("firstName").Value = customer.sFirstName;
            xmlCustomer.Element("surName").Value = customer.sFirstName;
            xml.Save(customerPath);
        }

        public List<Product> ListProducts()
        {
            XDocument xml = XDocument.Load(productsPath);
            var elements = xml.Root.Descendants("product");

            var products = elements.Select(p => new Product
                (
                    label: p.Descendants("label").FirstOrDefault().Value,
                    price: Convert.ToDouble(p.Descendants("price").FirstOrDefault().Value)
                )
                {
                    ID = Convert.ToInt16(p.Descendants("id").FirstOrDefault().Value)
                }
            );

            return products.ToList();
        }

        public Product GetProduct(int productId)
        {
            XDocument xml = XDocument.Load(productsPath);
            var elements = xml.Root.Descendants("product");

            var product = elements
                .Where(p => p.Descendants("id").FirstOrDefault().Value == productId.ToString())
                .Select(p => new Product
                (
                    label: p.Descendants("label").FirstOrDefault().Value,
                    price: Convert.ToDouble(p.Descendants("price").FirstOrDefault().Value)
                )
                {
                    ID = Convert.ToInt16(p.Descendants("id").FirstOrDefault().Value)
                }
            ).FirstOrDefault();

            return product;
        }

        public int AddProduct(Product product)
        {
            XDocument xml = XDocument.Load(productsPath);
            var lastProduct = xml.Root.Descendants("product").Last();
            int newId = Convert.ToInt16(lastProduct.Descendants("id").FirstOrDefault()) + 1;

            XElement newProduct = new XElement(
                "product",
                new XElement("id", newId),
                new XElement("label", product.sLabel),
                new XElement("price", product.dPrice)
            );
            xml.Element("products").Add(newProduct);
            xml.Save(productsPath);

            return newId;
        }

        public void DeleteProduct(int productId)
        {
            XDocument xml = XDocument.Load(productsPath);

            var product = xml.Descendants("customer")
                .Where(p => p.Descendants("id").FirstOrDefault().Value == productId.ToString())
                .FirstOrDefault();
            product.Remove();
            xml.Save(productsPath);
        }

        public void EditProduct(Product product)
        {
            XDocument xml = XDocument.Load(productsPath);

            var xmlProduct = xml.Descendants("product")
                .Where(p => p.Descendants("id").FirstOrDefault().Value == product.ID.ToString())
                .FirstOrDefault();

            xmlProduct.Element("label").Value = product.sLabel;
            xmlProduct.Element("price").Value = product.dPrice.ToString();
            xml.Save(productsPath);
        }

        public List<Order> ListOrders()
        {
            XDocument xml = XDocument.Load(ordersPath);
            var elements = xml.Root.Descendants("order");

            var orders = elements.Select(o => new Order
                (
                    c: GetCustomer(Convert.ToInt16(o.Descendants("customerId").FirstOrDefault().Value)),
                    p: GetProduct(Convert.ToInt16(o.Descendants("orderId").FirstOrDefault().Value)),
                    amount: Convert.ToInt16(o.Descendants("amount").FirstOrDefault().Value),
                    orderDate: new DateTime(Convert.ToInt64(o.Descendants("orderDate").FirstOrDefault().Value))
                )
            );

            return orders.ToList();
        }

        public int AddOrder(Order order)
        {
            XDocument xml = XDocument.Load(ordersPath);
            // todo check empty
            var lastOrder = xml.Root.Descendants("order").Last();
            int newId = Convert.ToInt16(lastOrder.Descendants("id").FirstOrDefault()) + 1;

            XElement newOrder = new XElement(
                "order",
                new XElement("id", newId),
                new XElement("customerId", order.Customer.ID),
                new XElement("productId", order.Product.ID),
                new XElement("amount", order.iAmount),
                new XElement("orderDate", order.OrderDate.Ticks)
            );
            xml.Element("orders").Add(newOrder);
            xml.Save(ordersPath);

            return newId;
        }
    }
}
