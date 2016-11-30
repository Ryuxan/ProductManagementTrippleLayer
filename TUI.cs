﻿using System;
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
        public TUI(IFachkonzept iF)
        {
            this.iF = iF;
            DoCommand(Menu());
        }

        public char Menu()
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

        public void DoCommand(char c)
        {
            switch (c.ToString().ToLower())
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
                    DoCommand(Menu());
                    break;
            }
        }

        public void ShowCustomer(int i)
        {
            Console.WriteLine("Kunde " + i + ":");
            Console.WriteLine("Vorname: " + this.iF.GetCustomerFirstName(i));
            Console.WriteLine("Nachname: " + this.iF.GetCustomerName(i));
            Console.WriteLine("-------------------------------");
        }

        public void ShowProduct(int i)
        {
            Console.WriteLine("Produkt " + i + ":");
            Console.WriteLine("Bezeichnung: " + this.iF.GetProductLabel(i));
            Console.WriteLine("Typ: " + this.iF.GetProductTyp(i));
            Console.WriteLine("Preis: " + this.iF.GetProductPrice(i));
            Console.WriteLine("-------------------------------");
        }
        public void ShowOrder(Order o)
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

        public void ListCustomers()
        {
            List<int> Customers = this.iF.ListCustomers();
            foreach (int i in Customers)
            {
                ShowCustomer(i);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            DoCommand(Menu());
        }

        public void AddCustomer()
        {
            Console.WriteLine("Bitte geben Sie den Vornamen ein.");
            string sFirstName = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein.");
            string sName = Console.ReadLine();
            this.iF.AddCustomer(sFirstName, sName);
            DoCommand(Menu());
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu löschenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird gelöscht:");
            ShowCustomer(iID);
            Console.WriteLine("Löschen bestätigen?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Löschen bestätigen?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                this.iF.DeleteCustomer(iID);
            DoCommand(Menu());
        }

        public void EditCustomer()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu bearbeitenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird geändert:");
            ShowCustomer(iID);
            Console.WriteLine("Bitte geben Sie den Vornamen ein.");
            string sFirstName = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein.");
            string sName = Console.ReadLine();
            Console.WriteLine("Änderungen Speichern?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Änderungen Speichern?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                this.iF.EditCustomer(iID, sFirstName, sName);
            DoCommand(Menu());
        }

        public void ListProducts()
        {
            List<int> Products = this.iF.ListProducts();
            foreach (int i in Products)
            {
                ShowProduct(i);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            DoCommand(Menu());
        }

        public void AddProduct()
        {
            Console.WriteLine("Bitte geben Sie die Bezeichnung ein.");
            string sLabel = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Preis ein.");
            double dPrice = ValidateDouble(Console.ReadLine());
            this.iF.AddProduct(sLabel, dPrice);
            DoCommand(Menu());
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu löschenden Produkts ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgendes Produkt wird gelöscht:");
            ShowProduct(iID);
            Console.WriteLine("Löschen bestätigen?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Löschen bestätigen?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                this.iF.DeleteProduct(iID);
            DoCommand(Menu());
        }

        public void EditProduct()
        {
            Console.WriteLine("Bitte geben Sie die ID des zu bearbeitenden Kunden ein.");
            int iID = ValidateInt(Console.ReadLine());
            Console.WriteLine("Folgender Kunde wird geändert:");
            ShowProduct(iID);
            Console.WriteLine("Bitte geben Sie die Bezeichnung ein.");
            string sLabel = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Preis ein.");
            double dPrice = ValidateDouble(Console.ReadLine());
            Console.WriteLine("Änderungen Speichern?(y/n)");
            string sKey = Console.ReadKey().KeyChar.ToString();
            while ((sKey != "y") && (sKey != "n"))
            {
                Console.WriteLine("Ungültige Eingabe. Änderungen Speichern?(y/n)");
                sKey = Console.ReadKey().KeyChar.ToString();
            }
            if (sKey == "y")
                this.iF.EditProduct(iID, sLabel, dPrice);
            DoCommand(Menu());
        }

        public void ListOrders()
        {
            List<Order> Orders = iF.ListOrders();
            foreach (Order o in Orders)
            {
                ShowOrder(o);
            }
            Console.WriteLine("Drücken Sie eine beliebige Taste um zum Menü zurückzukehren.");
            Console.ReadKey();
            DoCommand(Menu());
        }

        public void AddOrder()
        {
            Order o = new Order();
            Console.WriteLine("Bitte geben Sie die Kunden-ID ein.");
            o.Customer = this.iF.GetCustomer(ValidateInt(Console.ReadLine()));
            Console.WriteLine("Bitte geben Sie die Produkt-ID ein.");
            o.Product = this.iF.GetProduct(ValidateInt(Console.ReadLine()));
            Console.WriteLine("Bitte geben Sie die Menge ein.");
            o.iAmount = ValidateInt(Console.ReadLine());
            o.OrderDate = DateTime.Now;
            this.iF.AddOrder(o);
            DoCommand(Menu());
        }

        public int ValidateInt(string s)
        {
            int i;
            while (!int.TryParse(s, out i))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wiederholen.");
                s = Console.ReadLine();
            }
            return i;
        }

        public double ValidateDouble(string s)
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