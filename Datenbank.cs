using System;
using System.Collections.Generic;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;


namespace ProduktVerwaltungTrippleLayer
{
    public class Datenbank : IDatenhaltung
    {
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        //private DataSet dsData;
        //private List<Customer> CustomerList;
        //private List<Product> ProductList;
        //private List<Order> OrderList;

        //DataTable dtCustomer;

        string myConnectionString = "SERVER=" + Properties.Settings.Default.Server + ";" +
                            "DATABASE=" + Properties.Settings.Default.Database + ";" +
                            "UID=" + Properties.Settings.Default.User + ";" +
                            "PASSWORD=" + Properties.Settings.Default.Password + ";";

        public Datenbank()
        {
            try
            {
                this.myConnection = new MySqlConnection(this.myConnectionString);
                //this.myConnection.ConnectionString = this.myConnectionString;
                //this.myConnection.Open();
                System.Globalization.CultureInfo custom = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                custom.NumberFormat.NumberDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = custom;


                //makeDataShema();
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
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = query;
            MySqlDataAdapter shema = new MySqlDataAdapter(query, myConnection);
            DataTable dt = new DataTable("CharacterInfo");
            shema.Fill(dt);
        }

        public override List<Customer> ListCustomers()
        {
            MySqlDataReader myReader;
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();

            List<Customer> CustomerList = new List<Customer>();

            this.myCommand.CommandText = "SELECT KundenNR, Vorname, Name FROM Kunde";
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string row = "";
                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";

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

            this.myConnection.Close();

            return CustomerList;
        }

        public override Customer GetCustomer(int customerId)
        {
            MySqlDataReader myReader;
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "SELECT KundenNR, Vorname, Name FROM Kunde WHERE KundenNR = " + customerId + ";";
            myReader = this.myCommand.ExecuteReader();
            myReader.Read();
            Customer cache = new Customer();

            if (myReader.HasRows)
            {
                string row = "";
                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";

                int id;
                string vorname, nachname;
                string[] splitter = row.Split(new char[] { ';', ',' });
                bool test = int.TryParse(splitter[0], out id);
                vorname = splitter[1];
                nachname = splitter[2];
                cache.ID = id;
                cache.sFirstName = vorname;
                cache.sSurName = nachname;
            }
            this.myConnection.Close();

            return cache;
        }

        public override int AddCustomer(Customer c)
        {
            this.myConnection.Open();
            myCommand = myConnection.CreateCommand();
            //INSERT INTO `kunde` (`KundenNR`, `Vorname`, `Name`) VALUES (NULL, 'Test', 'Test');
            myCommand.CommandText = "INSERT INTO kunde (KundenNR, Vorname, Name) VALUES (NULL, '" + c.sFirstName +
                                    "' , '" + c.sSurName + "');";
            myCommand.ExecuteNonQuery();

            this.myConnection.Close();

            return (int)this.myCommand.LastInsertedId;
        }

        public override void DeleteCustomer(int customerID)
        {
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            // "DELETE FROM `kunde` WHERE `kunde`.`KundenNR` = 1"
            this.myCommand.CommandText = "DELETE FROM kunde WHERE KundenNR = " + customerID + ";";
            this.myCommand.ExecuteNonQuery();
            this.myConnection.Close();
        }

        public override void EditCustomer(Customer c)
        {
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            // UPDATE `kunde` SET `Name` = 'Dudabist' WHERE `kunde`.`KundenNR` = 2;
            this.myCommand.CommandText = "UPDATE kunde SET Vorname='" + c.sFirstName + "'," +
                                                        "Name='" + c.sSurName + "'" +
                                                        "WHERE KundenNR = " + c.ID + ";";
            this.myCommand.ExecuteNonQuery();
            this.myConnection.Close();
        }

        public override List<Product> ListProducts()
        {
            List<Product> ProductList = new List<Product>();
            MySqlDataReader myReader;
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
            this.myCommand.CommandText = "SELECT ProduktNR, Preis, Typ, Bezeichnung FROM Produkt";
            myReader = this.myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string row = "";
                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";

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
                cache.sTyp = typ;
                cache.sLabel = bezeichnung;
                ProductList.Add(cache);
            }

            this.myConnection.Close();

            return ProductList;
        }

        public override Product GetProduct(int productId)
        {
            MySqlDataReader myReader;
            int id;
            double preis;
            string typ, bezeichnung;
            string row = "";
            Product cache = new Product();

            try
            {
                this.myConnection.Open();
                this.myCommand = this.myConnection.CreateCommand();
                //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
                this.myCommand.CommandText = "SELECT ProduktNR, Preis, Typ, Bezeichnung FROM Produkt WHERE ProduktNR =" + productId + ";";
                myReader = myCommand.ExecuteReader();
                myReader.Read();

                for (int i = 0; i < myReader.FieldCount; ++i)
                    row += myReader.GetValue(i).ToString() + ";";
                string[] splitter = row.Split(new char[] { ';' });
                //TODO: Test Methods einbauen
                bool test = int.TryParse(splitter[0], out id);
                bool test2 = double.TryParse(splitter[1], out preis);
                typ = splitter[2];
                bezeichnung = splitter[3];
                cache.ID = id;
                cache.dPrice = preis;
                cache.sTyp = typ;
                cache.sLabel = bezeichnung;

                this.myConnection.Close();
                return cache;            
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public override int AddProduct(Product product)
        {
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            //INSERT INTO `produkt` (`ProduktNr`, `Preis`, `Typ`, `Bezeichnung`) VALUES (NULL, '49.99', 'Spiele', 'Doom');
            this.myCommand.CommandText = "INSERT INTO produkt(ProduktNR, Preis, Typ, Bezeichnung)" +
                "Values(NULL, '" + product.dPrice + "', 'Spiel', '" + product.sLabel + "');";

            this.myCommand.ExecuteNonQuery();
            this.myConnection.Close();

            return (int)this.myCommand.LastInsertedId;
        }

        public override void DeleteProduct(int productId)
        {
            //"DELETE FROM kunde WHERE KundenNR = " + customerID + ";";
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "DELETE From produkt WHERE ProduktNR = " + productId + ";";
            this.myCommand.ExecuteNonQuery();
            this.myConnection.Close();
        }

        public override void EditProduct(Product product)
        {
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            this.myCommand.CommandText = "UPDATE produkt Set " +
                                        "preis='" + product.dPrice + "'," +
                                        "bezeichnung='" + product.sLabel +
                                        "' WHERE ProduktNR = " + product.ID + ";";
            this.myCommand.ExecuteNonQuery();
            this.myConnection.Close();
        }

        public override List<Order> ListOrders()
        {
            MySqlDataReader myReader;
            List<Order> OrderList = new List<Order>();
            this.myConnection.Open();
            this.myCommand = this.myConnection.CreateCommand();
            try
            {
                this.myCommand.CommandText = "SELECT OrderID, KundenNR, ProduktNr, Menge, Datum" +
                                            " FROM bestellt";
                //SELECT `OrderID`,`KundenNR`,`ProduktNr`,`Menge`,`Datum` FROM `bestellt`
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string row = "";
                    for (int i = 0; i < myReader.FieldCount; ++i)
                        row += myReader.GetValue(i).ToString() + ";";

                    int oID, kID, pID, menge;
                    DateTime dtDate;
                    string[] splitter = row.Split(new char[] { ';', ',' });
                    bool test = int.TryParse(splitter[0], out oID);
                    bool test2 = int.TryParse(splitter[1], out kID);
                    bool test3 = int.TryParse(splitter[2], out pID);
                    bool test4 = int.TryParse(splitter[3], out menge);
                    bool test5 = DateTime.TryParse(splitter[4], out dtDate);
                    if (test && test2 && test3 && test4 && test5)
                    {
                        Order cache = new Order();
                        cache.ID = oID;
                        cache.Customer = new Customer();
                        cache.Product = new Product();
                        cache.Customer.ID = kID;
                        cache.Product.ID = pID;
                        cache.iAmount = menge;
                        cache.OrderDate = dtDate;
                        OrderList.Add(cache);
                    }
                    else
                        throw new Exception("DataError");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetProduct: " + ex.Message);
            }

            this.myConnection.Close();
            return OrderList;
        }

        public override int AddOrder(Order ord)
        {
            try
            {
                this.myConnection.Open();
                this.myCommand = this.myConnection.CreateCommand();
                //"INSERT INTO kunde (KundenNR, Vorname, Name) VALUES (NULL, '" + c.sFirstName + "' , '" + c.sSurName + "');";
                this.myCommand.CommandText = "INSERT INTO bestellt(OrderID, KundenNR, ProduktNr, Menge, Datum)" +
                                            "VALUES(NULL," + ord.Customer.ID + ", " + ord.Product.ID + ", " + ord.iAmount
                    //+ ", CONVERT('" + ord.OrderDate.ToShortDateString() + "', datetime));";
                                            + ", '" + ord.OrderDate.Year + "-" + ord.OrderDate.Month + "-" + ord.OrderDate.Day + "' );";
                this.myCommand.ExecuteNonQuery();
                this.myConnection.Close();
                return (int)this.myCommand.LastInsertedId;
            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show(ex.Message);
                System.Diagnostics.Debug.WriteLine("Datebase AddOrder: " + ex.Message);
                return -1;
            }
        }

        public override Order GetOrder(int orderId)
        {
            List<Order> OrderList = ListOrders();
            OrderList = OrderList.Where(x => x.ID == orderId).ToList();
            return OrderList.First();
        }
    }
}
