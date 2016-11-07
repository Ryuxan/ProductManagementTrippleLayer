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

        void ListCustomers()
        {
            List<Customer> Customers = iF.ListCustomers();
        }

        void AddCustomer()
        {
            Console.WriteLine("Bitte geben Sie den Vornamen ein.");
            string sVorname = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein.");
            string sNachname = Console.ReadLine();
            Customer c = new Customer();
            c.sFirstName = sVorname;
            c.sSurName = sNachname;
        }

        void DeleteCustomer()
        {

        }

        void EditCustomer()
        {

        }

        void ListProducts()
        {

        }

        void AddProduct()
        {

        }

        void DeleteProduct()
        {

        }

        void EditProduct()
        {

        }

        void ListOrders()
        {

        }

        void AddOrder()
        {

        }
    }
}
