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
    /// Interaction logic for VerifyDeactivate.xaml
    /// </summary>
    public partial class VerifyDeactivate : Window
    {
        PropertyBL propertyBLL = new PropertyBL();
       
        public VerifyDeactivate()
        {
            InitializeComponent();
        }
       
        private void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyPropertyPL())
            {
                MessageBox.Show("Verified"); 
            }
            else
            {
                MessageBox.Show("Failed to verify product");
            }
        }
        public bool VerifyPropertyPL()
        {           
            Property verifyProperty = new Property();
            bool propertyVerified = false;
            if (verifyProperty != null)
            {
                verifyProperty.PropertyId = int.Parse(txtPropertyId.Text);               

                propertyVerified = propertyBLL.VerifyPropertyBL(verifyProperty);

            }
            return propertyVerified;
        }

        private void btndeactivate_Click(object sender, RoutedEventArgs e)
        {

            if (DeacivatePropertyPL())
            {
                MessageBox.Show("Deactivated");
            }
            else
            {
                MessageBox.Show("Failed to deactivate product");
            }
        }
        public bool DeacivatePropertyPL()
        {
            Property deactivateProperty = new Property();
            deactivateProperty.PropertyId = int.Parse(txtPropertyId.Text);
            bool propertyDeactivated = false;

            propertyDeactivated = propertyBLL.DeactivatePropertyBL(deactivateProperty);

            return propertyDeactivated;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }
    }

}
