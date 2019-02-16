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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        StringBuilder sb = new StringBuilder();
        PropertyBL propertyBL = new PropertyBL();
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string propName = txtPropertyName.Text;
                List<Property> prop = propertyBL.GetAllPropertyBL();
                if(prop == null && prop.Count<=0)
                {
                    sb.Append("Enter valid property name");
                }
                List<Property> pr = prop.Where(p => p.PropertyName == propName).ToList();
                dgSearchProperty.DataContext = pr;
            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " + sb.ToString() + ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtPropertyName.Text = String.Empty;
            dgSearchProperty.ItemsSource = null;
            dgSearchProperty.Columns.Clear();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }
    }
}
