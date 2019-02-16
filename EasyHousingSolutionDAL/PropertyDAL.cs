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
    public class PropertyDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);

        public bool AddPropertyDAL(Property newProperty)
        {
            bool PropertyAdded = false;
            try
            {
                string Query = "Project1.uspAddProperty";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PropertyName", newProperty.PropertyName);
                command.Parameters.AddWithValue("@PropertyType", newProperty.PropertyType);
                command.Parameters.AddWithValue("@Desc", newProperty.Description);
                command.Parameters.AddWithValue("@Adress", newProperty.Address);
                command.Parameters.AddWithValue("@PriceRange", newProperty.PriceRange);
                command.Parameters.AddWithValue("@InitialDeposit", newProperty.InitialDeposit);
                command.Parameters.AddWithValue("@LandMark", newProperty.Landmark);
                command.Parameters.AddWithValue("@IsActive", 0);
                command.Parameters.AddWithValue("@SellerId", newProperty.SellerId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                PropertyAdded = true;
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
            return PropertyAdded;
        }

        public List<Property> GetPropertyByOwnerDAL(string SellerName)
        {
            try
            {
                List<Property> PropertyList = new List<Property>();                
                string Query = "project1.uspGetPropertyByOwner";

                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@sellerName", SellerName);
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Property s = new Property();
                        s.PropertyId = int.Parse(Reader[0].ToString());
                        s.PropertyName = Reader[1].ToString();
                        s.PropertyType = Reader[2].ToString();
                        s.Description = Reader[3].ToString();
                        s.Address = Reader[4].ToString();
                        s.PriceRange = decimal.Parse(Reader[5].ToString());
                        s.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        s.Landmark = Reader[7].ToString();
                        s.IsActive = Reader[8].ToString();
                        s.SellerId = int.Parse(Reader[9].ToString());
                        PropertyList.Add(s);
                    }
                }
                connection.Close();
                return PropertyList;
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

        public List<Property> GetPropertyByRegionDAL(string CityName)
        {
            try
            {
                List<Property> PropertyList = new List<Property>();
                string Query = "project1.uspGetPropertyByRegion";

                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CityName", CityName);
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Property s = new Property();
                        s.PropertyId = int.Parse(Reader[0].ToString());
                        s.PropertyName = Reader[1].ToString();
                        s.PropertyType = Reader[2].ToString();
                        s.Description = Reader[3].ToString();
                        s.Address = Reader[4].ToString();
                        s.PriceRange = decimal.Parse(Reader[5].ToString());
                        s.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        s.Landmark = Reader[7].ToString();
                        s.IsActive = Reader[8].ToString();
                        s.SellerId = int.Parse(Reader[9].ToString());
                        PropertyList.Add(s);
                    }
                }
                connection.Close();
                return PropertyList;
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

        public bool EditPropertyDAL(Property editProperty)
        {
            bool PropertyEdited = false;
            try
            {
                string Query = "Project1.uspEditProperty";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PropertyId", editProperty.PropertyId);
                command.Parameters.AddWithValue("@PropertyName", editProperty.PropertyName);
                command.Parameters.AddWithValue("@PropertyType", editProperty.PropertyType);
                command.Parameters.AddWithValue("@Desc", editProperty.Description);
                command.Parameters.AddWithValue("@Adress", editProperty.Address);
                command.Parameters.AddWithValue("@PriceRange", editProperty.PriceRange);
                command.Parameters.AddWithValue("@InitialDeposit", editProperty.InitialDeposit);
                command.Parameters.AddWithValue("@LandMark", editProperty.Landmark);
                command.Parameters.AddWithValue("@SellerId", editProperty.@SellerId);
                connection.Open();
                command.ExecuteNonQuery();

                PropertyEdited = true;
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

            return PropertyEdited;

        }

        public Property SearchPropertyDAL(int searchPropertyID)
        {
            Property searchProperty = null;
            try
            {
                string Query = "Project1.uspSearchProperty";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pId", searchPropertyID);
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        searchProperty = new Property();
                        searchProperty.PropertyId = int.Parse(Reader[0].ToString());
                        searchProperty.PropertyName = Reader[1].ToString();
                        searchProperty.PropertyType = Reader[2].ToString();
                        searchProperty.Description = Reader[3].ToString();
                        searchProperty.Address = Reader[4].ToString();
                        searchProperty.PriceRange = decimal.Parse(Reader[5].ToString());
                        searchProperty.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        searchProperty.Landmark = Reader[7].ToString();
                        searchProperty.SellerId = int.Parse(Reader[9].ToString());
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
            return searchProperty;
        }

        public List<Property> GetVerifiedPropertyDAL()
        {
            try
            {
                List<Property> PropertyList = new List<Property>();
                string Query = "Project1.uspDisplayVerifiedProperty";

                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Property s = new Property();
                        s.PropertyId = int.Parse(Reader[0].ToString());
                        s.PropertyName = Reader[1].ToString();
                        s.PropertyType = Reader[2].ToString();
                        s.Description = Reader[3].ToString();
                        s.Address = Reader[4].ToString();
                        s.PriceRange = decimal.Parse(Reader[5].ToString());
                        s.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        s.Landmark = Reader[7].ToString();
                        s.IsActive = Reader[8].ToString();
                        s.SellerId = int.Parse(Reader[9].ToString());
                        PropertyList.Add(s);
                    }
                }
                connection.Close();
                return PropertyList;
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

        public List<Property> GetDeActivatedPropertyDAL()
        {
            try
            {
                List<Property> PropertyList = new List<Property>();
                string Query = "Project1.uspGetDeactivatedProperty";

                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Property s = new Property();
                        s.PropertyId = int.Parse(Reader[0].ToString());
                        s.PropertyName = Reader[1].ToString();
                        s.PropertyType = Reader[2].ToString();
                        s.Description = Reader[3].ToString();
                        s.Address = Reader[4].ToString();
                        s.PriceRange = decimal.Parse(Reader[5].ToString());
                        s.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        s.Landmark = Reader[7].ToString();
                        s.IsActive = Reader[8].ToString();
                        s.SellerId = int.Parse(Reader[9].ToString());
                        PropertyList.Add(s);
                    }
                }
                connection.Close();
                return PropertyList;
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

        public List<Property> GetAllPropertyDAL()
        {
            try
            {
                List<Property> PropertyList = new List<Property>();
                string Query = "select * from project1.Property ";                

                SqlCommand command = new SqlCommand(Query, connection);

                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Property s = new Property();
                        s.PropertyId = int.Parse(Reader[0].ToString());
                        s.PropertyName = Reader[1].ToString();
                        s.PropertyType = Reader[2].ToString();
                        s.Description = Reader[3].ToString();
                        s.Address = Reader[4].ToString();
                        s.PriceRange = decimal.Parse(Reader[5].ToString());
                        s.InitialDeposit = decimal.Parse(Reader[6].ToString());
                        s.Landmark = Reader[7].ToString();
                        s.IsActive = Reader[8].ToString();
                        s.SellerId = int.Parse(Reader[9].ToString());
                        PropertyList.Add(s);
                    }
                }
                connection.Close();
                return PropertyList;
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

        public bool DeletePropertyDAL(int deletePropertyID)
        {
            bool PropertyDeleted = false;
            try
            {
                SqlCommand command = new SqlCommand("Project1.uspDeleteProperty", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@propertyId", deletePropertyID);
                connection.Open();
                int numberOfRowsDeleted = command.ExecuteNonQuery();
                if (numberOfRowsDeleted > 0)
                {
                    PropertyDeleted = true;
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
            return PropertyDeleted;
        }

        public bool VerifyPropertyDAL(Property property)
        {
            bool propertyVerified = false;
            try
            {

                SqlCommand command = new SqlCommand("Project1.uspVerifyProperty");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PropertyId", property.PropertyId);          

                command.Connection = connection;
                connection.Open();
               int r= command.ExecuteNonQuery();
                if (r > 0)
                {
                    propertyVerified = true;
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
            return propertyVerified;
        }

        public bool DeactivatePropertyDAL(Property property)
        {
            bool propertyDeactivated = false;
            try
            {

                SqlCommand command = new SqlCommand("Project1.uspDeactivateProperty");
                command.CommandType =CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PropertyId", property.PropertyId);               

                command.Connection = connection;
                connection.Open();
               
                int r = command.ExecuteNonQuery();
                if (r > 0)
                {
                    propertyDeactivated = true;
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
            return propertyDeactivated;
        }
    }
}
