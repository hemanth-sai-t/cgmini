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

    public class SellersDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);
        public int getStateId(string StateName)
        {
            try
            {
                int StateId = 0;
                string Query = "Project1.uspGetStateId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StateName", StateName);
                connection.Open();
                int retrieveStateId = int.Parse(command.ExecuteScalar().ToString());
                //object retrieveStateId = command.ExecuteScalar().ToString();
                StateId = int.Parse(retrieveStateId.ToString());
                connection.Close();
                return StateId;
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
        public int getCityId(string CityName)
        {
            try
            {
                int CityId = 0;
                string Query = "Project1.uspGetCityId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cityName", CityName);
                connection.Open();
                object retrieveCityId = command.ExecuteScalar().ToString();
                CityId = int.Parse(retrieveCityId.ToString());
                connection.Close();
                return CityId;
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
        public bool AddSellerDAL(Seller newSeller)
        {
            bool SellerAdded = false;
            try
            {
                string Query = "Project1.uspAddSeller";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@FirstName", newSeller.FirstName);
                command.Parameters.AddWithValue("@LastName", newSeller.LastName);
                command.Parameters.AddWithValue("@UserName", newSeller.UserName);
                command.Parameters.AddWithValue("@DateofBirth", newSeller.DateofBirth);
                command.Parameters.AddWithValue("@PhoneNo", newSeller.PhoneNo);
                command.Parameters.AddWithValue("@Address", newSeller.Address);
                int stateId=getStateId(newSeller.StateName);
                int cityId = getCityId(newSeller.CityName);
                command.Parameters.AddWithValue("@StateId",stateId);
                command.Parameters.AddWithValue("@CityId", cityId);
                command.Parameters.AddWithValue("@EmailId", newSeller.EmailId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                SellerAdded = true;
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
            return SellerAdded;
        }     
    }
}
