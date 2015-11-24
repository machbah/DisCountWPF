using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisCountWPF.Model
{
    public class ProductData:INotifyPropertyChanged
    {
        private string productName;
        private string imageUrl;
        private string price;
        private string id;


        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }


        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }


        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }

        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public ProductData(string id,string ProductName, string ImagePath, string Price)
        {
            this.ProductName = ProductName;
            this.ImageUrl = ImagePath;
            this.Price = Price;
            this.ID = id;
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
     
        #endregion
    }
}
