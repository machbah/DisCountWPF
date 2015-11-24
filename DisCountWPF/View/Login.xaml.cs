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

namespace DisCountWPF.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private string userId;
        private string passWord;


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            userId = UserID.Text;
            passWord = PassWord.Password;

            var returnedResult= DataStore.Store.AllUser.Find(item => item.UserID.Equals(userId));

            if (returnedResult.PassWord.Equals(passWord))
            {
                DataStore.Store.CurrentUser = returnedResult;

                Uri uri = new Uri("/View/Customer.xaml", UriKind.RelativeOrAbsolute);
                this.NavigationService.Navigate(uri);
            }
            else
                MessageBox.Show("Try again!!"); 
        }
    }
}
