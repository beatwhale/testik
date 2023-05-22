using Practic;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            table.ItemsSource = DB.context.CarTable.ToList();
            table.IsReadOnly = true;
            
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void Button_create_Click(object sender, RoutedEventArgs e)
        {
            new Windows.CreateCar().Show();
        }

        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            CarTable selItem = (CarTable)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Для начала выберите элемент, чтобы его изменить");
            }
            else new Windows.EditCar(selItem).Show();
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            string car = "car";
            object selItem = (CarTable)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент для удаления.");
            }
            else new Windows.DeleteConfirmed(selItem, car).Show();
        }
    }
}
