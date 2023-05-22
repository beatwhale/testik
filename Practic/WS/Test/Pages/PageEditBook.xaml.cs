using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using Test.AppDataFile;

namespace Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditBook.xaml
    /// </summary>
    public partial class PageEditBook : Page
    {
        public PageEditBook(Book book)
        {
            InitializeComponent();
            ComboBoxCategory.SelectedIndex = (int)book.Category_id - 1;
            ComboBoxCategory.SelectedValuePath = "Id";
            ComboBoxCategory.DisplayMemberPath = "Category";
            ComboBoxCategory.ItemsSource = ConnectOdb.connectObj.BookCategory.ToList();

            BookObj.Id = book.Id;
            TextBoxAuthor.Text = book.Author;
            TextBoxName.Text = book.Name;
            //TextCost.Text = Convert.ToString(book.Cost);
            //TxtImage.Text = book.ImagePath;

            //if (book.IsActove != false {
                 //RadioBActive.IsChecked = true);
                  // } else {RadioBNotActive.IsChecked = true;
                  // logicRb = false; }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {   try { 
            IEnumerable<Book> books = ConnectOdb.connectObj.Book.Where(x => x.Id == BookObj.Id).AsEnumerable().
            Select(x =>
            {
                x.Name = TextBoxName.Text;
                x.Author = TextBoxAuthor.Text;
                x.Category_id = (int)ComboBoxCategory.SelectedValue;
                return x;

                /* x.Cost = Convert.ToDecimal(TextCost.Text);

                 if (string.IsNullOrWhiteSpace(TextBoxDescription.Text))
                 {
                     x.Description = "";
                 }
                 else
                 {
                     x.Description = TextBoxDescription.Text;
                 }
                 -- is null ?*/

            });
            foreach (Book bookk in books)
            {
                ConnectOdb.connectObj.Entry(bookk).State = System.Data.Entity.EntityState.Modified;
            }
            ConnectOdb.connectObj.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            } 
        }

    }
}
