using System;
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

        List<int> ListCustomers();
        Customer GetCustomer(int customerId);
        string GetCustomerName(int customerId);
        string GetCustomerFirstName(int customerId);
        void AddCustomer(string sFirstName, string sName);
        void DeleteCustomer(int customerId);
        void EditCustomer(int customerId, string sFirstName, string sName);

        List<int> ListProducts();
        Product GetProduct(int productId);
        string GetProductLabel(int productId);
        double GetProductPrice(int productId);
        string GetProductTyp(int productId);
        void AddProduct(string sLabel, double dPrice);
        void DeleteProduct(int productId);
        void EditProduct(int productId, string sLabel, double dPrice);

        List<Order> ListOrders();
        void AddOrder(int customerId, int productId, int iAmount, DateTime dt);
        Order GetOrder(int orderId);
        int GetOrderCustomerId(int orderId);
        int GetOrderProductId(int orderId);
        int GetOrderAmount(int orderId);
        DateTime GetOrderDate(int orderId);
    }
}
