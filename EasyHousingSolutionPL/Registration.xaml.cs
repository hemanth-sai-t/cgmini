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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SellersBL sellersBLL = new SellersBL();
        BuyersBL buyersBL = new BuyersBL();
        UserBL userBL = new UserBL();
        public Registration()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                Users newUser = new Users();
                newUser.UserName = txtUsername.Text;
                newUser.Password = pbPassword.Password.ToString();
                newUser.UserType = cbUsertype.Text;

                if (newUser.UserType == "Buyer")
                {
                    Application.Current.Properties["username"] = newUser.UserType;
                    try
                    {
                        userBL.AddUserBL(newUser);
                    }

                    catch (EasyHousingSolutionException ex)
                    {
                        sb.Append(ex.Message.ToString());
                    }

                    Buyer buyer = new Buyer();
                    buyer.UserName = txtUsername.Text;
                    buyer.FirstName = txtFirstname.Text;
                    buyer.LastName = txtLastname.Text;
                    if (dpDob.Text.ToString() != string.Empty)
                    {
                        buyer.DateOfBirth = DateTime.Parse(dpDob.Text.ToString());
                    }
                    else
                    {
                        buyer.DateOfBirth = DateTime.Parse("01-01-1000");
                    }
                    if (txtPhone.Text.ToString() != string.Empty)
                    {
                        buyer.PhoneNo = long.Parse(txtPhone.Text);
                    }
                    else
                    {
                        buyer.PhoneNo = 0;
                    }
                    buyer.EmailId = txtUsername.Text;
                    buyer.Address = txtAddress.Text;

                    if (buyersBL.AddBuyerBL(buyer))
                    {
                        MessageBox.Show("Registered successfully....");
                        Login obj = new Login();
                        this.Hide();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong...");
                    }

                }
                else if (newUser.UserType == "Seller")
                {
                    Application.Current.Properties["username"] = newUser.UserType;
                    try
                    {
                        userBL.AddUserBL(newUser);
                    }

                    catch (EasyHousingSolutionException ex)
                    {
                        sb.Append(ex.Message.ToString());
                    }

                    Seller seller = new Seller();
                    seller.UserName = txtUsername.Text;
                    seller.FirstName = txtFirstname.Text;
                    seller.LastName = txtLastname.Text;
                    if (dpDob.Text.ToString() != string.Empty)
                    {
                        seller.DateofBirth = DateTime.Parse(dpDob.Text.ToString());
                    }
                    else
                    {
                        seller.DateofBirth = DateTime.Parse("01-01-1000");
                    }
                    if (txtPhone.Text.ToString() != string.Empty)
                    {
                        seller.PhoneNo = long.Parse(txtPhone.Text);
                    }
                    else
                    {
                        seller.PhoneNo = 0;
                    }
                    seller.Address = txtAddress.Text;
                    seller.StateName = cbStates.Text;
                    seller.CityName = cbCities.Text;
                    seller.EmailId = txtUsername.Text;
                    if (sellersBLL.AddSellerBL(seller))
                    {
                        MessageBox.Show("Registered successfully....");
                        Login obj = new Login();
                        this.Hide();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong...");
                    }

                }
                else
                {
                    MessageBox.Show("Please select user type");
                }

            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
            }
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbUsertype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string userType = cbUsertype.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                if (userType.Equals("Seller"))
                {
                    txtAddress.IsEnabled = true;
                    cbStates.IsEnabled = true;
                    cbCities.IsEnabled = true;
                }
                else if (userType.Equals("Buyer"))
                {
                    cbStates.IsEnabled = false;
                    cbCities.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {           
                txtAddress.Text = String.Empty;
                txtEmail.Text = String.Empty;
                txtFirstname.Text = String.Empty;
                txtLastname.Text = String.Empty;
                txtPhone.Text = String.Empty;
                txtUsername.Text = String.Empty;
                cbUsertype.Text = "Select";
                cbStates.Text = "Select";
                cbCities.Text = "Select";
                pbPassword.Password = String.Empty;           
        }
    }
}
