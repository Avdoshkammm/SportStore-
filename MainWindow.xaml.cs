using SportStoreStonks.Models;
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

namespace SportStoreStonks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();

            statusUser.Text = user.RoleNavigation.Name;

            using (SportStoreContext db = new SportStoreContext())
            {
                if (user != null)
                {
                    statusUser.Text = user.RoleNavigation.Name;
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name} {user.Patronymic}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    MessageBox.Show("Гость");
                }

                productlistView.ItemsSource = db.Products.ToList();
            }

        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExitToFirst_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new LoginWindow();
            log.Show();
            this.Close();

        }

        private void addUserButtonClick(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().ShowDialog();
        }
    }
}
