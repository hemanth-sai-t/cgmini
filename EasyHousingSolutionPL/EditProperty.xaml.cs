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

namespace EasyHousingSolutionPL{
//    / <summary>
//    / Interaction logic for EditProperty.xaml
//    / </summary>
    public partial class EditProperty : Window
    {
        EasyHousingSolutionBLL.PropertyBL propertyBL = new EasyHousingSolutionBLL.PropertyBL();

        public EditProperty()
        {
            InitializeComponent();
        }
        private void cbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbCities.Items.Clear();
                cbCities.Items.Add("Select");
                string stateName = cbStates.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();

                if (stateName.Equals("Telangana"))
                {
                    cbCities.Items.Add("Hyderabad");
                    cbCities.Items.Add("Nizamabad");
                }
                else if (stateName.Equals("Maharashtra"))
                {
                    cbCities.Items.Add("Mumbai");
                    cbCities.Items.Add("Pune");
                }
                else if (stateName.Equals("Andhra Pradesh"))
                {
                    cbCities.Items.Add("Visakhapatnam");
                    cbCities.Items.Add("Vijayawada");
                }
                else if (stateName.Equals("Karnataka"))
                {
                    cbCities.Items.Add("Bangalore");
                    cbCities.Items.Add("Mysore");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        public void SearchPropertyPL()
        {
            try
            {
                int PropertyId = int.Parse(txtPropertyId.Text);
                Property searchProperty = propertyBL.SearchPropertyBL(PropertyId);
                if (searchProperty != null)
                {
                    MessageBox.Show("Record Found");
                    txtPropertyName.Text = searchProperty.PropertyName;
                    CbPropertyType.Text = searchProperty.PropertyType;
                    txtDescription.Text = searchProperty.Description;
                   // txtAddress.Text = searchProperty.Address;
                    txtPriceRange.Text = searchProperty.PriceRange.ToString();
                    txtInitialDeposite.Text = searchProperty.InitialDeposit.ToString();
                    txtLandmark.Text = searchProperty.Landmark;
                    txtSellerId.Text = searchProperty.SellerId.ToString();
                }
                else
                {
                    MessageBox.Show("Record not Found");
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


        public bool EditPropertyPL()
        {
            int PropertyId = int.Parse(txtPropertyId.Text);
            Property editProperty = propertyBL.SearchPropertyBL(PropertyId);
            bool PropertyEdited = false;
            try
            {
                if (editProperty != null)
                {
                    editProperty.PropertyId = int.Parse(txtPropertyId.Text);
                    editProperty.PropertyName = txtPropertyName.Text;

                    editProperty.PropertyType = CbPropertyType.Text;
                    editProperty.Description = txtDescription.Text;
                    editProperty.Address = cbCities.Text;
                    editProperty.PriceRange = decimal.Parse(txtPriceRange.Text);
                    editProperty.InitialDeposit = decimal.Parse(txtInitialDeposite.Text);
                    editProperty.Landmark = txtLandmark.Text;
                    editProperty.SellerId = int.Parse(txtSellerId.Text);


                    PropertyEdited = propertyBL.EditPropertyBL(editProperty);

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
            return PropertyEdited;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            SearchPropertyPL();
        }

        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EditPropertyPL())
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Failed to update Property");
                }
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
        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                txtPropertyName.Text = String.Empty;
                CbPropertyType.Text = String.Empty;
                txtDescription.Text = String.Empty;
               // txtAddress.Text = String.Empty;
                txtPriceRange.Text = String.Empty;
                txtInitialDeposite.Text = String.Empty;
                txtLandmark.Text = String.Empty;
                txtSellerId.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using EasyHousingSolutionBLL;
//using EHSException;
//using EasyHousingSolutionEntity;

//namespace EasyHousingSolutionPL
//{
//    / <summary>
//    / Interaction logic for EditProperty.xaml
//    / </summary>
//    public partial class EditProperty : Window
//    {
//        StringBuilder sb = new StringBuilder();
//        PropertyBL propertyBL = new PropertyBL();

//        public EditProperty()
//        {
//            InitializeComponent();
//        }
//        private void cbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            try
//            {
//                cbCities.Items.Clear();
//                cbCities.Items.Add("Select");
//                string stateName = cbStates.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();

//                if (stateName.Equals("Telangana"))
//                {
//                    cbCities.Items.Add("Hyderabad");
//                    cbCities.Items.Add("Nizamabad");
//                }
//                else if (stateName.Equals("Maharashtra"))
//                {
//                    cbCities.Items.Add("Mumbai");
//                    cbCities.Items.Add("Pune");
//                }
//                else if (stateName.Equals("Andhra Pradesh"))
//                {
//                    cbCities.Items.Add("Visakhapatnam");
//                    cbCities.Items.Add("Vijayawada");
//                }
//                else if (stateName.Equals("Karnataka"))
//                {
//                    cbCities.Items.Add("Bangalore");
//                    cbCities.Items.Add("Mysore");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex);
//            }
//        }
//        public void SearchPropertyPL()
//        {
//            int PropertyId = 0;
//            Property searchProperty = null;
//            try
//            {
//                if (txtPropertyId.Text.ToString() != string.Empty)
//                {
//                    PropertyId = int.Parse(txtPropertyId.Text);
//                    searchProperty = propertyBL.SearchPropertyBL(PropertyId);
//                }
//                else
//                {
//                    sb.Append("Property id required");
//                }

//                if (searchProperty != null)
//                {
//                    MessageBox.Show("Record Found");
//                    txtPropertyName.Text = searchProperty.PropertyName;
//                    CbPropertyType.Text = searchProperty.PropertyType;
//                    txtDescription.Text = searchProperty.Description;
//                    txtPriceRange.Text = searchProperty.PriceRange.ToString();
//                    txtInitialDeposite.Text = searchProperty.InitialDeposit.ToString();
//                    txtLandmark.Text = searchProperty.Landmark;
//                    txtSellerId.Text = searchProperty.SellerId.ToString();
//                }
//                else
//                {
//                    MessageBox.Show("Record not Found");
//                }
//            }
//            catch (EasyHousingSolutionException ex)
//            {
//                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
//            }
//        }


//        public bool EditPropertyPL()
//        {
//            int PropertyId = 0;
//            Property editProperty = null;
//            if (txtPropertyId.Text.ToString() != string.Empty)
//            {
//                PropertyId = int.Parse(txtPropertyId.Text);
//            }
//            else
//            {
//                sb.Append("Property id required");
//            }

//            bool PropertyEdited = false;
//            try
//            {
//                if (editProperty != null)
//                {
//                    editProperty.PropertyId = int.Parse(txtPropertyId.Text);
//                    editProperty.PropertyName = txtPropertyName.Text;
//                    editProperty.PropertyType = CbPropertyType.Text;
//                    editProperty.Description = txtDescription.Text;
//                    if (cbStates.Text.ToString() == string.Empty)
//                    {
//                        sb.Append("State Required");
//                    }
//                    if (txtPriceRange.Text.ToString() != string.Empty)
//                    {
//                        editProperty.PriceRange = Decimal.Parse(txtPriceRange.Text);
//                    }
//                    else
//                    {
//                        editProperty.PriceRange = -1;
//                    }
//                    if (txtInitialDeposite.Text.ToString() != string.Empty)
//                    {
//                        editProperty.InitialDeposit = long.Parse(txtInitialDeposite.Text);
//                    }
//                    else
//                    {
//                        editProperty.InitialDeposit = -1;
//                    }

//                    editProperty.Landmark = txtLandmark.Text;
//                    if (txtSellerId.Text.ToString() != string.Empty)
//                    {
//                        editProperty.SellerId = int.Parse(txtSellerId.Text);
//                    }
//                    else
//                    {
//                        editProperty.SellerId = -1;
//                    }

//                    editProperty.Address = cbCities.Text;

//                    PropertyEdited = propertyBL.EditPropertyBL(editProperty);
//                }

//            }
//            catch (EasyHousingSolutionException ex)
//            {
//                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
//            }
//            return PropertyEdited;
//        }

//        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
//        {
//            SearchPropertyPL();
//        }

//        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                if (EditPropertyPL())
//                {
//                    MessageBox.Show("Updated");
//                }
//                else
//                {
//                    MessageBox.Show("Failed to update property");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
//            }
//        }

//        private void btnReset_Click_1(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                txtPropertyName.Text = String.Empty;
//                CbPropertyType.Text = String.Empty;
//                txtDescription.Text = String.Empty;
//                txtAddress.Text = String.Empty;
//                txtPriceRange.Text = String.Empty;
//                txtInitialDeposite.Text = String.Empty;
//                txtLandmark.Text = String.Empty;
//                txtSellerId.Text = String.Empty;
//                cbCities.Text = "Select";
//                cbStates.Text = "Select";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex);
//            }
//        }

//        private void Hyperlink_Click(object sender, RoutedEventArgs e)
//        {

//            Login obj = new Login();
//            this.Hide();
//            obj.Show();

//        }
//    }
//}
