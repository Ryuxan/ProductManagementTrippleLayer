﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProduktVerwaltungTrippleLayer
{
    interface IFachkonzept
    {
        //protected IFachkonzept(IDatenhaltung daten);
        //protected abstract IDatenhaltung daten;

        List<Customer> ListCustomers();
        Customer GetCustomer(int customerId);
        void AddCostomer(Customer c);
        void DeleteCustomer(int customer);
        void EditCustomer(Customer c);

        List<Product> ListProducts();
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        void EditProduct(Product product);

        List<Order> ListOrders();
        void AddOrder(Customer c, Product p, int amount, DateTime Date);
    }
}
