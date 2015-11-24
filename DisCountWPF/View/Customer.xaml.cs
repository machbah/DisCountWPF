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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        User currentUser;
        int row;

        public Customer()
        {
            currentUser = DataStore.Store.CurrentUser;
            InitializeComponent();
            LoadItems();
            row = 0;
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/View/Products.xaml", UriKind.RelativeOrAbsolute);
            this.NavigationService.Navigate(uri);
        }

        private void OrderADD_Click(object sender, RoutedEventArgs e)
        {
            Label tb = new Label();
            tb.Content = "Item ID";
            Grid.SetRow(tb, row);
            Grid.SetColumn(tb, 0);

            TextBox itemNumber = new TextBox();
            itemNumber.Name = "item" + row;
            Grid.SetRow(itemNumber, row);
            Grid.SetColumn(itemNumber, 1);


            Label tb1 = new Label();
            tb1.Content = "Quantity";
            Grid.SetRow(tb1, row);
            Grid.SetColumn(tb1, 2);

            TextBox itemNumber1 = new TextBox();
            itemNumber1.Name = "quantity" + row;
            Grid.SetRow(itemNumber1, row);
            Grid.SetColumn(itemNumber1, 3);

            OrderItemGrid.Children.Add(tb);
            OrderItemGrid.Children.Add(tb1);
            OrderItemGrid.Children.Add(itemNumber);
            OrderItemGrid.Children.Add(itemNumber1);

            RowDefinition rd = new RowDefinition();
            OrderItemGrid.RowDefinitions.Add(rd);

            row++;
        }

        void LoadItems()
        {
            NameInfo.Content = "Welcome " +currentUser.FirstName + " " + currentUser.MiddleName + " " + currentUser.LastName;
            UserID.Content = currentUser.UserID;
            
            // defining discount schemas
            Random random=new Random();
            int randNumber =random.Next(1,100);

            if (randNumber % 2 == 0)
                DiscountSchema.Content = "Single Highest Schema";
            else
                DiscountSchema.Content = "Multiple Discount Schema";

            DiscountSchema.Foreground= new SolidColorBrush(Colors.Red);



        }
        
        private class priceList
        {
           public int id;
           public int quantity;
           public double price;
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<priceList> list = new List<priceList>();

                for (int i = 0; i < row; i++)
                {
                    var textbox = (TextBox)OrderItemGrid.Children.Cast<UIElement>().First(e1 => Grid.GetRow(e1) == i && Grid.GetColumn(e1) == 1);
                    var quantity = (TextBox)OrderItemGrid.Children.Cast<UIElement>().First(e1 => Grid.GetRow(e1) == i && Grid.GetColumn(e1) == 3);

                    int item;
                    int intquantity;

                    Int32.TryParse(textbox.Text.ToString(), out item);
                    Int32.TryParse(quantity.Text.ToString(), out intquantity);

                    if (item != 0 && intquantity != 0)
                    {
                        var t = list.Find(item1 => item1.id.Equals(item));
                        var priceTem = DataStore.Store.AllProduct.Find(item1 => item1.ID.Equals(item.ToString()));

                        if (t == null)
                        {
                            priceList pc = new priceList();
                            pc.id = item;
                            pc.quantity = intquantity;
                            pc.price = pc.quantity * Double.Parse(priceTem.Price);

                            list.Add(pc);
                        }
                        else
                        {
                            t.quantity += intquantity;
                            t.price = t.quantity * Double.Parse(priceTem.Price);
                        }
                    }
                }

                double fivePercent;
                double tenPercent;
                double fifteenPercent;
                double twentyPercent;

                double largest = 0;
                string reason = "";

                if (row == 0 || list.Count() == 0)
                    return;

                if (DiscountSchema.Content.Equals("Single Highest Schema"))
                {
                    //5% off if you buy 2 iphone 6 –“Iphone 6 Discount”
                    var temp = list.Find(item1 => item1.id.Equals(1));

                    if (temp.quantity == 2)
                    {
                        var priceTem = DataStore.Store.AllProduct.Find(item1 => item1.ID.Equals("1"));

                        fivePercent = (5 * temp.quantity * Int32.Parse(priceTem.Price)) / 100;
                        largest = fivePercent;
                        reason = "Iphone 6 Discount";
                    }

                    //10% off if its customers birthday on the day of ordering any product. – “Birthday Discount”

                    DateTime today = DateTime.Today;

                    int monthdiff = currentUser.Birthday.Month - today.Month;

                    int daydiff = currentUser.Birthday.Day - today.Day;

                    int yearDiff = currentUser.Birthday.Year - today.Year;

                    double sum = list.Sum(item => item.price);

                    if (monthdiff == 0 && daydiff == 0 && yearDiff != 0)
                    {
                        tenPercent = (10 * sum) / 100;

                        if (tenPercent > largest)
                        {
                            largest = tenPercent;
                            reason = "Birthday Discount";
                        }
                    }

                    //15% off if customer is more than 50 years old  - “Senior Citizen Discount”

                    if (yearDiff > 50)
                    {
                        fifteenPercent = (15 * sum) / 100;

                        if (fifteenPercent > largest)
                        {
                            largest = fifteenPercent;
                            reason = "Senior Citizen Discount";
                        }
                    }

                    //20% off if order total is more than £3000 – “High Value Order Discount”

                    if (sum > 3000)
                    {
                        twentyPercent = (20 * sum) / 100;

                        if (twentyPercent > largest)
                        {
                            largest = twentyPercent;
                            reason = "High Value Order Discount";
                        }
                    }

                    DisList.Text = reason + "\n " + "Single Highest Schema";
                    DisPrice.Text = (sum - largest).ToString();
                }
                else
                {
                    fifteenPercent = 0;
                    tenPercent = 0;
                    fivePercent = 0;
                    twentyPercent = 0;

                    //5% off if you buy 2 iphone 6 –“Iphone 6 Discount”
                    var temp = list.Find(item1 => item1.id.Equals(1));

                    if (temp.quantity == 2)
                    {
                        var priceTem = DataStore.Store.AllProduct.Find(item1 => item1.ID.Equals("1"));

                        fivePercent = (5 * temp.quantity * Int32.Parse(priceTem.Price)) / 100;
                        //largest = fivePercent;
                        reason = "Iphone 6 Discount";
                    }

                    //10% off if its customers birthday on the day of ordering any product. – “Birthday Discount”

                    DateTime today = DateTime.Today;

                    int monthdiff = currentUser.Birthday.Month - today.Month;

                    int daydiff = currentUser.Birthday.Day - today.Day;

                    int yearDiff = currentUser.Birthday.Year - today.Year;

                    double sum = list.Sum(item => item.price);

                    if (monthdiff == 0 && daydiff == 0 && yearDiff != 0)
                    {
                        tenPercent = (10 * sum) / 100;

                        reason += " \n Birthday Discount";
                    }

                    //15% off if customer is more than 50 years old  - “Senior Citizen Discount”

                    if (yearDiff > 50)
                    {
                        fifteenPercent = (15 * sum) / 100;

                        reason += " \n Senior Citizen Discount";
                    }

                    //20% off if order total is more than £3000 – “High Value Order Discount”

                    if (sum > 3000)
                    {
                        twentyPercent = (20 * sum) / 100;

                        reason += " \n High Value Order Discount";
                    }

                    DisList.Text = reason + "\n " + "Multiple Discount Schema";
                    DisPrice.Text = (sum - (fivePercent + tenPercent + fifteenPercent + twentyPercent)).ToString();
                }

                string originalPrice = "";

                foreach (priceList pl in list)
                {
                    originalPrice += "Item no " + pl.id + " cost is " + pl.price;
                }

                OriPrice.Text = originalPrice;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Try Again");
            }
        }
    }
    
}
