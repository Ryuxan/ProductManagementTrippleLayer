﻿using System;

namespace ProduktVerwaltungTrippleLayer
{
    class EntryPoint
    {
        [STAThread]
        public static void Main(String[] args)
        {
            //Gui wind = new Gui(new Fachkonzept2(new XMLData()));
            //wind.ShowDialog();
            new TUI(new Fachkonzept1(new XMLData()));
            //Customer c = new Customer();
            //c.ID = 2;
            //new Random().Next().ToString();
            //c.sFirstName = new Random().Next().ToString(); // "Hallo";
            //c.sSurName = new Random().Next().ToString(); // "Duda";
            //new Datenbank();
            //System.Collections.Generic.List<Customer> customers = new Datenbank().ListCustomers();
            //new Datenbank().AddCostomer(c);
            //new Datenbank().DeleteCustomer(1);
            //new Datenbank().EditCustomer(c);
        }
    }
}
