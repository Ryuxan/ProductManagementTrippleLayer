using ProduktVerwaltungTrippleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProduktVerwaltungTrippleLayer
{
    /// <summary>
    /// Interaktionslogik für Gui.xaml
    /// </summary>
    public partial class Gui : Window
    {
        private IFachkonzept fachKonzept;

        public Gui()
        {
            //XMLData xml = new XMLData();
            //Customer c = new Customer("vorname", "nachname");

            //var cs = xml.ListCustomers();
            //c.ID = xml.AddCustomer(c);
            //cs = xml.ListCustomers();
            //xml.DeleteCustomer(4);
            //cs = xml.ListCustomers();
            //xml.DeleteCustomer(14);
            //cs = xml.ListCustomers();
            //xml.GetCustomer(3);
            //cs = xml.ListCustomers();
            //xml.GetCustomer(41);
            //cs = xml.ListCustomers();

            this.fachKonzept = null;
            InitializeComponent();

            //cbx_customer_select.ItemsSource = fachKonzept.ListCustomers();
            //cbx_product_select.ItemsSource = fachKonzept.ListProducts();
        }

        public Gui(IFachkonzept iF)
        {
            this.fachKonzept = iF;
            InitializeComponent();
            cbx_customer_select.ItemsSource = fachKonzept.ListCustomers();
            cbx_product_select.ItemsSource = fachKonzept.ListProducts();            
           
        }

        private void btn_create_order(object sender, RoutedEventArgs e)
        {
            int customerId = 0;
            int productId = 0;
            Customer c = fachKonzept.GetCustomer(customerId);
            Product p = fachKonzept.GetProduct(productId);
            int amount;
            int.TryParse(tbx_amount.Text, out amount);
            Order order = new Order(c, p, amount, DateTime.Now);
            fachKonzept.AddOrder(order);
        }

        private void btn_create_product(object sender, RoutedEventArgs e)
        {
            string label = tbx_product_name.Text;
            double price;
            double.TryParse(tbx_product_price.Text, out price);
            Product product = new Product(label, price);
            fachKonzept.AddProduct(product);
        }

        private void btn_create_customer(object sender, RoutedEventArgs e)
        {
            string firstName = tbx_customer_firstname.Text;
            string surName = tbx_customer_surname.Text;
            Customer customer = new Customer(firstName, surName);
            fachKonzept.AddCustomer(customer);
        }
    }
}
