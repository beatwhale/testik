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
    /// Логика взаимодействия для Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        public Error(string error_method)
        {
            InitializeComponent();
            switch (error_method)
            {
                case "errorAddOrEdit":
                    message.Text = "Были введены некорректные данные. Необходимо заполнить форму заново.";
                    message.Width = 600;
                    break;
                case "emptyField":
                    message.Text = "Один или несколько полей были не заполнены. Попробуйте еще раз ";
                    message.Width = 600;
                    break;
                case "errorDelete":
                    message.Text = "Этот объект невозможно удалить, т.к. он используется в другой таблице. Необходимо удалить все упоминания этого объекта в других таблицах.";
                    message.Width = 800;
                    message.FontSize = 16;
                    break;
                default:
                    message.Text = "Произошла ошибка! Повторите операцию снова";
                    message.Width = 500;
                    break;
            }
        }

        private void Btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
