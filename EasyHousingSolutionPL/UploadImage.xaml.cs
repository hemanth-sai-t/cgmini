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
using EasyHousingSolutionEntity;
using EHSException;
using Microsoft.Win32;

namespace EasyHousingSolutionPL
{
    /// <summary>
    /// Interaction logic for UploadImage.xaml
    /// </summary>
    public partial class UploadImage : Window
    {
        ImageBL imageBL = new ImageBL();
        StringBuilder sb = new StringBuilder();
        string imagepath;
        public UploadImage()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Images images = new Images();
                if (txtPropertyId.Text.ToString() != string.Empty)
                {
                    images.PropertyId = int.Parse(txtPropertyId.Text);
                    images.Image = imagepath;
                    if (imageBL.AddImageBL(images))
                    {
                        MessageBox.Show("Uploaded successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
                else
                {
                    sb.Append("Enter valid property id");
                }
                
            }
            catch (EasyHousingSolutionException ex)
            {
                MessageBox.Show("Error: " +sb.ToString()+ ex.Message);
            }          
        }

        private void btnBrowseImages_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if((bool)op.ShowDialog())
            {
                imagepath = op.FileName;
            }          
            txtImagePath.Text = imagepath;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }
    }
}
