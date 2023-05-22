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
using System.Windows.Shapes;

namespace Practic.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public CreateOrder()
        {
            InitializeComponent();
            
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_add_order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Date_priemki.Text) && Helper.CheckField(Id_car.Text) && Helper.CheckField(Tabel_number.Text) && Helper.CheckField(Date_get.Text) && Helper.CheckField(Work_time.Text) && Helper.CheckField(Car_trouble.Text) && Helper.CheckField(Job_description.Text))
                {
                    var order = new Order
                    {
                        Date_priemki = Date_priemki.Text,
                        Id_car = Convert.ToInt32(Id_car.Text),
                        Tabel_number = Convert.ToInt32(Tabel_number.Text),
                        Date_get = Date_get.Text,
                        Work_time = Work_time.Text
                    };

                    DB.context.Order.Add(order);
                    DB.context.SaveChanges();

                    MessageBox.Show("Заказ успешно добавлен. Не забудьте откорректировать данные после работ!");
                    this.Close();
                }
                else new Windows.Error("emptyField").Show();
            }
            catch
            {
                new Windows.Error("errorAddOrEdit").Show();
            }
        }
    }
}
