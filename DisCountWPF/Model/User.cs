using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DisCountWPF.Model
{
    public class User:INotifyPropertyChanged
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string city;
        private DateTime birthDay;
        private string userId;
        private string passWord;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }


        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }


        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }


        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string UserID
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged("UserID");
            }
        }


        public string PassWord
        {
            get
            {
                return passWord;
            }
            set
            {
                passWord = value;
                OnPropertyChanged("PassWord");
            }
        }


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public DateTime Birthday
        {
            get { return birthDay; }
            set { birthDay = value; }
        }
        #endregion
    }
}
