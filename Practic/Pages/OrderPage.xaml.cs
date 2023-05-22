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

namespace Practic.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            table.ItemsSource = DB.context.Order.ToList();
            table.IsReadOnly = true;
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void Button_create_Order_Click(object sender, RoutedEventArgs e)
        {
            new Windows.CreateOrder().Show();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            string order = "order";
            object selItem = (Order)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент для удаления.");
            }
            else new Windows.DeleteConfirmed(selItem, order).Show();
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            Order selItem = (Order)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Вы не выбрали какой либо элемент в таблице.");
            }
            else new Windows.EditOrder(selItem).Show();
        }
    }
}
