using System;
using System.Collections.Generic;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProduktVerwaltungTrippleLayer
{
    class Datenbank : IDatenhaltung
    {
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        private DataSet dsData;
        //private List<Customer> CustomerList;
        //private List<Product> ProductList;
        //private List<Order> OrderList;

        DataTable dtCustomer;

        string myConnectionString = "SERVER=" + Properties.Settings.Default.Server + ";" +
                            "DATABASE=" + Properties.Settings.Default.Database + ";" +
                            "UID=" + Properties.Settings.Default.User + ";";
        //"PASSWORD=triple;";

        public Datenbank()
        {
            try
            {
                this.myConnection = new MySqlConnection(this.myConnectionString);
                //this.myConnection.ConnectionString = this.myConnectionString;
                this.myConnection.Open();
                makeDataShema();
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

        private void makeDataShema()
        {
            string query = "SELECT * FROM characters WHERE _StreamName = 'root'"; 
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = query;
            MySqlDataAdapter shema = new MySqlDataAdapter(query, myConnection);
            DataTable dt = new DataTable("CharacterInfo");
            shema.Fill(dt);
            
        }

        public override List<Customer> ListCustomers()
        {
            MySqlDataReader myReader;
            this.myCommand = this.myConnection.CreateCommand();
            List<Customer> CustomerList = new List<Customer>();

            this.myCommand.CommandText = "SELECT KundenNR, Vorname, Name FROM Kunde";
            myReader = myCommand.ExecuteReader();

            //this.dtCustomer.

            while (myReader.Read())
            {
                //DataRow dRow;
                string row = "";
                //myReader
                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";

                //myReader.GetFieldValue<int>()

                int id;
                string vorname, nachname;
                string[] splitter = row.Split(new char[] { ';', ',' });
                bool test = int.TryParse(splitter[0], out id);
                vorname = splitter[1];
                nachname = splitter[2];
                Customer cache = new Customer();
                cache.ID = id;
                cache.sFirstName = vorname;
                cache.sSurName = nachname;
                CustomerList.Add(cache);
            }

            return CustomerList;
        }

        public override Customer GetCustomer(int customerId)
        {
            MySqlDataReader localTest;
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "SELECT KundenNR, Vorname, Name FROM Kunde WHERE KundenNR = " + customerId + ";";
            localTest = this.myCommand.ExecuteReader();
            localTest.Read();
            Customer cache = new Customer();
            cache.ID = localTest.GetFieldValue<int>(1);

            return cache;
            //throw new NotImplementedException();
        }

        public override void AddCostomer(Customer c)
        {
            myCommand = myConnection.CreateCommand();
            //INSERT INTO `kunde` (`KundenNR`, `Vorname`, `Name`) VALUES (NULL, 'Test', 'Test');
            myCommand.CommandText = "INSERT INTO kunde (KundenNR, Vorname, Name) VALUES (NULL, '" + c.sFirstName + "' , '" + c.sSurName + "');";
            myCommand.ExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public override void DeleteCustomer(int customerID)
        {
            this.myCommand = this.myConnection.CreateCommand();
            // "DELETE FROM `kunde` WHERE `kunde`.`KundenNR` = 1"
            this.myCommand.CommandText = "DELETE FROM kunde WHERE KundenNR = " + customerID + ";";
            this.myCommand.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public override void EditCustomer(Customer c)
        {
            this.myCommand = this.myConnection.CreateCommand();
            // UPDATE `kunde` SET `Name` = 'Dudabist' WHERE `kunde`.`KundenNR` = 2;
            this.myCommand.CommandText = "UPDATE kunde SET Vorname='" + c.sFirstName + "'," +
                                                        "Name='" + c.sSurName + "'" +
                                                        "WHERE KundenNR = " + c.ID + ";";
            this.myCommand.ExecuteNonQuery();
        }

        public override List<Product> ListProducts()
        {
            List<Product> ProductList = new List<Product>();
            MySqlDataReader myReader;
            this.myCommand = this.myConnection.CreateCommand();
            //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
            this.myCommand.CommandText = "SELECT ProduktNR, Preis, Typ, Bezeichnung FROM Produkt";
            myReader = myCommand.ExecuteReader();

            //this.dtCustomer.

            while (myReader.Read())
            {
                //DataRow dRow;
                string row = "";
                //myReader
                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";

                //myReader.GetFieldValue<int>()

                int id;
                double preis;
                string typ, bezeichnung;
                string[] splitter = row.Split(new char[] { ';', ',' });
                bool test = int.TryParse(splitter[0], out id);
                bool test2 = double.TryParse(splitter[1], out preis);
                typ = splitter[2];
                bezeichnung = splitter[3];
                Product cache = new Product();
                cache.ID = id;
                cache.dPrice = preis;
                //cache.sLabel = typ;
                cache.sLabel = bezeichnung;
                ProductList.Add(cache);
            }

            return ProductList;
            //throw new NotImplementedException();
        }

        public override Product GetProduct(int productId)
        {
            MySqlDataReader myReader;
            int id;
            double preis;
            string typ, bezeichnung;
            string row = "";

            this.myCommand = this.myConnection.CreateCommand();
            //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
            this.myCommand.CommandText = "SELECT ProduktNR, Preis, Typ, Bezeichnung FROM Produkt WHERE PoduktNR =" + productId + ";";
            myReader = myCommand.ExecuteReader();
            myReader.Read();

            string[] splitter = row.Split(new char[] { ';', ',' });
            //TODO: Test Methods einbauen
            bool test = int.TryParse(splitter[0], out id);
            bool test2 = double.TryParse(splitter[1], out preis);
            typ = splitter[2];
            bezeichnung = splitter[3];
            Product cache = new Product();
            cache.ID = id;
            cache.dPrice = preis;
            //cache.sLabel = typ;
            cache.sLabel = bezeichnung;

            return cache;
            //throw new NotImplementedException();
        }

        public override void AddProduct(Product product)
        {
            this.myCommand = this.myConnection.CreateCommand();
            //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
            this.myCommand.CommandText = "Insert Into Produkt(ProduktNR, Preis, Typ, Bezeichnung)" +
                "Values(null, " + product.dPrice + ", 'typplatzhalter', '" + product.sLabel + "';";

            this.myCommand.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public override void DeleteProduct(int productId)
        {
            //"DELETE FROM kunde WHERE KundenNR = " + customerID + ";";
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "DELETE From produkt WHERE ProduktNR = " + productId + ";";
            this.myCommand.ExecuteNonQuery();
        }

        public override void EditProduct(Product product)
        {
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "UPDATE prdukt Set" +
                                        "preis=" + product.dPrice + "," +
                                        "bezeichnung='" + product.sLabel + "';";
            this.myCommand.ExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public override List<Order> ListOrders()
        {
            //TODO make them;
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
