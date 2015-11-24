using DisCountWPF.Model;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string city;
        private DateTime birthDay;
        private string userId;
        private string passWord;

        public Register()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            firstName = FirstName.Text;
            middleName = MiddleName.Text;
            lastName = LastName.Text;
            city = CityName.Text;


            if (Birthdate.SelectedDate != null)
                birthDay = (DateTime)Birthdate.SelectedDate;
       

            userId = UserID.Text;
            passWord = PassWord.Password;

            string reConfirmed = RePassWord.Password;

            bool passed = true;

            if (!passWord.Equals(reConfirmed))
            {
                MessageBox.Show("Password not matched");
                passed=false;
            }
            if(birthDay.Equals(new DateTime()))
            {
                MessageBox.Show("Please put birthday");
                passed=false;
            }


            if(userId.Equals(""))
            {
                MessageBox.Show("Please Provide A user Name");
                passed=false;
            }

            if (passed)
            {
                User singleUser = new User();

                singleUser.FirstName = firstName;
                singleUser.MiddleName = middleName;
                singleUser.LastName = lastName;
                singleUser.City = city;
                singleUser.Birthday = birthDay;
                singleUser.UserID = userId;
                singleUser.PassWord = passWord;

                DataStore.Store.AllUser.Add(singleUser);
                MessageBox.Show("User Added Sucessfully");

                Uri uri = new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute);
                this.NavigationService.Navigate(uri);
            }
            
        }
    }
}
