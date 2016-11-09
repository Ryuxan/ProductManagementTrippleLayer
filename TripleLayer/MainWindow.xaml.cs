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

namespace TripleLayer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFachkonzept fachKonzept;

        public MainWindow(IFachkonzept fk)
        {
            this.fachKonzept = fk;
            InitializeComponent();
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
            fachKonzept.AddCostomer(customer);
        }
    }
}
