using DisCountWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisCountWPF.DataStore
{
    public class Store
    {
        private static List<User> allUser;
        private static User currentUser;
        private static List<ProductData> allProduct;

        private Store()
        {
            
        }
        public static void PrepareProductList()
        {
            DataStore.Store.AllProduct.Clear();
            DataStore.Store.AllProduct.Add(new Model.ProductData("1", "IPhone 6", "iphone.jpg", "300"));
            DataStore.Store.AllProduct.Add(new Model.ProductData("2", "Iphone 5", "", "200"));
            DataStore.Store.AllProduct.Add(new Model.ProductData("3", "Ipad", "", "500"));
            DataStore.Store.AllProduct.Add(new Model.ProductData("4", "Macbook Air", "", "1000"));
            DataStore.Store.AllProduct.Add(new Model.ProductData("5", "Macbook Pro", "", "2000"));
        }

        public static User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = new User();
                }
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public static List<User> AllUser
        {
            get
            {
                if(allUser==null)
                {
                    allUser = new List<User>();
                }
                return allUser;
            }
        }

        public static List<ProductData> AllProduct
        {
            get
            {
                if (allProduct == null)
                {
                    allProduct = new List<ProductData>();
                }
                return allProduct;
            }
        }
    }
}
