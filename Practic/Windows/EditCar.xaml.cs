using Practic.Pages;
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
    /// Логика взаимодействия для EditCar.xaml
    /// </summary>
    public partial class EditCar : Window
    {
        public int id { get; set; }
        public EditCar(CarTable car)
        {
            InitializeComponent();
            id = car.Id_car;
            Gos_number.Text = car.Gos_number;
            Car_brand.Text = car.Car_brand;
            Car_year.Text = car.Car_year;
            Car_client_name.Text = car.Car_client_name;
            Car_client_phone.Text = car.Car_client_phone;

        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Gos_number.Text) && Helper.CheckField(Car_brand.Text) && Helper.CheckField(Car_year.Text) && Helper.CheckField(Car_client_name.Text) && Helper.CheckField(Car_client_phone.Text))
                {
                    CarTable car = DB.context.CarTable.Find(id);
                    car.Gos_number = Gos_number.Text;
                    car.Car_brand = Car_brand.Text;
                    car.Car_year = Car_year.Text;
                    car.Car_client_name = Car_client_name.Text;
                    car.Car_client_phone = Car_client_phone.Text;
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

        private void Button_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
