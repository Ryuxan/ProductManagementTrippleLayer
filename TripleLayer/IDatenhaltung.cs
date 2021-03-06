﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProduktVerwaltungTrippleLayer
{
    interface IDatenhaltung
    {
        List<Customer> ListCustomers();
        Customer GetCustomer(int customerId);
        void AddCostomer(Customer c);
        void DeleteCustomer(int customerID);
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
