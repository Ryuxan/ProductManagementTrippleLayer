using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktVerwaltungTrippleLayer
{
    public class TUI
    {
        IFachkonzept iF;
        public TUI(IFachkonzept _iF)
        {
            iF = _iF;
            doshit(Init());
        }

        public char Init()
        {
            Console.WriteLine("KUNDEN-VERWALTUNGS-SYSTEM");
            Console.WriteLine("");
            Console.WriteLine("Kunden anzeigen            (a)");
            Console.WriteLine("Neuen Kunden anlegen       (b)");
            Console.WriteLine("Kundendaten bearbeiten     (c)");
            Console.WriteLine("Kunde löschen              (d)");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Produkte anzeigen          (e)");
            Console.WriteLine("Neues Produkt anlegen      (f)");
            Console.WriteLine("Produktdaten bearbeiten    (g)");
            Console.WriteLine("Produkt löschen            (h)");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Bestellungen anzeigen      (i)");
            Console.WriteLine("Neue Bestellung eingeben   (j)");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Ende                       (k)");
            Console.WriteLine("");
            Console.WriteLine("Wählen Sie einen Menüpunkt:");
            return Console.ReadKey().KeyChar;
        }

        public void doshit(char c)
        {
            switch(c.ToString().ToLower())
            {
                case "a":
                    ListCustomers();
                    break;
                case "b":
                    AddCustomer();
                    break;
                case "c":
                    EditCustomer();
                    break;
                case "d":
                    DeleteCustomer();
                    break;
                case "e":
                    ListProducts();
                    break;
                case "f":
                    AddProduct();
                    break;
                case "g":
                    EditProduct();
                    break;
                case "h":
                    DeleteProduct();
                    break;
                case "i":
                    ListOrders();
                    break;
                case "j":
                    AddOrder();
                    break;
                case "k":
                    break;
                default:
                    Console.WriteLine("Keine gültige Eingabe. Bitte wiederholen.");
                    doshit(Init());
                    break;
            }
        }

        void ShowCustomer(Customer c)
        {
            Console.WriteLine("Kunde " + c.ID + ":");
            Console.WriteLine("Vorname: " + c.sFirstName);
            Console.WriteLine("Nachname: " + c.sSurName);
            Console.WriteLine("-------------------------------");
        }

        void ShowProduct(Product p)
        {
            Console.WriteLine("Produkt " + p.ID + ":");
            Console.WriteLine("Bezeichnung: " + p.sLabel);
            Console.WriteLine("Typ: " + p.sTyp);
            Console.WriteLine("Preis: " + p.dPrice);
            Console.WriteLine("-------------------------------");
        }
        void ShowOrder(Order o)
        {
            Console.WriteLine("Kunde " + o.Customer.ID + ":");
            Console.WriteLine("Vorname: " + o.Customer.sFirstName);
            Console.WriteLine("Nachname: " + o.Customer.sSurName);
            Console.WriteLine("Produkt " + o.Product.ID + ":");
            Console.WriteLine("Bezeichnung: " + o.Product.sLabel);
            Console.WriteLine("Typ: " + o.Product.sTyp);
            Console.WriteLine("Preis: " + o.Product.dPrice);
            Console.WriteLine("Menge: " + o.iAmount);
            Console.WriteLine("Gesamtpreis: " + (o.Product.dPrice * o.iAmount));
            Console.WriteLine("-------------------------------");
        }

        void ListCustomers()
        {
            List<Customer> Customers = iF.ListCustomers();
            foreach(Customer c in Customers)
            {
                ShowCustomer(c);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            doshit(Init());
        }

        void AddCustomer()
        {
            Customer c = new Customer();
            Console.WriteLine("Bitte geben Sie den Vornamen ein.");
            c.sFirstName = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein.");
            c.sSurName = Console.ReadLine();
            iF.AddCustomer(c);
        }

        void DeleteCustomer()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu löschenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird gelöscht:");
            ShowCustomer(iF.GetCustomer(iID));
            Console.WriteLine("Löschen bestätigen?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Löschen bestätigen?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                iF.DeleteCustomer(iID);
            doshit(Init());
        }

        void EditCustomer()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu bearbeitenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird geändert:");
            Customer c = iF.GetCustomer(iID);
            ShowCustomer(c);
            Console.WriteLine("Bitte geben Sie den Vornamen ein.");
            c.sFirstName = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein.");
            c.sSurName = Console.ReadLine();
            Console.WriteLine("Änderungen Speichern?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Änderungen Speichern?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                iF.EditCustomer(c);
            doshit(Init());
        }

        void ListProducts()
        {
            List<Product> Products = iF.ListProducts();
            foreach (Product p in Products)
            {
                ShowProduct(p);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            doshit(Init());
        }

        void AddProduct()
        {
            Product p = new Product();
            Console.WriteLine("Bitte geben Sie den Typ ein.");
            p.sTyp = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie die Bezeichnung ein.");
            p.sLabel = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Preis ein.");
            p.dPrice = ValidateDouble(Console.ReadLine());
            iF.AddProduct(p);
        }

        void DeleteProduct()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu löschenden Produkts ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgendes Produkt wird gelöscht:");
            ShowProduct(iF.GetProduct(iID));
            Console.WriteLine("Löschen bestätigen?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Löschen bestätigen?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                iF.DeleteProduct(iID);
            doshit(Init());
        }

        void EditProduct()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu bearbeitenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird geändert:");
            Product p = iF.GetProduct(iID);
            ShowProduct(p);
            Console.WriteLine("Bitte geben Sie den Typ ein.");
            p.sTyp = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie die Bezeichnung ein.");
            p.sLabel = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Preis ein.");
            p.dPrice = ValidateDouble(Console.ReadLine());
            Console.WriteLine("Änderungen Speichern?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Änderungen Speichern?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                iF.EditProduct(p);
            doshit(Init());
        }

        void ListOrders()
        {
            List<Order> Orders = iF.ListOrders();
            foreach (Order o in Orders)
            {
                ShowOrder(o);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            doshit(Init());
        }

        void AddOrder()
        {
            Order o = new Order();
            Console.WriteLine("Bitte geben Sie die Kunden-ID ein.");
            o.Customer = iF.GetCustomer(ValidateInt(Console.ReadLine()));
            Console.WriteLine("Bitte geben Sie die Produkt-ID ein.");
            o.Product=iF.GetProduct(ValidateInt(Console.ReadLine()));
            Console.WriteLine("Bitte geben Sie die Menge ein.");
            o.iAmount = ValidateInt(Console.ReadLine());
            o.OrderDate = DateTime.Now;
            iF.AddOrder(o);
        }

        int ValidateInt(string s)
        {
            int i;
            while (!int.TryParse(s, out i))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wiederholen.");
                s = Console.ReadLine();
            }
            return i;
        }

        double ValidateDouble(string s)
        {
            double d;
            while (!double.TryParse(s, out d))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wiederholen.");
                s = Console.ReadLine();
            }
            return d;
        }
    }
}
