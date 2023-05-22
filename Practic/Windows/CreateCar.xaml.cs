using Practic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Window
    {
        public CreateCar()
        {
            InitializeComponent();
        }
        private void Button_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Gos_number.Text) && Helper.CheckField(Car_brand.Text) && Helper.CheckField(Car_year.Text) && Helper.CheckField(Car_client_name.Text) && Helper.CheckField(Car_client_phone.Text)) 
                {
                    var car = new CarTable
                    {
                        Gos_number = Gos_number.Text,
                        Car_brand = Car_brand.Text,
                        Car_year = Car_year.Text,
                        Car_client_name = Car_client_name.Text,
                        Car_client_phone = Car_client_phone.Text
                    };

                    DB.context.CarTable.Add(car);
                    DB.context.SaveChanges();

                    MessageBox.Show("Успешно. Машина добавлена.");
                    this.Close();
                }
                else new Windows.Error("emptyField").Show();
            }
            catch
            {
                new Windows.Error("errorAddOrEdit").Show();
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
