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
using EasyHousingSolutionEntity;
using EHSException;
using EasyHousingSolutionBLL;

namespace EasyHousingSolutionPL
{
    /// <summary>
    /// Interaction logic for ViewProperty.xaml
    /// </summary>
    public partial class ViewProperty : Window
    {
        PropertyBL propertyBL = new PropertyBL();
        CartBL cartBL = new CartBL();
        EasyHousingSolutionEntity.Cart addCart = new EasyHousingSolutionEntity.Cart();
        BuyersBL buyersBL = new BuyersBL();
        string BuyerName = null;
        List<Property> propList = new List<Property>();
       // ImageBL imageBL = new ImageBL();
       
        public ViewProperty()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string uname = Application.Current.Properties["username"].ToString();
                if (uname.Equals("Admin"))
                {
                    btnDelete.Visibility = Visibility.Visible;
                }
                else
                {
                    BuyerName = Application.Current.Properties["BuyerName"].ToString();
                    btnAddToCart.Visibility = Visibility.Visible;
                }
                    propList =propertyBL.GetAllPropertyBL();
                dgViewAllData.DataContext = propList;
            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnShow_details_Click(object sender, RoutedEventArgs e)
        {
            Property property = (Property)dgViewAllData.SelectedItem;           
            addCart.PropertyId= property.PropertyId;
            txtPropName.Text = property.PropertyName;
            txtPropType.Text = property.PropertyType;
            txtPrice.Text = property.PriceRange.ToString();
            txtLandmark.Text = property.Landmark;
            txtAddress.Text = property.Address;
            txtSeller.Text = property.SellerId.ToString();
            txtInitialDeposit.Text = property.InitialDeposit.ToString();
            txtDes.Text = property.Description;
           // Images imgObj = imageBL.GetImageBL(property.PropertyId);
            //imgProperty.im imgObj.Image
            // imgProperty.Source = new BitmapImage(new Uri(imgObj.Image, UriKind.Relative));
           // imgProperty.Source =( imgObj.Image);
    //        imgProperty.Source = new BitmapImage(
    //new Uri(imgObj.Image));
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            int id=buyersBL.getBuyerIdBL(BuyerName);
            addCart.BuyerId = id;
           if(cartBL.AddCartBL(addCart))
            {
                MessageBox.Show("Product added to cart...");
            }
            else{
                MessageBox.Show("Failed to add to cart");
            }
        }

        private void btnSortByPrice_Click(object sender, RoutedEventArgs e)
        {
            var sortedData = propList.OrderBy(p => p.PriceRange);            
            dgViewAllData.DataContext = (List < Property >)sortedData.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Property property = (Property)dgViewAllData.SelectedItem;
            if(propertyBL.DeletePropertyBL( property.PropertyId))
            {
                MessageBox.Show("Property deleted successfully...");
            }
            else
            {
                MessageBox.Show("Failed to delete");
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
