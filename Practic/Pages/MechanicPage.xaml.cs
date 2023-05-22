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
    /// Логика взаимодействия для MechanicPage.xaml
    /// </summary>
    public partial class MechanicPage : Page
    {
        public MechanicPage()
        {
            InitializeComponent();
            table.ItemsSource = DB.context.MechanicTable.ToList();
            table.IsReadOnly = true;
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void Button_create_Click(object sender, RoutedEventArgs e)
        {
            new Windows.CreateMechanic().Show();
        }

        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            MechanicTable selItem = (MechanicTable)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Вы не выбрали какой либо элемент в таблице.");
            }
            else new Windows.EditMechanic(selItem).Show();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            string mechanic = "mechanic";
            object selItem = (MechanicTable)table.SelectedItem;
            if (selItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент для удаления.");
            }
            else new Windows.DeleteConfirmed(selItem, mechanic).Show();
        }
    }
}
