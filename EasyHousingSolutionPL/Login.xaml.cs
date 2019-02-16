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
using EasyHousingSolutionBLL;
using EHSException;

namespace EasyHousingSolutionPL
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        StringBuilder sb = new StringBuilder();
        UserBL userBL = new UserBL();
        public Login()
        {
            InitializeComponent();
        }

     
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users newUser = new Users();
                newUser.UserName = txtUsername.Text;
                newUser.Password = txtPassword.Password.ToString();
                if (cbUserType.Text.ToString() == string.Empty)
                {
                    sb.Append("User type Required");
                }
                newUser.UserType = cbUserType.Text;
                if (userBL.getPasswordBLL(newUser))
                {
                    if (newUser.UserType == "Buyer")
                    {
                        Application.Current.Properties["username"] = newUser.UserType;
                        Application.Current.Properties["BuyerName"] = newUser.UserName;
                    }
                    else if (newUser.UserType == "Seller")
                    {
                        Application.Current.Properties["username"] = newUser.UserType;
                    }
                    else if (newUser.UserType == "Admin")
                    {
                        Application.Current.Properties["username"] = newUser.UserType;
                    }
                    if (!(newUser.UserType == "Select"))
                    {
                        MainWindow obj = new MainWindow();
                        this.Hide();
                        obj.Show();
                    }
                }

                else
                {
                    MessageBox.Show("Invalid details...");
                }
            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
            }
           
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration obj = new Registration();
            this.Hide();
            obj.Show();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
              txtUsername.Text = String.Empty;
                txtPassword.Password = String.Empty;
                cbUserType.Text = String.Empty;           
        }
    }
}
