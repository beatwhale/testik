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
    /// Логика взаимодействия для DeleteConfirmed.xaml
    /// </summary>
    public partial class DeleteConfirmed : Window
    {
        public object ItemVar { get; set; }
        public string TypeVar { get; set; }
        public DeleteConfirmed(object itemObj, string typeObj)
        {
            InitializeComponent();
            ItemVar = itemObj;
            TypeVar = typeObj;
        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeVar == "mechanic")
                {
                    MechanicTable item = (MechanicTable)ItemVar;
                    DB.context.MechanicTable.Remove(item);
                    DB.context.SaveChanges();
                    MessageBox.Show("Успешно. Механик был удален, пожалуйста, обновите страницу.");
                    this.Close();
                }
                if (TypeVar == "car")
                {
                    CarTable item = (CarTable)ItemVar;
                    DB.context.CarTable.Remove(item);
                    DB.context.SaveChanges();
                    MessageBox.Show("Успешно. Машина была удалена, пожалуйста, обновите страницу.");
                    this.Close();
                }
                if (TypeVar == "order")
                {
                    Order item = (Order)ItemVar;
                    DB.context.Order.Remove(item);
                    DB.context.SaveChanges();
                    MessageBox.Show("Успешно. Наряд был удален, пожалуйста, обновите страницу.");
                    this.Close();
                }
            }
            catch
            {
                new Windows.Error("errorDelete").Show();
            }
        }
        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
