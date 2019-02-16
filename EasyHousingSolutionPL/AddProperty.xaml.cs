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

namespace EasyHousingSolutionPL
{
    /// <summary>
    /// Interaction logic for AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        StringBuilder sb = new StringBuilder();
        PropertyBL propertyBL = new PropertyBL();
        public AddProperty()
        {
            InitializeComponent();
        }

       
        public bool AddPropertyPL()
        {

            Property newProperty = new Property();
            bool IsAdd = false;
            try
            {
                newProperty.PropertyName = txtPropertyName.Text;
                newProperty.PropertyType = CbPropertyType.Text;

                newProperty.Description = txtDescription.Text;
                if(CbState.Text.ToString() == string.Empty)
                {
                    sb.Append("State Required");
                }
                
                newProperty.Address = CbCity.Text;
                
                if (txtPriceRange.Text.ToString() != string.Empty)
                {
                    newProperty.PriceRange = Decimal.Parse(txtPriceRange.Text);
                }
                else
                {
                    newProperty.PriceRange = -1;
                }
                if (txtInitialDeposit.Text.ToString() != string.Empty)
                {
                    newProperty.InitialDeposit = long.Parse(txtInitialDeposit.Text);
                }
                else
                {
                    newProperty.InitialDeposit = -1;
                }

                newProperty.Landmark = txtLandmark.Text;
                if (txtSellerId.Text.ToString() != string.Empty)
                {
                    newProperty.SellerId = int.Parse(txtSellerId.Text);
                }
                else
                {
                    newProperty.SellerId = -1;
                }
               
                IsAdd = propertyBL.AddPropertyBL(newProperty);
            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " +sb.ToString()+ ex.Message);
            }
            return IsAdd;
        }


        private void CbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CbCity.Items.Clear();
                CbCity.Items.Add("Select");
                string stateName = CbState.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();

                if (stateName.Equals("Telangana"))
                {
                    CbCity.Items.Add("Hyderabad");
                    CbCity.Items.Add("Nizamabad");
                }
                else if (stateName.Equals("Maharashtra"))
                {
                    CbCity.Items.Add("Mumbai");
                    CbCity.Items.Add("Pune");
                }
                else if (stateName.Equals("Andhra Pradesh"))
                {
                    CbCity.Items.Add("Visakhapatnam");
                    CbCity.Items.Add("Vijayawada");
                }
                else if (stateName.Equals("Karnataka"))
                {
                    CbCity.Items.Add("Bangalore");
                    CbCity.Items.Add("Mysore");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddPropertyPL())
                {
                    MessageBox.Show("Property Added successfully");
                }
                else
                {
                    MessageBox.Show("Failed to Add property");
                }
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                txtPropertyName.Text = String.Empty;
                CbPropertyType.Text = String.Empty;
                txtDescription.Text = String.Empty;
                CbState.Text = String.Empty;
                CbCity.Text = String.Empty;
                txtPriceRange.Text = String.Empty;
                txtInitialDeposit.Text = String.Empty;
                txtLandmark.Text = String.Empty;
                txtSellerId.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
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
