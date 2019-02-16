using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHousingSolutionEntity;
using System.Data;
using System.Data.SqlClient;
using EHSException;

namespace EasyHousingSolutionDAL
{
    public class CartDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);
        public bool AddCartDAL(Cart newCart)
        {
            bool CartAdded = false;
            try
            {
                string Query = "Project1.uspAddCart";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BuyerId", newCart.BuyerId);
                command.Parameters.AddWithValue("@PropertyId", newCart.PropertyId);
               
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                CartAdded = true;
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
            return CartAdded;
        }

        public List<Property> GetAllCartDAL()
        {
            List<Property> CartList = new List<Property>();
            try
            {               
                string Query = "Project1.uspDisplaycart";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                       Property prop = new Property();
                        prop.PropertyId= int.Parse(Reader[0].ToString());
                        prop.PropertyName = Reader[1].ToString();
                        prop.PropertyType = Reader[2].ToString();
                        prop.Description = Reader[3].ToString();
                        prop.Address = Reader[4].ToString();
                        prop.PriceRange = decimal.Parse(Reader[5].ToString());
                        prop.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        prop.Landmark = Reader[7].ToString();

                        CartList.Add(prop);
                    }
                }
                connection.Close();
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
            return CartList;
            
        }

        public bool DeleteCartDAL(string propName)
        {
            bool CartDeleted = false;
            try
            {               
                SqlCommand command = new SqlCommand("Project1.uspDeletecart", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PropertyName", propName);
                connection.Open();
                int numberOfRowsDeleted = command.ExecuteNonQuery();
                if (numberOfRowsDeleted > 0)
                {
                    CartDeleted = true;
                }              
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
            return CartDeleted;

        }        
    }
}
