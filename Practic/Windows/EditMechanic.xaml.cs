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
    /// Логика взаимодействия для EditMechanic.xaml
    /// </summary>
    public partial class EditMechanic : Window
    {
        public int id { get; set; }
        public EditMechanic(MechanicTable mechanic)
        {
            InitializeComponent();
            id = mechanic.Tabel_number;
            Mechanic_name.Text = mechanic.Mechanic_name;
            Mechanic_lvl.Text = mechanic.Mechanic_lvl;
        }
        private void Button_update_mechanic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.CheckField(Mechanic_name.Text) && Helper.CheckField(Mechanic_lvl.Text))
                { 
                    MechanicTable mechanic = DB.context.MechanicTable.Find(id);
                    mechanic.Mechanic_name = Mechanic_name.Text;
                    mechanic.Mechanic_lvl = Mechanic_lvl.Text;                 
                    DB.context.SaveChanges();
                    this.Close();
                    MessageBox.Show("Успешно. Данные обновлены, пожалуйста обновите страницу.");

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
