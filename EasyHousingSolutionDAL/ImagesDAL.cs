using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyHousingSolutionEntity;
using System.Data;
using System.Data.SqlClient;
using EHSException;

using System.Threading.Tasks;

namespace EasyHousingSolutionDAL
{
    public class ImagesDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);

        public bool AddImageDAL(Images newImage)
        {
            bool ImageAdded = false;
            try
            {
                string Query = "Project1.uspAddImage" +
                    "";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@propertyId", newImage.PropertyId);              
                command.Parameters.AddWithValue("@img", newImage.Image);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
             
                ImageAdded = true;
               
            }
            catch (Exception ex)
            {
                throw new EasyHousingSolutionException(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return ImageAdded;
        }

        public Images GetImageDAL(int PropertyId)
        {
            try
            {                
                Images obj = new Images();
                string Query = "Project1.uspDisplayImage";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PropertyId", PropertyId);
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                      
                        obj.ImageId = int.Parse(Reader[0].ToString());                        
                        obj.Image = Reader[1].ToString();                       
                    }
                }
                connection.Close();
                return obj;
            }
            catch (Exception ex)
            {
                throw new EasyHousingSolutionException(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
