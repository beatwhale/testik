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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.Pages;
using Test.AppDataFile;
using Test.Navigation;

namespace Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBook.xaml
    /// </summary>
    public partial class PageBook : Page
    {
        public PageBook()
        {
            InitializeComponent();
            var DataBook = ConnectOdb.connectObj.Book.ToList();
            ListBook.ItemsSource = DataBook;

            // ListProduct.ItemsSource = ConnectOdb.connectObj.BookSet.Where (x => x.Name.StartsWith(TextBlockSearch.Text)).ToList(); Poisk

        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEditBook((sender as Button).DataContext as Book));
        }
    }
}
