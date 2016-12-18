using System;
using System.Collections.Generic;
using System.Linq;


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

        public override int AddCustomer(Customer c)
        {
            return this.Datenhaltung.AddCustomer(c);
        }

        public override int AddCustomer(string firstName, string surName)
        {
            Customer cache = new Customer();
            cache.sFirstName = firstName;
            cache.sSurName = surName;
            return AddCustomer(cache);
        }


        public override void DeleteCustomer(int customerID)
        {
            this.Datenhaltung.DeleteCustomer(customerID);
        }

        public override void EditCustomer(Customer c)
        {
            this.Datenhaltung.EditCustomer(c);
        }

        public override void EditCustomer(int customerID, string firstName, string surName)
        {
            Customer cache = new Customer();
            cache.ID = customerID;
            cache.sFirstName = firstName;
            cache.sSurName = surName;
            EditCustomer(cache);
        }

        public override Product GetProduct(int productId)
        {
            return this.Datenhaltung.GetProduct(productId);
        }

        public override int AddProduct(Product product)
        {
            return this.Datenhaltung.AddProduct(product);
        }

        public override int AddProduct(string label, string type, double price)
        {
            Product cache = new Product();
            cache.sLabel = label;
            cache.sTyp = type;
            cache.dPrice = price;
            return AddProduct(cache);
        }

        public override void DeleteProduct(int productId)
        {
            this.Datenhaltung.DeleteProduct(productId);
        }

        public override void EditProduct(Product product)
        {
            this.Datenhaltung.EditProduct(product);
        }

        public override void EditProduct(int productID, string label, string type, double price)
        {
            Product cache = new Product();
            cache.sLabel = label;
            cache.sTyp = type;
            cache.dPrice = price;
            EditProduct(cache);
        }

        public override int AddOrder(Order ord)
        {
            return this.Datenhaltung.AddOrder(ord);
        }

        public override int AddOrder(int customerID, int ProductID, int amount, DateTime date)
        {
            Order cache = new Order();
            Customer customer = new Customer();
            Product product = new Product();
            customer.ID = customerID;
            cache.Customer = customer;
            product.ID = ProductID;
            cache.Product = product;
            cache.iAmount = amount;
            cache.OrderDate = date;
            return AddOrder(cache);
        }

        //public override List<Customer> ListCustomers()
        //{
        //    return this.Datenhaltung.ListCustomers();
        //}

        //public override List<Product> ListProducts()
        //{
        //    return this.Datenhaltung.ListProducts();
        //}

        public override List<Order> ListOrders()
        {
            return this.Datenhaltung.ListOrders();
        }

        public override string GetCustomerName(int customerId)
        {
            return this.Datenhaltung.GetCustomer(customerId).sSurName;
        }

        public override string GetCustomerFirstName(int customerId)
        {
            return this.Datenhaltung.GetCustomer(customerId).sFirstName;
        }

        public override string GetProductLabel(int productId)
        {
            return this.Datenhaltung.GetProduct(productId).sLabel;
        }

        public override double GetProductPrice(int productId)
        {
            return this.Datenhaltung.GetProduct(productId).dPrice;
        }

        public override string GetProductTyp(int productId)
        {
            return this.Datenhaltung.GetProduct(productId).sTyp;
        }

        public override void AddProduct(string sLabel, double dPrice)
        {
            Product cache = new Product();
            cache.sLabel = sLabel;
            cache.dPrice = dPrice;

            this.AddProduct(cache);
        }

        public override Order GetOrder(int orderId)
        {
            return this.Datenhaltung.GetOrder(orderId);
        }

        public override int GetOrderCustomerId(int orderId)
        {
            return this.Datenhaltung.GetOrder(orderId).Customer.ID;
        }

        public override int GetOrderProductId(int orderId)
        {
            return this.Datenhaltung.GetOrder(orderId).Product.ID;
        }

        public override int GetOrderAmount(int orderId)
        {
            return this.Datenhaltung.GetOrder(orderId).iAmount;
        }

        public override DateTime GetOrderDate(int orderId)
        {
            return this.Datenhaltung.GetOrder(orderId).OrderDate;
        }

        public override void EditProduct(int productId, string sLabel, double dPrice)
        {
            Product cache = new Product();
            cache.ID = productId;
            cache.sLabel = sLabel;
            cache.dPrice = dPrice;

            this.EditProduct(cache);
        }

        public override List<int> ListCustomers()
        {
            List<Customer> customerList = this.Datenhaltung.ListCustomers();
            List<int> customerIDS = new List<int>();
            foreach(Customer c in customerList)
            {
                customerIDS.Add(c.ID);
            }

            return customerIDS;
        }

        public override List<int> ListProducts()
        {
            List<Product> productList = this.Datenhaltung.ListProducts();
            List<int> prodIDs = new List<int>();
            foreach (Product p in productList)
            {
                prodIDs.Add(p.ID);
            }

            return prodIDs;
        }
    }
}
