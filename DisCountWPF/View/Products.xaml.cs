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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
          
            InitializeComponent();
            this.Loaded += Products_Loaded;
        }

        void Products_Loaded(object sender, RoutedEventArgs e)
        {
            lstProduct.ItemsSource = DataStore.Store.AllProduct;
        }

        
    }
}
