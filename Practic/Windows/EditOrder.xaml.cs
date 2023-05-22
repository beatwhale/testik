using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public int id
        {
            get; set;
        }
        public EditOrder(Order order)
        {
            InitializeComponent();
            id = order.Id;
            Date_priemki.Text = order.Date_priemki;
            Tabel_number.Text = order.Tabel_number.ToString();
            Id_car.Text = order.ToString();
            Date_get.Text = order.Date_get;
            Car_trouble.Text = order.Car_trouble;
            Job_description.Text = order.Job_description;
            Work_time.Text = order.Work_time;
        }

  
        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Date_priemki.Text) && Helper.CheckField(Tabel_number.Text) && Helper.CheckField(Id_car.Text) && Helper.CheckField(Date_get.Text) && Helper.CheckField(Car_trouble.Text) && Helper.CheckField(Job_description.Text) && Helper.CheckField(Work_time.Text))
                {
                    Order order = DB.context.Order.Find(id);
                    order.Date_priemki = Date_priemki.Text;
                    order.Tabel_number = Convert.ToInt32(Tabel_number.Text);
                    order.Id_car = Convert.ToInt32(Id_car.Text);
                    order.Date_get = Date_get.Text;
                    order.Car_trouble = Car_trouble.Text;
                    order.Job_description = Job_description.Text;
                    order.Work_time = Work_time.Text;
                    DB.context.SaveChanges();
                    this.Close();
                    MessageBox.Show("Успешно. Данные обновлены.");

                }
                else new Windows.Error("emptyField").Show();
            }
            catch
            {
                new Windows.Error("errorAddOrEdit").Show();
            }
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
