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
using System.Windows.Shapes;
using EasyHousingSolutionBLL;
using EHSException;
using EasyHousingSolutionEntity;
using System.Data;

namespace EasyHousingSolutionPL
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        CartBL cartBL = new CartBL();
        List<Property> cartList = new List<Property>();
        public Cart()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cartList = cartBL.GetAllCartsBL();
            dgCart.DataContext = cartList.Select(x => new { x.PropertyName, x.PropertyType, x.Description, x.Address, x.PriceRange, x.InitialDeposit, x.Landmark }).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EasyHousingSolutionEntity.Cart cart = new EasyHousingSolutionEntity.Cart();
                string propName = txtPropertyName.Text;
                if (cartBL.DeleteCartBL(propName))
                {
                    MessageBox.Show("Cart item deleted successfully...");
                }
                else
                {
                    MessageBox.Show("Something went wrong...");
                }
            }
            catch(EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }
    }
}
