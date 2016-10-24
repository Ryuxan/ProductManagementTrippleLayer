using System;
using System.Collections.Generic;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


namespace ProduktVerwaltungTrippleLayer
{
    class Datenbank : IDatenhaltung
    {
        private string databasename;
        //OleDB or MySQL or Maria?
        //private OleDbConnection connection;
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        private string sConnectinstring;
        //private List<Customer> CustomerList;
        //private List<Product> ProductList;
        //private List<Order> OrderList;

        string myConnectionString = "SERVER=localhost;" +
                            "DATABASE=mydatabase;" +
                            "UID=user;" +
                            "PASSWORD=mypassword;";

        public Datenbank()
        {
            try
            {
                this.myConnection.Open();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        ~Datenbank()
        {
            this.myConnection.Close();
        }

        public override List<Customer> ListCustomers()
        {
            MySqlDataReader myReader;
            myCommand = new MySqlCommand();
            List<Customer> CustomerList = new List<Customer>();

            myCommand.CommandText = "SELECT * FROM myTABLE";
            myCommand.Connection = myConnection;
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {

            }

            return CustomerList;
        }

        public override Customer GetCustomer(int customerId)
        {
            MySqlDataReader localTest;
            myCommand = new MySqlCommand();
            myCommand.CommandText = "SELECT * FROM myTABLE WHERE CustomerID = " + customerId;
            myCommand.Connection = myConnection;
            localTest = myCommand.ExecuteReader();
            localTest.Read();
            localTest.GetFieldValue<int>(1);

            return new Customer();
            //throw new NotImplementedException();
        }

        public override void AddCostomer(Customer c)
        {
            //throw new NotImplementedException();
        }

        public override void DeleteCustomer(int customerID)
        {
            //throw new NotImplementedException();
        }

        public override void EditCustomer(Customer c)
        {
            //throw new NotImplementedException();
        }

        public override List<Product> ListProducts()
        {
            List<Product> ProductList = new List<Product>();
            return ProductList;
            //throw new NotImplementedException();
        }

        public override Product GetProduct(int productId)
        {
            return new Product();
            //throw new NotImplementedException();
        }

        public override void AddProduct(Product product)
        {
            //throw new NotImplementedException();
        }

        public override void DeleteProduct(int productId)
        {
            //throw new NotImplementedException();
        }

        public override void EditProduct(Product product)
        {
            //throw new NotImplementedException();
        }

        public override List<Order> ListOrders()
        {
            List<Order> OrderList = new List<Order>();
            return OrderList;
            //throw new NotImplementedException();
        }

        public override void AddOrder(Customer c, Product p, int amount, DateTime Date)
        {
            //throw new NotImplementedException();
        }
    }
}
