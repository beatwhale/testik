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
using System.Windows.Navigation;

namespace Practic.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateMechanic.xaml
    /// </summary>
    public partial class CreateMechanic : Window
    {
        public CreateMechanic()
        {
            InitializeComponent();
        }

        private void Button_create_mechanic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Mechanic_name.Text) && Helper.CheckField(Mechanic_lvl.Text))
                {
                    var mechanic = new MechanicTable
                    {
                        Mechanic_name = Mechanic_name.Text,
                        Mechanic_lvl = Mechanic_lvl.Text,
                    };

                    DB.context.MechanicTable.Add(mechanic);
                    DB.context.SaveChanges();
                    this.Close();
                    MessageBox.Show("Успешно. Механик добавлен в базу данных, обновите страницу.");
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
    }
}
